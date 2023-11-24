using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.ServiceModel.Channels;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using NumerosGallegos.ServicioNumerosGallegoWCF;
namespace NumerosGallegos
{
    public partial class _Default : Page
    {
        private int contador = 0;
        string lang;
        protected void Page_Load(object sender, EventArgs e)
        {
            lang = Request.QueryString["lang"];
            if (!string.IsNullOrEmpty(lang))
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            }
            formulario.Attributes["placeholder"] = HttpContext.GetGlobalResourceObject("Resource", "placeholder").ToString();
            lblTitle.Text= HttpContext.GetGlobalResourceObject("Resource", "InicioCabecera").ToString();

            Label lblTextoInicial1 = new Label();
            lblTextoInicial1.Text = HttpContext.GetGlobalResourceObject("Resource", "textoInicial1").ToString();

            Label lblTextoInicial2 = new Label();
            lblTextoInicial2.Text = HttpContext.GetGlobalResourceObject("Resource", "textoInicial2").ToString();

            Panel divTextoInicial = new Panel();
            divTextoInicial.CssClass = "textoInicial";
            divTextoInicial.ID = "divTextoInicial0";

            Panel divEjemplos = new Panel();
            divEjemplos.CssClass = "tarjetaEjemplos";
            divEjemplos.ID = "divEjemplos";


            Panel cabeceraEjemplos = new Panel();
            cabeceraEjemplos.CssClass = "cabeceraEjemplos";

            Label titejemplo = new Label();
            titejemplo.Text = HttpContext.GetGlobalResourceObject("Resource", "titEjemplos").ToString();
            cabeceraEjemplos.Controls.Add(titejemplo);

            HtmlGenericControl fila1 = new HtmlGenericControl("p");
            HtmlGenericControl fila2 = new HtmlGenericControl("p");
            HtmlGenericControl fila3 = new HtmlGenericControl("p");
            HtmlGenericControl fila4 = new HtmlGenericControl("p");

            HtmlGenericControl pElement = new HtmlGenericControl("p");
            HtmlGenericControl pElement1 = new HtmlGenericControl("p");
            HtmlGenericControl pElement2 = new HtmlGenericControl("label");
            HtmlGenericControl pElement3= new HtmlGenericControl("label");
            HtmlGenericControl pElement4 = new HtmlGenericControl("label");
            HtmlGenericControl pElement5 = new HtmlGenericControl("label");
            HtmlGenericControl pElement6 = new HtmlGenericControl("label");
            HtmlGenericControl pElement7 = new HtmlGenericControl("label");
            HtmlGenericControl pElement8 = new HtmlGenericControl("label");
            HtmlGenericControl pElement9 = new HtmlGenericControl("label");
            HtmlGenericControl pElement10 = new HtmlGenericControl("label");
            HtmlGenericControl pElement11 = new HtmlGenericControl("label");
            HtmlGenericControl pElement12 = new HtmlGenericControl("label");
            HtmlGenericControl pElement13 = new HtmlGenericControl("label");
            HtmlGenericControl pElement14 = new HtmlGenericControl("label");
            HtmlGenericControl pElement15 = new HtmlGenericControl("label");

            pElement2.InnerText = "13289";
            pElement2.Attributes["onclick"] = "simularEnvioFormulario('13289');";
            pElement3.InnerText = "53625999567"; 
            pElement3.Attributes["onclick"] = "simularEnvioFormulario('53625999567');";
            pElement4.InnerText = "345676 "; 
            pElement4.Attributes["onclick"] = "simularEnvioFormulario('345676');";
            pElement5.InnerText = "13 289"; 
            pElement5.Attributes["onclick"] = "simularEnvioFormulario('13 289');";
            pElement6.InnerText = "53 625 999 567"; 
            pElement6.Attributes["onclick"] = "simularEnvioFormulario('53 625 999 567');";
            pElement7.InnerText = "345 676"; 
            pElement7.Attributes["onclick"] = "simularEnvioFormulario('345676');";
            pElement8.InnerText = "3/4 ";
            pElement8.Attributes["onclick"] = "simularEnvioFormulario('3/4');";
            pElement9.InnerText = "78/125";
            pElement9.Attributes["onclick"] = "simularEnvioFormulario('78/125');";
            pElement10.InnerText = "100.000/250";
            pElement10.Attributes["onclick"] = "simularEnvioFormulario('100.000/250');";
            pElement11.InnerText = "3,4";
            pElement11.Attributes["onclick"] = "simularEnvioFormulario('3,4');";
            pElement12.InnerText = "78,125";
            pElement12.Attributes["onclick"] = "simularEnvioFormulario('78,125');";
            pElement13.InnerText = "100.000,250";
            pElement13.Attributes["onclick"] = "simularEnvioFormulario('100.000,250');";
            pElement14.InnerText = "345 676,13 289";
            pElement14.Attributes["onclick"] = "simularEnvioFormulario('345 676,13 289');";
            pElement15.InnerText = "345 676/13 289";
            pElement15.Attributes["onclick"] = "simularEnvioFormulario('345 676/13 289');";



