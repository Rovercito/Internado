<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Internado.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">

    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
    
    <div class="row">
        <div class="chart-container col-md-4">
            <canvas id="myChart" width="400" height="400"></canvas>
        </div>
        <div class="chart-container col-md-4">
            <canvas id="myChart1" width="400" height="400"></canvas>
        </div>
        <div class="chart-container col-md-4">
            <canvas id="myChart2" width="400" height="400"></canvas>
        </div>
    </div>
    

  
        <script>
            document.addEventListener('DOMContentLoaded', function () {
                
                var data = <%= CargarDatosGrafico() %>;

                var config = {
                    type: 'doughnut',
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
                                text: 'Filtro Doctor'
                            }
                        },
                        cutout: 50,
                    },
                };

                var ctx = document.getElementById('myChart').getContext('2d');

                document.getElementById('myChart').style.width = '100%';
                document.getElementById('myChart').style.height = 'auto';

                var myChart = new Chart(ctx, config);

            });


            document.addEventListener('DOMContentLoaded', function () {

                var data1 = <%= CargarDatosGrafico() %>;

                var config1 = {
                    type: 'doughnut',
                    data: data1,
                    options: {
                        responsive: true,
                        plugins: {
                            legend: {
                                position: 'top',
                            },
                            title: {
                                display: true,
                                size: 50,
                                text: 'Gráfica General'
                            }
                        },
                        cutout: 50,
                    },
                };

                var ctx1 = document.getElementById('myChart1').getContext('2d');

                document.getElementById('myChart1').style.width = '100%';
                document.getElementById('myChart1').style.height = 'auto';

                var myChart1 = new Chart(ctx1, config1);

            });

            document.addEventListener('DOMContentLoaded', function () {

                var data2 = <%= CargarDatosHospital() %>;

                var config2 = {
                    type: 'doughnut',
                    data: data2,
                    options: {
                        responsive: true,
                        plugins: {
                            legend: {
                                position: 'top',
                            },
                            title: {
                                display: true,
                                size: 50,
                                text: 'Gráfica Hospital'
                            }
                        },
                        cutout: 50,
                    },
                };

                var ctx2 = document.getElementById('myChart2').getContext('2d');

                document.getElementById('myChart2').style.width = '100%';
                document.getElementById('myChart2').style.height = 'auto';

                var myChart2 = new Chart(ctx2, config2);

            });

           
        </script>

    <style>
        .chart-container{
            flex: 1;
        width: 400px;
        height: 400px;
        margin-right: 10px;
        }
    </style>
</asp:Content>
