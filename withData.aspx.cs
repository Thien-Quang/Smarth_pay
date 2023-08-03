using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;

namespace smarthr_pay
{
    public partial class withData : System.Web.UI.Page
    {


        string connectionString = @"Data Source=DESKTOP-M12R4KO;Initial Catalog=HR;Integrated Security=True";
        string myconnectionString = "server=127.0.0.1;port=3306;user id=root;password=Vancodocton.2402;database=payroll";
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string employeeID = Employeeid.Text;
            string firstName = Firstname.Text;
            string lastName = Lastname.Text;
            string middleInitial = Middleinitial.Text;
            string address1 = Address1.Text;
            string address2 = Address2.Text;
            string city = City.Text;
            string state = State.Text;
            string zip = Zip.Text;
            string email = Email.Text;
            string phoneNumber = PhoneNumber1.Text;
            string socialSecurityNumber = SocialSecurityNumber.Text;
            string driversLicense = DriversLicenses.Text;
            string maritalStatus = MaritalStatus.Text;
            string gender = Gender1.Text;
            string shareholderStatus = Sharegolder_Status.Text;
            string benefitPlans = BenefitPlanse.Text;
            string ethnicity = Ethnicity.Text;
            string paySSN = SSN.Text;
            string payRate = Payrate.Text;
            string payratesID = Payrates_id.Text;
            string vacationDays = Vacation_Day.Text;
            string paidLastYear = PaidLastYear.Text;
            string paidToDate = PaidToDate.Text;



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Personal  (Employee_ID, First_Name, Last_Name, Middle_Initial, Address1, Address2, City, State, Zip, Email, Phone_Number, Social_Security_Number, Drivers_License, Marital_Status, Gender, Shareholder_Status, Benefit_Plans, Ethnicity) " +
                      "VALUES (@EmployeeID, @FirstName, @LastName, @MiddleInitial, @Address1, @Address2, @City, @State, @Zip, @Email, @PhoneNumber, @SocialSecurityNumber, @DriversLicense, @MaritalStatus, @Gender, @ShareholderStatus, @BenefitPlans, @Ethnicity)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@MiddleInitial", middleInitial);
                    command.Parameters.AddWithValue("@Address1", address1);
                    command.Parameters.AddWithValue("@Address2", address2);
                    command.Parameters.AddWithValue("@City", city);
                    command.Parameters.AddWithValue("@State", state);
                    command.Parameters.AddWithValue("@Zip", zip);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("@SocialSecurityNumber", socialSecurityNumber);
                    command.Parameters.AddWithValue("@DriversLicense", driversLicense);
                    command.Parameters.AddWithValue("@MaritalStatus", maritalStatus);
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@ShareholderStatus", shareholderStatus);
                    command.Parameters.AddWithValue("@BenefitPlans", benefitPlans);
                    command.Parameters.AddWithValue("@Ethnicity", ethnicity);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Label1.Text = " successfully added newl";
                    }
                    else
                    {
                        Label1.Text = "add new failure";
                    }


                }
                using (MySqlConnection mySqlConnection = new MySqlConnection(myconnectionString))
                {
                    string myquery = "INSERT INTO employee (Employee_Number,idEmployee, Last_Name, firt_Name, SSN, Pay_Rate, PayRates_id, Vacation_Days, Paid_To_Date, Paid_Last_Year)" +
                    " VALUES (@Employee_Number,@EmployeeID, @LastName, @FirstName, @SSN, @PayRate, @PayRatesID, @VacationDays, @PaidToDate, @PaidLastYear)";
                    
                    MySqlCommand command = new MySqlCommand(myquery, mySqlConnection);
                    command.Parameters.AddWithValue("@Employee_Number", employeeID);
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@SSN", socialSecurityNumber);
                    command.Parameters.AddWithValue("@PayRate", payRate);
                    command.Parameters.AddWithValue("@PayRatesID", payratesID);
                    command.Parameters.AddWithValue("@VacationDays", vacationDays);
                    command.Parameters.AddWithValue("@PaidToDate", paidToDate);
                    command.Parameters.AddWithValue("@PaidLastYear", paidLastYear);
                    mySqlConnection.Open();
                    int flag = command.ExecuteNonQuery();
                    if (flag > 0)
                    {
                        Label2.Text = " successfully added newl";
                    }
                    else
                    {
                        Label2.Text = "add new failure";
                    }
                    mySqlConnection.Close();
                }

            }
            
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // Lấy thông tin cần thiết để xóa dữ liệu
            string employeeID = Employeeid.Text; // Sử dụng giá trị của trường Employee ID hoặc trường tương ứng

            // Thực hiện xóa dữ liệu từ cơ sở dữ liệu
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Personal WHERE Employee_ID = @EmployeeID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Xóa thành công
                        Label1.Text = "Delete successful for SQL.";
                    }
                    else
                    {
                        // Xóa không thành công
                        Label1.Text = "Delete failed to SQL.";
                    }
                }
            }
            using (MySqlConnection mySqlconnection = new MySqlConnection(myconnectionString))
            {
                // Mở kết nối
                mySqlconnection.Open();

                // Tạo câu truy vấn DELETE
                string query = "DELETE FROM employee WHERE Employee_Number = @EmployeeID";

                // Tạo đối tượng MySqlCommand
                using (MySqlCommand command = new MySqlCommand(query, mySqlconnection))
                {
                    // Gán giá trị cho tham số trong câu truy vấn
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);

                    // Thực thi câu truy vấn
                    int rowsAffected = command.ExecuteNonQuery();

                    // Kiểm tra số hàng bị ảnh hưởng
                    if (rowsAffected > 0)
                    {
                        // Xóa thành công
                        Label2.Text = "Delete successful for My SQL.";
                    }
                    else
                    {
                        // Không tìm thấy dữ liệu hoặc lỗi xảy ra
                        Label2.Text = "Delete failed to My SQL.";
                    }
                }
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ các trường nhập liệu
            string employeeID = Employeeid.Text;
            string firstName = Firstname.Text;
            string lastName = Lastname.Text;
            string middleInitial = Middleinitial.Text;
            string address1 = Address1.Text;
            string address2 = Address2.Text;
            string city = City.Text;
            string state = State.Text;
            string zip = Zip.Text;
            string email = Email.Text;
            string phoneNumber = PhoneNumber1.Text;
            string socialSecurityNumber = SocialSecurityNumber.Text;
            string driversLicense = DriversLicenses.Text;
            string maritalStatus = MaritalStatus.Text;
            string gender = Gender1.Text;
            string shareholderStatus = Sharegolder_Status.Text;
            string benefitPlans = BenefitPlanse.Text;
            string ethnicity = Ethnicity.Text;
            string paySSN = SSN.Text;
            string payRate = Payrate.Text;
            string payratesID = Payrates_id.Text;
            string vacationDays = Vacation_Day.Text;
            string paidLastYear = PaidLastYear.Text;
            string paidToDate = PaidToDate.Text;


            // Câu lệnh SQL để cập nhật dữ liệu
            string updateQuery = "UPDATE Personal SET First_Name = @FirstName, Last_Name = @LastName, Middle_Initial = @MiddleInitial, Address1 = @Address1, Address2 = @Address2, City = @City, State = @State, Zip = @Zip, Email = @Email, Phone_Number = @PhoneNumber, Social_Security_Number = @SocialSecurityNumber, Drivers_License = @DriversLicense, Marital_Status = @MaritalStatus, Gender = @Gender, Shareholder_Status = @ShareholderStatus, Benefit_Plans = @BenefitPlans, Ethnicity = @Ethnicity WHERE Employee_ID = @EmployeeID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    // Thêm các tham số vào câu lệnh SQL
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@MiddleInitial", middleInitial);
                    command.Parameters.AddWithValue("@Address1", address1);
                    command.Parameters.AddWithValue("@Address2", address2);
                    command.Parameters.AddWithValue("@City", city);
                    command.Parameters.AddWithValue("@State", state);
                    command.Parameters.AddWithValue("@Zip", zip);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("@SocialSecurityNumber", socialSecurityNumber);
                    command.Parameters.AddWithValue("@DriversLicense", driversLicense);
                    command.Parameters.AddWithValue("@MaritalStatus", maritalStatus);
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@ShareholderStatus", shareholderStatus);
                    command.Parameters.AddWithValue("@BenefitPlans", benefitPlans);
                    command.Parameters.AddWithValue("@Ethnicity", ethnicity);                
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        // Cập nhật thành công
                        Label1.Text = "Update successful";
                    }
                    else
                    {
                        // Không tìm thấy bản ghi để cập nhật
                        Label1.Text = "Update failed";
                    }
                }
            }
            //updat payroll
            using (MySqlConnection mySqlConnection = new MySqlConnection(myconnectionString))
            {
                
                string updatemyquery = "UPDATE employee SET idEmployee=@employeeID, Last_Name = @lastName, Firt_Name = @firtname, SSN = @SSN, Pay_Rate = @PayRate, PayRates_id = @PayRatesID,Vacation_Days =@VacationDays, Paid_To_Date = @PaidToDate, Paid_Last_Year =  @PaidLastYear WHERE Employee_Number = @Employee_Number";
                
                MySqlCommand command = new MySqlCommand(updatemyquery, mySqlConnection);
                command.Parameters.AddWithValue("@Employee_Number", employeeID);
                command.Parameters.AddWithValue("@employeeID", employeeID);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@FirtName", firstName);
                command.Parameters.AddWithValue("@SSN", socialSecurityNumber);
                command.Parameters.AddWithValue("@PayRate", payRate);
                command.Parameters.AddWithValue("@PayRatesID", payratesID);
                command.Parameters.AddWithValue("@VacationDays", vacationDays);
                command.Parameters.AddWithValue("@PaidToDate", paidToDate);
                command.Parameters.AddWithValue("@PaidLastYear", paidLastYear);
                mySqlConnection.Open();
                int flag = command.ExecuteNonQuery();
                if (flag > 0)
                {
                    Label2.Text = "Update successfully";
                }
                else
                {
                    Label2.Text = "Update failure";
                }
                mySqlConnection.Close();
            }


        }

    }
}