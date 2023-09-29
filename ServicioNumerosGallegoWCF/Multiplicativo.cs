using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicioNumerosGallegoWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Multiplicativo 
    {
        protected static string[] UNIDADM = { "", "", "duplo", "triplo", "cuádruplo", "quíntuplo", "séxtuplo", "séptuplo", "óctuplo", "nónuplo", };
        protected static string[] UNIDAD = { "cero", "un", "dous", "tres", "catro", "cinco", "sies", "sete", "oito", "nove", };
        protected static string[] UNICOS = { "dez", "once", "doce", "trece", "catorce", "quince", "dezaseis", "dezasete", "dezaoito", "dezanove" };
        protected static string[] DECENA = { "", "dez", "vinte", "trinta", "corenta", "cincuenta", "sesenta", "setenta", "oitenta", "noventa" };
        protected static string[] CENTENA = { "", "cento", "douscentos", "trescentos", "catrocentos", "cincocentos", "seiscentos", "setecentos", "oitocentos", "novecentos" };
        protected static string[] SINGULARM = { "", "mil", "millóns", "mil millóns", "billóns", "mil billóns", "trillóns", "mil trillóns", "cuadrillóns", "mil cuadrillóns"};
        
        public string traducir(string input)
        {
           
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

            return resultado.ToString().Trim();
        }

        private string TraducirBloque(int bloque, int nbloques, int i)
        {
            StringBuilder resultado = new StringBuilder();

            int centenas = bloque / 100;
            int decenas = (bloque % 100) / 10;
            int unidades = bloque % 10;
            bool flag = false;

            if (centenas > 0)
            {
                if (centenas == 1 && decenas == 0 && unidades == 0  && nbloques==1)
                {
                    resultado.Append("céntuplo");
                }
                else if (centenas == 1 && decenas == 0 && unidades == 0 && nbloques > 1) 
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
            if (decenas == 1)
            {
                if (unidades == 0 && decenas == 1 && centenas == 0 && nbloques == 1)
                {
                    return resultado.Append("décuplo").ToString();
                }
                if (unidades > 0)
                {
                    resultado.Append(UNICOS[unidades]);
                    resultado.Append(" ");
                    unidades = 0;
                    flag = true;
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

                else if (nbloques==1 && decenas ==0 && centenas==0)
                {
                    resultado.Append(UNIDADM[unidades]);
                    resultado.Append(" ");
                }

                else
                {
                    resultado.Append(UNIDAD[unidades]);
                    resultado.Append(" ");
                }
            }

            if (nbloques - i == 1 && (nbloques == 1 && decenas == 0 && centenas == 0)==false
                && (unidades == 0 && decenas == 1 && centenas == 0 && nbloques == 1)==false
                && (centenas == 1 && decenas == 0 && unidades == 0)==false || flag == true && nbloques - i == 1)
            {
                resultado.Append("veces");
            }

            return resultado.ToString();
        }
    }
}
