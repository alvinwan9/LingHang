using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontState_LeaveMsg_LeaveMsg : System.Web.UI.Page
{
    protected DAL.DReply dre = new DAL.DReply();
    static private Paging PageList;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PageList = new Paging(new DAL.DLeaveMsg().GetAll().ToList<Object>(), 4);
            RefreshList();
        }
    }
    protected void MsgSubmitBtn_Click(object sender, EventArgs e)
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
        if (!VerifyImage1.Text.Equals(YanZhengText.Value))
        {
            VerifyTextLbl.Text = "请填写正确验证码^_^";
            return;
        }
        else
        {
            VerifyTextLbl.Text = "";
        }
        if (i >= 3)
        {
            if (new DAL.DLeaveMsg().Insert(info))
            {
                Response.Write("<script language='javascript'>alert('留言成功！')</script>");
                PageList = new Paging(new DAL.DLeaveMsg().GetAll().ToList<Object>(), 4);
                RefreshList();
                nameText.Value = "";
                themeText.Value = "";
                linkInfoText.Value = "";
                msgInfoBox.Text = "";
                YanZhengText.Value = "";
            }
            else
            {
                Response.Write("<script language='javascript'>alert('留言失败！')</script>");
            }
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
        int totalPage=PageList.GetTotalPage();
        int currentPage=PageList.GetCurrentPage();
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
        LeaveMsgList.DataSource = PageList.GetCurrentList();
        LeaveMsgList.DataBind();
    }
}

