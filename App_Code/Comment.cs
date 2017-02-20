using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

public class Comment
{
    /// <summary>
    /// 发邮件
    /// </summary>
    /// <param name="to"></param>
    /// <param name="title"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    public static bool sendEmail(string to, string title, string content)
    {
        try
        {
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.163.com");
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("LingHangYouXiang@163.com", "linghang");
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;

            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage("LingHangYouXiang@163.com", to, title, content);
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true; // 允许邮件主体使用HTML
            message.Priority = System.Net.Mail.MailPriority.High;
            client.Send(message);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    /// <summary>
    /// 文件上传（asp:FileUpload的对象myControl，服务器地址severUrl）
    /// </summary>
    /// <param name="myControl"></param>
    /// <param name="severUrl"></param>
    /// <returns></returns>
    public static bool SaveImg(System.Web.UI.WebControls.FileUpload myControl, string severUrl,string picName)
    {
        //获取文件的后缀名picLastName
        string localUrl = myControl.PostedFile.FileName;//获取上传的文件路径（本地路径）
        int index = localUrl.LastIndexOf(".");
        string picLastName = localUrl.Substring(index);
        if (picLastName != ".jpeg" && picLastName != ".jpg" && picLastName != ".gif" && picLastName != ".png" && picLastName != ".bmp")
        {
            return false;
        }
        //上传后的文件名
        string pictureName = null;
        pictureName = picName + picLastName;

        try
        {
            myControl.SaveAs(severUrl+"/" + pictureName);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    /// <summary>
    /// 邮箱的验证
    /// </summary>
    /// <param name="mail"></param>
    /// <returns></returns>
    public static bool IsEmail(string mail)
    {
        string email_match = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
        return System.Text.RegularExpressions.Regex.IsMatch(mail, email_match);
    }
    /// <summary>
    /// 电话号码的验证
    /// </summary>
    /// <param name="phone"></param>
    /// <returns></returns>
    public static bool IsPhone(string phone)
    {
        string phone_match = @"^1[3|4|5|8][0-9]\d{4,8}$";
        return System.Text.RegularExpressions.Regex.IsMatch(phone, phone_match);
    }
    /// <summary>
    /// QQ号码的验证
    /// </summary>
    /// <param name="qq"></param>
    /// <returns></returns>
    public static bool IsQQNumber(string qq)
    {
        string qq_match = @"[1-9][0-9]\{4,\}";
        return System.Text.RegularExpressions.Regex.IsMatch(qq, qq_match);
    }
}
