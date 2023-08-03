using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;

namespace smarthr_pay
{
    public partial class TotalEarning : System.Web.UI.Page
    {
        SQLuse sql = new SQLuse();
        MySQLuse mysql = new MySQLuse();



        protected decimal totalSalaryLastYearbyMan =0;
        protected decimal totalSalaryToYearbyMan = 0;

        protected decimal totalSalaryLastYearbyWoman = 0;
        protected decimal totalSalaryToYearbyWoman = 0;

        protected decimal totalSalaryLastYearbyStackhoder = 0;
        protected decimal totalSalaryToYearbyStackhoder = 0;

        protected decimal totalSalaryLastYearbyKinh = 0;
        protected decimal totalSalaryToYearbyKinh = 0;

        protected decimal totalSalaryLastYearbyHoa = 0;
        protected decimal totalSalaryToYearbyHoa = 0;

        protected decimal totalSalaryLastYearbyFullTime = 0;
        protected decimal totalSalaryToYearbyFullTime = 0;

        protected decimal totalSalaryLastYearbyPastTime = 0;
        protected decimal totalSalaryToYearbyPastTime = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            
             string sqlQuery = "SELECT p.Employee_ID, p.First_Name,p.Last_Name, p.Gender,p.Shareholder_Status, p.Ethnicity , j.Department, j.Job_Category " +
                               "FROM Personal p " +
                               "JOIN Job_History j ON p.Employee_ID = j.Employee_ID";        

            string mysqlQuery = "SELECT e.Employee_Number, e.Pay_Rate, e.Paid_To_Date, e.Paid_Last_Year, pr.Pay_Amount, pr.Tax_Percentage " +
                            "FROM Employee e " +
                            "JOIN pay_rates pr ON e.PayRates_id = pr.idPay_Rates";
            

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Employee_ID");
            dataTable.Columns.Add("First_Name");
            dataTable.Columns.Add("Last_Name");
            dataTable.Columns.Add("Gender");
            dataTable.Columns.Add("Shareholder_Status");
            dataTable.Columns.Add("Ethnicity");
            dataTable.Columns.Add("Department");
            dataTable.Columns.Add("Job_Category");
            dataTable.Columns.Add("Pay_Rate");
            dataTable.Columns.Add("Paid_To_Date");
            dataTable.Columns.Add("Paid_Last_Year");
            dataTable.Columns.Add("Pay_Amount");
            dataTable.Columns.Add("Tax_Percentage");
            dataTable.Columns.Add("Total_Salary", typeof(decimal));

            
            // Lấy dữ liệu từ nguồn thứ nhất
            DataTable sqlData = sql.LoadDL(sqlQuery);
            DataTable mysqlData = mysql.LoadDL(mysqlQuery);
            int rowCount = Math.Max(sqlData.Rows.Count, mysqlData.Rows.Count);

            for (int i = 0; i < rowCount; i++)
            {
                int gender1 = 0;
                int shareholder = 0;
                string Ethnicity = "";
                String category = "";

                DataRow newRow = dataTable.NewRow();

                if (i < sqlData.Rows.Count)
                {
                    DataRow sqlRow = sqlData.Rows[i];
                    newRow["Employee_ID"] = sqlRow["Employee_ID"];
                    newRow["First_Name"] = sqlRow["First_Name"];
                    newRow["Last_Name"] = sqlRow["Last_Name"];

                    if ((bool)sqlRow["Gender"] == false)
                    {
                        newRow["Gender"] = "Female";
                    }
                    else
                    {
                        newRow["Gender"] = "Male";
                        gender1 = 1;

                    }
                    if((bool)sqlRow["Shareholder_Status"] == true)
                    {
                        newRow["Shareholder_Status"] = "Yes" ;
                        shareholder = 1;
                    }
                    else sqlRow["Shareholder_Status"] = "No";

                    newRow["Ethnicity"] = Ethnicity= (string) sqlRow["Ethnicity"];
                   

                    newRow["Department"] = sqlRow["Department"];

                    newRow["Job_Category"] =category= (string) sqlRow["Job_Category"];
                }

                if (i < mysqlData.Rows.Count)
                {
                    DataRow mysqlRow = mysqlData.Rows[i];
                    newRow["Pay_Rate"] = mysqlRow["Pay_Rate"];
                    newRow["Paid_To_Date"] = mysqlRow["Paid_To_Date"];
                    newRow["Paid_Last_Year"] = mysqlRow["Paid_Last_Year"];
                    newRow["Pay_Amount"] = mysqlRow["Pay_Amount"];
                    newRow["Tax_Percentage"] = mysqlRow["Tax_Percentage"];
                }
                decimal totalSalary1 = Convert.ToDecimal(newRow["Pay_Amount"]) * (Convert.ToDecimal(newRow["Pay_Rate"]) - Convert.ToDecimal(newRow["Tax_Percentage"]));
                newRow["Total_Salary"] = totalSalary1;

                //Kiểm tra có phải là cổ đông không
                if(shareholder==1)
                {
                    totalSalaryLastYearbyStackhoder += Convert.ToDecimal(newRow["Paid_Last_Year"]);
                    totalSalaryToYearbyStackhoder += totalSalary1;
                }

                // Kiểm tra giới tính và hiển thị thông tin tương ứng
                if (gender1 == 1)
                {
                    totalSalaryLastYearbyMan += Convert.ToDecimal(newRow["Paid_Last_Year"]);
                    totalSalaryToYearbyMan += totalSalary1;
                } 
                else
                {
                    totalSalaryLastYearbyWoman += Convert.ToDecimal(newRow["Paid_Last_Year"]);
                    totalSalaryToYearbyWoman += totalSalary1;
                }
                //kiểm tra dân tộc

                if(Ethnicity == "Kinh")
                {
                    totalSalaryLastYearbyKinh += Convert.ToDecimal(newRow["Paid_Last_Year"]);
                    totalSalaryToYearbyKinh += totalSalary1;
                }
                else
                {
                    totalSalaryLastYearbyHoa += Convert.ToDecimal(newRow["Paid_Last_Year"]);
                    totalSalaryToYearbyHoa += totalSalary1;
                }

                // kiểm tra tính toán category
                if (category == "Full Time")
                {
                    totalSalaryLastYearbyFullTime += Convert.ToDecimal(newRow["Paid_Last_Year"]);
                    totalSalaryToYearbyFullTime += totalSalary1;
                }
                else
                {
                    totalSalaryLastYearbyPastTime += Convert.ToDecimal(newRow["Paid_Last_Year"]);
                    totalSalaryToYearbyPastTime += totalSalary1;
                }


                dataTable.Rows.Add(newRow);
            }


            GridView1.DataSource = dataTable;
            GridView1.DataBind();

             
        }
    }

}