<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ArticleModify.aspx.cs" Inherits="BackState_BlogsModify" %>

<%@ Register Src="~/UserControl/MyEditBox.ascx" TagPrefix="uc1" TagName="MyEditBox" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        th {
            background-color:aliceblue;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
       <table>
           <tr>
               <th>标题</th>
               <th>内容所属组</th>
               <th>是否标记重点</th>
           </tr>
           <tr>
              <td>
                  <asp:TextBox ID="SearchTitle" Text="" runat="server"></asp:TextBox>
              </td>
              <td>
                  <asp:DropDownList ID="SearchType" runat="server"></asp:DropDownList>
              </td>
               <td>
                  <asp:DropDownList ID="SearchIsImportant" runat="server"></asp:DropDownList>
              </td>
              <td>
                  <asp:Button ID="SearchButton" runat="server" Text="搜索" OnClick="SearchButton_Click" />
              </td>
             </tr>
       </table>
    </div>
        <div style=" width: 75%;text-align:center">
            <asp:DataList ID="Article" runat="server" Width="100%"  OnItemCommand="Article_ItemCommand">
            <HeaderTemplate>
                <table style="width:100%;text-align:center;">
                    <tr>
                        <th style="width:10%">标题</th>
                        <th style="width:10%">作者</th>
                        <th style="width:40%">内容</th>
                        <th style="width:10%">所属组</th>
                        <th style="width:10%">发布时间</th>
                        <th style="width:10%">是否标记</th>
                        <th style="width:10%">操作</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
                        <td style="width:10%">
                            <%#DataBinder.Eval(Container.DataItem,"title") %>
                        </td>
                        <td style="width:10%">
                            <%#DataBinder.Eval(Container.DataItem,"name") %>
                        </td>
                        <td style="width:40%">
                            <%#DataBinder.Eval(Container.DataItem,"info") %>
                        </td>
                        <td style="width:10%">
                            <%#DataBinder.Eval(Container.DataItem,"type") %>
                        </td>
                        <td style="width:10%">
                            <%#DataBinder.Eval(Container.DataItem,"time") %>
                        </td>
                        <td style="width:10%">
                            <%#DataBinder.Eval(Container.DataItem,"isImportant") %>
                        </td>
                        <td style="width:10%">
                            <%#DataBinder.Eval(Container.DataItem,"isImportant").ToString().Equals("1")?"是":"否" %>
                        </td>
                        <td style="width:10%">
                           <asp:Button ID="Update" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id") %>' CommandName="GetArticleById"  runat="server" Text="修改" />
                        </td>
                    </tr>
            </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
        </asp:DataList>
        </div>
    <div style="width:1000px;text-align:center">
            <fieldset style="width:0px;">
                <legend>修改</legend>
                <div style=" width: 100%">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="UTitle" runat="server" Text="标题"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Title" Width="470px" runat="server"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="UName" runat="server" Text="发布人"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Name" Width="470px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="UType" runat="server" Text="所属组"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="Type" Width="470px" runat="server"></asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="UIsImportant" runat="server" Text="标记"></asp:Label>
                            </td>
                            <td>&nbsp;
                            <asp:RadioButton ID="Yes" runat="server" Text="是" GroupName="IsFinish" />
                                &nbsp;
                            <asp:RadioButton ID="No" runat="server" Text="否" Checked="true" GroupName="IsFinish" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <uc1:MyEditBox runat="server" ID="Info" Width="500" Height="200" />
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Button ID="Submit" runat="server" Text="提交" OnClientClick="return confirm('您确认修改该记录吗?')" OnClick="Submit_Click" />
                            </td>

                        </tr>
                    </table>
                </div>
            </fieldset>
        </div>
    </form>
</body>
</html>
