using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using OnlineExamApplication.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OnlineExamApplication.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            //connecting string 
            string connString = ConfigurationManager.ConnectionStrings["onlineExamDB"].ConnectionString;

            //adding role
            ApplicationDbContext context = new ApplicationDbContext();
            var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            //connection
            SqlConnection con = new SqlConnection(connString);

            //open connection
            con.Open();

            //check if user exist
            SqlCommand cm = new SqlCommand("SELECT * FROM tblUser WHERE Email = @Email", con);
            cm.Parameters.AddWithValue("@Email", Email.Text);
            SqlDataReader dr = cm.ExecuteReader();

            if (!dr.Read())
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
                IdentityResult result = manager.Create(user, Password.Text);

                if (result.Succeeded)
                {
                    //create user role
                    var role = new IdentityRole();
                    if(radExaminer.Checked == true){
                        role.Name = "examiner";
                        rolemanager.Create(role);

                        //add role
                        manager.AddToRole(user.Id, "examiner");
                    }
                    else if (radStudent.Checked == true)
                    {
                        role.Name = "student";
                        rolemanager.Create(role);

                        //add role
                        manager.AddToRole(user.Id, "student");
                    }
                    

                   //close con
                    con.Close();
                    signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    ErrorMessage.Text = result.Errors.FirstOrDefault();
                }
            }
            else
            {
                Response.Write("<script>alert('Patient ID number already exist');</script>");
            }
            //close connection
            con.Close();
            dr.Close();
        }
    }
}