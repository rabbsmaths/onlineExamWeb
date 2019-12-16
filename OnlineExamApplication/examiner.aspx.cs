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

            if (!Page.IsPostBack)
            {
                //bind question types
                string[] quesiontype = { "Yes/No", "Text", "Numeric" };
                dlQuestionType.DataSource = quesiontype;
                dlQuestionType.DataBind();

                bindLookUpData(connString); //load data
            }

            bindGridVewData(connString);//load data
        }

        protected void btnTestTitle_Click(object sender, EventArgs e)
        {
            //connecting string 
            string connString = ConfigurationManager.ConnectionStrings["onlineExamDB"].ConnectionString;

            //connection
            SqlConnection con = new SqlConnection(connString);

            //open connection
            con.Open();

            //get userID
            //check if medication already exist
            SqlCommand command = new SqlCommand("SELECT ID FROM tblUser WHERE Email =@Email", con);
            command.Parameters.AddWithValue("@Email", HttpContext.Current.User.Identity.Name);
            SqlDataReader r = command.ExecuteReader();
            string ID = "";
            while (r.Read())
            {
                ID = r[0].ToString();
            }
            r.Close();

            ////command object to run procedure
            SqlCommand cmd = new SqlCommand("procAddNewTest", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("user_ID", ID);
            cmd.Parameters.AddWithValue("t_TestDescription", txtTestTitle.Text);
            //execute command
            int k = cmd.ExecuteNonQuery();
            if (k != 0)
            {
                Response.Write("<script>alert('New exam title is successfully added!!!!');</script>");
                txtTestTitle.Text = "";

                //hide add test option
                divTestTitle.Visible = false;
                divSelectTest.Visible = true;
                divAddQ.Visible = true;
            }

            con.Close(); //close connection
            bindLookUpData(connString); //load data
        
        }

        protected void btnAddQuestion_Click(object sender, EventArgs e)
        {
            //connecting string 
            string connString = ConfigurationManager.ConnectionStrings["onlineExamDB"].ConnectionString;

            //connection
            SqlConnection con = new SqlConnection(connString);

            //open connection
            con.Open();

            //get userID
            //check if medication already exist
            SqlCommand command = new SqlCommand("SELECT ID FROM tblUser WHERE Email =@Email", con);
            command.Parameters.AddWithValue("@Email", HttpContext.Current.User.Identity.Name);
            SqlDataReader r = command.ExecuteReader();
            string ID = "";
            while (r.Read())
            {
                ID = r[0].ToString();
            }
            r.Close();

            ////command object to run procedure
            SqlCommand cmd = new SqlCommand("procAddNewQuestion", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("t_testNo", dlSelectTest.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("Question",txtQuestion.Text);
            cmd.Parameters.AddWithValue("Question_Type",dlQuestionType.SelectedValue.ToArray());
            cmd.Parameters.AddWithValue("Answer", txtAnswer.Text);


            //execute command
            int k = cmd.ExecuteNonQuery();
            if (k != 0)
            {
                Response.Write("<script>alert('New question successfully added!!!!');</script>");
                txtAnswer.Text = "";
                txtQuestion.Text = "";
                txtTestTitle.Text = "";

                //hide add test option
                divTestTitle.Visible = false;
                divSelectTest.Visible = true;
                divAddQ.Visible = true;
            }

            con.Close(); //close connection
            bindGridVewData(connString);//load data
        }

        //bind the lookup
        public void bindLookUpData(string connString)
        {
           
            //connection
            SqlConnection con = new SqlConnection(connString);

            //open connection
            con.Open();
            //bind the questions
            SqlCommand command = new SqlCommand("SELECT t_TestDescription,t_testNo FROM tblTest t, tblUser u WHERE u.ID = t.user_ID AND u.Email = @email", con);
            command.Parameters.AddWithValue("@email", HttpContext.Current.User.Identity.Name);
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
                divAddQ.Visible = true;
                divTestTitle.Visible = false;
            }
            else
            {
                divSelectTest.Visible = true;
                divAddQ.Visible = false;
                divSelectTest.Visible = false;
            }
            con.Close();
        }

        //bindGridview
        public void bindGridVewData(string connString)
        {
            //connection
            SqlConnection con = new SqlConnection(connString);

            //open connection
            con.Open();

            //bind the questions int gridview
            SqlCommand command = new SqlCommand("SELECT t.t_TestDescription, q.Question, q.Question_Type, q.Answer FROM tblTest t, tblQuestion q WHERE t.t_testNo = q.t_testNo AND t.t_testNo = @testNo Order By  t.t_TestDescription", con);
            command.Parameters.AddWithValue("@testNo", dlSelectTest.SelectedValue.ToString());
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grdQuestions.DataSource = dt;
            grdQuestions.DataBind();

            con.Close();
        }

       
    }
}