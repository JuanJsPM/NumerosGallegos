using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicioNumerosGallegoWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Fraccionario 
    {
        protected static string[] UNIDAD = { "", "", "medio", "terzo", "cuarto", "quinto", "sexto", "sétimo", "oitavo", "noveno", };
        protected static string[] SINGULARMF = { "", "milésimo", "millonésimo", "mil millonésimo", "billónésimo", "mil billónésimo", "trillónésimo", "mil trillónésimo", "cuadrillónésimo", "mil cuadrillónésimo" };
        protected static string[] SINGULARM = { "", "mil", "millóns", "mil millóns", "billóns", "mil billóns", "trillóns", "mil trillóns", "cuadrillóns", "mil cuadrillóns" };
        public int count=0;
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
                if (bloque==0 && flag==true) //contamos bloques de 000 para utilizar SINGULARMF
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

                    if (count>0) 
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

            if (unidades > 0)
            {
                if (unidades > 1 && decenas == 0 && centenas == 0 && nbloques == 1)
                {
                    resultado.Append(UNIDAD[unidades]);
                    resultado.Append(" ");
                }

                if ((nbloques - i - 1) > 0 && unidades == 1 && decenas == 0 && centenas == 0) 
                {
                    resultado.Append(" ");
                }
            }
 
            if (decenas == 1 && unidades == 0 && centenas == 0 && nbloques == 1)
            {
                resultado.Append("décimo");
            }

            if (decenas == 0 && unidades == 0 && centenas == 1 && nbloques == 1)
            {
                resultado.Append("centésimo");
            }

            if ((unidades > 1 && decenas == 0 && centenas == 0 && nbloques == 1)==false 
                && (decenas == 1 && unidades == 0 && centenas == 0 && nbloques == 1)==false
                && bloque!=000 && ((nbloques - i - 1) % 2 != 0 && unidades == 1 && decenas == 0 && centenas == 0)== false
                &&(unidades==1 && decenas ==0 && centenas ==0 && nbloques > 0) ==false
                &&(unidades == 0 && decenas == 0 && centenas == 0 && nbloques == 1) == false
                &&(decenas == 0 && unidades == 0 && centenas == 1 && nbloques == 1)==false)
            {
                if(nbloques-i == 1 )
                {
                    resultado.Append(new Cardinal().traducir(bloque.ToString()));
                    if (resultado[resultado.Length - 1] == 'a')
                    {
                        resultado.Append("vo");
                    }
                    else
                    {
                        resultado.Append("avo");
                    }
                }
                else
                {
                    resultado.Append(new Cardinal().traducir(bloque.ToString()));
                }
               
            }

            return resultado.ToString();
        }
    }
}
