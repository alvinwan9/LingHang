<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NoticeSelect.aspx.cs" Inherits="BackState_NoticeSelect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>NoticeSelect</title>
    <style>
        .table {
            width:450px;
            margin:0,50px,0,20px;
            float:left;            
        }
        .table2 {
            margin-left:50px;;
            float:left;   
        }
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
        <div class="table">
            <asp:DropDownList ID="SelectDropDownList" runat="server" OnSelectedIndexChanged="SelectDropDownList_SelectedIndexChanged">
                <asp:ListItem Value="0" Selected="True">查询所有</asp:ListItem>
                <asp:ListItem Value="1">按标题查找</asp:ListItem>
                <asp:ListItem Value="2">查找最近公告</asp:ListItem>
            </asp:DropDownList> 
            <asp:TextBox ID="TitleSelectBox" runat="server"></asp:TextBox>
            <asp:Button ID="SelectBtn" runat="server" Text="查找" OnClick="SelectBtn_Click" />
            <asp:DataList ID="NoticeDatalistList" OnItemCommand="NoticeDatalistList_ItemCommand" runat="server">
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
                            <asp:LinkButton ID="LookBtn" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id") %>' CommandName="LookOperate" runat="server">查看</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:DataList>  
         </div>
        <div class="table2">
                <fieldset style="width:auto;">
                    <legend>最近公告</legend>
                    <p>标题：<asp:Label ID="TitleLbl" runat="server" Text="Label"></asp:Label><br /></p>
            
                    <p>时间：<asp:Label ID="TimeLbl" runat="server" Text="Label"></asp:Label><br /></p>
            
                    <p>作者：<asp:Label ID="AuthorLbl" runat="server" Text="Label"></asp:Label><br /></p>
            
                    <fieldset style="width:auto;">
                        <legend>内容</legend>
                        <div id="infoBox" style="width:400px; height:200px;" runat="server"></div>
                    </fieldset>
                  </fieldset>
        </div>

        <div style="clear: both;">&nbsp;</div>

<%--        <%=content %>--%>
    </div>

    </form>
</body>
</html>
