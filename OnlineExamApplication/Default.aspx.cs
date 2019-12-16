using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineExamApplication
{
    public partial class _Default : Page
    {
        //public variables
        public string msg { get; set; } 
        public string link { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
          //set message
            this.msg = "Welcome back examiner please click the link below to manage your test questions.";
        }
    }
}