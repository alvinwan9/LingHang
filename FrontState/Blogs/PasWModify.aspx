<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PasWModify.aspx.cs" Inherits="FrontState_Blogs_PasWModify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .button {
            background-color:#5a7c7d;
            cursor:pointer;
            color:white;
        }
        .button:hover {
            background-color:#bbdecc;
            cursor:pointer;
            color:#02171d;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p style="color:#95bab2;">---------------------密码重置-----------------------</p>
            <div style="color:#948585; margin-left:20px;"><br />
                原密码：<asp:TextBox ID="OldPsdBox" TextMode="Password" runat="server"></asp:TextBox>
                <asp:Label ID="OldPsdLbl" ForeColor="#ff6666" runat="server" Text=""></asp:Label><br /><br />
                新密码：<asp:TextBox ID="NewPsdBox" TextMode="Password" runat="server"></asp:TextBox><br /><br />
                请确认：<asp:TextBox ID="ForSureBox" TextMode="Password" runat="server"></asp:TextBox>
                <asp:Label ID="ForSureLbl" runat="server"  ForeColor="#ff6666" Text=""></asp:Label><br /><br />

                <asp:Button CssClass="button" ID="ModifyBtn" runat="server" Text="修改" OnClick="ModifyBtn_Click" />
            </div>
        </div>
    </form>
</body>
</html>
