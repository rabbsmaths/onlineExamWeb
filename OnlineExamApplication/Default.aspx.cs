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
    public partial class _Default : Page
    {
        //public variables
        public string msg { get; set; } 
        public string link { get; set; }
        public string head { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //connecting string 
            string connString = ConfigurationManager.ConnectionStrings["onlineExamDB"].ConnectionString;

            //connection
            SqlConnection con = new SqlConnection(connString);

            //open connection
            con.Open();

            //check user role
            SqlCommand cm = new SqlCommand("SELECT r.name  FROM tblUser u , tblRole r, tblUserRole ur WHERE u.ID = ur.userID AND r.ID = ur.RoleID AND Upper(Email) = Upper(@email)", con);
            cm.Parameters.AddWithValue("@Email", HttpContext.Current.User.Identity.Name);
            SqlDataReader r = cm.ExecuteReader();
            while (r.Read())
            {
                if (r["name"].ToString() == "examiner")
                {
                    //set message
                    this.msg = "Welcome back examiner please click the link below to manage your test questions.";
                    //set title
                    this.head = "Manage or Add New Exam";
                    //set link
                    this.link = "~/eximaner";
                }else if (r["name"].ToString() == "student")
                {
                    //set message
                    this.msg = "Welcome back student please click the link below to take the exam.";
                    //set title
                    this.head = "Take Exam";
                    //set link
                    this.link = "~/student";
                }
            }
            r.Close();

          
        }
    }
}