<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeaveMsg.aspx.cs" Inherits="FrontState_LeaveMsg_LeaveMsg" %>
<%@ Register Src="~/UserControl/MyEditBoxWithouBorder.ascx" TagPrefix="uc1" TagName="MyEditBoxWithouBorder" %>
<%@ Register Src="~/UserControl/VerifyImage.ascx" TagPrefix="uc1" TagName="VerifyImage" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../../CSS/LeaveMsgCSS/leave_msg.css" rel="stylesheet" />
    <link href="../../CSS/css.css" rel="stylesheet" />
    <style type="text/css">
        * {
            padding: 0;
            margin: 0;
            border: 0;
            color:#000;
            text-decoration: none;
        }
    </style>
    <title>留言板</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<div id="whole">
   <div id="top">
        <div id="logo">
        	<a href="#">
            	<img src="../../Image/logo.png" alt="nav-photo" />
            </a> 
        </div>
    </div>
   <div id="containerr">        

            <div class="nav">
                <div class="nav1">                  
                   <a href="../../Default.aspx"><li class="one">首页</li></a>  
                   <a href="../TeamIntroduce/team.html"><li class="two">团队简介</li></a>  
                   <a href="../Member/Member.aspx"><li class="three">团队成员</li></a>  
                   <a href="../ExampleShow/Example.aspx" ><li class="four">案例展示</li></a>  
                   <a href="../LinkUs/Link.aspx"><li class="five">联系我们</li></a>  
                   <a href="#"><li class="six">留言板</li></a>  
                   <a href="../Blogs/Logon.aspx" target="_blank"><li class="seven">个人中心</li></a>  
                <div class="clear"></div>
                </div>
                <div class="photo">
                    <div class="photo-in">
                        <a href="#" ></a>
                    </div>
                    <div style="clear:both;"><img src="../../Image/leave-msg.jpg" /></div>
                </div>
            </div>
<!--          *********************************************************  
-->         <div class="middle">
				<div class="Liuyan">
                    <div class="topbar">
                    	<h4 style="color:#fff;">Message</h4><span>留言板</span>
                        <p class="hr"></p>

                        <div class="clear"></div>
                    </div>
                    <asp:Repeater ID="LeaveMsgList" runat="server">
                        <ItemTemplate>
                            <div>
                                <div class="top">
                                    <a href="#"><span class="nick">昵称：<%#DataBinder.Eval(Container.DataItem,"name")%></span></a><span class="theme">主题：<%#DataBinder.Eval(Container.DataItem,"theme")%></span></div>
                                <div class="main">
                                    <p class="leavemsg-time">留言时间：<%#DataBinder.Eval(Container.DataItem,"time","{0:yyyy-MM-dd}")%></p>
                                    <p><%#DataBinder.Eval(Container.DataItem,"info")%></p>
                                    <asp:Repeater runat="server" DataSource='<%#dre.GetreplyByparentld(Convert.ToInt32(DataBinder.Eval(Container.DataItem,"id")))%>'>
                                        <ItemTemplate>
                                            <p style="height:10px;"></p>
                                            <p class="leavemsg-time">回复时间：<%#DataBinder.Eval(Container.DataItem,"time")%></p>
                                            <p><%#DataBinder.Eval(Container.DataItem,"info")%></p>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                <p class="hr"></p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="nextpage">
                    <p>
                        <asp:LinkButton ID="PrePageLBtn" Enabled="false" runat="server" OnClick="PrePageLBtn_Click">上一页</asp:LinkButton>
                        |当前第<b style="color:#fff;"><asp:Label ID="CurrentPageLbl" runat="server" Text="1"></asp:Label></b>页 | 共<b style="color:#fff;"><asp:Label ID="TotalPageLbl" runat="server" Text=""></asp:Label></b>页|
                        <asp:LinkButton ID="NextPageLBtn" runat="server" OnClick="NextPageLBtn_Click">下一页</asp:LinkButton>
                    </p>
                </div>
            </div>
<!--        *******************************************************    
-->            
            <div class="bottom bottom-1">

                <div class="mall"> 
                    <div class="topbar">
                    	<h4 style="color:#fff;">LeaveMsg</h4><span>留言</span>
						<p class="hr"></p>
                        <div class="clear"></div>
                    </div>      
                        <span>您的昵称：</span><input id="nameText" runat="server" type="text" class="my-input"  />
                        <asp:Label ID="nameTextLbl" runat="server" Text=""></asp:Label><br />
                        <span>您的主题：</span><input id="themeText" runat="server" type="text"  class="my-input" />
                        <asp:Label ID="themeTextLbl" runat="server" Text=""></asp:Label><br />
                        <div class="lianxifs">
                        		<p>联系方式：</p>
                            	<select id="linkTypeText" runat="server">
                                  <option value="QQ">QQ</option>
                                  <option value="邮箱">邮箱</option>
                                  <option value="手机">手机</option>
                                  <option value="audi">微信</option>
                                </select>
                                <input id="linkInfoText" type="text" runat="server"  />
                                <asp:Label ID="linkLbl" runat="server" Text=""></asp:Label><br />
								<div class="clear"></div>
                        </div>
                        <p class="mall-massage">留言信息：</p>
                        <uc1:MyEditBoxWithouBorder runat="server" Width="400" Height="200" MyTool="Cut,Copy,Paste,Fontface,Bold,Italic,Link,Unlink,Emot" ID="msgInfoBox" /><br />
                        <div class="clear"></div>
                        <div style="width:160px; float:left;">
                            <span>验证码：</span>
                            <input id="YanZhengText" runat="server" type="text"  class="yanzheng"/>
                        </div>
                        <div style="width:200px; float:left;"><uc1:VerifyImage runat="server" ID="VerifyImage1" /></div>
                        <asp:Label ID="VerifyTextLbl" runat="server" Text=""></asp:Label>
                        <div class="clear"></div><br />
                        <asp:Button ID="MsgSubmitBtn" CssClass="submit" runat="server" Text="提交" OnClick="MsgSubmitBtn_Click" />

                        <div class="clear"></div>
                    </div>
                </div>
            </div>
<!--   *************************************************************************
-->
    <footer>
	<img src="../../Image/foot.png"/>
    <p>2011(C) Powered by LingHang Studio, All Rights Reservedingyan Studio, All Rights Reserved</p>
    <div class="clear"></div>
    </footer>
</div>
    </div>
        </div>
    </form>
</body>
</html>
