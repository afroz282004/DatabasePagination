using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace WebApp1
{
    public partial class RepeaterControl1 : System.Web.UI.Page
    {
        private int iPageSize = 10;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GetCustomers(1);
            }
        }

        private void GetCustomers(int iPageIndex)
        {

            //Afroz develop for Database level pagination dated 10-Jan-20
            string conString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(conString);
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("GetCustomer", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@PageIndex", iPageIndex);
            sqlCmd.Parameters.AddWithValue("@PageSize", iPageSize);
            sqlCmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
            sqlCmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
            IDataReader iDr = sqlCmd.ExecuteReader();
            Repeater1.DataSource = iDr;
            Repeater1.DataBind();
            iDr.Close();
            sqlCon.Close();
            int iRecordCount = Convert.ToInt32(sqlCmd.Parameters["@RecordCount"].Value);

            double dPageCount = (double)((decimal)iRecordCount / Convert.ToDecimal(iPageSize));
            int iPageCount = (int)Math.Ceiling(dPageCount);
            List<ListItem> lPages = new List<ListItem>();
            if (iPageCount > 0)
            {
                for (int i = 1; i <= iPageCount; i++)
                    lPages.Add(new ListItem(i.ToString(), i.ToString(), i != iPageIndex));
            }
            Repeater2.DataSource = lPages;
            Repeater2.DataBind();
            //Afroz develop for Database level pagination dated 10-Jan-20
        }

        protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int iPageIndex = Convert.ToInt32(e.CommandArgument);
            GetCustomers(iPageIndex);
        }
    }
}