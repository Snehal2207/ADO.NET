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
    public partial class DisconnectDataAccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void getData()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter("select *from StudentDetail",con);
            DataSet ds = new DataSet();
            da.Fill(ds, "StudentDetail");

            ds.Tables["StudentDetail"].PrimaryKey = new DataColumn[] { ds.Tables["StudentDetail"].Columns["Sid"] };
            Cache.Insert("DATASET",ds,null,DateTime.Now.AddHours(24),System.Web.Caching.Cache.NoSlidingExpiration);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            lblmsg.ForeColor = System.Drawing.Color.Green;
            lblmsg.Text = "Fetching Data from Database";
        }
        private void getDataCache()
        {
            if (Cache["DATASET"] != null)
            {
                DataSet ds = (DataSet)Cache["DATASET"];
                GridView1.DataSource = ds;
                GridView1.DataBind();

            }
        }
        protected void btngetdata_Click(object sender, EventArgs e)
        {
            getData();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            getDataCache();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (Cache["DATASET"] != null)
            {
                DataSet ds = (DataSet)Cache["DATASET"];
                DataRow dr = ds.Tables["StudentDetail"].Rows.Find(e.Keys["Sid"]);
                dr["Sname"] = e.NewValues["Sname"];
                dr["Sbranch"] = e.NewValues["Sbranch"];
                dr["Sphone"] = e.NewValues["Sphone"];
                dr["Sfees"] = e.NewValues["Sfees"];
                dr["Dname"] = e.NewValues["Dname"];
                dr["Slevel"] = e.NewValues["Slevel"];
                Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
                GridView1.EditIndex = -1;
                
                getDataCache();
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            getDataCache();
       
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (Cache["DATASET"] != null)
            {
                DataSet ds = (DataSet)Cache["DATASET"];
                DataRow dr = ds.Tables["StudentDetail"].Rows.Find(e.Keys["Sid"]);
                dr.Delete();
                Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
                GridView1.EditIndex = -1;

                getDataCache();
            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            string query = "select *from StudentDetail";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = (DataSet)Cache["DATASET"];
            string updatecmd = "update StudentDetail set Sname=@Sname ,Sbranch=@Sbranch,Sphone=@Sphone,Sfees=@Sfees,Dname=@Dname,Slevel=@Slevel where Sid=@Sid ";
            SqlCommand upcmd = new SqlCommand(updatecmd, con);
            upcmd.Parameters.Add("@Sname", SqlDbType.NVarChar, 100, "Sname");
            upcmd.Parameters.Add("@Sbranch", SqlDbType.NVarChar, 100, "Sbranch");
            upcmd.Parameters.Add("@Sphone", SqlDbType.Int, 0, "Sphone");
            upcmd.Parameters.Add("@Sfees", SqlDbType.Decimal, 0, "Sfees");
            upcmd.Parameters.Add("@Dname", SqlDbType.NVarChar, 100, "Dname");
            upcmd.Parameters.Add("@Slevel", SqlDbType.NVarChar, 100, "Slevel");
            upcmd.Parameters.Add("@Sid", SqlDbType.Int, 0, "Sid");
            da.UpdateCommand = upcmd;

            string deletecmd = "delete from StudentDetail  where Sid=@Sid ";
            SqlCommand dltcmd = new SqlCommand(deletecmd, con);
            dltcmd.Parameters.Add("@Sid", SqlDbType.Int, 0, "Sid");
            da.DeleteCommand = dltcmd;
            da.Update(ds, "StudentDetail");
            lblmsg.ForeColor = System.Drawing.Color.Green;
            lblmsg.Text = "Table Updated";

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet ds = (DataSet)Cache["DATASET"];
            //Acceptchnages Method
            //ds.AcceptChanges();
            //Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
            //getDataCache();
                
            if(ds.HasChanges())
            {
                ds.RejectChanges();
                Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
                getDataCache();
                lblmsg.ForeColor = System.Drawing.Color.Green;
                lblmsg.Text = "Undonw changes";

            }
            else
            {
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Text = "No row undo";
            }
        }
    }
}