using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace sqlBulk
{
    public partial class FirstsqlBulk : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                DataSet ds = new DataSet();
                ds.ReadXml(Server.MapPath("~/Data.xml"));

                DataTable dstud = ds.Tables["Student"];
                DataTable demp = ds.Tables["Employe"];
                con.Open();
                using (SqlBulkCopy sb = new SqlBulkCopy(con)) 
                {
                    sb.DestinationTableName = "StudentTable";
                    sb.ColumnMappings.Add("Stid", "Stid");
                    sb.ColumnMappings.Add("Sname", "Sname");
                    sb.ColumnMappings.Add("Sbranch", "Sbranch");                    
                    sb.ColumnMappings.Add("Sfees", "Sfees");
                    sb.WriteToServer(dstud);
                
                }

                using (SqlBulkCopy sb = new SqlBulkCopy(con))
                {
                    sb.DestinationTableName = "EmployeTable";
                    sb.ColumnMappings.Add("Eid", "Eid");
                    sb.ColumnMappings.Add("Ename", "Ename");
                    sb.ColumnMappings.Add("Ebranch", "Ebranch");                    
                    sb.ColumnMappings.Add("Efees", "Efees");
                    sb.WriteToServer(demp);

                }
       
            }
            

        }
    }
}