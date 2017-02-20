using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontState_Blogs_MemberCenter : System.Web.UI.Page
{
    static protected Model.Member member = new Model.Member();
    protected void Page_Load(object sender, EventArgs e)
    {
        string qq = Request.QueryString["qq"].ToString();
        if (!IsPostBack)
        {
            GetInfo(qq);
        }

    }
    private void GetInfo(string qq)
    {
        Model.Notice notice = new DAL.DNotice().Getnewtime();
        if (notice.Info.Length > 150)
        {
            NoticeHTML.InnerHtml = notice.Info.Substring(0, 149);
        }
        else
        {
            NoticeHTML.InnerHtml = notice.Info;
        }

        DAL.DMember info = new DAL.DMember();
        member = info.GetMemberByQQ(qq);
        name.Text = member.Name;
        QQ.Text = qq;
        char[] spit = new char[] { '>' };
        Dept.Text = member.Dept.Split(spit)[1];
        GreatArticleList.DataSource = new DAL.DArticle().GetArticleByTitleAndTypeAndIsImportant("", "", 1);
        GreatArticleList.DataBind();
    }
}