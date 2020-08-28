using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class SqlcmdBuilder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnid_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            string query = "select Sid,Sname,Dname,Sfees from StudentDetail where Sid="+txtid.Text;
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            sda.Fill(ds,"StudentDetail");
            ViewState["SQLQUERY"]=query;
            ViewState["DATASET"]=ds;
            if (ds.Tables["StudentDetail"].Rows.Count > 0)
            {
                DataRow dr = ds.Tables["StudentDetail"].Rows[0];
                txtname.Text=dr["Sname"].ToString();
                ddldname.SelectedValue = dr["Dname"].ToString();
                txtfees.Text = dr["Sfees"].ToString();
                lblmsg.ForeColor = System.Drawing.Color.Green;
                lblmsg.Text = "Record is found";

            }
            else {
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Text = "The student id doesnt match with record" + txtid.Text;
            }

        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter((string)ViewState["SQLQUERY"], con);
            SqlCommandBuilder cm = new SqlCommandBuilder(da);
            DataSet ds = (DataSet)ViewState["DATASET"];
            if (ds.Tables["StudentDetail"].Rows.Count > 0)
            {
                DataRow dr = ds.Tables["StudentDetail"].Rows[0];
                dr["Sname"] = txtname.Text;
                dr["Dname"] = ddldname.SelectedValue;
                dr["Sfees"] = txtfees.Text;
            }
            int rowupdate=da.Update(ds, "StudentDetail");
            if (rowupdate > 0)
            {
                lblmsg.ForeColor = System.Drawing.Color.Green;
                lblmsg.Text = rowupdate + "row(s) updated";
            }
            else
            {
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Text ="No row updated";
            }
        }
    }
}