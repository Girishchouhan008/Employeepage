using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Employeeproject.page.employees
{

    public class CreateModel : PageModel
    {
        public employeeInfo employeeInfo = new employeeInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            employeeInfo.first_name = Request.Form["first_name"];
            employeeInfo.first_name = Request.Form["last_name"];
            employeeInfo.first_name = Request.Form["email"];
            employeeInfo.first_name = Request.Form["dob"];
            employeeInfo.first_name = Request.Form["gender"];
            employeeInfo.first_name = Request.Form["country"];
            employeeInfo.first_name = Request.Form["state"];

            if (employeeInfo.first_name.Length ==0 || employeeInfo.last_name.Length == 0 || employeeInfo.email.Length == 0 || employeeInfo.dob.Length == 0 || employeeInfo.gender.Length == 0 || employeeInfo.country.Length == 0 || employeeInfo.state.Length == 0)

            {
                errorMessage = "All the fields are required";
                return;
            }

            try
            {
                String connectionString = "Data Source=DESKTOP-20C6ETA\\SQLEXPRESS;Initial Catalog=Employee_page;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO employee_details" +
                        "(first_name, last_name, email, dob, gender, country, state) VALUES " +
                        "(@first_name, @last_name, @email, @dob, @gender, @country, @state);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@first_name", employeeInfo.first_name);
                        command.Parameters.AddWithValue("@last_name", employeeInfo.last_name);
                        command.Parameters.AddWithValue("@email", employeeInfo.email);
                        command.Parameters.AddWithValue("@dob", employeeInfo.dob);
                        command.Parameters.AddWithValue("@gender", employeeInfo.gender);
                        command.Parameters.AddWithValue("@country", employeeInfo.country);
                        command.Parameters.AddWithValue("@state", employeeInfo.state);

                        command.ExecuteNonQuery();
                    }
                }
            
            
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }



            employeeInfo.first_name = ""; employeeInfo.last_name = "";employeeInfo.email = ""; employeeInfo.dob = ""; employeeInfo.gender = ""; employeeInfo.country = ""; employeeInfo.state = "";
            successMessage = "New Employee added successfully";

        }
    }
}
