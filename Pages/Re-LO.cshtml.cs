using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CA.Pages
{
    public class Re_LOModel : PageModel
    {
        public void OnPost()
        {
            // Retrieve the form values
            string username = Request.Form["username"];
            string email = Request.Form["email"];
            string password = Request.Form["password"];
            string confirmPassword = Request.Form["confirm-password"];

            // Validate the form values
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                // Return an error message
            }
            else if (password != confirmPassword)
            {
                // Return an error message
            }
            else
            {
                // Save the registration information to the database or perform any other processing
            }
        }
    }
}
