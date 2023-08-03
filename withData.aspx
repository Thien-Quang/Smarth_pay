<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="withData.aspx.cs" Inherits="smarthr_pay.withData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            padding: 20px;
        }

        .form-container {
            background-color: #ffffff;
            border: 1px solid #dddddd;
            padding: 20px;
            width: 900px;
            margin: 0 auto;
            display: flex;
            flex-wrap: wrap;
            justify-content: space-between;
        }


        .form-group {
            flex-basis: calc(50% - 10px);
        }

        .form-actions {
            text-align: center;
            margin-top: 20px;
        }

        .form-container h2 {
            text-align: center;
        }

        .form-container .form-group {
            margin-bottom: 10px;
        }

            .form-container .form-group label {
                display: inline-block;
                width: 120px;
                font-weight: bold;
            }

            .form-container .form-group input {
                width: 200px;
                padding: 5px;
            }

        .form-container .form-actions {
            text-align: center;
            margin-top: 20px;
        }

            .form-container .form-actions button {
                padding: 10px 20px;
                font-weight: bold;
            }

        .employee-table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

            .employee-table th,
            .employee-table td {
                padding: 10px;
                border: 1px solid #dddddd;
            }

            .employee-table th {
                background-color: #f4f4f4;
                font-weight: bold;
            }

            .employee-table td {
                text-align: center;
            }
    </style>
    </head>
    <body>

        <div style="display: flex; justify-content: center; align-items: center">
            <h2>Employee </h2>
        </div>
        <div class="form-container">
            <form id="employee-form">

                <div class="form-group">
                    <label for="employee-id">Employee ID:</label>
                    <asp:TextBox ID="Employeeid" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="first-name">First Name:</label>
                    <asp:TextBox ID="Firstname" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="last-name">Last Name:</label>
                    <asp:TextBox ID="Lastname" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="Middle-initial">Middle Initial:</label>
                    <asp:TextBox ID="Middleinitial" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="Address1">Address 1:</label>
                    <asp:TextBox ID="Address1" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="Address2">Address 2:</label>
                    <asp:TextBox ID="Address2" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="city">City :</label>
                    <asp:TextBox ID="City" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="state">State:</label>
                    <asp:TextBox ID="State" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="zip">Zip :</label>
                    <asp:TextBox ID="Zip" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="email">Email :</label>
                    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="phoneNumber">Phone Number :</label>
                    <asp:TextBox ID="PhoneNumber1" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="SocialSecurityNumber">Social Security Number :</label>
                    <asp:TextBox ID="SocialSecurityNumber" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="Drivers_License">Drivers License :</label>
                    <asp:TextBox ID="DriversLicenses" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="Marital_Status">Marital Status:</label>
                    <asp:TextBox ID="MaritalStatus" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="gender1">Gender:</label>
                    <asp:TextBox ID="Gender1" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="Sharegolder_Status">Shareholder Status :</label>
                    <asp:TextBox ID="Sharegolder_Status" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="Benefit_Plans">Benefit Plans:</label>
                    <asp:TextBox ID="BenefitPlanse" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="Ethnicity">Ethnicity:</label>
                    <asp:TextBox ID="Ethnicity" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="SSN">Pay SSN:</label>
                    <asp:TextBox ID="SSN" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="pay-rate">Pay Rate:</label>
                    <asp:TextBox ID="Payrate" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="payrates_id">Pay Rates ID:</label>
                    <asp:TextBox ID="Payrates_id" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="Vacation_Days">Vacation Day:</label>
                    <asp:TextBox ID="Vacation_Day" runat="server"></asp:TextBox>
                </div>
                 <div class="form-group">
                    <label for="Paid_To_Date">Paid To Date:</label>
                    <asp:TextBox ID="PaidToDate" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="Paid_Last_Year">Paid Last Year:</label>
                    <asp:TextBox ID="PaidLastYear" runat="server"></asp:TextBox>
                </div>

                <div class="form-actions">
                    <style>
                        .form-actions {
                            width: 100%;
                            display: grid;
                            grid-template-columns: repeat(3, 1fr);
                            grid-gap: 10px;
                            justify-content: center;
                            margin-top: 20px;
                        }

                            btnAdd {
                                padding: 10px 10px;
                                margin: 0 30px;
                                font-weight: bold;
                            }
                    </style>
                   <asp:Button  ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                   <asp:Button  ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                   <asp:Button  ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />

                </div>
                  
            </form>
            <div>
    <asp:Label ID="Label1" runat="server"></asp:Label>
    <asp:Label ID="Label2" runat="server"></asp:Label>
</div>
        </div>
</asp:Content>
