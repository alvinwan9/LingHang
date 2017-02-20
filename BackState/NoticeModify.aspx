<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NoticeModify.aspx.cs" Inherits="BackState_NoticeModify" %>

<%@ Register Src="~/UserControl/MyEditBox.ascx" TagPrefix="uc1" TagName="MyEditBox" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>NoticeModify</title>
    <style>
        th {
            background-color:aliceblue;
            width:100px;
        }
        td {
            text-align:center;
        }
        .table {
            margin:0,50px,0,20px;
            float:left;            
        }
        .table2 {
            margin:0,0,0,0;
            float:left;   
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <div class="table">
                <asp:DataList ID="NoticeDatalistListUpdate" BorderWidth="0" OnItemCommand="NoticeUpdateCommand" runat="server">
                <HeaderTemplate>
                    <table id="tb">
                        <tr>
                            <th>ID</th>
                            <th>标题</th>
                            <th>发布时间</th>
                            <th>发布人</th>
                            <th>操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#DataBinder.Eval(Container.DataItem,"id") %></td>
                        <td><%#DataBinder.Eval(Container.DataItem,"title") %></td>
                        <td><%#DataBinder.Eval(Container.DataItem,"time") %></td>
                        <td><%#DataBinder.Eval(Container.DataItem,"author" )%></td>
                        <td>
                            <asp:LinkButton ID="UpdateBtn"  OnClientClick="return confirm('您确认修改该记录吗?')" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id") %>' CommandName="UpdateOperate" runat="server">修改</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:DataList>  
            </div>
            <div class="table2">
           <fieldset style="width:0px;">
               <legend>修改</legend>
                <p>标题：<asp:TextBox ID="TitleUpdateBox"  Width="350px" runat="server"></asp:TextBox></p>
                <p>作者：<asp:TextBox ID="AuthorUpdateBox" Width="350px" runat="server"></asp:TextBox><br /></p>
                <p>
                    <uc1:MyEditBox runat="server" ID="InfoUpdateBox"  Width="325" Height="200" MyTool="Simple"/>
                </p>
                <asp:Button ID="UpdateBtn"  OnClientClick="return confirm('您确认修改该记录吗?')" runat="server" Text="修改" OnClick="NoticeBtn_Click" />
           </fieldset>
         </div>   
    </div>
    </form>
</body>
</html>
