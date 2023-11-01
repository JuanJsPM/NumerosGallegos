using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;

namespace ServicioNumerosGallegoWCF
{
    public class Comprobar
    {
        public bool ComprobarFormatoNormal(string input)
        {
            bool TrueCardinalSeparadores = Regex.IsMatch(input, @"\d{1,3}\d{1,3}(\.\d{3}|\s\d{3})*"); //separadores "." y " "
            bool TrueCardinalPlano = Regex.IsMatch(input, @"^[0-9]*$");

            if (TrueCardinalSeparadores || TrueCardinalPlano)
            {
                return CardinalValido(input.Replace(".", "").Replace(" ", ""));
            } 
            return false;   
        }

        public bool ComprobarFormatoFraccionario(string input)
        {
            bool TrueFraccion = Regex.IsMatch(input.Replace(".", "").Replace(" ", ""), @"^\d+\/\d+$"); //Comprueba si hay fraccion, ejemplo "96/41"

            if (TrueFraccion)
            {
                string[] partes =input.Split('/');
                if (ComprobarFormatoNormal(partes[0])&& ComprobarFormatoNormal(partes[1]))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public bool ComprobarFormatoDecimal(string input)
        {
            bool TrueDecimal = Regex.IsMatch(input.Replace(".", "").Replace(" ", ""), @"^\d+,\d+$"); //Comprueba si es un número con decimales ejemplo "10,23"

            if (TrueDecimal)
            {
                string[] partes = input.Split(',');
                if (ComprobarFormatoNormal(partes[0]) && ComprobarFormatoNormal(partes[1]))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        private bool CardinalValido(string input)
        {
            if (!Regex.IsMatch(input, @"^[0-9]{1,30}$"))
            {
                return false;
            }
            return true;
        }
    }
}
