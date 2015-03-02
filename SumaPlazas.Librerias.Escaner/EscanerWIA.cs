using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WIA;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace SumaPlazas.Librerias.Escaner
{
    [ComVisible(true)]
    public class EscanerWIA
    {

        public string ObtenerImagen(string NombreArchivo)
        {
            const string WiaFormatJPEG = "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}";
            string MyPicturesPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            string FilePath = MyPicturesPath + "\\" + NombreArchivo + ".jpg";
            string TempPath = MyPicturesPath + "\\Temp.jpg";
            try
            {
                WIA.CommonDialog WiaCommonDialog = new WIA.CommonDialog();
                ImageFile ImageFile = WiaCommonDialog.ShowAcquireImage(WiaDeviceType.ScannerDeviceType,
                                                                       WiaImageIntent.ColorIntent,
                                                                       WiaImageBias.MinimizeSize,
                                                                       WiaFormatJPEG,
                                                                       false,
                                                                       true,
                                                                       true);
                if (ImageFile != null)
                {
                    ImageProcess ImageProcess = new ImageProcess();
                    AddWIAFilter(ImageProcess.FilterInfos, ImageProcess.Filters, "Convert");
                    SetWIAProperty(ImageProcess.Filters[ImageProcess.Filters.Count].Properties, "FormatID", WiaFormatJPEG);
                    SetWIAProperty(ImageProcess.Filters[ImageProcess.Filters.Count].Properties, "Quality", 20);
                    ImageFile = ImageProcess.Apply(ImageFile);
                    if (File.Exists(FilePath))
                    {
                        File.Delete(FilePath);
                    }
                    ImageFile.SaveFile(FilePath);
                    long fileLength = new FileInfo(FilePath).Length;
                    //MessageBox.Show("tamaño anterior: " + fileLength);
                    //Si la imagen escaneada es mayor 50Kb, se itera reduciendo la imagen a la mitad de su tamaño
                    while (fileLength > 51200)
                    {
                        if (File.Exists(FilePath))
                        {
                            File.Copy(FilePath, TempPath);
                            File.Delete(FilePath);
                        }
                        using (Image oldImage = Image.FromFile(TempPath))
                        {
                            int w = oldImage.Width / 2;
                            int h = oldImage.Height / 2;
                            Image thumb = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                            Graphics oGraphic = Graphics.FromImage(thumb);
                            oGraphic.CompositingQuality = CompositingQuality.HighSpeed;
                            oGraphic.SmoothingMode = SmoothingMode.HighSpeed;
                            oGraphic.InterpolationMode = InterpolationMode.Low;
                            Rectangle rect = new Rectangle(0, 0, w, h);
                            oGraphic.DrawImage(oldImage, rect);
                            thumb.Save(FilePath, ImageFormat.Jpeg);
                        }
                        if (File.Exists(TempPath))
                        {
                            File.Delete(TempPath);
                        }
                        fileLength = new FileInfo(FilePath).Length;
                        //MessageBox.Show("tamaño nuevo: " + fileLength);
                    }
                    return FilePath;
                }
                else
                {
                    return "";
                }
            }
            //catch (Exception ex)
            catch
            {
                //MessageBox.Show("Error de aplicación: " + ex.Message);
                return "";
            }
        }

        private static void SetWIAProperty(IProperties properties, object propName, object propValue)
        {
            Property prop = properties.get_Item(ref propName);
            prop.set_Value(ref propValue);
        }

        private static void AddWIAFilter(IFilterInfos filterinfos, IFilters filters, object convertFilter)
        {
            string convertFilterID = filterinfos.get_Item(ref convertFilter).FilterID;
            filters.Add(convertFilterID, 0);
        }

    }
}
