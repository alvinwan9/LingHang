using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Model;

public partial class BackState_LMessageReplay : System.Web.UI.Page
{
    static int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        DLeaveMsg dleavemsg = new DLeaveMsg();

        LeaveMassage.DataSource = dleavemsg.GetAll();
        LeaveMassage.DataBind();
    }

  protected void    Button_Click(object sender, EventArgs e)
    {   
        DLeaveMsg dleavemsg = new DLeaveMsg();
        LeaveMassage.DataSource = dleavemsg.GetleaveMsgByTheme(SearchName.Text);
      
        LeaveMassage.DataBind();
    }

    protected void LeaveMassage_ItemCommand(object source, DataListCommandEventArgs e)
  {
     
      if (e.CommandName == "detail")
      {
          string theme = e.CommandArgument.ToString();
          textDiv.InnerHtml = theme;
      }
      if (e.CommandName == "Detail")
      {
          string info = e.CommandArgument.ToString();
          textDiv.InnerHtml = info;
      }
     
        if (e.CommandName == "answer")
        {
            DReply dRe = new DReply();
            id = Convert.ToInt32(e.CommandArgument.ToString());
            IsReplyingLbl.Text ="正在给留言——"+ new DLeaveMsg().GetleaveMsgById(id).Theme+"回复：";
        }
    }




    protected void Button1_Click(object sender, EventArgs e)
    {
        DReply dRe = new DReply();
        Reply info=new Reply();
        info.Parentld=id;
        info.Name="petter";
        info.Time=DateTime.Now;
        info.Info=ReplyBox.Text;
        if (dRe.Insert(info))
        {
            Response.Write("成功！！！");
            IsReplyingLbl.Text = "";
        }
    }
}
