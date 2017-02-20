using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_VerifyImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetIamge();
    }

    private void GetIamge()
    {
        string chkCode = string.Empty;
        //颜色列表，用于验证码、噪线、噪点 
        Color[] color = new Color[] { Color.Black, Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Brown, Color.Brown, Color.DarkBlue };
        //字体列表，用于验证码 
        string[] font = new string[] { "Times New Roman", "MS Mincho", "Book Antiqua", "Gungsuh", "PMingLiU", "Impact" };
        chkCode = Session["VerifyText"].ToString();
        Random rnd = new Random();
        Bitmap bmp = new Bitmap(100, 40);
        Graphics g = Graphics.FromImage(bmp);
        g.Clear(Color.White);
        //画噪线 
        for (int i = 0; i < 10; i++)
        {
            int x1 = rnd.Next(100);
            int y1 = rnd.Next(40);
            int x2 = rnd.Next(100);
            int y2 = rnd.Next(40);
            Color clr = color[rnd.Next(color.Length)];
            g.DrawLine(new Pen(clr), x1, y1, x2, y2);
        }
        //画验证码字符串 
        for (int i = 0; i < chkCode.Length; i++)
        {
            string fnt = font[rnd.Next(font.Length)];
            Font ft = new Font(fnt, 18);
            Color clr = color[rnd.Next(color.Length)];
            g.DrawString(chkCode[i].ToString(), ft, new SolidBrush(clr), (float)i * 20 + 8, (float)8);
        }
        
        //画噪点 
        for (int i = 0; i < 100; i++)
        {
            int x = rnd.Next(bmp.Width);
            int y = rnd.Next(bmp.Height);
            Color clr = color[rnd.Next(color.Length)];
            bmp.SetPixel(x, y, clr);
        }
        //清除该页输出缓存，设置该页无缓存 
        Response.Buffer = true;
        Response.ExpiresAbsolute = System.DateTime.Now.AddMilliseconds(0);
        Response.Expires = 0;
        Response.CacheControl = "no-cache";
        Response.AppendHeader("Pragma", "No-Cache");
        //将验证码图片写入内存流，并将其以 "image/Png" 格式输出 
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        try
        {
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            Response.ClearContent();
            Response.ContentType = "image/Png";
            Response.BinaryWrite(ms.ToArray());
        }
        finally
        {
            //显式释放资源 
            //Response.Write(bmp.ToString());

            //MyImage = bmp;
            bmp.Dispose(); 
            g.Dispose(); 
        }
    }
}