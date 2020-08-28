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
    public partial class ExchangeTableData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
        
            string sdb = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            string ddb = ConfigurationManager.ConnectionStrings["DBDest"].ConnectionString;
        
            using (SqlConnection scon = new SqlConnection(sdb))
            {
                SqlCommand cmd = new SqlCommand("select * from StudentTable", scon);
                scon.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader()) 
                {
                    using (SqlConnection dcon = new SqlConnection(ddb))
                    {
                        using (SqlBulkCopy sb = new SqlBulkCopy(dcon))
                        {
                            sb.DestinationTableName = "StudentTable";
                            dcon.Open();
                            sb.WriteToServer(rdr);

                        }  
                    }
                }

                cmd = new SqlCommand("select * from EmployeTable", scon);
                //scon.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    using (SqlConnection dcon = new SqlConnection(ddb))
                    {
                        using (SqlBulkCopy sb = new SqlBulkCopy(dcon))
                        {
                            sb.DestinationTableName = "EmployeTable";
                            dcon.Open();
                            sb.WriteToServer(rdr);

                        }
                    }
                }

            }   
        }
    }
}