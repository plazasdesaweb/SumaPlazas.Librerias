using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyDataCardCP60;
using System.Runtime.InteropServices;

namespace SumaPlazas.Librerias.Impresora.CP60
{
    [ComVisible(true)]
    public class ProyDataCardCP60
    {
        private DataCardCP60 objDataCardCP60;
        
        public ProyDataCardCP60()
        {
            objDataCardCP60 = new DataCardCP60();
        }

        public bool Imprimir(string NombreImpresora, ref string Nombre, ref string Apellido, ref string NroTarjeta,ref string Track1,ref string Track2,ref string TipoTarjeta,ref string Corporacion,ref string FechaVencimiento)
        {
            objDataCardCP60.sNombreImpresora = NombreImpresora;
            return objDataCardCP60.Imprimir(Nombre, Apellido, NroTarjeta, Track1, Track2, TipoTarjeta, Corporacion, FechaVencimiento);             
        }

        public string EstadoImpresora(string NombreImpresora)
        {
            objDataCardCP60.sNombreImpresora = NombreImpresora;
            return objDataCardCP60.EstadoImpresora();
        }

        public string ReanudarImpresora(string NombreImpresora)
        {
            objDataCardCP60.sNombreImpresora = NombreImpresora;
            return objDataCardCP60.ReanudarImpresora();
        }

        public string LimpiarErrores(string NombreImpresora)
        {
            objDataCardCP60.sNombreImpresora = NombreImpresora;
            return objDataCardCP60.LimpiarErrores();
        }
    }
}
