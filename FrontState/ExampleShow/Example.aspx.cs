using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontState_ExampleShow_Example : System.Web.UI.Page
{
    static private Paging PageList;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PageList = new Paging(new DAL.DExample().GetAll().ToList<Object>(), 6);
            RefreshList();
        }
    }
    protected void PrePageLBtn_Click(object sender, EventArgs e)
    {
        PageList.PrePage();
        RefreshList();
    }
    protected void NextPageLBtn_Click(object sender, EventArgs e)
    {
        PageList.NextPage();
        RefreshList();
    }
    private void RefreshList()
    {
        int totalPage = PageList.GetTotalPage();
        int currentPage = PageList.GetCurrentPage();
        if (currentPage == 1)
        {
            PrePageLBtn.Enabled = false;
        }
        else
        {
            PrePageLBtn.Enabled = true;
        }
        if (currentPage == totalPage)
        {
            NextPageLBtn.Enabled = false;
        }
        else
        {
            NextPageLBtn.Enabled = true;
        }
        CurrentPageLbl.Text = PageList.GetCurrentPage().ToString();
        TotalPageLbl.Text = PageList.GetTotalPage().ToString();
        ExampleList.DataSource = PageList.GetCurrentList();
        ExampleList.DataBind();
    }
}