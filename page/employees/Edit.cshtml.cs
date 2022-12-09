using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Employeeproject.page.employees
{
    public class EditModel : PageModel
    {
        public employeeInfo employeeInfo = new employeeInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
            String first_name = Request.Query["first_name"];

            try
            {
                String connectionString = "Data Source=DESKTOP-20C6ETA\\SQLEXPRESS;Initial Catalog=Employee_page;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * From employee_details WHERE first_name=@first_name";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@first_name", first_name);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                
                                employeeInfo.first_name = reader.GetString(0);
                                employeeInfo.last_name = reader.GetString(1);
                                employeeInfo.email = reader.GetString(2);
                                employeeInfo.dob = reader.GetDateTime(3).ToString();
                                employeeInfo.email = reader.GetString(4);
                                employeeInfo.country = reader.GetString(5);
                                employeeInfo.state = reader.GetString(6);

                                
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        public void OnPost()
        {
            employeeInfo.first_name = Request.Form["first_name"];
            employeeInfo.last_name = Request.Form["last_name"];
            employeeInfo.email = Request.Form["email"];
            employeeInfo.dob = Request.Form["dob"];
            employeeInfo.gender = Request.Form["gender"];
            employeeInfo.country = Request.Form["country"];
            employeeInfo.state = Request.Form["state"];

            if (employeeInfo.first_name.Length == 0 || employeeInfo.last_name.Length == 0 || employeeInfo.email.Length == 0 || employeeInfo.dob.Length == 0 || employeeInfo.gender.Length == 0 || employeeInfo.country.Length == 0 || employeeInfo.state.Length == 0)

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
                    String sql = "UPDATE employee_details" +
                        "SET first_name=@first_name, last_name=@last_name, email=@email, dob=@dob, gender=@gender, country=@country, state=@state" + "WHERE first_name=@first_name";

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

            Response.Redirect("/employees/Index");
        }
    }

}
