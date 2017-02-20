using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontState_WriteBlogs : System.Web.UI.Page
{
    static string qq;
    static string name;
    protected void Page_Load(object sender, EventArgs e)
    {
        qq = Request.QueryString["qq"].ToString();
        name = Request.QueryString["name"].ToString();
    }
    protected void Insert_Click(object sender, EventArgs e)
    {
        Model.Article article = new Model.Article();
        string str=BlogNameText.Value;
        if (str.Equals("") || str.Equals("博客标题"))
        {
            article.Title = "无标题";
        }
        else
        {
            article.Title = str;
        }
        article.Info = BlogContentBox.Text;
        article.QQ = qq;
        article.Name = name;
        if (new DAL.DArticle().Insert(article))
        {
            Response.Write("<script language='javascript'>alert('发布成功！')</script>");
        }
        else
        {
            Response.Write("<script language='javascript'>alert('发布失败！')</script>");
        }
    }
}