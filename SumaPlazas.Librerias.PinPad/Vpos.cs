using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Vpos;

namespace SumaPlazas.Librerias.PinPad
{
    [ComVisible(true)]
    public class Vpos
    {
        private cVPOS objVpos;

        public Vpos()
        {
            objVpos = new cVPOS();
        }

        public string CrearPin()
        {
            string strBanda = "";
            string[] ArrResultado;
            string Resultado = "";
            Resultado = objVpos.Lectura_Banda(ref strBanda);
            ArrResultado = Resultado.Split(',');
            if (ArrResultado[0] == "00")
            {
                string strCID = "";
                string strMonto = "0,00";
                string strTipoCuenta = "2";
                string strCodigoSeguridad = "";
                string strCuentasEspeciales = "14";
                string strDVerificador = "";
                string strVacio = "";
                strDVerificador = ArrResultado[2];
                Resultado = objVpos.Datos_Externos(ref strCID, ref strMonto, ref strTipoCuenta, ref strCodigoSeguridad, ref strCuentasEspeciales, ref strVacio, ref strVacio, ref strVacio, ref strVacio, ref strVacio, ref strDVerificador, ref strVacio, ref strVacio, ref strVacio, ref strVacio);
                //if (Resultado == null)
                //{
                //    Resultado = "X2";
                //}
            }
            //else
            //{
            //    if (Resultado == null)
            //    {
            //        Resultado = "X1";
            //    }
            //}
            return Resultado;
        }

        public string CambiarPin()
        {
            string strBanda = "";
            string[] ArrResultado;
            string Resultado = "";
            Resultado = objVpos.Lectura_Banda(ref strBanda);
            ArrResultado = Resultado.Split(',');
            if (ArrResultado[0] == "00")
            {
                string strCID = "";
                string strMonto = "0,00";
                string strTipoCuenta = "2";
                string strCodigoSeguridad = "";
                string strCuentasEspeciales = "15";
                string strDVerificador = "";
                string strVacio = "";
                strDVerificador = ArrResultado[2];
                Resultado = objVpos.Datos_Externos(ref strCID, ref strMonto, ref strTipoCuenta, ref strCodigoSeguridad, ref strCuentasEspeciales, ref strVacio, ref strVacio, ref strVacio, ref strVacio, ref strVacio, ref strDVerificador, ref strVacio, ref strVacio, ref strVacio, ref strVacio);
                //if (Resultado == null)
                //{
                //    Resultado = "X2";
                //}
            }
            //else
            //{
            //    if (Resultado == null)
            //    {
            //        Resultado = "X1";
            //    }
            //}
            return Resultado;
        }

        public string ReiniciarPin()
        {
            string strBanda = "";
            string[] ArrResultado;
            string Resultado = "";
            Resultado = objVpos.Lectura_Banda(ref strBanda);
            ArrResultado = Resultado.Split(',');
            if (ArrResultado[0] == "00")
            {
                string strCID = "";
                string strMonto = "0,00";
                string strTipoCuenta = "0";
                string strCodigoSeguridad = "";
                string strCuentasEspeciales = "29";
                string strDVerificador = "";
                string strVacio = "";
                strDVerificador = ArrResultado[2];
                Resultado = objVpos.Datos_Externos(ref strCID, ref strMonto, ref strTipoCuenta, ref strCodigoSeguridad, ref strCuentasEspeciales, ref strVacio, ref strVacio, ref strVacio, ref strVacio, ref strVacio, ref strDVerificador, ref strVacio, ref strVacio, ref strVacio, ref strVacio);
                //if (Resultado == null)
                //{
                //    Resultado = "X2";
                //}
            }
            //else
            //{
            //    if (Resultado == null)
            //    {
            //        Resultado = "X1";
            //    }
            //}
            return Resultado;
        }
    }
}
