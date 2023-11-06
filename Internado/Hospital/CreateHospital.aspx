<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="CreateHospital.aspx.cs" Inherits="Internado.Hospital.CreateHospital" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Registro</h1>

    <h1>Create</h1>

<h4>Hospital</h4>
<hr />
 <div class="row">
     <div class="col-md-4">
         <div class="form-group">
             <asp:Label ID="lblNameHospital" runat="server" AssociatedControlID="txtNameHospital">Nombre del Hospital</asp:Label>
             <asp:TextBox ID="txtNameHospital" runat="server" CssClass="form-control"></asp:TextBox>
         </div>


         <div class="form-group">
             <asp:Label ID="lblLatitude" runat="server" AssociatedControlID="txtLatitude">Latitud</asp:Label>
             <asp:TextBox ID="txtLatitude" ReadOnly="false"   ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
         </div>
         <div class="form-group">
             <asp:Label ID="lblLongitude" runat="server" AssociatedControlID="txtLongitude">Longitud</asp:Label>
             <asp:TextBox ID="txtLongitude" ReadOnly="false"   ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
         </div>
         <asp:HiddenField ID="latitudHiddenField" runat="server" />
         <asp:HiddenField ID="longitudHiddenField" runat="server" />



         <div class="form-group">
             <asp:Label ID="lblPhone" runat="server" AssociatedControlID="txtPhone">Teléfono</asp:Label>
             <asp:TextBox ID="txtPhone"  runat="server" CssClass="form-control"></asp:TextBox>
         </div>
         <div class="form-group">
             <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail">Email</asp:Label>
             <asp:TextBox ID="txtEmail"  runat="server" CssClass="form-control"></asp:TextBox>
         </div>
         <div class="form-group">
             <asp:Label ID="lblDescription" runat="server" AssociatedControlID="txtDescription">Descripcion</asp:Label>
             <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
         </div>
         <div class="col-md-8">
                <div id="map" style="width: 100%; height: 400px;"></div>
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
                            var latitudeInput = document.getElementById('txtLatitude');
                            var longitudeInput = document.getElementById('txtLongitude');

                            latitudeInput.value = location.lat();
                            longitudeInput.value = location.lng();

                            var getLatitude = latitudeInput.value;
                            var getLongitude = longitudeInput.value;

                            document.getElementById('<%= latitudHiddenField.ClientID %>').value = getLatitude;
                            document.getElementById('<%= longitudHiddenField.ClientID %>').value = getLongitude;


                        });
                    }
                </script>
                <script>
                    google.maps.event.addDomListener(window, 'load', initMap);
                </script>
         </div>

         <div class="form-group">
             <asp:Button ID="btnCreate" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="btnCreate_Click" />
         </div>
     </div>
 </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
