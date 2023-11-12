<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Internado.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <canvas id="myChart" width="100" height="100" ></canvas>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
    <script>
        document.addEventListener('DOMContentLoaded', function () {
            // Datos para el gráfico
            var data = {
                labels: ['Interino', 'Doctor', 'Hospital'],
                datasets: [{
                    data: [30, 50, 20],
                    backgroundColor: [
                        'rgba(255, 99, 132, 0.5)',
                        'rgba(54, 162, 235, 0.5)',
                        'rgba(255, 206, 86, 0.5)'
                    ],
                    borderColor: [
                        'rgba(255, 99, 132, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)'
                    ],
                    borderWidth: 5
                }]
            };

            // Configuración del gráfico
            var config = {
                type: 'pie',
                data: data,
                options: {
                    responsive: true,
                    plugins: {
                        legend: {
                            position: 'top',
                        },
                        title: {
                            display: true,
                            size: 50,
                            text: 'Grafico GENERAL'
                        }
                    }
                },
            };

            // Obtén el contexto del lienzo
            var ctx = document.getElementById('myChart').getContext('2d');

            // Crea el gráfico con Chart.js
            var myChart = new Chart(ctx, config);
        });
    </script>

</asp:Content>
