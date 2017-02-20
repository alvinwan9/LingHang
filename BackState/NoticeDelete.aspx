<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NoticeDelete.aspx.cs" Inherits="BackState_NoticeDelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>NoticeDelete</title>
    <style>
        th {
            background-color:aliceblue;
            width:100px;
        }
        td {
            text-align:center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DataList ID="NoticeDatalistListDelete" OnItemCommand="NoticeDeleteCommand" runat="server">
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
                        <asp:LinkButton ID="DeleteBtn" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id") %>'  OnClientClick="return confirm('您确认删除该记录吗?')" CommandName="DeleteOperate" runat="server">删除</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:DataList>    
    </div>
    </form>
</body>
</html>
