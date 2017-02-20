<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WriteBlogs.aspx.cs" Inherits="FrontState_WriteBlogs" %>

<%@ Register Src="~/UserControl/MyEditBox.ascx" TagPrefix="uc1" TagName="MyEditBox" %>
<%@ Register Src="~/UserControl/MyEditBoxWithouBorder.ascx" TagPrefix="uc1" TagName="MyEditBoxWithouBorder" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../../UserControl/xhEditor/jquery/jquery-1.4.4.min.js"></script>
    <script src="../../UserControl/xhEditor/xheditor-1.1.14-en.min.js"></script>
    <script src="../../UserControl/xhEditor/xheditor-1.1.14-zh-cn.min.js"></script>
    <script src="../../UserControl/xhEditor/xheditor-1.1.14-zh-tw.min.js"></script>


    <style type="text/css">
        .title {
            background-color:#16232d;
            color:#9fc6ba;
            border:0px;
            width:94%;
            height:30px;
            font-size:25px;
            border-bottom:inset 2px #101268;
            text-align:center;
        }
        .content {
            border:0px;
            width:94%;
            height:500px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
            <div style=" width: 100%">
                <p style="color:#95bab2;">-----------------------写博客------------------------</p>
                <div>
                    <input id="BlogNameText" runat="server" class="title" type="text" value="博客标题" onmouseout="javascript:if(this.value=='')this.value='博客标题';" onfocus="javascript:if(this.value=='博客标题')this.value='';"/>
                </div><br />
                <div>
                    <asp:TextBox ID="BlogContentBox" CssClass="content" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <script type="text/javascript">
                    <!--
                        $(pageInit);
                        function pageInit() {
                            $('#BlogContentBox').xheditor({ tools: 'Pastetext,Blocktag,Fontface,FontSize,Bold,Italic,Underline,Strikethrough,FontColor,BackColor,Removeformat,Align,Outdent,Indent,Link,Unlink,Emot,Preview', showBlocktag: true, internalScript: false, internalStyle: false, forcePtag: true, upImgUrl: "xhEditor/demos/upload.aspx", upImgExt: "jpg,jpeg,gif,png", upMediaUrl: "xhEditor/demos/upload.aspx", upMediaExt: "swf,wmv,avi,wma,mp3,mid" });
                        }
                    //-->
                    </script> 
                </div>
                <div >
                <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Insert_Click" />
                <input type="reset" title="重置" align="center"/>
                </div>
               
            </div>
    </form>
</body>
</html>
