using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Configuration;

namespace ServicioNumerosGallegoWCF
{
    public class ServicioNumerosGallegos : IServicioNumerosGallegos
    {
        
        public List<Conversion> TraduciraTexto(string value, string lenguaje)
        {
            // MainClass
            List<Conversion> salida = new List<Conversion>();
            int input=0;
            bool fraccion = false;

            string[] ejemplosCardinalSustantivo = { "O número", "da boa sorte", "é un número moi bonito" };
            string[] ejemplosCardinalPronombre = { "¿Cantos euros tes na túa conta? Teño" };
            string[] ejemplosCardinalAdjetivo = { "Custoume", "libras en Inglaterra", "Teño", "dólares aforrados" };

            string[] ejemplosOrdianlPronombre = { "persoa que remate os seus estudos recibirá unha bolsa", "¿Que pasaxeiro recibirá o premio? o" };
            string[] ejemplosOrdianlAdjetivo = { "No maratón quedei de", "lugar", "Esta é a", "vez que leo este libro" };

            string[] ejemplosFraccionarioSustantivo = { "das estrelas está lonxe", "Deixa de lado dous", "do total de moedas", "Deixa de lado", "Quero", "de empanada" };
            string[] ejemplosFraccionarioAdjetivos = { "A calvicie sófrea", "parte da poboación mundial, segundo a OMS", "Dúas", "partes de auga son demasiado poucas para a fórmula química" };
            string[] ejemplosFraccionarioPronombre = { "Pedinche un terzo do teu tempo e non me deches nin un" };

            string[] ejemplosMultiplicativoSustantivo = { "Tes o", "de diñeiro que o ano pasado" };
            string[] ejemplosMultiplicativoAdjetivo1 = { "Fixo unha", "voltereta desde mil metros de altura", "Houbo un","asasinato no teu barrio onte á noite" };
            string[] ejemplosMultiplicativoVerbo1 = { "Debes", "os teus beneficios na empresa o próximo ano", "Detido por", "a taxa de alcol ao volante" };
            string[] ejemplosMultiplicativoAdjetivo2 = { "Tes", "máis diñeiro que o ano pasado", "Este número é", "maior que este outro" };
            string[] ejemplosMultiplicativoVerbo2 = { "Debes de", "as túas ganancias na empresa o próximo ano", "Detido por", "a taxa de alcol ao volante" };

            if (new Comprobar().ComprobarFormatoFraccionario(value)) 
            {
                string[] partes = value.Split('/');
                fraccion = true; 
            }
            else if (new Comprobar().ComprobarFormatoDecimal(value))
            {
                string[] partes = value.Split(',');
            }
            else
            {
                if (value.Replace(".", "").Replace(" ", "").Length < 4) 
                {
                    input = int.Parse(value.Replace(".", "").Replace(" ", ""));
                }
                else
                {
                    input = 101;
                }
            }
            if (!string.IsNullOrEmpty(lenguaje))
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lenguaje);
            }
            NumerosGallegos data = new NumerosGallegos(value);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (KeyValuePair<string, string> resultado in data.GallegoAnumeros())
            {
                Conversion conversion = new Conversion();
                conversion.Tipo = HttpContext.GetGlobalResourceObject("Resource", resultado.Key).ToString();
                conversion.TitEjemplos = HttpContext.GetGlobalResourceObject("Resource", "TitEjemplos").ToString();
                conversion.TitOpciones = HttpContext.GetGlobalResourceObject("Resource", "TitOpciones").ToString();
                conversion.TitNotas = HttpContext.GetGlobalResourceObject("Resource", "TitNotas").ToString();
                conversion.TitReferencias = HttpContext.GetGlobalResourceObject("Resource", "TitReferencias").ToString();
                conversion.Referencias = new List<string>();
                conversion.Respuestas = new List<string>();
                conversion.RespuestasMayuscula = new List<string>();
                string respuesta = resultado.Value;
                string respuestaMayus = resultado.Value.ToUpper();

                string referencia1 = "Real academia galega";
                string enlace1 = "https://academia.gal";
                string referencia1Final = referencia1 + " | "+ enlace1;
                string referencia2 = "Portal das palabras";
                string enlace2 = "https://portaldaspalabras.gal";
                string referencia2Final = referencia2 + " | " + enlace2;
                string referencia3 = "Normas ortogrñaficas e morfolóxicas do idioma galego";
                string enlace3 = "https://publicacions.academia.gal/index.php/rag/catalog/book/252";
                string referencia3Final = referencia3 + " | " + enlace3;

                conversion.Referencias.Add(referencia3Final);
                conversion.Referencias.Add(referencia1Final);
                conversion.Referencias.Add(referencia2Final);
                conversion.Respuestas.Add(respuesta);
                conversion.RespuestasMayuscula.Add(respuestaMayus);

                conversion.MasOpciones = new List<Opcion>();
                conversion.MasOpcionesMayuscula = new List<Opcion>();

                conversion.Ejemplos = new List<string>();
                conversion.EjemplosMayuscula = new List<string>();

                conversion.Notas = new List<string>();

                if (resultado.Key == "Cardinal") 
                {
                    string resultadoMayus = char.ToUpper(resultado.Value[0]) + resultado.Value.Substring(1);
                    string ejemplo1 = ejemplosCardinalSustantivo[0]+" "+ resultado.Value+" "+ ejemplosCardinalSustantivo[1]+". ("+ (HttpContext.GetGlobalResourceObject("Resource", "Sustantivo").ToString())+").";
                    string ejemplo2 = resultadoMayus+ " "+ ejemplosCardinalSustantivo[2] + ". (" + (HttpContext.GetGlobalResourceObject("Resource", "Sustantivo").ToString()) + ").";
                    string ejemplo3 = ejemplosCardinalPronombre[0] + " " + resultado.Value + ". (" + (HttpContext.GetGlobalResourceObject("Resource", "Pronombre").ToString()) + ").";
                    string ejemplo4 = ejemplosCardinalAdjetivo[0]+" "+resultado.Value+" "+ ejemplosCardinalAdjetivo[1] + ". (" + (HttpContext.GetGlobalResourceObject("Resource", "Adjetivo").ToString()) + ").";
                    string ejemplo5 = ejemplosCardinalAdjetivo[2] +" "+resultado.Value+" "+ejemplosCardinalAdjetivo[3]+ ". (" + (HttpContext.GetGlobalResourceObject("Resource", "Adjetivo").ToString()) + ").";

                    string nota1 = HttpContext.GetGlobalResourceObject("Resource", "NotaCardinal1").ToString();
                    string nota2 = HttpContext.GetGlobalResourceObject("Resource", "NotaCardinal2").ToString();
                    string nota3 = HttpContext.GetGlobalResourceObject("Resource", "NotaCardinal3").ToString();
                    string nota4 = HttpContext.GetGlobalResourceObject("Resource", "NotaCardinal4").ToString();
                    string nota5 = HttpContext.GetGlobalResourceObject("Resource", "NotaCardinal5").ToString();



                    Opcion opcion1 = new Opcion(HttpContext.GetGlobalResourceObject("Resource", "TitOpcionesCardinal1").ToString());
                    opcion1.Opciones = new List<string>
                    {
                        resultado.Value
                    };

                    conversion.Ejemplos.Add(ejemplo1);
                    conversion.EjemplosMayuscula.Add(ejemplo1.ToUpper());
                    conversion.Ejemplos.Add(ejemplo2);
                    conversion.EjemplosMayuscula.Add(ejemplo2.ToUpper());
                    conversion.Ejemplos.Add(ejemplo3);
                    conversion.EjemplosMayuscula.Add(ejemplo3.ToUpper());
                    conversion.Ejemplos.Add(ejemplo4);
                    conversion.EjemplosMayuscula.Add(ejemplo4.ToUpper());
                    conversion.Ejemplos.Add(ejemplo5);
                    conversion.EjemplosMayuscula.Add(ejemplo5.ToUpper());

                    conversion.Notas.Add(nota1);
                    conversion.Notas.Add(nota2);
                    conversion.Notas.Add(nota3);
                    conversion.Notas.Add(nota4);
                    conversion.Notas.Add(nota5);

                    conversion.MasOpciones.Add(opcion1);

                    Opcion opcion2 = new Opcion(HttpContext.GetGlobalResourceObject("Resource", "TitOpcionesCardinal2").ToString());
                    string valorFemenino1 = "unha";
                    string valorFemenino2 = "dúas";
                    string valorFemenino3 = "as";

                    if (resultado.Value.EndsWith("un"))
                    {
                        string valorFemeninoFinal = resultado.Value.Substring(0, resultado.Value.Length - 2) + valorFemenino1;
                        opcion2.Opciones = new List<string>
                        {
                            valorFemeninoFinal
                        };
                        conversion.MasOpciones.Add(opcion2);
                    }

                    if (resultado.Value.EndsWith("dous"))
                    {
                        string valorFemeninoFinal = resultado.Value.Substring(0, resultado.Value.Length - 4) + valorFemenino2;
                        opcion2.Opciones = new List<string>
                        {
                            valorFemeninoFinal
                        };
                        conversion.MasOpciones.Add(opcion2);
                    }

                    if (resultado.Value.EndsWith("centos"))
                    {
                        string valorFemeninoFinal = resultado.Value.Substring(0, resultado.Value.Length - 2) + valorFemenino3;
                        opcion2.Opciones = new List<string>
                        {
                            valorFemeninoFinal
                        };
                        conversion.MasOpciones.Add(opcion2);
                    }


                }

                if (resultado.Key == "Ordinal" && input > 0)
                {

                    Opcion opcion1 = new Opcion(HttpContext.GetGlobalResourceObject("Resource", "TitOpcionesOrdinal1").ToString());
                    opcion1.Opciones = new List<string>
                    {
                        resultado.Value
                    };
                    conversion.MasOpciones.Add(opcion1);

                    Opcion opcion2 = new Opcion(HttpContext.GetGlobalResourceObject("Resource", "TitOpcionesOrdinal2").ToString());
                    string valorFemenino = resultado.Value.Substring(0, resultado.Value.Length - 1) + "a";

                    string ejemplo1 = "A "+valorFemenino+" "+ ejemplosOrdianlPronombre[0]+ ". (" + (HttpContext.GetGlobalResourceObject("Resource", "Pronombre").ToString()) + ").";
                    string ejemplo2 = ejemplosOrdianlPronombre[1]+" "+resultado.Value+". (" + (HttpContext.GetGlobalResourceObject("Resource", "Pronombre").ToString()) + ").";
                    string ejemplo3 = ejemplosOrdianlAdjetivo[0]+" "+resultado.Value+" "+ejemplosOrdianlAdjetivo[1] + ". (" + (HttpContext.GetGlobalResourceObject("Resource", "Adjetivo").ToString()) + ").";
                    string ejemplo4 = ejemplosOrdianlAdjetivo[2]+" "+ resultado.Value+" "+ ejemplosOrdianlAdjetivo[3] + ". (" + (HttpContext.GetGlobalResourceObject("Resource", "Adjetivo").ToString()) + ").";

                    string nota1 = HttpContext.GetGlobalResourceObject("Resource", "NotaOrdinal1").ToString();
                    string nota2 = HttpContext.GetGlobalResourceObject("Resource", "NotaOrdinal2").ToString();
                    string nota3 = HttpContext.GetGlobalResourceObject("Resource", "NotaOrdinal3").ToString();

                    opcion2.Opciones = new List<string>
                    {
                        valorFemenino
                    };

                    conversion.Ejemplos.Add(ejemplo1);
                    conversion.EjemplosMayuscula.Add(ejemplo1.ToUpper());
                    conversion.Ejemplos.Add(ejemplo2);
                    conversion.EjemplosMayuscula.Add(ejemplo2.ToUpper());
                    conversion.Ejemplos.Add(ejemplo3);
                    conversion.EjemplosMayuscula.Add(ejemplo3.ToUpper());
                    conversion.Ejemplos.Add(ejemplo4);
                    conversion.EjemplosMayuscula.Add(ejemplo4.ToUpper());
                    conversion.MasOpciones.Add(opcion2);

                    conversion.Notas.Add(nota1);
                    conversion.Notas.Add(nota2);
                    conversion.Notas.Add(nota3);
                }

                if ((resultado.Key == "Fraccionario" || resultado.Key == "Fractional") && input>1 || (resultado.Key == "Fraccionario" || resultado.Key == "Fractional") && fraccion == true)
                {
                    string nota1 = HttpContext.GetGlobalResourceObject("Resource", "NotaFraccionario1").ToString();
                    string nota2 = HttpContext.GetGlobalResourceObject("Resource", "NotaFraccionario2").ToString();
                    string nota3 = HttpContext.GetGlobalResourceObject("Resource", "NotaFraccionario3").ToString();

                    conversion.Notas.Add(nota1);
                    conversion.Notas.Add(nota2);
                    conversion.Notas.Add(nota3); 

                    if (fraccion == false) 
                    {
                        
                        
                        Opcion opcion2 = new Opcion(HttpContext.GetGlobalResourceObject("Resource", "TitOpcionesFraccionario2").ToString());
                        string valorFemenino = resultado.Value.Substring(0, resultado.Value.Length - 1) + "a";
                        string ejemplo1 = "Un " + resultado.Value + " " + ejemplosFraccionarioSustantivo[0] + ". (" + (HttpContext.GetGlobalResourceObject("Resource", "Sustantivo").ToString()) + ").";
                        string ejemplo2 = ejemplosFraccionarioSustantivo[1] + " " + resultado.Value + "s " + ejemplosFraccionarioSustantivo[2] + ". (" + (HttpContext.GetGlobalResourceObject("Resource", "Sustantivo").ToString()) + ").";
                        string ejemplo3 = ejemplosFraccionarioAdjetivos[0] + " " + valorFemenino + " " + ejemplosFraccionarioAdjetivos[1] + ". (" + (HttpContext.GetGlobalResourceObject("Resource", "Adjetivo").ToString()) + ").";
                        string ejemplo4 = ejemplosFraccionarioAdjetivos[2] + " " + valorFemenino + "s " + ejemplosFraccionarioAdjetivos[3] + ". (" + (HttpContext.GetGlobalResourceObject("Resource", "Adjetivo").ToString()) + ").";
                        string ejemplo5 = ejemplosFraccionarioPronombre[0]+" "+resultado.Value+". (" + (HttpContext.GetGlobalResourceObject("Resource", "Pronombre").ToString()) + ").";

                        opcion2.Opciones = new List<string>
                        {
                            valorFemenino
                        };
                        conversion.Ejemplos.Add(ejemplo1);
                        conversion.EjemplosMayuscula.Add(ejemplo1.ToUpper());
                        conversion.Ejemplos.Add(ejemplo2);
                        conversion.EjemplosMayuscula.Add(ejemplo2.ToUpper());
                        conversion.Ejemplos.Add(ejemplo3);
                        conversion.EjemplosMayuscula.Add(ejemplo3.ToUpper());
                        conversion.Ejemplos.Add(ejemplo4);
                        conversion.EjemplosMayuscula.Add(ejemplo4.ToUpper());
                        conversion.Ejemplos.Add(ejemplo5);
                        conversion.EjemplosMayuscula.Add(ejemplo5.ToUpper());

                        conversion.MasOpciones.Add(opcion2);

                    }
                    else
                    {
                        Opcion opcion1 = new Opcion(HttpContext.GetGlobalResourceObject("Resource", "TitOpcionesFraccionario1").ToString());
                        string resultadoMayus = char.ToUpper(resultado.Value[0]) + resultado.Value.Substring(1);
                        string valorFemenino = resultado.Value.Substring(0, resultado.Value.Length - 1) + "a";
                        string resultadoMayus1 = char.ToUpper(valorFemenino[0]) + valorFemenino.Substring(1);
                        string ejemplo1 = ejemplosFraccionarioSustantivo[4]+" "+resultado.Value+" "+ ejemplosFraccionarioSustantivo[5]+  ". (" + (HttpContext.GetGlobalResourceObject("Resource", "Sustantivo").ToString()) + ").";
                        string ejemplo2 = ejemplosFraccionarioSustantivo[3] + " " + resultado.Value + "s " + ejemplosFraccionarioSustantivo[2] + ". (" + (HttpContext.GetGlobalResourceObject("Resource", "Sustantivo").ToString()) + ").";
                        string ejemplo3 = ejemplosFraccionarioAdjetivos[0] + " " + valorFemenino + " " + ejemplosFraccionarioAdjetivos[1] + ". (" + (HttpContext.GetGlobalResourceObject("Resource", "Adjetivo").ToString()) + ").";
                        string ejemplo4 = resultadoMayus1 + "s " + ejemplosFraccionarioAdjetivos[3] + ". (" + (HttpContext.GetGlobalResourceObject("Resource", "Adjetivo").ToString()) + ").";
                        opcion1.Opciones = new List<string>
                    {
                        resultado.Value
                    };
                        conversion.Ejemplos.Add(ejemplo1);
                        conversion.EjemplosMayuscula.Add(ejemplo1.ToUpper());
                        conversion.Ejemplos.Add(ejemplo2);
                        conversion.EjemplosMayuscula.Add(ejemplo2.ToUpper());
                        conversion.Ejemplos.Add(ejemplo3);
                        conversion.EjemplosMayuscula.Add(ejemplo3.ToUpper());
                        conversion.Ejemplos.Add(ejemplo4);
                        conversion.EjemplosMayuscula.Add(ejemplo4.ToUpper());
                        conversion.MasOpciones.Add(opcion1);
                    }
                    
                }
                if ((resultado.Key == "Multiplicativo" || resultado.Key== "Multiplicative") && input > 1)
                {
                    string nota1 = HttpContext.GetGlobalResourceObject("Resource", "NotaMultiplicativo1").ToString();
                    string nota2 = HttpContext.GetGlobalResourceObject("Resource", "NotaMultiplicativo2").ToString();
                    string nota3 = HttpContext.GetGlobalResourceObject("Resource", "NotaMultiplicativo3").ToString();

                    conversion.Notas.Add(nota1);
                    conversion.Notas.Add(nota2);
                    conversion.Notas.Add(nota3);

                    if (input>10 && input!=100)
                    {
                        Opcion opcion1 = new Opcion(HttpContext.GetGlobalResourceObject("Resource", "TitOpcionesMultiplicativo1").ToString());
                        opcion1.Opciones = new List<string>
                        {
                            resultado.Value
                        };
                        conversion.MasOpciones.Add(opcion1);

                        Opcion opcion2 = new Opcion(HttpContext.GetGlobalResourceObject("Resource", "TitOpcionesMultiplicativo2").ToString());
                        string valorconVerbo = "multiplicar por " + resultado.Value.Substring(0, resultado.Value.Length - 6);
                        string ejemplo1 = ejemplosMultiplicativoAdjetivo2[0]+" "+ resultado.Value+" "+ ejemplosMultiplicativoAdjetivo2[1] + ". (" + (HttpContext.GetGlobalResourceObject("Resource", "Expresión con adjetivo").ToString()) + ").";
                        string ejemplo2 = ejemplosMultiplicativoAdjetivo2[2] + " " + resultado.Value + " " + ejemplosMultiplicativoAdjetivo2[3] + ". (" + (HttpContext.GetGlobalResourceObject("Resource", "Expresión con adjetivo").ToString()) + ").";
                        string ejemplo3 = ejemplosMultiplicativoVerbo2[0] + " " + valorconVerbo + " " + ejemplosMultiplicativoVerbo2[1] + ". (" + (HttpContext.GetGlobalResourceObject("Resource", "Expresión con verbo").ToString()) + ").";
                        string ejemplo4 = ejemplosMultiplicativoVerbo2[2] + " " + valorconVerbo + " " + ejemplosMultiplicativoVerbo2[3] + ". (" + (HttpContext.GetGlobalResourceObject("Resource", "Expresión con verbo").ToString()) + ").";

                        opcion2.Opciones = new List<string>
                        {
                            valorconVerbo
                        };
                        conversion.Ejemplos.Add(ejemplo1);
                        conversion.EjemplosMayuscula.Add(ejemplo1.ToUpper());
                        conversion.Ejemplos.Add(ejemplo2);
                        conversion.EjemplosMayuscula.Add(ejemplo2.ToUpper());
                        conversion.Ejemplos.Add(ejemplo3);
                        conversion.EjemplosMayuscula.Add(ejemplo3.ToUpper());
                        conversion.Ejemplos.Add(ejemplo4);
                        conversion.EjemplosMayuscula.Add(ejemplo4.ToUpper());

                        conversion.MasOpciones.Add(opcion2);
                    }
                    else
                    {
                        string terminacionVerbo = "plicar";
                        Opcion opcion1 = new Opcion(HttpContext.GetGlobalResourceObject("Resource", "TitOpcionesMultiplicativo3").ToString());
                        opcion1.Opciones = new List<string>
                        {
                            resultado.Value
                        };
                        conversion.MasOpciones.Add(opcion1);

                        Opcion opcion2 = new Opcion(HttpContext.GetGlobalResourceObject("Resource", "TitOpcionesMultiplicativo4").ToString());
                        Opcion opcion3 = new Opcion(HttpContext.GetGlobalResourceObject("Resource", "TitOpcionesMultiplicativo5").ToString());
                        string valorVerbo = resultado.Value.Substring(0, resultado.Value.Length - 3) + terminacionVerbo;
                        switch (valorVerbo) //ESTE SWITCH  QUITA LAS TILDES
                        {
                            case string s when s.Contains("á"):
                                valorVerbo = valorVerbo.Replace("á", "a");
                                break;
                            case string s when s.Contains("é"):
                                valorVerbo = valorVerbo.Replace("é", "e");
                                break;
                            case string s when s.Contains("í"):
                                valorVerbo = valorVerbo.Replace("í", "i");
                                break;
                            case string s when s.Contains("ó"):
                                valorVerbo = valorVerbo.Replace("ó", "o");
                                break;
                            default:
                                break;

                        }
                        string valorFemenino = resultado.Value.Substring(0, resultado.Value.Length - 1) + "a";
                        string ejemplo1 = ejemplosMultiplicativoSustantivo[0] + " " + resultado.Value + " " + ejemplosMultiplicativoSustantivo[1] + ". (" + (HttpContext.GetGlobalResourceObject("Resource", "Sustantivo").ToString()) + ").";
                        string ejemplo2 = ejemplosMultiplicativoAdjetivo1[0]+" "+valorFemenino+" "+ejemplosMultiplicativoAdjetivo1[1] +". (" + (HttpContext.GetGlobalResourceObject("Resource", "Adjetivo").ToString()) + ").";
                        string ejemplo3 = ejemplosMultiplicativoAdjetivo1[2]+" "+resultado.Value+" "+ejemplosMultiplicativoAdjetivo1[3]+ ". (" + (HttpContext.GetGlobalResourceObject("Resource", "Adjetivo").ToString()) + ").";
                        string ejemplo4 = ejemplosMultiplicativoVerbo1[0]+" "+valorVerbo+" "+ ejemplosMultiplicativoVerbo1[1] + ". (" + (HttpContext.GetGlobalResourceObject("Resource", "Verbo").ToString()) + ").";
                        string ejemplo5 = ejemplosMultiplicativoVerbo1[2]+" "+ valorVerbo+" "+ ejemplosMultiplicativoVerbo1[3]+ ". (" + (HttpContext.GetGlobalResourceObject("Resource", "Verbo").ToString()) + ").";
                        opcion3.Opciones = new List<string>
                        {
                            valorFemenino
                        };
                        opcion2.Opciones = new List<string>
                        {
                            valorVerbo
                        };

                        conversion.Ejemplos.Add(ejemplo1);
                        conversion.EjemplosMayuscula.Add(ejemplo1.ToUpper());
                        conversion.Ejemplos.Add(ejemplo2);
                        conversion.EjemplosMayuscula.Add(ejemplo2.ToUpper());
                        conversion.Ejemplos.Add(ejemplo3);
                        conversion.EjemplosMayuscula.Add(ejemplo3.ToUpper());
                        conversion.Ejemplos.Add(ejemplo4);
                        conversion.EjemplosMayuscula.Add(ejemplo4.ToUpper());
                        conversion.Ejemplos.Add(ejemplo5);
                        conversion.EjemplosMayuscula.Add(ejemplo5.ToUpper());

                        conversion.MasOpciones.Add(opcion3);
                        conversion.MasOpciones.Add(opcion2);

                    }
                    
                }
                if (resultado.Key == "Decimal") 
                {
                    Opcion opcion1 = new Opcion(HttpContext.GetGlobalResourceObject("Resource", "TitOpcionesDecimal").ToString());
                    opcion1.Opciones = new List<string>
                        {
                            resultado.Value
                        };
                    string ejemplo1 = ejemplosCardinalSustantivo[0] + " " + resultado.Value + " " + ejemplosCardinalSustantivo[1] + ". (" + (HttpContext.GetGlobalResourceObject("Resource", "Sintagma nominal").ToString()) + ").";
                    string ejemplo2 = "O " + resultado.Value + " " + ejemplosCardinalSustantivo[2] + ". (" + (HttpContext.GetGlobalResourceObject("Resource", "Sintagma nominal").ToString()) + ").";

                    string nota1 = HttpContext.GetGlobalResourceObject("Resource", "NotaCardinal2").ToString();
                    string nota2 = HttpContext.GetGlobalResourceObject("Resource", "NotaCardinal3").ToString();
                    string nota3 = HttpContext.GetGlobalResourceObject("Resource", "NotaCardinal4").ToString();

                    conversion.Notas.Add(nota1);
                    conversion.Notas.Add(nota2);
                    conversion.Notas.Add(nota3);

                    conversion.Ejemplos.Add(ejemplo1);
                    conversion.EjemplosMayuscula.Add(ejemplo1.ToUpper());
                    conversion.Ejemplos.Add(ejemplo2);
                    conversion.EjemplosMayuscula.Add(ejemplo2.ToUpper());
                    conversion.MasOpciones.Add(opcion1);
                }
                salida.Add(conversion); 
            }

            List<Conversion> salidaOrdenada = salida.OrderBy(item => ObtenerOrden(item.Tipo)).ToList();

            // Función para obtener el orden de los tipos
            int ObtenerOrden(string tipo)
            {
                switch (tipo)
                {
                    case "Cardinal": return 0;
                    case "Ordinal": return 1;
                    case "Fraccionario": return 2;
                    case "Fractional": return 2;
                    case "Multiplicative": return 3;
                    case "Multiplicativo": return 3;
                    default: return int.MaxValue;
                }
            }

            return salidaOrdenada;
        }
    }
}