            fila1.Controls.Add(pElement2);
            fila1.Controls.Add(pElement3);
            fila1.Controls.Add(pElement4);

            fila2.Controls.Add(pElement5);
            fila2.Controls.Add(pElement6);
            fila2.Controls.Add(pElement7);

            fila3.Controls.Add(pElement8);
            fila3.Controls.Add(pElement9);
            fila3.Controls.Add(pElement10);
            fila3.Controls.Add(pElement15);

            fila4.Controls.Add(pElement11);
            fila4.Controls.Add(pElement12);
            fila4.Controls.Add(pElement13);
            fila4.Controls.Add(pElement14);

            divEjemplos.Controls.Add(fila1);
            divEjemplos.Controls.Add(fila2);
            divEjemplos.Controls.Add(fila3);
            divEjemplos.Controls.Add(fila4);

            pElement.Controls.Add(lblTextoInicial1);
            pElement1.Controls.Add(lblTextoInicial2);

            divTextoInicial.Controls.Add(pElement);
            divTextoInicial.Controls.Add(pElement1);
            divTextoInicial.Controls.Add(cabeceraEjemplos);
            divTextoInicial.Controls.Add(divEjemplos);


            textoinicialContainer.Controls.Add(divTextoInicial);


        }
        protected void formulario_TextChanged(object sender, EventArgs e)
        {
            string resultado = formulario.Text;
            textoinicialContainer.Style["display"]="none";
            tarjetasContainer.Style["margin-top"] = "20px";
            lang = Request.QueryString["lang"];
            ServicioNumerosGallegosClient servicio = new ServicioNumerosGallegosClient("BasicHttpBinding_IServicioNumerosGallegos");
            bool TrueCardinalPlano = Regex.IsMatch(resultado, @"^[0-9]*$");
            bool TrueFraccion = Regex.IsMatch(resultado.Replace(".", "").Replace(" ", ""), @"^\d{0,30}\/\d{1,30}$");
            bool Truetamaño = Regex.IsMatch(resultado.Replace(".", "").Replace(" ", ""), @"^[0-9]{1,30}$");
            bool TrueCardinalSeparadores = Regex.IsMatch(resultado, @"^\d{1,3}(\.\d{3}|\s\d{3})*");
            bool ContieneLetras = Regex.IsMatch(resultado, @"[a-zA-Z]");
            bool TrueDecimal = Regex.IsMatch(resultado.Replace(".", "").Replace(" ", ""), @"^\d{0,30},\d{1,30}$");

            try
            {
                if ((TrueCardinalPlano && Truetamaño) || TrueFraccion || TrueDecimal|| (TrueCardinalSeparadores && Truetamaño) && !ContieneLetras)
                {
                    List<Conversion> resultadoTraducido = servicio.TraduciraTexto(resultado,lang);
                    
                    tarjetasContainer.Controls.Clear();

                    foreach (Conversion conversion in resultadoTraducido)
                    {
                        if (!string.IsNullOrEmpty(conversion.Respuestas[0]))
                        {

                            Panel tarjeta = new Panel();
                            tarjeta.CssClass = "tarjeta";
                            tarjeta.ID = "tarjeta" + contador;


                            Panel cabecera = new Panel();
                            cabecera.CssClass = "cabecera";

                            Label lblTipo = new Label();
                            lblTipo.Text = conversion.Tipo;
                            cabecera.Controls.Add(lblTipo);
                            lblTipo.Style["font-weight"] = "bold";
                            lblTipo.Style["font-size"] = "large";
                            lblTipo.ID = "tipo" + contador;
                            Label lblRespuesta = new Label();
                            lblRespuesta.Text = conversion.Respuestas[0];
                            lblRespuesta.ID = "respuesta" + contador;
                            lblRespuesta.Style["font-size"] = "large";

                            Panel divimgCopiar = new Panel();
                            divimgCopiar.CssClass = "DivImg";

                            Panel divrespuesta = new Panel();
                            divrespuesta.CssClass = "Divrespuesta";


                            Image imgCopiar = new Image();
                            imgCopiar.ImageUrl = "iconos/icono_copiar.png";
                            imgCopiar.Attributes["onclick"] = $"navigator.clipboard.writeText('{HttpUtility.JavaScriptStringEncode(conversion.Respuestas[0])}');";   
                            imgCopiar.Attributes["style"] = "cursor: pointer ;";

                            divimgCopiar.Controls.Add(imgCopiar);
                            divrespuesta.Controls.Add(divimgCopiar);
                            divrespuesta.Controls.Add(lblRespuesta);

                            Panel divimg2 = new Panel();
                            divimg2.CssClass = "DivImg";

                            Image imgMostrarOcultar = new Image();
                            imgMostrarOcultar.ID = "imgMostrarOcultar_" + contador;
                            imgMostrarOcultar.ImageUrl = "iconos/icono_flechaAbajo.png";
                            divimg2.Attributes["style"] = "float:right;";
                            imgMostrarOcultar.Attributes["style"] = "cursor: pointer ;";
                            imgMostrarOcultar.Attributes["onclick"] = $"mostrarOcultarDivContenedor('divContenedor_{contador}', 'imgMostrarOcultar_{contador}')";
                            divimg2.Controls.Add(imgMostrarOcultar);

                            Panel divimg3 = new Panel();
                            divimg3.CssClass = "DivImg";

                            Panel divimg4 = new Panel();
                            divimg4.CssClass = "DivImg";

                            Image imgNotas = new Image();
                            imgNotas.ID = "imgNotas" + contador;
                            imgNotas.ImageUrl = "iconos/notas.png";
                            divimg4.Attributes["style"] = "float:right;";
                            imgNotas.Attributes["style"] = "cursor: pointer ;";
                            imgNotas.Attributes["onclick"] = "mostrarDivEmergente([" + string.Join(",", conversion.Notas.Select(r => "'" + r + "'")) + "], '" + conversion.TitNotas + "'); return false;";

                            divimg4.Controls.Add(imgNotas);

                            Image imgReferencias = new Image();
                            imgReferencias.ID = "imgReferencias" + contador;
                            imgReferencias.ImageUrl = "iconos/referencia.png";
                            divimg3.Attributes["style"] = "float:right;";
                            imgReferencias.Attributes["style"] = "cursor: pointer ;";
                            imgReferencias.Attributes["onclick"] = "mostrarDivEmergente([" + string.Join(",", conversion.Referencias.Select(r => "'" + r + "'")) + "], '" + conversion.TitReferencias + "'); return false;";


                            divimg3.Controls.Add(imgReferencias);

                            Panel divContenedor = new Panel();
                            divContenedor.CssClass = "contenedor";
                            divContenedor.ID = "divContenedor_" + contador;
                            divContenedor.Attributes["style"] = "display:none;";

                            Panel div1 = new Panel();
                            div1.CssClass = "div1";
                            Label lblDiv1 = new Label();
                            lblDiv1.Text = conversion.TitOpciones;
                            div1.Controls.Add(lblDiv1);

                            Panel div2 = new Panel();
                            div2.CssClass = "div2";
                            foreach (Opcion opcion in conversion.MasOpciones)
                            {

                                Label lblTitulo = new Label();
                                lblTitulo.Text = opcion.Titulo;
                                div2.Controls.Add(lblTitulo);


                                HtmlGenericControl ul = new HtmlGenericControl("ul");
                                foreach (string opcionTexto in opcion.Opciones)
                                {
                                    Literal li = new Literal();
                                    li.Text = "<li>" + HttpUtility.HtmlEncode(opcionTexto) + "</li>";
                                    ul.Controls.Add(li);
                                }
                                div2.Controls.Add(ul);
                            }

                            Panel div3 = new Panel();
                            div3.CssClass = "div3";
                            Label lblDiv3 = new Label();
                            lblDiv3.Text = conversion.TitEjemplos;
                            div3.Controls.Add(lblDiv3);

                            Panel div4 = new Panel();
                            div4.CssClass = "div4";
                            HtmlGenericControl ul2 = new HtmlGenericControl("ul");
                            foreach (var ejemplo in conversion.Ejemplos)
                            {
                                Literal li = new Literal();
                                li.Text = "<li>" + HttpUtility.HtmlEncode(ejemplo) + "</li>";
                                ul2.Controls.Add(li);
                            }
                            div4.Controls.Add(ul2);

                            divContenedor.Controls.Add(div1);
                            divContenedor.Controls.Add(div2);
                            divContenedor.Controls.Add(div3);
                            divContenedor.Controls.Add(div4);

                            tarjeta.Controls.Add(cabecera);
                            tarjeta.Controls.Add(divrespuesta);
                            cabecera.Controls.Add(divimg2);
                            cabecera.Controls.Add(divimg3);
                            cabecera.Controls.Add(divimg4);

                            contador++;
                            
                            tarjetasContainer.Controls.Add(tarjeta);
                            tarjetasContainer.Controls.Add(divContenedor);
                        }

                    }
                }
                else
                {//Tarjeta error

                    Panel panelError = new Panel();
                    panelError.CssClass = "error-panel tarjeta";

                    Panel divCabecera = new Panel();
                    divCabecera.CssClass = "error-header";
                    Label lblCabecera1 = new Label();
                    lblCabecera1.CssClass = "error-header-text1";
                    lblCabecera1.Text = "Error ";
                    Label lblCabecera = new Label();
                    lblCabecera.CssClass = "error-header-text";
                    lblCabecera.Text ="- " + HttpContext.GetGlobalResourceObject("Resource", "titError").ToString();
                    divCabecera.Controls.Add(lblCabecera1);
                    divCabecera.Controls.Add(lblCabecera);

                    Panel divContenido = new Panel();
                    divContenido.CssClass = " error-content";
                    HtmlGenericControl ulErrores = new HtmlGenericControl("ul");
                    HtmlGenericControl liError = new HtmlGenericControl("li");
                    HtmlGenericControl liError2 = new HtmlGenericControl("li");
                    HtmlGenericControl liError3 = new HtmlGenericControl("li");
                    HtmlGenericControl liError4 = new HtmlGenericControl("li");
                    HtmlGenericControl liError5 = new HtmlGenericControl("li");
                    HtmlGenericControl liError6 = new HtmlGenericControl("li");
                    HtmlGenericControl liError7 = new HtmlGenericControl("li");
                    liError.InnerText = HttpContext.GetGlobalResourceObject("Resource", "listaError1").ToString();
                    ulErrores.Controls.Add(liError);
                    liError2.InnerText = HttpContext.GetGlobalResourceObject("Resource", "listaError2").ToString();
                    ulErrores.Controls.Add(liError2);
                    liError3.InnerText = HttpContext.GetGlobalResourceObject("Resource", "listaError3").ToString();
                    ulErrores.Controls.Add(liError3);
                    liError4.InnerText = HttpContext.GetGlobalResourceObject("Resource", "listaError4").ToString();
                    ulErrores.Controls.Add(liError4);
                    liError5.InnerText = HttpContext.GetGlobalResourceObject("Resource", "listaError5").ToString();
                    ulErrores.Controls.Add(liError5);
                    liError6.InnerText = HttpContext.GetGlobalResourceObject("Resource", "listaError6").ToString();
                    ulErrores.Controls.Add(liError6);
                    liError7.InnerText = HttpContext.GetGlobalResourceObject("Resource", "listaError7").ToString();
                    ulErrores.Controls.Add(liError7);

                    divContenido.Controls.Add(ulErrores);
                    panelError.Controls.Add(divCabecera);
                    panelError.Controls.Add(divContenido);
                    tarjetasContainer.Controls.Add(panelError);
                }
                
            }
            catch (Exception ex)
            {

                Response.Write("Error al enviar el formulario: " + ex.Message);
            }

        }

    }
}