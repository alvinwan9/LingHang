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

public partial class BackState_LMessageDelete : System.Web.UI.Page
{
   
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
   
  protected void  LeaveMassage_ItemCommand(object source, DataListCommandEventArgs e)
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
       
        if (e.CommandName == "delete")
        {
         
            DLeaveMsg info=new DLeaveMsg();
            string isSuccuss = (info.Delete(Convert.ToInt32(e.CommandArgument.ToString())) ? "true" : "false");
            Response.Write("<script language=<'javascript'>alert('" + isSuccuss + "');</script>");
        }

        if (e.CommandName == "answer")
        {
            DReply dRe = new DReply();
            int id=Convert.ToInt32(e.CommandArgument.ToString());
            LeaveMsg msgInfo = new DLeaveMsg().GetleaveMsgById(id);
            LeaveMsgLbl.Text = msgInfo.Theme;
            ReplyList.DataSource = dRe.GetreplyByparentld(id);
            ReplyList.DataBind();
        }
       


        
 
       
     

    }
}
