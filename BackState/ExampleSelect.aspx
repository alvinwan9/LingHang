<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExampleSelect.aspx.cs" Inherits="BackState_ExampleSelect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        .main {
            width: 1000px;
            margin-left: auto;
            margin-right: auto;
        }

        .search {
        }

        .table {
            width: 100%;
            text-align: center;
        }

        .style1 {
            border: 1px solid #96C2F1;
            background-color: #EFF7FF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <div style="margin-bottom: 10px;">
                <b>案例管理</b><span style="color: #aeacac">-查找案例</span>
            </div>
            <div style="margin-bottom: 5px; width:100%;">
                <table class="search">
                    <tr>
                        <td>项目案例名</td>

                        <td>
                            <asp:TextBox ID="SearchByName" runat="server"></asp:TextBox>
                        </td>
                        <td>类型</td>
                        <td>
                            <asp:TextBox ID="SearchByType" runat="server"></asp:TextBox>
                        </td>
                        <td>主要负责组</td>
                        <td>
                            <asp:DropDownList ID="SearchByDept" runat="server"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="SearchButton" runat="server" Text="搜索" OnClick="SearchButton_Click" />
                            <asp:Button ID="Candel" runat="server" Text="重置" OnClick="Candel_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="style1">

                <asp:DataList ID="DataList1" runat="server" Width="100%" OnItemCommand="DataList1_ItemCommand">
                    <HeaderTemplate>

                        <table class="table">
                            <tr style="background-color: #B2D3F5;">
                                <td style="width: 14%;">项目案例名
                                </td>
                                <td style="width: 14%;">主要负责组
                                </td>
                                <td style="width: 14%;">完成时间
                                </td>
                                <td style="width: 16%;">实例网址
                                </td>
                                <td style="width: 12%;">首页图片
                                </td>
                                <td style="width: 14%;">类型
                                </td>
                                <td style="width: 16%;">简介
                                </td>
                            </tr>
                        </table>

                    </HeaderTemplate>
                    <ItemTemplate>
                        <table class="table">
                            <tr>
                                <td width="14%">
                                    <%#DataBinder.Eval(Container.DataItem,"name") %>
                                </td>
                                <td width="14%">
                                    <%#DataBinder.Eval(Container.DataItem,"mainGroup") %>
                                </td>
                                <td width="14%">
                                    <%#DataBinder.Eval(Container.DataItem,"time","{0:yyyy-MM-dd}" ) %>
                                </td>
                                <td width="16%">
                                    <a target="_blank" href='<%#DataBinder.Eval(Container.DataItem,"url") %>' title='<%#DataBinder.Eval(Container.DataItem,"url") %>'>
                                        <%#DataBinder.Eval(Container.DataItem, "url").ToString().Length<15?DataBinder.Eval(Container.DataItem,"url"):DataBinder.Eval(Container.DataItem,"url").ToString().Substring(0,15)+"..." %>                                </td>
                                <td width="12%">
                                    <asp:LinkButton ID="ShowPic" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id")%>'>点击查看</asp:LinkButton>
                                </td>
                                <td width="14%">
                                    <%#DataBinder.Eval(Container.DataItem,"type") %>
                                </td>
                                <td width="16%">
                                    <a title='<%#DataBinder.Eval(Container.DataItem,"info")%>' style="text-decoration: none; color: black;">
                                        <%#DataBinder.Eval(Container.DataItem,"info").ToString().Length<7?DataBinder.Eval(Container.DataItem,"info"):DataBinder.Eval(Container.DataItem,"info").ToString().Substring(0,7)+"..." %>
                                    </a>
                                </td>

                            </tr>
                        </table>
                    </ItemTemplate>

                </asp:DataList>
            </div>
            <div id="Show" style="display: none;width:50%;" runat="server" >
                <asp:Image ID="ShowImg"   runat="server" Width="300px" Height="420px"   ImageUrl="~/FrontState/ExampleShow/ExampleImg/暂无图片.jpg" />

            </div>
        </div>
    </form>
</body>
</html>
