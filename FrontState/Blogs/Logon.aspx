<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Logon.aspx.cs" Inherits="FrontState_Blogs_Logon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../../CSS/Blog/logon.css" rel="stylesheet" />
    <title>个人中心</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="whole">
    <div class="main">
    	<div class="passage">
        	<p>领航工作室登陆界面</p>
        </div>
        <div class="load">
            <span>用户名：</span>
            <input id="UserNameText" runat="server"  type="text"/>
            <br /><br />
            <span id="pass">密&nbsp;&nbsp;&nbsp;码：</span>
            <input id="PasswordText" runat="server"  type="password" />
            <br />
            <br />
            <asp:Button ID="LogonBtn" CssClass="button" runat="server" Text="登录" OnClick="LogonBtn_Click" />
        </div>
    </div>
   </div>
    </form>
</body>
</html>
