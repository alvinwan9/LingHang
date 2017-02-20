using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BackState_NoticeSelect : System.Web.UI.Page
{
    private DAL.DNotice info = new DAL.DNotice();
    private static Model.Notice m_info = new Model.Notice();
    protected void Page_Load(object sender, EventArgs e)
    {
         Model.Notice now_info = new Model.Notice();
        if (!IsPostBack)
        {
            //content = "ada";
            NoticeDatalistList.DataSource = info.GetAllByTime();
            NoticeDatalistList.DataBind();

            now_info =info.Getnewtime();
            TitleLbl.Text = now_info.Title;
            TimeLbl.Text = now_info.Time.ToString();
            AuthorLbl.Text = now_info.Author;
            infoBox.InnerHtml = now_info.Info;
        }
    }
    protected void SelectBtn_Click(object sender, EventArgs e)
    {
        if (SelectDropDownList.SelectedValue == "0")
        {
            TitleSelectBox.Enabled = true;
            NoticeDatalistList.DataSource = info.GetAllByTime();
            NoticeDatalistList.DataBind();
        }
        else if (SelectDropDownList.SelectedValue == "1")
        {
            if (TitleSelectBox.Text.Equals("") || TitleSelectBox.Text == null)
            {
                Response.Write("<script language='javascript'>alert('请输入要查询的标题！')</script>");
                Response.Write(SelectDropDownList.SelectedValue);
            }
            else
            {
                NoticeDatalistList.DataSource = info.GetTitle(TitleSelectBox.Text.ToString());
                NoticeDatalistList.DataBind();
            }
        }
        else
        {
            NoticeDatalistList.DataSource = new List<Model.Notice> { info.Getnewtime() };
            NoticeDatalistList.DataBind();
        }
    }
    protected void SelectDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (SelectDropDownList.SelectedValue == "0")
        {
            TitleSelectBox.Enabled = false;
        }
        else if (SelectDropDownList.SelectedValue == "1")
        {
            TitleSelectBox.Enabled = true;
        }
        else
        {
            TitleSelectBox.Enabled = false;
        }
        Response.Write("<script>window.location.href='~/NoticeSelect.aspx'</script>");
    }
    protected void NoticeDatalistList_ItemCommand(object source, DataListCommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        m_info = info.GetById(Convert.ToInt32(id));

        TitleLbl.Text = m_info.Title;
        TimeLbl.Text = m_info.Time.ToString();
        AuthorLbl.Text = m_info.Author;
        infoBox.InnerHtml = m_info.Info;
    }
    //public string content
    //{
    //    get { return content; }
    //    set { content = "caolonghao"; }
    //}
}