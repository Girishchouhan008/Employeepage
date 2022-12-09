using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data;

namespace Employeeproject.page.employees
{
    public class IndexModel : PageModel
    {
        public List<employeeInfo> Listemployees = new List<employeeInfo>();
               
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=DESKTOP-20C6ETA\\SQLEXPRESS;Initial Catalog=Employee_page;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * From employee_details";

                    using(SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                employeeInfo employeeInfo = new employeeInfo();
                                employeeInfo.first_name = reader.GetString(0);
                                employeeInfo.last_name = reader.GetString(1);
                                employeeInfo.email = reader.GetString(2);
                                employeeInfo.dob = reader.GetDateTime(3).ToString();
                                employeeInfo.email = reader.GetString(4);
                                employeeInfo.country = reader.GetString(5);
                                employeeInfo.state = reader.GetString(6);

                                Listemployees.Add(employeeInfo);
                            }
                        }
                    }
                }
            
            }
            catch (Exception ex)
            {

            }
        }
    }

    public class employeeInfo
        {
        public string first_name;
    public string last_name;
    public string email;
    public string dob;
    public string gender;
    public string country;
    public string state;
}


}
