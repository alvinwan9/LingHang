using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontState_Blogs_PasWModify : System.Web.UI.Page
{
    static string qq;
    protected void Page_Load(object sender, EventArgs e)
    {
        qq = Request.QueryString["qq"].ToString();
    }
    protected void ModifyBtn_Click(object sender, EventArgs e)
    {
        DAL.DMember DMe = new DAL.DMember();
        if (DMe.CanLogin(qq, OldPsdBox.Text))
        {
            OldPsdLbl.Text = "";
            Model.Member info = DMe.GetMemberByQQ(qq);
            if (NewPsdBox.Text.Equals(ForSureBox.Text))
            {
                info.Password = NewPsdBox.Text;
                ForSureLbl.Text = "";
                if (DMe.Update(info))
                {
                    Response.Write("<script language='javascript'>alert('修改成功！')</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('修改失败！')</script>");
                }
            }
            else
            {
                ForSureLbl.Text = "与新密码不一致";
            }
        }
        else
        {
            OldPsdLbl.Text = "密码错误！";
        }
    }
}