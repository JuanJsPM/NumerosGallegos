using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicioNumerosGallegoWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Decimal
    {
        protected static string[] UNIDAD = { "cero", "unha", "dúas", "tres", "catro", "cinco", "sies", "sete", "oito", "nove", };
        protected static string[] UNICOS = { "dez", "once", "doce", "trece", "catorce", "quince", "dezaseis", "dezasete", "dezoito", "dezanove" };
        protected static string[] DECENA = { "", "dez", "vinte", "trinta", "corenta", "cincuenta", "sesenta", "setenta", "oitenta", "noventa" };
        protected static string[] CENTENA = { "", "cento", "douscentas", "trescentas", "catrocentas", "cincocentas", "seiscentas", "setecentas", "oitocentas", "novecentas" };
        protected static string[] SINGULARM = { "", "mil", "millóns", "mil millóns", "billóns", "mil billóns", "trillóns", "mil trillóns", "cuadrillóns", "mil cuadrillóns" };
        protected static string[] SINGULARD = { "", "décimas", "centésimas", "milésimas", "dezmilésimas", "cenmilésimas", "millonésimas", "dezmillonésimas",
                "cenmillonésimas", "milmillonésimas", "dezmilmillonésimas", "cenmilmillonésimas", "billonésimas", "dezbillonésimas", "cenbillonésimas"
                , "milbillonésimas", "dezmilbillonésimas", "cenmilbillonésimas", "trillonésimas", "deztrillonésimas", "centrillonésimas", "miltrillonésimas"
                , "dezmiltrillonésimas", "cenmiltrillonésimas", "cuadrillónésimas", "dezcuadrillónésimas", "cencuadrillónésimas", "milcuadrillónésimas", "mildezcuadrillónésimas"
                , "dezmildezcuadrillónésimas", "cenmildezcuadrillónésimas"};


        public string traducir(string input)
        {
            int tamaño = input.Length;
            
            if (string.IsNullOrEmpty(input))
            {
                return "Entrada inválida. Por favor, ingrese un número válido.";
            }


            // Agregar ceros a la izquierda si es necesario para tener una longitud múltiplo de 3
            while (input.Length % 3 != 0)
            {
                input = "0" + input;
            }

            // Convertir la cadena en bloques de 3 dígitos
            List<string> bloques = new List<string>();
            for (int i = 0; i < input.Length; i += 3)
            {
                string bloque = input.Substring(i, 3);
                bloques.Add(bloque);
            }


            // Construir la traducción
            StringBuilder resultado = new StringBuilder();
            if (int.Parse(input) == 1)
            {
                string recortar = SINGULARD[tamaño];
                resultado.Insert(0, recortar.Remove(recortar.Length - 1, 1));
            }
            else
            {
                resultado.Insert(0, SINGULARD[tamaño]);
            }

            for (int i = bloques.Count - 1; i >= 0; i--)
            {

                int bloque = int.Parse(bloques[i]);

                string traduccionBloque = TraducirBloque(bloque, bloques.Count, i);

                if (!string.IsNullOrEmpty(traduccionBloque))
                {
                    resultado.Insert(0, " ");
                    if ((bloques.Count - i - 1) > 1 && bloques[i] == "001" && (bloques.Count - i - 1) % 2 == 0)
                    {
                        string recortar = SINGULARM[bloques.Count - i - 1];
                        resultado.Insert(0, recortar.Remove(recortar.Length - 1, 1));
                    }
                    else
                    {
                        resultado.Insert(0, SINGULARM[bloques.Count - i - 1]);
                    }
                    
                    resultado.Insert(0, traduccionBloque);
                }
            }

            resultado.Insert(0, " ");

            return resultado.ToString().Trim();
        }

        private string TraducirBloque(int bloque, int nbloques, int i)
        {
            StringBuilder resultado = new StringBuilder();

            int centenas = bloque / 100;
            int decenas = (bloque % 100) / 10;
            int unidades = bloque % 10;


            if (centenas > 0)
            {
                if (centenas == 1 && decenas == 0 && unidades == 0)
                {
                    resultado.Append("cen ");
                }
                else
                {
                    resultado.Append(CENTENA[centenas]);
                    resultado.Append(" ");
                }
            }
            if (decenas > 1)
            {
                resultado.Append(DECENA[decenas]);
                resultado.Append(" ");
                if (unidades > 0)
                {
                    resultado.Append("e ");
                }
            }
            else if (decenas == 1)
            {
                if (unidades > 0)
                {
                    resultado.Append(UNICOS[unidades]);
                    resultado.Append(" ");
                    unidades = 0; 
                }
                else
                {
                    resultado.Append(DECENA[decenas]);
                    resultado.Append(" ");
                }
            }

            if (unidades > 0)
            {
                if ((nbloques - i - 1) % 2 != 0 && unidades == 1 && decenas == 0 && centenas == 0) //i un iterador caso=1000
                {
                    resultado.Append(" ");
                }

                else
                {
                    resultado.Append(UNIDAD[unidades]);
                    resultado.Append(" ");
                }
            }
            if (nbloques == 1 && bloque == 0)
            {
                resultado.Append(UNIDAD[unidades]);
                resultado.Append(" ");
            }
            return resultado.ToString();
        }
    }
}
