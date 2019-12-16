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
    public partial class student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //connecting string 
            string connString = ConfigurationManager.ConnectionStrings["onlineExamDB"].ConnectionString;

            //connection
            SqlConnection con = new SqlConnection(connString);

            //open connection
            con.Open();

            if (!Page.IsPostBack)
            {
                btnSubmitTest.Visible = false;

                bindLookUpData(connString); //load data
            }

        }


        //bind the lookup
        public void bindLookUpData(string connString)
        {

            //connection
            SqlConnection con = new SqlConnection(connString);

            //open connection
            con.Open();
            //bind the questions
            SqlCommand command = new SqlCommand("SELECT t_TestDescription,t_testNo FROM tblTest t, tblUser u WHERE u.ID = t.user_ID ", con);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dlSelectTest.DataSource = dt;
            dlSelectTest.DataTextField = "t_TestDescription";
            dlSelectTest.DataValueField = "t_testNo";
            dlSelectTest.DataBind();
            //check if any exam questions available for this user
            SqlDataReader rd = command.ExecuteReader();
            if (rd.Read())
            {
               
            }
            else
            {
                
            }
            con.Close();
        }

        protected void btnStartExam_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["onlineExamDB"].ConnectionString;

            //connection
            SqlConnection con = new SqlConnection(connString);

            //open connection
            con.Open();

            //bind the questions int gridview
            SqlCommand command = new SqlCommand("SELECT t.t_TestDescription, q.Question, q.Question_Type FROM tblTest t, tblQuestion q WHERE t.t_testNo = q.t_testNo AND t.t_testNo = @testNo Order By  t.t_TestDescription", con);
            command.Parameters.AddWithValue("@testNo", dlSelectTest.SelectedValue.ToString());
            SqlDataReader r = command.ExecuteReader();


            //create dynamic html 
            int count = 1;
            int lookups = 1;
            while (r.Read())
            {
                if (r["Question_Type"].ToString().ToLower() == "number" || r["Question_Type"].ToString().ToLower() == "text")
                {
                    mainDIv.InnerHtml += "<div class='form-group'><Label runat='server' Class='col-md-2 control-label'>" + r["Question"].ToString() + "</Label><div class='col-md-10'><input type='" + r["Question_Type"].ToString() + "' runat='server' ID='Question" + count + "' Class='form-control' width ='280' /> </div></div>";
                    count++;
                }
                else
                {
                    mainDIv.InnerHtml += "<div class='form-group'><Label runat='server' Class='col-md-2 control-label'>" + r["Question"].ToString() + "</Label><div class='col-md-10'><select id = 'yesno" + lookups + "' runat ='server' Class='form-control' style='width:280px;'><option value='No'>No</option><option value='Yes'>Yes</option></select> </div></div>";
                    lookups++;
                }
            }
           
            r.Close();//close reader
            btnStartExam.Visible = false;
            btnSubmitTest.Visible = true;
            con.Close();//close connection
        }

        protected void btnSubmitTest_Click(object sender, EventArgs e)
        {

        }

    }
}