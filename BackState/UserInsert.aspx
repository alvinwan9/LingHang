<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInsert.aspx.cs" Inherits="BackState_UserInsert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        .style1 {
            border: 1px solid #96C2F1;
            background-color: #EFF7FF;
            float: right;
            width: 75%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 1000px; margin-left: auto; margin-right: auto;">
            <div style="margin-bottom: 10px;">
                <b>用户管理</b><span style="color: #aeacac">-添加用户</span>
            </div>
            <fieldset style="float: left; width: 20%">
                <legend>添加</legend>
                <div style="float: left; width: 100%">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="IName" runat="server" Text="姓名"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Name" runat="server" Width="97%"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="ISex" runat="server" Text="性别"></asp:Label>
                            </td>
                            <td>
                                <asp:RadioButton ID="Man" runat="server" GroupName="Sex"  Text="男" Checked="true"/>
                                <asp:RadioButton ID="Woman" runat="server" GroupName="Sex" Text="女"/>
                                
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="IJoinYear" runat="server" Text="年份"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="JoinYear" runat="server" Width="100%">
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="IQQ" runat="server" Text="Q　Q"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="QQ" runat="server" Width="97%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="IPassword" runat="server" Text="密码"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Password" runat="server" Width="97%"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="ITel" runat="server" Text="电话"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Tel" runat="server" Width="97%"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="IDept" runat="server" Text="部门"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="Team" runat="server" Width="100%" OnTextChanged="Team_TextChanged" AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:DropDownList ID="Dept" runat="server" Width="100%">
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="IDuty" runat="server" Text="职位"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="Duty" runat="server" Width="100%">
                                </asp:DropDownList>

                            </td>
                        </tr>

                        <tr style="text-align: center;">

                            <td>
                                <asp:Button ID="Insert" runat="server" Text="提交" OnClientClick="return confirm('您确认增添该记录吗?')" OnClick="Insert_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Cancel" runat="server" Text="重置" OnClick="Cancel_Click" />
                            </td>

                        </tr>


                    </table>
                </div>
            </fieldset>
            <div class="style1">
                <asp:DataList ID="DataList1" runat="server" Width="100%">
                    <HeaderTemplate>
                        <table style="width: 100%; text-align: center">
                            <tr style="background-color: #9db6c8;">
                                <td width="11%">姓名
                                </td>
                                <td width="10%">性别
                                </td>
                                <td width="11%">加入年份
                                </td>
                                <td width="11%">QQ
                                </td>
                                <td width="11%">密码
                                </td>
                                <td width="13%">电话
                                </td>
                                <td width="11%">部门职位
                                </td>
                                <td width="11%">职位
                                </td>
                                <td width="11%">资料是否完整
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
                                <td width="10%">
                                    <%#DataBinder.Eval(Container.DataItem,"sex") %>
                                </td>
                                <td width="11%">
                                    <%#DataBinder.Eval(Container.DataItem,"joinYear") %>
                                </td>
                                <td width="11%">
                                    <%#DataBinder.Eval(Container.DataItem,"qq") %>
                                </td>
                                <td width="11%" title="<%#DataBinder.Eval(Container.DataItem,"password")%>">
                                    <%#DataBinder.Eval(Container.DataItem,"password").ToString().Length<9?DataBinder.Eval(Container.DataItem,"password"):DataBinder.Eval(Container.DataItem,"password").ToString().Substring(0,6)+".."%>
                                </td>
                                <td width="13%">
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

                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div style="clear: both"></div>

        </div>
    </form>
</body>
</html>
