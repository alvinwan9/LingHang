using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontState_LinkUs_Link : System.Web.UI.Page
{
    protected Model.Member info = new Model.Member();
    protected void Page_Load(object sender, EventArgs e)
    {
        info = new DAL.DMember().GetMemberOfManagerNow();
    }
    protected void EmailSubmitBtn_Click(object sender, EventArgs e)
    {
        Model.LeaveMsg info = new Model.LeaveMsg();
        int i = 0;
        if (nameText.Value.Equals(""))
        {
            nameTextLbl.Text = "* 请填写昵称^_^";
        }
        else
        {
            nameTextLbl.Text = "";
            info.Name = nameText.Value;
            i++;
        }
        if (themeText.Value.Equals(""))
        {
            themeTextLbl.Text = "* 请填写话题^_^";
        }
        else
        {
            themeTextLbl.Text = "";
            info.Theme = themeText.Value;
            i++;
        }
        if (!linkInfoText.Value.Equals(""))
        {
            switch (linkTypeText.Value)
            {
                case "QQ":
                    if (Comment.IsQQNumber(linkInfoText.Value))
                    {
                        info.Link = "QQ:" + linkInfoText.Value;
                        i++;
                    }
                    else
                    {
                        linkLbl.Text = "* 请填写正确的QQ号码^_^";
                    }
                    break;
                case "邮箱":
                    if (Comment.IsEmail(linkInfoText.Value))
                    {
                        info.Link = "邮箱:" + linkInfoText.Value;
                        i++;
                    }
                    else
                    {
                        linkLbl.Text = "* 请填写正确的邮箱^_^";
                    }
                    break;
                case "手机":
                    if (Comment.IsPhone(linkInfoText.Value))
                    {
                        info.Link = "手机:" + linkInfoText.Value;
                        i++;
                    }
                    else
                    {
                        linkLbl.Text = "* 请填写正确的手机号码^_^";
                    }
                    break;
                default:
                    info.Link = "微信：" + linkInfoText.Value;
                    i++;
                    break;
            }
        }
        if (msgInfoBox.Text.Equals(""))
        {
            msgInfoBox.Msg = "* 请填写内容^_^";
        }
        else
        {
            msgInfoBox.Msg = "";
            info.Info = msgInfoBox.Text;
            i++;
        }

        if (i > 3)
        {
            string emailInfo="昵称："+info.Name+"<br/>"
                +"联系方式："+info.Link+"<br/>"
                + "内容：<br/>" + info.Info;
            if (Comment.sendEmail("1460300366@qq.com"/*2991830997@qq.com"*/, info.Theme, emailInfo))
            {
                Response.Write("<script language='javascript'>alert('发送成功！')</script>");
                nameText.Value = "";
                themeText.Value = "";
                linkInfoText.Value = "";
                msgInfoBox.Text = "";
            }
            else
            {
                Response.Write("<script language='javascript'>alert('发送失败！')</script>");
            }
        }
    }
}