using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BackState_NoticeInsert : System.Web.UI.Page
{
    private DAL.DNotice d_notice = new DAL.DNotice();
    private Model.Notice m_notice = new Model.Notice();
    IList<Model.Notice> info = new List<Model.Notice>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            NoticeDatalistListInsert.DataSource = d_notice.GetAllByTime();
            NoticeDatalistListInsert.DataBind();
        }
    }
    protected void NoticeBtn_Click(object sender, EventArgs e)
    {
        m_notice.Title = TitleBox.Text;
        m_notice.Info = InfoBox.Text;
        m_notice.Time = DateTime.Now;
        m_notice.Author = "领航工作室";
        if (d_notice.Insert(m_notice))
        {
            Response.Write("<script language='javascript'>alert('发布成功！')</script>");
        }
        else
        {
            Response.Write("<script language='javascript'>alert('发布失败！')</script>");
        }
        TitleBox.Text = "";
        InfoBox.Text = "";

        NoticeDatalistListInsert.DataSource = d_notice.GetAllByTime();
        NoticeDatalistListInsert.DataBind();
    }

    protected void NoticeCommand(object sender, DataListCommandEventArgs e)
    {
        showInfo.Attributes["style"] = "dispaly:block;";
        int notice_id =Convert.ToInt32( e.CommandArgument.ToString());
        infoDiv.InnerHtml = new DAL.DNotice().GetById(notice_id).Info;
    }
}