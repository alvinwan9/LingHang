<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InfoModify.aspx.cs" Inherits="FrontState_Blogs_UserModify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        a{
            text-decoration:none;
            color:#c8e4d4;
        }
        a:hover {
            color:#9fa350;
        }
        .button {
            background-color:#5a7c7d;
            cursor:pointer;
            color:white;
            border:solid 2px #aba3e9;
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
            <div>
                <p style="color:#95bab2;">---------------------个人资料-----------------------</p>
                <p style="margin-left:20px; color:#b9b5b5;width:300px; line-height:25px; float:left">
                    姓名：<%=member.Name.Equals("")?"待完善":member.Name %><br />
                    性别：<%=member.Sex.Equals("")?"待完善":member.Sex  %><br />
                    加入领航时的年份：<%=member.JoinYear%><br />
                    QQ：<%=member.QQ %><br />
                    电话：<%=member.Tel.Equals("")?"待完善":member.Tel  %><br />
                    所属部门：<%=member.Dept.Replace("<br/>","+") %><br />
                    身份：<%=member.Duty %><br />
                    头像：<%=member.UserPic.Equals("")?"待完善":"如右"  %><br />
                </p>
                <asp:Image ID="Image2" ImageUrl='<%#ResolveUrl(member.UserPic) %>' Width="100" Height="120" runat="server" />
                <p style="padding:0px; clear:both;"></p>
            </div>
            <div style="float:left;width:100px; padding-left:20px;">
                <asp:LinkButton ID="ModifyLBtn" runat="server" OnClick="ModifyLBtn_Click">
                    \/<br />
                    \/<br />
                    \/ 修<br />
                    \/<br />
                    \/ 改<br />
                    \/<br />
                    \>>>>>>>>>>><br />
                </asp:LinkButton>
            </div>
             <div style="float:right;width:300px;">
                 <br /><br />
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="UName" runat="server" Text="姓名:" ForeColor="White"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="Name" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="USex" runat="server" Text="性别:" ForeColor="White"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButton ID="Man" runat="server" GroupName="Sex" Text="男" ForeColor="White" />
                            <asp:RadioButton ID="Woman" runat="server" GroupName="Sex" Text="女" ForeColor="White" />
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <asp:Label ID="UTel" runat="server" Text="电话:" ForeColor="White"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="Tel" runat="server"></asp:TextBox>
                        </td>
                    </tr>

                    
                    <tr>
                        <td>
                            <asp:Label ID="UPic" runat="server" Text="头像:" ForeColor="White"></asp:Label>

                        </td>
                        <td>
                            <div style="margin-top:20px;">
                                <asp:Image ID="Pic"  Width="100" Height="120" runat="server" />
                            </div>
                            <asp:FileUpload ID="PicUrl" runat="server" Width="100%" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:right;"><br />
                            <asp:Button ID="Submit" CssClass="button" runat="server" Text="修改" OnClientClick="return confirm('您确认修改该记录吗?')" OnClick="Submit_Click" />
                        </td>
                        <td style="text-align:center;"><br />
                            <asp:Button ID="Cancel" CssClass="button" runat="server" Text="重置" OnClick="Cancel_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="clear:both;"></div>
        </div>
    </form>
</body>
</html>
