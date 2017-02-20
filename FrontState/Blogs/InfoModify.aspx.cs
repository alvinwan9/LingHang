using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontState_Blogs_UserModify : System.Web.UI.Page
{
    static protected Model.Member member = new Model.Member();
    protected void Page_Load(object sender, EventArgs e)
    {
        string qq = Request.QueryString["qq"].ToString();
        DAL.DMember info = new DAL.DMember();
        member = info.GetMemberByQQ(qq);

    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        member.Name=Name.Text ;
        if (Man.Checked)
        {
            member.Sex = "男";
        }
        else
        {
            member.Sex = "女";
        }
        member.Tel=Tel.Text;
        if (!PicUrl.FileName.Equals(""))
        {
            if (Comment.SaveImg(PicUrl, MapPath("~/FrontState/Member/HeadImg"), member.QQ))
            {
                int index = PicUrl.FileName.LastIndexOf(".");
                string picLastName = PicUrl.FileName.Substring(index);
                member.UserPic = MapPath("~/FrontState/Member/HeadImg") + "/" + member.QQ + picLastName;
            }
        }
        DAL.DMember info = new DAL.DMember();
        if (info.Update(member))
        {
            Response.Write("<script language='javascript'>alert('修改成功！')</script>");
            Cancel_Click(sender, e);
        }
        else
        {
            Response.Write("<script language='javascript'>alert('修改失败！')</script>");
            member = info.GetMemberByQQ(member.QQ);
        }
    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        Name.Text = "";
        Man.Checked = false;
        Woman.Checked = false;
        
        Tel.Text = "";
        Pic.ImageUrl = "";
    }
    protected void ModifyLBtn_Click(object sender, EventArgs e)
    {
        Name.Text = member.Name;
        if (member.Sex.Equals("男"))
        {
            Man.Checked = true;
            Woman.Checked = false;
        }
        else
        {
            Man.Checked = false;
            Woman.Checked = true;
        }
        Tel.Text = member.Tel;
        Pic.ImageUrl = member.UserPic;
    }
}