using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServicioNumerosGallegoWCF
{
    public class NumerosGallegos
    {

        private string input = "";
        private ConcurrentDictionary<string, string> resultado;
        public NumerosGallegos(string input) 
        {
            this.input = input;
            this.resultado = new ConcurrentDictionary<string, string>();
        }

        public ConcurrentDictionary<string, string> GallegoAnumeros()
        {
            try
            {
                if (new Comprobar().ComprobarFormatoNormal(input))
                {
                    string inputProcedado = input.Replace(".", "").Replace(" ", "");
                    Parallel.Invoke(
                        () => 
                        {
                            resultado["Cardinal"] = new Cardinal().traducir(inputProcedado);
                            resultado["Ordinal"] = new Ordinal().traducir(inputProcedado);
                            resultado["Fraccionario"] = new Fraccionario().traducir(inputProcedado);
                            resultado["Multiplicativo"] = new Multiplicativo().traducir(inputProcedado);
                        }
                        );
                    return resultado;
                }

                if (new Comprobar().ComprobarFormatoFraccionario(input))
                {
                    string[] partes = input.Split('/');
                    string numerador ="";
                    string denominador = "";

                    Parallel.Invoke(
                        () =>
                        {
                            numerador = new Cardinal().traducir(partes[0].Replace(".", "").Replace(" ", ""));
                            denominador = new Fraccionario().traducir(partes[1].Replace(".", "").Replace(" ", ""));
                        }
                        );
                    resultado["Fraccionario"] = numerador +" "+ denominador;
                    return resultado;
                }

                if (new Comprobar().ComprobarFormatoDecimal(input))
                {
                    string[] partes = input.Split(',');
                    string parteEntera = "";
                    string parteDecimal = "";

                    Parallel.Invoke(
                        () =>
                        {
                            parteEntera = new Cardinal().traducir(partes[0].Replace(".", "").Replace(" ", ""));
                            parteDecimal = new Decimal().traducir(partes[1].Replace(".", "").Replace(" ", ""));
                        }
                        );
                    resultado["Decimal"] = parteEntera + " con " + parteDecimal;
                    return resultado;
                }


            }
            catch(Exception error)
            {
                if (error.GetType() == typeof(FormatException))
                {
                    resultado["Error"] = "El formato es incorrecto";
                }
                if (error.GetType() == typeof(IndexOutOfRangeException))
                {
                    resultado["Error"] = "Desbordamiento de índice";
                }
                return resultado;
            }
            return resultado;
        }

    }
}
