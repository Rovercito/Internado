<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Internado.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cambiar Contraña</title>
     <link rel="stylesheet" href="~/css/users.css"/>
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous"/>
</head>
<body style="background:white;">
    <section id="inicio" >
        <header style="background-color: #990040">
            <h1 class="title" style="color:white"></h1>
        </header>
    </section>


    <section>
        <div class="login-box" style="background-color:#990040" >
            <h2 style="color:black">Cambiar Contraseña</h2>
           <form id="formLogin" runat="server">
                <div class="mb-3">
                    <asp:TextBox runat="server" ID="txtNewPassword" placeholder="Password" TextMode="Password" required="" CssClass="form-control" />
                </div>
               <div class="mb-3 text-center">
                    <div id="passwordMessage" class="text-muted">
                        Seguridad de la contraseña:
                        Utiliza 8 caracteres como mínimo. No utilices una contraseña de otro sitio ni un término que sea demasiado obvio, como el nombre de tu mascota.
                    </div>
                </div>
                <div class="mb-3">
                    <asp:TextBox runat="server" ID="txtConfirmNewPassword" TextMode="Password" placeholder="Contraseña" required="" CssClass="form-control" />
                </div>
                <asp:Button ID="btnChangePassword" runat="server" Text="Cambiar Contraseña" OnClick="btnChangePassword_Click" CssClass="form-control" style="background:white; color:#990040;" />
                <asp:Label Text="" ID="lblInfo" runat="server" CssClass="text-danger" />
            </form>


        </div>
    </section>
</body>
</html>
