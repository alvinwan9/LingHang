using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BackState_NoticeDelete : System.Web.UI.Page
{
    private DAL.DNotice info = new DAL.DNotice();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            NoticeDatalistListDelete.DataSource = info.GetAllByTime();
            NoticeDatalistListDelete.DataBind();
        }
    }
    protected void NoticeDeleteCommand(object sender, DataListCommandEventArgs e)
    {
        string notice_id = e.CommandArgument.ToString();
        if (info.Delete(Convert.ToInt32(notice_id)))
        {
            NoticeDatalistListDelete.DataSource = info.GetAll();
            NoticeDatalistListDelete.DataBind();
            Response.Write("<script language='javascript'>alert('删除成功！')</script>");
        }
    }
}