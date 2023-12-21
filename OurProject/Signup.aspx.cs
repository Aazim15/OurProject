// Signup.aspx.cs
using System;
using System.Configuration;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace OurProject
{
    public partial class Signup : System.Web.UI.Page
    {
        public object Email { get; private set; }

        protected void SignupButton_Click(object sender, EventArgs e)
        {
            // Get user input from form controls
            string Name = this.Name.Text;
            string username = this.username.Text;
            string email = this.email.Text;
            string password = this.password.Text;
            string confirmPassword = this.confirmPassword.Text;
            string dob = this.dob.Text;

            // Perform basic validation (you should enhance this)
            if (string.IsNullOrEmpty(Name) || (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(dob)))
            {
                // Display an error message or handle validation failure
                return;
            }

            // Check if the password and confirm password match
            if (password != confirmPassword)
            {
                // Display an error message or handle password mismatch
                return;
            }



            // Save user information to the database (you should use parameterized queries)
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Replace the following query with a parameterized query to prevent SQL injection
                string query = "INSERT INTO Users (Name,Email,UserName,Password,DOB) VALUES (@Name, @Email, @UserName,@Password,@dob)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name",Name);
                    command.Parameters.AddWithValue("@Email",email);
                    command.Parameters.AddWithValue("@UserName",username);
                    command.Parameters.AddWithValue("@Password",password);
                    command.Parameters.AddWithValue("@DOB",dob);
                    command.ExecuteNonQuery();
                }
            }

            // Redirect to a success page or login page
            Response.Redirect("Login.aspx");
        }


    }
}
