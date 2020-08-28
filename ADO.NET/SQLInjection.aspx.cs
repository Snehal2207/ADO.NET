using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace ADO.NET
{
    public partial class SQLInjection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using(SqlConnection con = new SqlConnection(CS))
            
            {
               // string cmd1 = "select * from StudentDetail where Dname like '"+TextBox1.Text+"%'";
               // string cmd1 = ;
                SqlCommand cmd = new SqlCommand("select *from StudentDetail where Dname like @Dname", con);
                cmd.Parameters.AddWithValue("@Dname" ,TextBox1.Text + "%");
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
            
        }
    }
}