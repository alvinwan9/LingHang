<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserDelete.aspx.cs" Inherits="BackState_UserDelete" %>

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
                <b>用户管理</b><span style="color: #aeacac">-删除用户</span>
            </div>
            <div class="style1">
                <asp:DataList ID="DataList1" runat="server" Width="100%" OnItemCommand="DataList1_ItemCommand">
                    <HeaderTemplate>
                        <table style="width: 100%; text-align: center">
                            <tr style="background-color: #B2D3F5;">
                                <td width="11%">姓名
                                </td>
                                <td width="11%">性别
                                </td>
                                <td width="11%">加入年份
                                </td>
                                <td width="11%">QQ
                                </td>
                                <td width="11%">电话
                                </td>
                                <td width="11%">部门
                                </td>
                                <td width="11%">职位
                                </td>
                                <td width="12%">资料是否完整
                                </td>
                                <td width="11%">操作
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 100%; text-align: center">
                            <tr>
                                <td width="11%">
                                    <%#DataBinder.Eval(Container.DataItem,"name") %>
                                </td>
                                <td width="11%">
                                    <%#DataBinder.Eval(Container.DataItem,"sex") %>
                                </td>
                                <td width="11%">
                                    <%#DataBinder.Eval(Container.DataItem,"joinYear") %>
                                </td>
                                <td width="11%">
                                    <%#DataBinder.Eval(Container.DataItem,"qq") %>
                                </td>
                                <td width="11%">
                                    <%#DataBinder.Eval(Container.DataItem,"tel") %>
                                </td>
                                <td width="11%">
                                    <%#DataBinder.Eval(Container.DataItem,"dept") %>
                                </td>
                                <td width="11%">
                                    <%#DataBinder.Eval(Container.DataItem,"duty") %>
                                </td>
                                <td width="11%">
                                    <%#DataBinder.Eval(Container.DataItem,"isFinish").ToString().Equals("1")?"是":"否" %>
                                </td>
                                <td width="11%">
                                    <asp:LinkButton ID="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id") %>' OnClientClick="return confirm('您确认删除该记录吗?')" runat="server" Text="删除" />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </form>
</body>
</html>
