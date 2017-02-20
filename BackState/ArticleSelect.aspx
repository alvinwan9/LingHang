<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ArticleSelect.aspx.cs" Inherits="BackState_BlogsSelect" %>

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
    <div>
        <asp:DataList ID="Article" runat="server" Width="100%" >
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
                        <td></td>
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
