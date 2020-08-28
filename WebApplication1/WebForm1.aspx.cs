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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select *from StudentDetail", con);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("SId");
                    dt.Columns.Add("SName");
                    dt.Columns.Add("SBranch");
                    dt.Columns.Add("SPhone");
                    dt.Columns.Add("SFees");
                    dt.Columns.Add("DFees");
                    //dt.Columns.Add("SLevel");
                    while (rdr.Read()) 
                    {
                        DataRow dr = dt.NewRow();
                        int sfees = Convert.ToInt32(rdr["Sfees"]);
                        double dfees = sfees * 0.9;

                        dr["SId"] = rdr["Sid"];
                        dr["SName"] = rdr["Sname"];
                        dr["SBranch"] = rdr["Sbranch"];
                        dr["SPhone"] = rdr["Sphone"];
                        dr["SFees"] = sfees;
                        dr["DFees"] = dfees;

                        dt.Rows.Add(dr);


                    }
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                }
               
            }
           
        }
    }
}