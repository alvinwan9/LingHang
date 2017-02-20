using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_VerifyImage : System.Web.UI.UserControl
{
    public string Text
    {
        get{ return VerifyTextLbl.Text; }
        set { VerifyTextLbl.Text = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        string chkCode = string.Empty;
        //验证码的字符集，去掉了一些容易混淆的字符 
        char[] character = new char[] { '2', '3', '4', '5', '6', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'R', 'S', 'T', 'W', 'X', 'Y' };
        Random rnd = new Random();
        //生成验证码字符串 
        for (int i = 0; i < 4; i++)
        {
            chkCode += character[rnd.Next(character.Length)];
        }
        Text = chkCode;
        Session["VerifyText"] = chkCode;

        if (IsPostBack)
        {
            VerifyImg.Visible = true;
            VerifyImg.ImageUrl = ResolveUrl("~/UserControl/VerifyImage.aspx");
        }
    }

    protected void ChangeImageLBtn_Click(object sender, EventArgs e)
    {
        string chkCode = string.Empty;
        //验证码的字符集，去掉了一些容易混淆的字符 
        char[] character = new char[] { '2', '3', '4', '5', '6', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'R', 'S', 'T', 'W', 'X', 'Y' };
        Random rnd = new Random();
        //生成验证码字符串 
        for (int i = 0; i < 4; i++)
        {
            chkCode += character[rnd.Next(character.Length)];
        }
        Text = chkCode;
        Session["VerifyText"] = chkCode;
        VerifyImg.Visible = true;
        VerifyImg.ImageUrl = ResolveUrl("~/UserControl/VerifyImage.aspx");
    }
}