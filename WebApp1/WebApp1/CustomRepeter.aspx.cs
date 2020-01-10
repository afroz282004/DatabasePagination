using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp1
{
    public partial class CustomRepeter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepeater();
            }

        }
        private void BindRepeater()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("StudentId", typeof(Int32));
            dt.Columns.Add("StudentName", typeof(string));
            dt.Columns.Add("StudentQualification", typeof(string));
            dt.Rows.Add(1, "Vikram Singh", "B.Tech");
            dt.Rows.Add(2, "Uma Shankar Rai", "MCA");
            dt.Rows.Add(3, "Naresh Chandra", "MCA");
            dt.Rows.Add(4, "Naga Bhusan Jena", "B.Tech");
            dt.Rows.Add(6, "Anand Chauhan", "B.Tech");
            dt.Rows.Add(7, "Zaki Ahmad", "B.Tech");
            dt.Rows.Add(8, "Isha Phatik", "B.Tech");
            PagedDataSource pageds = new PagedDataSource();

            DataView dv = new DataView(dt);
            pageds.DataSource = dv;
            pageds.AllowPaging = true;
            pageds.PageSize = 3;
            if (ViewState["PageNumber"] != null)
                pageds.CurrentPageIndex = Convert.ToInt32(ViewState["PageNumber"]);
            else
                pageds.CurrentPageIndex = 0;
            if (pageds.PageCount > 1)
            {


                rptPaging.Visible = true;
                ArrayList pages = new ArrayList();
                for (int i = 0; i < pageds.PageCount; i++)
                    pages.Add((i + 1).ToString());
                rptPaging.DataSource = pages;
                rptPaging.DataBind();
                for (int i = 0; i < rptPaging.Items.Count; i++)
                {
                    LinkButton lnkPage = (LinkButton)rptPaging.Items[i].FindControl("lnkPage");
                    if (i == pageds.CurrentPageIndex)
                    {
                        lnkPage.BackColor = Color.Red;
                    }
                    else
                    {
                        lnkPage.BackColor = Color.Green;
                    }
                }
            }
            else
            {
                rptPaging.Visible = false;
            }
            rptStudentData.DataSource = pageds;
            rptStudentData.DataBind();
        }
        // Binding Data on Page Item Change
        protected void rptPaging_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ViewState["PageNumber"] = Convert.ToInt32(e.CommandArgument) - 1;
            BindRepeater();
        }

    }
}