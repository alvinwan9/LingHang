<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NoticeInsert.aspx.cs" Inherits="BackState_NoticeInsert" %>

<%@ Register Src="~/UserControl/MyEditBox.ascx" TagPrefix="uc1" TagName="MyEditBox" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>NoticeInsert</title>
    <style>
       .insert {
            width:400px;
            margin:20px,50px,30px,20px;
            float:left;            
        }
        .table {
            margin-left:50px;
            float: left;
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
        <div class="insert">
            <fieldset style="width:auto;">
            <legend>公告发布栏</legend>
            <p>标题:<asp:TextBox ID="TitleBox"  Width="310px" runat="server"></asp:TextBox></p>
            <p>
               <uc1:MyEditBox runat="server" ID="InfoBox"  Width="325" Height="200" MyTool="Simple"/>
            </p>            
            <asp:Button ID="NoticeBtn"  OnClientClick="return confirm('您确认增添该记录吗?')" runat="server" Text="发布" OnClick="NoticeBtn_Click" />
            </fieldset>
        </div>
        <div class="table">
            <asp:DataList ID="NoticeDatalistListInsert" OnItemCommand="NoticeCommand" runat="server">
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
                        <asp:LinkButton ID="DeleteBtn"  CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id") %>' CommandName="LookOperate" runat="server">查看</asp:LinkButton>
                    </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:DataList>  
            <fieldset id="showInfo" runat="server" style="display:none;">
                  <legend>内容</legend>
                  <div id="infoDiv" runat="server"></div>
            </fieldset> 
        </div>
        <div style="clear:both"></div>
    </div>
        
    </form>
</body>
</html>
