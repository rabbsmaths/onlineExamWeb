using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace OnlineExamApplication
{
    public partial class examiner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //connecting string 
            string connString = ConfigurationManager.ConnectionStrings["onlineExamDB"].ConnectionString;

            //connection
            SqlConnection con = new SqlConnection(connString);

            //open connection
            con.Open();


        }

        protected void btnTestTitle_Click(object sender, EventArgs e)
        {
            //connecting string 
            string connString = ConfigurationManager.ConnectionStrings["onlineExamDB"].ConnectionString;

            //connection
            SqlConnection con = new SqlConnection(connString);

            //open connection
            con.Open();

            ////command object to run procedure
            SqlCommand cmd = new SqlCommand("procAddNewTest", con);

            cmd.CommandType = CommandType.StoredProcedure;

            //get userID
            //check if medication already exist
            SqlCommand command = new SqlCommand("SELECT ID FROM tblUser WHERE Email =@Email", con);
            command.Parameters.AddWithValue("@Email", HttpContext.Current.User.Identity.Name);
            SqlDataReader r = command
            cmd.Parameters.AddWithValue("user_ID", pmedCode.Text);
            cmd.Parameters.AddWithValue("t_TestDescription", txtTestTitle.Text);
            //execute command
            int k = cmd.ExecuteNonQuery();
            if (k != 0)
            {
                Response.Write("<script>alert('New exam title is successfully added!!!!');</script>");
            }

            con.Close(); //close connection

        }

       
    }
}