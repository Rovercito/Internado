<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompletedTasks.aspx.cs" Inherits="Internado.StudentPage.CompletedTasks" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%= Page.Title %> - Internado</title>
    <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="~/css/site.css" />
    <link rel="stylesheet" href="~/Internado.styles.css"/>
  <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
      <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.6/font/material-design-icons/Material-Design-Icons.woff'% />
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCu4An09CCaQwzQ_xJJptpjqFRGg781E_8&libraries=places"></script>

</head>
<body>
    <form id="form1" runat="server">
        <header>
            <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light border-bottom box-shadow mb-3" style="background: #990040">
                <div class="container-fluid">
                    <a class="navbar-brand" href="/Home/Index"><img src="/Images/logo.png" width="80" height="80" /></a>
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target=".navbar-collapse" aria-controls="navbarSupportedContent"
                        aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="justify-content-between">
                       <ul class="navbar-nav flex-grow-1">
                            <li class="nav-item">
                                <a class="nav-link text-white" style="font-size:x-large; text-align: center" href="CompletedTasks.aspx">Tareas<br /> Completadas</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link text-white" style="font-size:x-large; text-align: center" href="StudentPage.aspx">Tareas<br /> Asignadas</a>
                            </li>
                        </ul>
                    </div>
                    <div class="user-profile" style="position: relative; top: 20px; right: 20px;">
                        <div style="margin-bottom: 30px; display: inline-block">
                            <asp:Label runat="server" ID="lblUsername" class="user-name" style="color: white; display: inline-block"></asp:Label>
                            <div style="display: inline-block; vertical-align: middle;">
                                <div class="status-circle"></div>
                            </div>
                            <select id="userMenu" class="btn btn-link  white-menu"  onchange ="handleMenuChange(this)" style="display: inline-block">
                                <option value="MenuIcon">&nbsp;☰ Menu</option>
                                <option value="CambiarContrasena">Cambiar Contraseña</option>
                                <option value="CerrarSesion">Cerrar Sesión</option>
                            </select>
 
                        </div>
                    </div>
                </div>
            </nav>
        </header>
      
        <asp:Literal ID="LiteralTable" runat="server"></asp:Literal>
    </form>
    <footer class="border-top footer text-muted" style="background: #990040; position: fixed; bottom: 0; width: 100%;">
        <div class="container">
            &copy; <%= DateTime.Now.Year %> - Internados
        </div>
    </footer>


    <style>
     .white-menu {
         background-color: transparent;
         color: white; 
     }
 
     .status-circle {
         width: 25px;
         height: 25px;
         background-color: green;
         border-radius: 50%;
         margin-left: 7px;
         display: inline-block;
         vertical-align: middle;
     }
     .user-name {
         margin-right: 5px;
     }
    </style>

    <script>
         function handleMenuChange(selectElement) {
             var selectedValue = selectElement.value;
 
             switch (selectedValue) {
                 case "CambiarContrasena":
                     window.location.href = '<%= ResolveUrl("~/ChangePassword.aspx") %>';
                 break;
 
             case "CerrarSesion":
                 window.location.href = '<%= ResolveUrl("~/Logout.aspx") %>';
                     break;
 
                 // Otros casos según sea necesario
 
                 default:
                     // Manejar el valor por defecto si es necesario
                     break;
             }
         }
    </script>



    <script src="/lib/jquery/dist/jquery.min.js"></script>
    <script src="/lib/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
    <script src="/js/site.js"></script>
         <script src='https://code.jquery.com/jquery-2.2.4.min.js'></script>
<script src='https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.6/js/materialize.min.js'></script><script  src="js/script.js"></script>

   
</body>
</html>
