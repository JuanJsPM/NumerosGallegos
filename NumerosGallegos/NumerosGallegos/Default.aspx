    <%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NumerosGallegos._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="StyleSheet1.css" rel="stylesheet">
    <main style="flex-grow: 1;">
        <section class="row" aria-labelledby="aspnetTitle">
            <div class="tarjetaIdiomas">
                <div id="dividiomascontainer" >
                    <div class="divIdiomaImg" onclick="ChangeLanguage('es');" style="cursor: pointer;" >
                        <div class="DivImg"  style="float: left;width: 30px;margin-right: 5px;margin-left: 5px;">
                            <img src="/iconos/spanish.png" alt="Español" />
                        </div>
                        <div  style="float: left;">
                            <asp:Label ID="LabelEs"  Text="Español"  runat="server" />
                        </div>
                
                    </div>
                    <div class="divIdiomaImg" style="cursor: pointer;" onclick="ChangeLanguage('en');">
                        <div class="DivImg"  style="float: left;width: 30px;margin-right: 5px;margin-left: 5px;">
                            <img src="/iconos/english.png" alt="English" />
                        </div>
                        <div  style="float: left;">
                            <asp:Label ID="LabelEn"  Text="English"  runat="server" />
                        </div>
                        
                    </div>
                    <div class="divIdiomaImg" style="padding-bottom: 6px;cursor: pointer;" onclick="ChangeLanguage('gl');">
                        <div class="DivImg"  style="float: left;width: 30px;margin-right: 5px;margin-left: 5px;">
                             <img src="/iconos/galego.png" alt="Galego" />
                        </div>
                        <div  style="float: left;">
                            <asp:Label ID="LabelGl"  Text="Galego"  runat="server" />
                        </div>
                        
                    </div>
                </div>
            </div>
            <div class="InicioTarjeta">
                <div class="InicioCabecera">
                     <h1 id="aspnetTitle" onclick="window.location.href = 'Default';">Números Gallegos</h1>
                </div>

                <div class="InicioContent">
                    <div  style="margin-bottom:10px; width:95%">
                        <asp:Label ID="lblTitle" CssClass="lead" Text="" style="float: left;" runat="server" />
                    </div>
                    <div class="row divformulario"  style="width: 100%; padding-top: 10px">
                        <asp:TextBox ID="formulario" runat="server" OnTextChanged="formulario_TextChanged" style="margin-left: 10px;" ></asp:TextBox> 
                    </div>
                </div>
            </div>       
        </section>
        <div>
             <div class="row tarjetasContainer" runat="server" id="tarjetasContainer"></div>
             <div class="row tarjetasContainer textoinicial" runat="server" id="textoinicialContainer"></div>
        </div>
    </main>
    <footer class="row">
        <div class="row tarjetaF" style="flex-direction: unset;">    
            <div class="col-md-3  col-sm-12 iatext-pie">
                <a href="https://iatext.ulpgc.es" target="_blank"><img src="iconos/iatext-pie.png"></a>
            </div>
            <div class="col-md-9  col-sm-12 cita">
                <p> Peraza Machín, J. Trabajo de fin de grado - Ingeniería informática - 2023.
                    Convertidor de números a texto en gallego - Números TIP.Carreras-Riudavets, F Tutor de TFG.
                </p>
            </div>  
        </div>
    </footer>

   <script type="text/javascript">
       function simularEnvioFormulario(ejemplo) {
           var formularioTextBox = document.getElementById('MainContent_formulario');
           formularioTextBox.value = ejemplo;
           document.forms[0].submit();
           
       }
       function mostrarOcultarDivContenedor(id, imgId) {
           event.preventDefault();
           var divContenedor = document.getElementById('MainContent_' + id);
           var imgElement = document.getElementById('MainContent_' + imgId);

           if (divContenedor.style.display === "none") {
               divContenedor.style.display = "block";
               imgElement.src = "/iconos/icono_flechaArriba.png"; 
           } else {
               divContenedor.style.display = "none";
               imgElement.src = "/iconos/icono_flechaAbajo.png"; 
           }
       }
       var popupAbierto = false;
       function mostrarDivEmergente(lista, tit) {

           if (popupAbierto) {
               return;
           }

           var popup = document.createElement('div');
           var popupimg = document.createElement('div');
           popup.className = 'popup-container';
           popupimg.className = 'DivImg'

           var popupHeader = document.createElement('div');
           popupHeader.className = 'popup-header';
           popupHeader.innerText = tit;
           

           var closeButton = document.createElement('img');

           closeButton.src = '/iconos/cerrar.png'; 
           closeButton.className = 'popup-close';
           

           closeButton.addEventListener('click', function () {
               document.body.removeChild(popup);
               popupAbierto = false;
           });

           popupimg.appendChild(closeButton);
           popupHeader.appendChild(popupimg);
           popup.appendChild(popupHeader);

           var popupContent = document.createElement('div');
           popupContent.className = 'popup-content';

           var ul = document.createElement('ul');
           lista.forEach(function (item) {
               var li = document.createElement('li');
               if (item.includes("|")) {
                   var parts = item.split("|");
                   var link = document.createElement('a');
                   link.href = parts[1].trim();
                   link.textContent = parts[1].trim();
                   var texto = document.createTextNode(parts[0].trim() + ": ");
                   li.appendChild(texto);
                   li.appendChild(link);
               } else { 
                   var textNode = document.createTextNode(item);
                   li.appendChild(textNode);
               }
               ul.appendChild(li);
               
           });
           popupContent.appendChild(ul);
           popup.appendChild(popupContent);
           document.body.appendChild(popup);
           popupAbierto = true;
       }
       function ChangeLanguage(lang) {
             window.location.href = 'Default?lang=' + lang;
       }

   </script>

    </asp:Content>
