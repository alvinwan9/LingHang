using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontState_Blogs_Logon : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LogonBtn_Click(object sender, EventArgs e)
    {
        DAL.DMember info = new DAL.DMember();
       
        if (info.CanLogin(UserNameText.Value, PasswordText.Value))
        {
            Server.Transfer("MemberCenter.aspx?qq="+UserNameText.Value);
        }
        else
        {
            Response.Write("<script language='javascript'>alert('用户名或密码不正确！')</script>");
        }
        //}
    }
}