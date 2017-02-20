using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BackState_NoticeModify : System.Web.UI.Page
{
    private DAL.DNotice info = new DAL.DNotice();
    private static Model.Notice m_info = new Model.Notice();
    static int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            NoticeDatalistListUpdate.DataSource = info.GetAllByTime();
            NoticeDatalistListUpdate.DataBind();
        }
    }
    protected void NoticeUpdateCommand(object sender, DataListCommandEventArgs e)
    {
        string notice_id = e.CommandArgument.ToString();
        id = Convert.ToInt32(notice_id);
        m_info = info.GetById(id);

        TitleUpdateBox.Text = m_info.Title;
        AuthorUpdateBox.Text = m_info.Author;
        InfoUpdateBox.Text = m_info.Info;
    }
    protected void NoticeBtn_Click(object sender, EventArgs e)
    {
        m_info.Title = TitleUpdateBox.Text;
        m_info.Author = AuthorUpdateBox.Text;
        m_info.Info = InfoUpdateBox.Text;
        if (info.Update(m_info))
        {
            NoticeDatalistListUpdate.DataSource = info.GetAllByTime();
            NoticeDatalistListUpdate.DataBind();
            Response.Write("<script language='javascript'>alert('修改成功！')</script>");
        }
        else
            Response.Write("<script language='javascript'>alert('修改失败！')</script>");
    }
}