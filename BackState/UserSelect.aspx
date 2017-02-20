<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserSelect.aspx.cs" Inherits="BackState_UserSelect" %>

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

        .table {
            width: 100%;
            text-align: center;
        }

        .style1 {
            border: 1px solid #96C2F1;
            background-color: #EFF7FF;
            float: left;
            width: 75%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <div style="margin-bottom: 10px;">
                <b>用户管理</b><span style="color: #aeacac">-查找用户</span>
            </div>
            <div>
                <table style="font-size: 15px;">

                    <tr>
                        <td>·姓名:</td>
                        <td >
                            <asp:TextBox ID="SearchName" runat="server"></asp:TextBox>
                        </td>
                        <td>·加入年份:</td>
                        <td>
                            <asp:DropDownList ID="SearchJoinYear" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>·团队部门:</td>
                        <td>
                            <asp:DropDownList ID="SearchTeam" runat="server" OnTextChanged="SearchTeam_TextChanged" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:DropDownList ID="SearchDept" runat="server"></asp:DropDownList>
                        </td>
                        <td>·职位:</td>
                        <td>

                            <asp:DropDownList ID="SearchDuty" runat="server"></asp:DropDownList>
                        </td>

                        <td>
                            <asp:Button ID="SearchButton" runat="server" Text="搜索" OnClick="SearchButton_Click" />
                        </td>
                        <td>
                            <asp:Button ID="Cancel" runat="server" Text="重置" OnClick="Cancel_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="style1">
                <asp:DataList ID="DataList1" runat="server" Width="100%">
                    <HeaderTemplate>
                        <table class="table">
                            <tr style="background-color: #9db6c8;">
                                <td width="13%">姓名
                                </td>
                                <td width="11%">性别
                                </td>
                                <td width="13%">加入年份
                                </td>
                                <td width="13%">QQ
                                </td>
                                <td width="15%">电话
                                </td>
                                <td width="13%">部门
                                </td>
                                <td width="11%">职位
                                </td>
                                <td width="11%">资料是否完整
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table class="table">
                            <tr>
                                <td width="13%">
                                    <%#DataBinder.Eval(Container.DataItem,"name") %>
                                </td>
                                <td width="11%">
                                    <%#DataBinder.Eval(Container.DataItem,"sex") %>
                                </td>
                                <td width="13%">
                                    <%#DataBinder.Eval(Container.DataItem,"joinYear") %>
                                </td>
                                <td width="13%">
                                    <%#DataBinder.Eval(Container.DataItem,"qq") %>
                                </td>
                                <td width="15%">
                                    <%#DataBinder.Eval(Container.DataItem,"tel") %>
                                </td>
                                <td width="13%">
                                    <%#DataBinder.Eval(Container.DataItem,"dept") %>
                                </td>
                                <td width="11%">
                                    <%#DataBinder.Eval(Container.DataItem,"duty") %>
                                </td>
                                <td width="11%">
                                    <%#DataBinder.Eval(Container.DataItem,"isFinish").ToString().Equals("1")?"是":"否" %>
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
