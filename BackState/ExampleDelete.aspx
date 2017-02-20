<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExampleDelete.aspx.cs" Inherits="BackState_ExampleDelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        .style1 {
            border: 1px solid #96C2F1;
            background-color: #EFF7FF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 1000px; margin-left: auto; margin-right: auto">
            <div style="margin-bottom: 10px;">
                <b>案例管理</b><span style="color: #aeacac">-删除案例</span>
            </div>
            <div class="style1">
                <asp:DataList ID="DataList1" runat="server" Width="100%" OnItemCommand="DataList1_ItemCommand">
                    <HeaderTemplate>
                        <table style="width: 100%; text-align: center">
                            <tr style="background-color: #B2D3F5;">
                                <td width="15%">案例名
                                </td>
                                <td width="14%">主要负责组
                                </td>
                                <td width="15%">完成时间
                                </td>
                                <td width="17%">实例网址
                                </td>
                                </td>
                                <td width="14%">类型
                                </td>
                                <td width="15%">简介
                                </td>
                                <td width="9%">操作

                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 100%; text-align: center">
                            <tr>
                                <td width="15%">
                                    <%#DataBinder.Eval(Container.DataItem,"name") %>
                                </td>
                                <td width="14%">
                                    <%#DataBinder.Eval(Container.DataItem,"mainGroup") %>
                                </td>
                                <td width="15%">
                                    <%#DataBinder.Eval(Container.DataItem,"time","{0:yyyy-MM-dd}" ) %>
                                </td>
                                <td width="17%">
                                    <a target="_blank" href='<%#DataBinder.Eval(Container.DataItem,"url") %>' title='<%#DataBinder.Eval(Container.DataItem,"url") %>'>
                                        <%#DataBinder.Eval(Container.DataItem, "url").ToString().Length<15?DataBinder.Eval(Container.DataItem,"url"):DataBinder.Eval(Container.DataItem,"url").ToString().Substring(0,15)+"..." %>
                                    </a>
                                </td>
                                </td>
                                <td width="14%">
                                    <%#DataBinder.Eval(Container.DataItem,"type") %>
                                </td>
                                <td width="15%">
                                    <a target="_blank" title='<%#DataBinder.Eval(Container.DataItem,"info")%>' style="text-decoration: none; color: black;">
                                        <%#DataBinder.Eval(Container.DataItem,"info").ToString().Length<7?DataBinder.Eval(Container.DataItem,"info"):DataBinder.Eval(Container.DataItem,"info").ToString().Substring(0,7)+"..." %>
                                    </a>
                                </td>
                                <td width="9%">
                                    <asp:LinkButton ID="Update" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id") %>' OnClientClick="return confirm('您确认删除该记录吗?')" CommandName="GetId" runat="server" Text="删除" />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>

            </div>
    </form>
</body>
</html>
