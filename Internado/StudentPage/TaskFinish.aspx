<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskFinish.aspx.cs" Inherits="Internado.StudentPage.TaskFinish" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%= Page.Title %> - Internado</title>
    <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="~/css/site.css" />
    <link rel="stylesheet" href="~/Internado.styles.css"/>
     <link rel="stylesheet" href="~/css/box.css"/>
  <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
      <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.6/font/material-design-icons/Material-Design-Icons.woff'% />
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCu4An09CCaQwzQ_xJJptpjqFRGg781E_8&libraries=places"></script>

</head>
<body style="background:#D6A8A8">
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
                       
                    </div>
                    <div class="user-profile" style="position: relative; top: 20px; right: 20px;">
                        <div style="margin-left: 50px">
                            <img src="/Images/user.png" alt="Imagen de perfil" width="40" height="40" />
                        </div>
                        <div style="margin-bottom: 30px">
                            <span class="user-name" id="username" style="color: white">Nombre de usuario</span>
                        </div>
                    </div>
                </div>
            </nav>
        </header>
       <section id="inicio" >
        <header style="background-color: #D6A8A8">
            <h1 class="title" style="color:white"></h1>
        </header>
    </section>


    <section>
        <div class="login-box" style="background-color:#D9D9D9" >
            <h2 style="color:black">Comentarios</h2>
                <div class="container">
                    <asp:Panel runat="server" CssClass="comment-panel">
                        <div class="form-group">
                            <asp:TextBox ID="txtComment" runat="server" CssClass="form-control txt" TextMode="MultiLine" Rows="5" placeholder="Escribe tu comentario"></asp:TextBox>
                        </div>
        
                        <div class="form-group">
                            <label for="fileImage">Sube una imagen:</label>
                            <asp:FileUpload ID="fileImage" runat="server" CssClass="form-control-file"/>
                        </div>
        
                        <div class="form-group">
                            <label for="fileAttachment">Sube un archivo:</label>
                            <asp:FileUpload ID="fileAttachment" runat="server" CssClass="form-control-file"/>
                        </div>
        
                        <div class="text-center">
                            <asp:Button ID="btnCancel" runat="server" Text="Cancelar" CssClass="btn btn-danger btn-custom" OnClick="btnCancel_Click"/>
                            <asp:Button ID="btnDone" runat="server" Text="Subir" CssClass="btn btn-success btn-custom" OnClick="btnDone_Click"/>
                        </div>
                    </asp:Panel>
                </div>



        </div>
    </section>
    </form>
    <footer class="border-top footer text-muted" style="background: #990040; position: fixed; bottom: 0; width: 100%;">
        <div class="container">
            &copy; <%= DateTime.Now.Year %> - Internados
        </div>
    </footer>

    <script src="/lib/jquery/dist/jquery.min.js"></script>
    <script src="/lib/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
    <script src="/js/site.js"></script>
         <script src='https://code.jquery.com/jquery-2.2.4.min.js'></script>
<script src='https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.6/js/materialize.min.js'></script><script  src="js/script.js"></script>

   
</body>
</html>