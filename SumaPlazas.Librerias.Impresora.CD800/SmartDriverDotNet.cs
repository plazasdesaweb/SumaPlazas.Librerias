using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartDriverDotNet;
using System.Runtime.InteropServices;

namespace SumaPlazas.Librerias.Impresora.CD800
{
    [ComVisible(true)]
    public class SmartDriverDotNet
    {
        private SmarTestDotNet objDataCardCD800;

        public SmartDriverDotNet()
        {
            objDataCardCD800 = new SmarTestDotNet();
        }

        public bool Imprimir(string NombreImpresora, string Nombre, string Apellido, string NroTarjeta, string Track1, string Track2, string TipoTarjeta, string Corporacion, string FechaVencimiento)
        {
            objDataCardCD800.PrinterName = NombreImpresora;
            return objDataCardCD800.Imprimir(Nombre, Apellido, NroTarjeta, Track1, Track2, TipoTarjeta, Corporacion, FechaVencimiento);
        }

        public string EstadoImpresora(string NombreImpresora)
        {
            objDataCardCD800.PrinterName = NombreImpresora;
            return objDataCardCD800.EstadoImpresora();
        }

        public string ReanudarImpresora(string NombreImpresora)
        {
            objDataCardCD800.PrinterName = NombreImpresora;
            return objDataCardCD800.ReanudarImpresora();
        }

        public string LimpiarErrores(string NombreImpresora)
        {
            objDataCardCD800.PrinterName = NombreImpresora;
            return objDataCardCD800.LimpiarErrores();
        }
    }

}