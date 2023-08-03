<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TotalEarning.aspx.cs" Inherits="smarthr_pay.TotalEarning" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%">
        <div class="filter" style="width: 100%; height: 36px; display: flex; justify-content: center; align-items: center;">
            <span style="display: inline-block; margin-right: 10px; font-size: 16px; width: 10%">Type:</span>
            <select id="filterSelect" style="display: inline-block; width: 50%; height: 50px" onclick="updateChart()">
                <option value="Select">Select</option>
                <option value="shareholder">Shareholder</option>
                <option value="gender">Gender</option>
                <option value="ethnicity">Ethnicity</option>
                <option value="category">Category</option>

            </select>
        </div>



        <div style="margin-top: 12px">
            <canvas id="genderChart" style="display: none;"></canvas>
            <canvas id="ethChart" style="display: none;"></canvas>
            <canvas id="shareholderChart" style="display: none;"></canvas>
            <canvas id="categoryChart" style="display: none;"></canvas>
        </div>

        <div class="gridview-container">
            <style>
                .gridview-container {
                    margin: 20px 8px;
                }

                .gridview {
                    table-layout: fixed;
                    width: 100%;
                }
            </style>

            <asp:GridView ID="GridView1" runat="server" CssClass="gridview" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Employee ID" DataField="Employee_ID" ItemStyle-Width="200px" />
                    <asp:BoundField HeaderText="First Name" DataField="First_Name" ItemStyle-Width="200px" />
                    <asp:BoundField HeaderText="Last Name" DataField="Last_Name" ItemStyle-Width="200px" />
                    <asp:BoundField HeaderText="Gender" DataField="Gender" ItemStyle-Width="200px" />
                    <asp:BoundField HeaderText="Ethnicity" DataField="Ethnicity" ItemStyle-Width="200px" />
                    <asp:BoundField HeaderText="Department" DataField="Department" ItemStyle-Width="300px" />
                    <asp:BoundField HeaderText="Job Category" DataField="Job_Category" ItemStyle-Width="200px" />
                    <asp:BoundField HeaderText="Pay Rate" DataField="Pay_Rate" ItemStyle-Width="200px" />
                    <asp:BoundField HeaderText="Paid To Date" DataField="Paid_To_Date" ItemStyle-Width="200px" />
                    <asp:BoundField HeaderText="Paid Last Year" DataField="Paid_Last_Year" ItemStyle-Width="200px" />
                    <asp:BoundField HeaderText="Pay Amount" DataField="Pay_Amount" ItemStyle-Width="300px" />
                    <asp:BoundField HeaderText="Tax Percentage" DataField="Tax_Percentage" ItemStyle-Width="200px" />
                    <asp:BoundField HeaderText="Total Salary" DataField="Total_Salary" ItemStyle-Width="200px" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <script>
        var totalSalaryLastYearbyMan = <%= totalSalaryLastYearbyMan %>;
        var totalSalaryToYearbyMan = <%= totalSalaryToYearbyMan %>;
        var totalSalaryLastYearbyWoman = <%= totalSalaryLastYearbyWoman %>;
        var totalSalaryToYearbyWoman = <%= totalSalaryToYearbyWoman %>;

        var totalSalaryLastYearbyStackhoder =  <%= totalSalaryLastYearbyStackhoder %>;
        var totalSalaryToYearbyStackhoder =  <%= totalSalaryToYearbyStackhoder %>;

        var totalSalaryLastYearbyKinh = <%= totalSalaryLastYearbyKinh %>;
        var totalSalaryToYearbyKinh = <%= totalSalaryToYearbyKinh %>;

        var totalSalaryLastYearbyHoa = <%= totalSalaryLastYearbyHoa %>;
        var totalSalaryToYearbyHoa =  <%= totalSalaryToYearbyHoa %>;

        var totalSalaryLastYearbyFullTime = <%= totalSalaryLastYearbyFullTime %>;
        var totalSalaryToYearbyFullTime = <%= totalSalaryToYearbyFullTime %>;

        var totalSalaryLastYearbyPastTime = <%= totalSalaryLastYearbyPastTime %>;
        var totalSalaryToYearbyPastTime = <%= totalSalaryToYearbyPastTime %>;
        var genderChart = false;
        var ethChart = false;
        var shareholderChart = false;
        var categoryChart = false;

        function createGenderChart() {
            var ctx = document.getElementById('genderChart').getContext('2d');

            // Khởi tạo biểu đồ cột
            gender = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: ['Last Year by Man', 'To Year by Man', 'Last Year by Woman', 'To Year by Woman'],
                    datasets: [{
                        label: 'Total Salary',

                        data: [
                            totalSalaryLastYearbyMan,
                            totalSalaryToYearbyMan,
                            totalSalaryLastYearbyWoman,
                            totalSalaryToYearbyWoman
                        ],
                        backgroundColor: [
                            'rgba(255, 99, 132, 0.2)', // Màu cột thứ nhất
                            'rgba(255, 99, 132, 0.2)', // Màu cột thứ hai
                            'rgba(75, 192, 192, 1)', // Màu cột thứ ba
                            'rgba(75, 192, 192, 1)' // Màu cột thứ tư
                        ],
                        borderColor: [
                            'rgba(255, 99, 132, 1)', // Màu viền cột thứ nhất
                            'rgba(255, 99, 132, 1)', // Màu viền cột thứ hai
                            'rgba(75, 192, 192, 1)', // Màu viền cột thứ ba
                            'rgba(75, 192, 192, 1)' // Màu viền cột thứ tư
                        ],
                        borderWidth: 1
                    }]
                },
                options: {
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    }
                }
            });
        }

        function createEthChart() {
            var ctx = document.getElementById('ethChart').getContext('2d');

            // Khởi tạo biểu đồ cột
            gender = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: ['Last Year by Kinh', 'To Year by Kinh', 'Last Year by Hoa', 'To Year by Hoa'],
                    datasets: [{
                        label: 'Total Salary',
                        data: [
                            totalSalaryLastYearbyKinh,
                            totalSalaryToYearbyKinh,
                            totalSalaryLastYearbyHoa,
                            totalSalaryToYearbyHoa
                        ],
                        backgroundColor: [
                            'rgba(255, 99, 132, 0.2)', // Màu cột thứ nhất
                            'rgba(255, 99, 132, 0.2)', // Màu cột thứ hai
                            'rgba(75, 192, 192, 1)', // Màu cột thứ ba
                            'rgba(75, 192, 192, 1)' // Màu cột thứ tư
                        ],
                        borderColor: [
                            'rgba(255, 99, 132, 1)', // Màu viền cột thứ nhất
                            'rgba(255, 99, 132, 1)', // Màu viền cột thứ hai
                            'rgba(75, 192, 192, 1)', // Màu viền cột thứ ba
                            'rgba(75, 192, 192, 1)' // Màu viền cột thứ tư
                        ],
                        borderWidth: 1
                    }]
                },
                options: {
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    }
                }
            });

        }
        function createShareholderChart() {
            var ctx = document.getElementById('shareholderChart').getContext('2d');

            // Khởi tạo biểu đồ cột
            gender = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: ['Last Year by Shareholder', 'To Year by Shareholder'],
                    datasets: [{
                        label: 'Total Salary',
                        data: [
                            totalSalaryLastYearbyStackhoder,
                            totalSalaryToYearbyStackhoder,

                        ],
                        backgroundColor: [
                            'rgba(255, 99, 132, 0.2)', // Màu cột thứ nhất
                            'rgba(255, 99, 132, 0.2)', // Màu cột thứ hai

                        ],
                        borderColor: [
                            'rgba(255, 99, 132, 1)', // Màu viền cột thứ nhất
                            'rgba(255, 99, 132, 1)', // Màu viền cột thứ hai

                        ],
                        borderWidth: 1
                    }]
                },
                options: {
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    }
                }
            });
        }
        function createCategoryChart() {
            var ctx = document.getElementById('categoryChart').getContext('2d');

            // Khởi tạo biểu đồ cột
            gender = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: ['Last Year by Full Time', 'To Year by Full Time', 'Last Year by Part Time', 'To Year by Part Time'],
                    datasets: [{
                        label: 'Total Salary',
                        data: [
                            totalSalaryLastYearbyFullTime,
                            totalSalaryToYearbyFullTime,
                            totalSalaryLastYearbyPastTime,
                            totalSalaryToYearbyPastTime
                        ],
                        backgroundColor: [
                            'rgba(255, 99, 132, 0.2)', // Màu cột thứ nhất
                            'rgba(255, 99, 132, 0.2)', // Màu cột thứ hai
                            'rgba(75, 192, 192, 1)', // Màu cột thứ ba
                            'rgba(75, 192, 192, 1)' // Màu cột thứ tư
                        ],
                        borderColor: [
                            'rgba(255, 99, 132, 1)', // Màu viền cột thứ nhất
                            'rgba(255, 99, 132, 1)', // Màu viền cột thứ hai
                            'rgba(75, 192, 192, 1)', // Màu viền cột thứ ba
                            'rgba(75, 192, 192, 1)' // Màu viền cột thứ tư
                        ],
                        borderWidth: 1
                    }]
                },
                options: {
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    }
                }
            });
        }



        function updateChart() {
            var filterSelect = document.getElementById("filterSelect");
            var selectedOption = filterSelect.value;


            if (selectedOption === "gender") {
                createGenderChart();
                document.getElementById('genderChart').style.display = 'block';
                document.getElementById('ethChart').style.display = 'none';
                document.getElementById('shareholderChart').style.display = 'none';
                document.getElementById('categoryChart').style.display = 'none';
            }
            if (selectedOption === "ethnicity") {
                createEthChart();
                document.getElementById('genderChart').style.display = 'none';
                document.getElementById('ethChart').style.display = 'block';
                document.getElementById('shareholderChart').style.display = 'none';
                document.getElementById('categoryChart').style.display = 'none';
            }
            if (selectedOption === "shareholder") {
                createShareholderChart();
                document.getElementById('genderChart').style.display = 'none';
                document.getElementById('ethChart').style.display = 'none';
                document.getElementById('shareholderChart').style.display = 'block';
                document.getElementById('categoryChart').style.display = 'none';
            }
            if (selectedOption === "category") {
                createCategoryChart();
                document.getElementById('genderChart').style.display = 'none';
                document.getElementById('ethChart').style.display = 'none';
                document.getElementById('shareholderChart').style.display = 'none';
                document.getElementById('categoryChart').style.display = 'block';
            }
        }

    </script>


</asp:Content>
