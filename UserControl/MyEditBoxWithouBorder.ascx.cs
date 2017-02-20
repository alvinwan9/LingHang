using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_MyEditBoxWithouBorder : System.Web.UI.UserControl
{
    public int Height
    {
        get;
        set;
    }
    public int Width
    {
        get;
        set;
    }
    public string Msg
    {
        get { return MyEditBoxLbl.Text; }
        set { MyEditBoxLbl.Text = value; }
    }
    private string myTool;
    /// <summary>
    /// 工具集合字符串
    /// </summary>
    public string MyTool
    {
        get { return myTool; }
        set
        {
            switch (value)
            {
                case "Simple":
                    myTool = Simple;
                    break;
                case "Standard":
                    myTool = Standard;
                    break;
                case "Completed":
                    myTool = Completed;
                    break;
                case "Extra":
                    myTool = Extra;
                    break;
                default:
                    myTool = value;
                    break;
            }
        }
    }
    public string Text
    {
        get { return MyEditBox.Text; }
        set { MyEditBox.Text = value; }
    }
    private string IDStr;
    //工具集合种类
    public static string Simple = "Cut,Copy,Paste,Fontface,Bold,Italic,FontColor,Link,Unlink,Emot";
    public static string Standard = "Cut,Copy,Paste,Fontface,Bold,Italic,FontColor,BackColor,Removeformat,Align,Outdent,Indent,Link,Unlink";
    public static string Completed = "Cut,Copy,Paste,Fontface,Bold,Italic,Underline,Strikethrough,FontColor,BackColor,Removeformat,Align,Outdent,Indent,Link,Unlink,Emot";
    public static string Extra = "Cut,Copy,Paste,Pastetext,Blocktag,Fontface,FontSize,Bold,Italic,Underline,Strikethrough,FontColor,BackColor,Removeformat,Align,Outdent,Indent,Link,Unlink,Emot,Img";
    /// <summary>
    /// 构造函数（设置默认样式）
    /// </summary>
    public UserControl_MyEditBoxWithouBorder()
    {
        Height = 400;
        Width = 500;
        MyTool = "Cut,Copy,Paste,Fontface,Bold,Italic,Underline,Strikethrough,FontColor,BackColor,Removeformat,Align,Outdent,Indent,Link,Unlink,Emot";
    }

    public void Refresh()
    {
        IDStr = this.ID.ToString();
        Response.Write("<script type='text/javascript'>"
            + "function pageInit() {"
                + "$('" + "#" + IDStr + "_MyEditBox" + "').xheditor({ tools: '" + MyTool + ",Preview', showBlocktag: true, internalScript: false, internalStyle: false, forcePtag: true, upImgUrl: 'xhEditor/demos/upload.aspx', upImgExt: 'jpg,jpeg,gif,png', upMediaUrl: 'xhEditor/demos/upload.aspx', upMediaExt: 'swf,wmv,avi,wma,mp3,mid' });"
            + "}"
            + "</script>");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MyEditBox.Width = Width;
            MyEditBox.Height = Height;
        }
        Refresh();
    }
}