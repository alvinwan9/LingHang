using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Model;

public partial class BackState_BlogsModify : System.Web.UI.Page
{
    DArticle info = new DArticle();
    static Article article;
    static int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Article.DataSource = info.GetAll();
            Article.DataBind();
            GetMemberType();
            GetIsImportant();
        }
    }

    protected void GetMemberType()
    {
        List<string> type = new List<string> 
            {
                "全部",
                "UI",
                "美工",
                "PHP",
                ".NET",
                "Android",
                "Java"
            };
        SearchType.DataSource = type;
        SearchType.DataBind();
    }

    protected void GetIsImportant()
    {
        List<string> isImportant = new List<string> 
            {
                "全部",
                "是",
                "否"
            };
        SearchIsImportant.DataSource = isImportant;
        SearchIsImportant.DataBind();
    }

    private int getIntOfIsImportant(string str)
    {
        if (str.Equals("是"))
        {
            return 1;
        }
        if (str.Equals("否"))
        {
            return 0;
        }
        return 0;
    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        if (SearchType.Text.Equals("全部") && SearchIsImportant.Text.Equals("全部"))
        {
            Article.DataSource = info.GetTitle(SearchTitle.Text);
            Article.DataBind();
            //Response.Write("0");
        }
        else if (SearchType.Text.Equals("全部"))
        {
            //Response.Write("01");
            Article.DataSource = info.GetArticleByTitleAndIsImportant(SearchTitle.Text,getIntOfIsImportant(SearchIsImportant.Text));
            Article.DataBind();
        }
        else if (SearchIsImportant.Text.Equals("全部"))
        {
            //Response.Write("0123");
            Article.DataSource = info.GetArticleByTitleAndType(SearchTitle.Text, SearchType.Text);
            Article.DataBind();
        }
        else
        {
            //Response.Write("013");
            Article.DataSource = info.GetArticleByTitleAndTypeAndIsImportant(Convert.ToString(SearchTitle.Text), Convert.ToString(SearchType.Text), getIntOfIsImportant(SearchIsImportant.Text));
            Article.DataBind();
        }
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        article.Id = id;
        article.Title = Title.Text;
        article.Name = Name.Text;
        article.Info = Info.Text;
        article.Type = Type.Text;
        if (Yes.Checked)
        {
            article.IsImportant = 1;
        }
        else
        {
            article.IsImportant = 0;
        }
        if (info.Update(article))
        {
            Response.Write("<script language='javascript'>alert('修改成功！')</script>");
        }
        else
        {
            Response.Write("<script language='javascript'>alert('修改失败！')</script>");
        }
        Article.DataSource = info.GetAll();
        Article.DataBind();


    }

    

    protected void Article_ItemCommand(object sender, DataListCommandEventArgs e)
    {
        id = Convert.ToInt32(e.CommandArgument.ToString());

        article = info.GetArticleById(id);
        Title.Text = article.Title;
        Name.Text = article.Name;
        Info.Text = article.Info;
        Type.Text = article.Type;
        if (article.IsImportant == 1)
        {
            Yes.Checked = true;
        }
        else
        {
            No.Checked = true;
        }
    }
}