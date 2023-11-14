<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Internado.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
          <link rel="stylesheet" href="~/css/loginn.css"/>
          <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous"/>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCu4An09CCaQwzQ_xJJptpjqFRGg781E_8&libraries=places"></script>

</head>
<body style="background:white;">
    <section id="inicio" >
        <header style="background-color: #990040">
            <h1 class="title" style="color:white"></h1>
        </header>
    </section>


    <section>
          <div class="login-box">
        <div class="left-side">
            <img src="Images/logo.png" alt="Descripción de la imagen" class="logo" />
        </div> 
        <div class="right-side">
              <button id="showFormButton" class="form-control btnLoginn">Iniciar Sesion</button>

                     <div class="col-md-8">
                <div id="map" style="width: 350px; height: 400px; margin-top:20px"></div>
                <script>
                    var map;
                    var marker;

                    function initMap() {
                        var cochabambaLatLng = { lat: -17.3895, lng: -66.1568 };

                        var mapOptions = {
                            center: cochabambaLatLng,
                            zoom: 15
                        };
                        map = new google.maps.Map(document.getElementById('map'), mapOptions);
                        // Agregar el evento de clic fuera de la función initMap
                        google.maps.event.addListener(map, 'click', function (event) {
                            if (marker) {
                                marker.setMap(null); // Eliminar el marcador anterior
                            }
                            var location = event.latLng;
                            marker = new google.maps.Marker({
                                position: location,
                                map: map,
                                title: 'Mi Marcador'
                            });
                            /*var latitudeInput = document.getElementById('txtLatitude');
                            var longitudeInput = document.getElementById('txtLongitude');

                            latitudeInput.value = location.lat();
                            longitudeInput.value = location.lng();

                            var getLatitude = latitudeInput.value;
                            var getLongitude = longitudeInput.value;*/



                        });
                    }
                </script>
                <script>
                    google.maps.event.addDomListener(window, 'load', initMap);
                </script>
         </div>


            <div class="login-box2">
                <h2>Iniciar Sesión</h2>
                <form runat="server" class="formLogin">
                    <div class="mb-3">
                        <asp:TextBox runat="server" ID="txtUserName" placeholder="Usuario" required="" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" placeholder="Contraseña" required="" CssClass="form-control" />
                    </div>
                        <asp:Button ID="btnLoginn" runat="server" Text="Ingresar" OnClick="btnLoginn_Click" CssClass="form-control" style="background:white; color:#990040;" />
                        <p class="message">¿Olvido contraseña <a href="ForgetPassword.aspx" class="link">Olvido</a></p>
                    <asp:Label Text="" ID="lblInfo" runat="server" CssClass="text-danger" />
            </form>
            </div>
        </div>
        </div>
    </section>

    <script>
        document.addEventListener("DOMContentLoaded", function (event) {
            const showFormButton = document.getElementById('showFormButton');
            const loginBox2 = document.querySelector('.login-box2');

            // Ocultar el formulario inicialmente
            loginBox2.style.display = 'none';

            showFormButton.addEventListener('click', function () {
                loginBox2.style.display = (loginBox2.style.display === 'none' ? 'flex' : 'none');
            });
        });
    </script>

</body>
</html>
