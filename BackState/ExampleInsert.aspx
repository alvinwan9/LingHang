<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExampleInsert.aspx.cs" Inherits="BackState_ExampleInsert" %>

<%@ Register Src="~/UserControl/MyEditBox.ascx" TagPrefix="uc1" TagName="MyEditBox" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        .style1 {
            margin-left: auto;
            margin-right: auto;
            border: 1px solid #96C2F1;
            background-color: #EFF7FF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 1000px; margin-left: auto; margin-right: auto;">
            <div style="margin-bottom: 10px;">
                <b>案例管理</b><span style="color: #aeacac">-插入案例</span>
            </div>
            <div class="style1">
                <asp:DataList ID="DataList1" runat="server" Width="100%" OnItemCommand="DataList1_ItemCommand" >
                    <HeaderTemplate>
                        <table style="width: 100%; text-align: center">
                            <tr style="background-color: #B2D3F5;">
                                <td width="13%">案例名
                                </td>
                                <td width="12%">主要负责组
                                </td>
                                <td width="12%">完成时间
                                </td>
                                <td width="15%">实例网址
                                </td>
                                <td width="13%">首页图片
                                </td>
                                <td width="12%">类型
                                </td>
                                <td width="13%">简介
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 100%; text-align: center">
                            <tr>
                                <td width="13%">
                                    <%#DataBinder.Eval(Container.DataItem,"name") %>
                                </td>
                                <td width="12%">
                                    <%#DataBinder.Eval(Container.DataItem,"mainGroup") %>
                                </td>
                                <td width="12%">
                                    <%#DataBinder.Eval(Container.DataItem,"time","{0:yyyy-MM-dd}" ) %>
                                </td>
                                <td width="15%">
                                    <a target="_blank" href='<%#DataBinder.Eval(Container.DataItem,"url") %>' title='<%#DataBinder.Eval(Container.DataItem,"url") %>'>
                                        <%#DataBinder.Eval(Container.DataItem, "url").ToString().Length<15?DataBinder.Eval(Container.DataItem,"url"):DataBinder.Eval(Container.DataItem,"url").ToString().Substring(0,15)+"..." %>
                                    </a>
                                </td>
                                </td>
                                <td width="13%">
                                    <asp:LinkButton ID="ShowPic" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id")%>'>点击查看</asp:LinkButton>

                                </td>
                                <td width="12%">
                                    <%#DataBinder.Eval(Container.DataItem,"type") %>
                                </td>
                                <td width="13%">
                                    <a target="_blank" title='<%#DataBinder.Eval(Container.DataItem,"info")%>' style="text-decoration: none; color: black;">
                                        <%#DataBinder.Eval(Container.DataItem,"info").ToString().Length<7?DataBinder.Eval(Container.DataItem,"info"):DataBinder.Eval(Container.DataItem,"info").ToString().Substring(0,7)+"..." %>
                                    </a>
                                </td>

                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div>
            <fieldset style="width: 50%;float:left;">
                <legend>插入</legend>
                <div style="width: 100%;">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="IName" runat="server" Text="项目案例名"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Name" runat="server" Width="100%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="IMainGroup" runat="server" Text="主要负责组"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="MainGroup" runat="server" Width="100%"></asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="ITime" runat="server" Text="完 成时 间"></asp:Label>

                            </td>
                            <td>

                                <asp:DropDownList ID="Year" runat="server" OnTextChanged="Month_TextChanged" AutoPostBack="true"></asp:DropDownList>
                                <asp:DropDownList ID="Month" runat="server" OnTextChanged="Month_TextChanged" AutoPostBack="true"></asp:DropDownList>
                                <asp:DropDownList ID="Day" runat="server"></asp:DropDownList>

                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="IUrl" runat="server" Text="实 例网 址"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Url" runat="server" Width="100%"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="IPic" runat="server" Text="首 页图 片"></asp:Label>

                            </td>
                            <td>
                                <asp:FileUpload ID="Pic" runat="server" Width="100%" />
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="IType" runat="server" Text="类　　　型"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Type" runat="server" Width="100%"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                <uc1:MyEditBox runat="server" ID="Info" Width="470" MyTool="Cut,Copy,Paste,Fontface,Bold,Italic,Link,Unlink" Height="150" />
                            </td>
                        </tr>

                        <tr style="text-align: center">

                            <td>
                                <asp:Button ID="Submit" runat="server" Text="提交" OnClientClick="return confirm('您确认增加此记录吗?')" OnClick="Submit_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Cancel" runat="server" Text="重置" OnClick="Cancel_Click" />
                            </td>

                        </tr>


                    </table>
                </div>

            </fieldset>
            <div id="Show" style="display:none "   runat="server">
                <asp:Image ID="ShowImg" runat="server"   Width="300px"  Height="420px" ImageUrl="~/FrontState/ExampleShow/ExampleImg/暂无图片.jpg"  />

            </div>

            </div>
        </div>
    </form>
</body>
</html>
