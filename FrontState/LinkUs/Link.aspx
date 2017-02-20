<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Link.aspx.cs" Inherits="FrontState_LinkUs_Link" %>
<%@ Register Src="~/UserControl/MyEditBoxWithouBorder.ascx" TagPrefix="uc1" TagName="MyEditBoxWithouBorder" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../../CSS/LinkCSS/link.css" rel="stylesheet" />
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
    <title>联系我们</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<div id="whole">
   <div id="top">
        <div id="logo">
        	<a href="">
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
                   <a href="#"><li class="five">联系我们</li></a>  
                   <a href="../LeaveMsg/LeaveMsg.aspx"><li class="six">留言板</li></a>  
                   <a href="../Blogs/Logon.aspx" target="_blank"><li class="seven">个人中心</li></a>  
                <div class="clear"></div>
                </div>
                <div class="photo">
                    <div class="photo-in">
                        <a href="#" ><img src="../../Image/link-us.jpg" /></a>
                    </div>
                    <div style="clear:both;"></div>
                </div>
            </div>
            <div class="middle">
                <div class="call">
                    <div class="topbar">
                    	<h4 style="color:#fff;">Leader</h4><span>团队领导</span>
						<p class="hr"></p>
                        <div class="clear"></div>
                    </div>
                    <div class="call-out">
                        <div class="call-in">
                            <h4 style="color:#fff;">团队主管:<%=info.Name %></h4><br />
                            <div>
                                <img width="100" height="110" src='<%=ResolveUrl(info.UserPic)%>' />
                                <div class="text">
                                    <p>qq:<%=info.QQ %></p>
                                    <p>邮箱:<%=info.QQ %>@qq.com</p>
                                    <p>电话:<%=info.Tel %></p>
                                    <p>工作室地址:武汉科技大学教三楼</p>
                                </div>
                            </div>
                        </div>
                        <div class="clear"></div>
                    </div>
                </div>
            </div>
            <div class="bottom bottom-1">

                <div class="mall"> 
                    <div class="topbar">
                    	<h4 style="color:#fff;">Emall</h4><span>邮件联系</span>
						<p class="hr"></p>
                        <div class="clear"></div>
                    </div>
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
                        <uc1:MyEditBoxWithouBorder runat="server" Width="400" Height="200" MyTool="Cut,Copy,Paste,Fontface,Bold,Italic,FontColor,Link,Unlink" ID="msgInfoBox" /><br />
                        <div class="clear"></div>
                        <asp:Button ID="EmailSubmitBtn" CssClass="submit" runat="server" Text="发送" OnClick="EmailSubmitBtn_Click"/>

                        <div class="clear"></div>
                    </div>
                </div>
            </div>
                
    <footer>
	<img src="../../Image/foot.png"/>
    <p>2011(C) Powered by LingHang Studio, All Rights Reserved</p>
    <div class="clear"></div>
    </footer>
</div>  
    </form>
</body>
</html>
