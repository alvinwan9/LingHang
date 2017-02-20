<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="LMessageDelete.aspx.cs" Inherits="BackState_LMessageDelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="SearchName" runat="server"></asp:TextBox>
        <asp:Button ID="Search" runat="server" Text="搜索" Width="40px" OnClick="Button_Click"/> 

    </div>
    <div>
        <asp:DataList ID="LeaveMassage" runat="server" OnItemCommand="LeaveMassage_ItemCommand">
          <HeaderTemplate>
              <table style="color:black;width:100%;border:solid;">  
                   <tr>
                       <td style="width:100px;margin:auto;">id</td>
                       <td style="width:100px;margin:auto;">留言人昵称</td>
                       <td style="width:100px;margin:auto;">话题</td>
                       <td style="width:100px;margin:auto;">内容</td>
                       <td style="width:100px;margin:auto;">时间</td>
                       <td style="width:100px;margin:auto;">联系方式</td>
                       <td style="width:100px;margin:auto;">是否已回复</td>
                       <td style="width:100px;margin:auto;">操作</td>
                       <td style="width:100px;margin:auto;">查看回复</td>
                    </tr>  
          </HeaderTemplate>  
                <ItemTemplate>
                    <tr>
                         <td><%#DataBinder.Eval(Container.DataItem,"id") %></td>
                         <td><%#DataBinder.Eval(Container.DataItem,"name") %></td>
                         <td> 
                             <asp:LinkButton ID="LinkButton1" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"theme") %>' CommandName="detail"  runat="server">
                                 <%#DataBinder.Eval(Container.DataItem,"theme").ToString().Length>10?DataBinder.Eval(Container.DataItem,"theme").ToString().Substring(0,10)+"…":DataBinder.Eval(Container.DataItem,"theme")%>
                              </asp:LinkButton>
                         </td>
                         <td> 
                              <asp:LinkButton ID="LinkButton2" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"info") %>' CommandName="Detail"  runat="server" >
                                  <%#DataBinder.Eval(Container.DataItem,"info").ToString().Length>10?DataBinder.Eval(Container.DataItem,"info").ToString().Substring(0,10)+"…":DataBinder.Eval(Container.DataItem,"info")%>
                              </asp:LinkButton>
                         </td>
                         <td><%#DataBinder.Eval(Container.DataItem,"time") %></td>
                         <td><%#DataBinder.Eval(Container.DataItem,"link") %></td>
                         <td><%#DataBinder.Eval(Container.DataItem,"isreply").ToString().Equals("1")?"是":"否" %></td> 
                         <td><asp:LinkButton ID="Button2" runat="server" Text="删除" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id") %>' CommandName="delete" OnClientClick="return confirm('您确认删除该记录吗?')"
/></td>
                         <td><asp:LinkButton ID="LinkButton3" runat="server" Text="查看回复" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id") %>' CommandName="answer" ></asp:LinkButton></td>        
                    </tr>
                </ItemTemplate>
              <FooterTemplate>
                  </table>
              </FooterTemplate>
       </asp:DataList>
        <br />
        
       <p><asp:Label ID="LeaveMsgLbl" runat="server" Text=""></asp:Label></p>
       <asp:DataList ID="ReplyList" runat="server">
           <ItemTemplate>
               <%#DataBinder.Eval(Container.DataItem,"time") %>由<%#DataBinder.Eval(Container.DataItem,"name") %>回复：<br />
               <%#DataBinder.Eval(Container.DataItem,"info") %>
               
           </ItemTemplate>
       </asp:DataList>
        <div id="textDiv" runat="server">

        </div>
        
       
    </div>
        
  </form>
</body>
</html>
