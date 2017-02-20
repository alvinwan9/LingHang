using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontState_Blogs_Blog : System.Web.UI.Page
{
    static protected Model.Article info=new Model.Article();
    static private Paging PageList;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        string qq = Request.QueryString["qq"].ToString();
        int id = Convert.ToInt32(Request.QueryString["id"].ToString());
        FillWriterInfo(qq);
        DealRightContent(id, qq);
        if (!IsPostBack)
        {
            HotArticleList.DataSource = new DAL.DArticle().GetByTotalReadTop8();
            HotArticleList.DataBind();
            GreatArticleList.DataSource = new DAL.DArticle().GetArticleByTitleAndTypeAndIsImportant("", "", 1);
            GreatArticleList.DataBind();
        }
    }

    private void FillWriterInfo(string qq)
    {
        Model.Member member = new DAL.DMember().GetMemberByQQ(qq);

        name.Text = member.Name;
        QQ.Text = qq;
        Dept.Text = member.Dept;
    }
    private void DealRightContent(int id,string qq)
    {
        DAL.DArticle DAr = new DAL.DArticle();
        if (id!=0)
        {
            info = DAr.GetArticleById(id);
            singleBlogDiv.Attributes["style"] = "display:block;min-height:800px;";
            MainContentDiv.Attributes["style"] = "display:none;";
            DAr.AddReadedMount(id);
        }
        else
        {
            singleBlogDiv.Attributes["style"] = "display:none;";
            MainContentDiv.Attributes["style"] = "display:block;";
            PageList = new Paging(DAr.GetByQQ(qq).ToList<Object>(), 6);
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
        MainContentList.DataSource = PageList.GetCurrentList();
        MainContentList.DataBind();
    }
    protected void KeySearchBtn_Click(object sender, EventArgs e)
    {
        DAL.DArticle DAr = new DAL.DArticle();
        string key = KeyText.Value;
        singleBlogDiv.Attributes["style"] = "display:none;";
        MainContentDiv.Attributes["style"] = "display:block;";
        if (key.Equals(" 请输入关键字.....") || key.Equals("") || key.Contains("全部"))
        {
            KeyText.Value = "全部";
            PageList = new Paging(DAr.GetAll().ToList<Object>(), 6);
            RefreshList();
        }
        else if (key.Contains("精品"))
        {
            PageList = new Paging(DAr.GetArticleByTitleAndTypeAndIsImportant("", "", 1).ToList<Object>(), 6);
            RefreshList();
        }
        else if (key.Contains("热门"))
        {
            PageList = new Paging(DAr.GetByTotalReadTop8().ToList<Object>(), 6);
            RefreshList();
        }
        else
        {
            PageList = new Paging(DAr.GetArticleByTitleOrTypeOrName(key,key,key).ToList<Object>(), 6);
            RefreshList();
        }
    }
    protected void UserSearchBox_Click(object sender, EventArgs e)
    {
        DAL.DArticle DAr = new DAL.DArticle();
        string key = UserNameText.Value;
        if (key.Equals(" 请输入作者名") || key.Equals("") || key.Contains("全部"))
        {
            UserNameText.Value = "全部";
            HotArticleList.DataSource = DAr.GetAll();
            HotArticleList.DataBind();
        }
        else
        {
            HotArticleList.DataSource = DAr.GetArticleByTitleOrTypeOrName("","",key);
            HotArticleList.DataBind();
        }
    }
}