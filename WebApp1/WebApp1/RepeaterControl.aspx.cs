using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace WebApp1
{
    public partial class RepeaterControl : System.Web.UI.Page
    {
        private int iPageSize = 10;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCustomers();
            }
        }

        private void GetCustomers()
        {
            DataTable dtData = new DataTable();
            string conString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(conString);
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("Select * From tblCustomers", sqlCon);
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
            sqlDa.Fill(dtData);
            sqlCon.Close();

            PagedDataSource pdsData = new PagedDataSource();
            DataView dv = new DataView(dtData);
            pdsData.DataSource = dv;
            pdsData.AllowPaging = true;
            pdsData.PageSize = iPageSize;
            if (ViewState["PageNumber"] != null)
                pdsData.CurrentPageIndex = Convert.ToInt32(ViewState["PageNumber"]);
            else
                pdsData.CurrentPageIndex = 0;
            if (pdsData.PageCount > 1)
            {
                Repeater1.Visible = true;
                ArrayList alPages = new ArrayList();
                for (int i = 1; i <= pdsData.PageCount; i++)
                    alPages.Add((i + 1).ToString());
                Repeater1.DataSource = alPages;
                Repeater1.DataBind();
            }
            else
            {
                Repeater1.Visible = false;
            }
            Repeater2.DataSource = pdsData;
            Repeater2.DataBind();
        }
        
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ViewState["PageNumber"] = Convert.ToInt32(e.CommandArgument);
            GetCustomers();
        }
    }
}