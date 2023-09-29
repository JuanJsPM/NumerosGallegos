using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicioNumerosGallegoWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Ordinal 
    {
        protected static string[] UNIDAD = { "", "primeiro", "segundo", "terceiro", "cuarto", "quinto", "sexto", "sétimo", "oitavo", "noveno", };
        protected static string[] DECENA = { "", "décimo", "vixésimo", "trixésimo", "cuadraxésimo", "quincuaxésimo", "sesaxésimo", "septuaxésimo", "octoxésimo", "nonaxésimo" };
        protected static string[] CENTENA = { "", "centésimo", "ducentésimo", "tricentésimo", "cuadrinxentésimo", "quinxentésimo", "sexcentésimo", "septinxentésimo", "octinxentésimo", "noninxentésimo" };
        protected static string[] SINGULARMF = { "", "milésimo", "millonésimo", "mil millonésimo", "billonésimo", "mil billonésimo", "trillonésimo", "mil trillonésimo", "cuadrillonésimo", "mil cuadrillonésimo" };
        protected static string[] SINGULARM = { "", "mil", "millóns", "mil millóns", "billóns", "mil billóns", "trillóns", "mil trillóns", "cuadrillóns", "mil cuadrillóns" };
       

        protected static string[] UNIDADcar = { "cero", "un", "dous", "tres", "catro", "cinco", "sies", "sete", "oito", "nove", };
        protected static string[] UNICOScar = { "dez", "once", "doce", "trece", "catorce", "quince", "dezaseis", "dezasete", "dezaoito", "dezanove" };
        protected static string[] DECENAcar = { "", "dez", "vinte", "trinta", "corenta", "cincuenta", "sesenta", "setenta", "oitenta", "noventa" };
        protected static string[] CENTENAcar = { "", "cento", "douscentos", "trescentos", "catrocentos", "cincocentos", "seiscentos", "setecentos", "oitocentos", "novecentos" };
        public int count = 0;
        private bool flag;
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
            flag = true;
            for (int i = bloques.Count - 1; i >= 0; i--)
            {
                int bloque = int.Parse(bloques[i]);
                if (bloque == 0 && flag == true) //contamos bloques de 000 para utilizar SINGULARMF
                {
                    count++;
                }
                else
                {
                    flag = false;
                }

                string traduccionBloque = TraducirBloque(bloque, bloques.Count, i);

                if (!string.IsNullOrEmpty(traduccionBloque))
                {
                    if (count > 0)
                    {
                        resultado.Insert(0, " ");
                        resultado.Insert(0, SINGULARMF[count]);
                        count = 0;
                    }
                    else
                    {
                        resultado.Insert(0, " ");
                        resultado.Insert(0, SINGULARM[bloques.Count - i - 1]);
                    }

                    resultado.Insert(0, " ");
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


            if (centenas > 0)
            {
                if ((nbloques - i - 1) > 0) 
                {
                    if (centenas == 1 && decenas == 0 && unidades == 0)
                    {
                        resultado.Append("cen ");
                    }
                    else
                    {
                        resultado.Append(CENTENAcar[centenas]);
                        resultado.Append(" ");
                    }
                }
                else 
                {
                    resultado.Append(CENTENA[centenas]);
                    resultado.Append(" ");
                }
            }
            if (decenas > 0)
            {
                if ((nbloques - i - 1) > 0)
                {
                    resultado.Append(DECENAcar[decenas]);
                    resultado.Append(" ");
                }
                else 
                {
                    resultado.Append(DECENA[decenas]);
                    resultado.Append(" ");
                }
                
            }
            if (unidades > 0)
            {
                if ((nbloques - i - 1) > 0 && unidades == 1 && decenas == 0 && centenas == 0) 
                {
                    resultado.Append(" ");
                }
                else if ((nbloques - i - 1) > 0) 
                {
                    resultado.Append(UNIDADcar[unidades]);
                    resultado.Append(" ");
                }
                else
                {
                    resultado.Append(UNIDAD[unidades]);
                    resultado.Append(" ");
                }
            }
            return resultado.ToString();
        }
    }
}
