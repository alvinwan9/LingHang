<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Member.aspx.cs" Inherits="FrontState_Member_Member" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../../CSS/MemberCSS/member.css" rel="stylesheet" />
    <link href="../../CSS/css.css" rel="stylesheet" />
    <title>团队成员</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<div id="whole">
   <div id="top">
        <div id="logo">
        	<a href="#">
                <img src="../../Image/logo.png" />
            </a> 
        </div>
    </div>
   <div id="containerr">        

            <div class="nav">
                <div class="nav1">                  
                   <a href="../../Default.aspx"><li class="one">首页</li></a>  
                   <a href="../TeamIntroduce/team.html"><li class="two">团队简介</li></a>  
                   <a href="#"><li class="three">团队成员</li></a>  
                   <a href="../ExampleShow/Example.aspx" ><li class="four">案例展示</li></a>  
                   <a href="../LinkUs/Link.aspx"><li class="five">联系我们</li></a>  
                   <a href="../LeaveMsg/LeaveMsg.aspx"><li class="six">留言板</li></a>  
                   <a href="../Blogs/Logon.aspx" target="_blank"><li class="seven">个人中心</li></a>  
                <div class="clear"></div>
                </div>
                <div class="photo">
                    <div class="photo-in">
                        <a href="#" ><img src="../../Image/team-member.jpg" /></a>
                    </div>
                    <div style="clear:both;"></div>
                </div>
            </div>
            
      <div class="middle">     
<!--*****************************成员模板*********************************-->

			  <div class="mid">
                  <div class="topbar">
                  		<h4>Team members</h4><span>团队成员</span>
						<p class="hr"></p>
                        <div class="clear"></div>
                  </div>
                  <div class="guid">
                       <div class="nav2">
                            <ul>
                                <li id="AllLi"  runat="server"><asp:LinkButton ID="AllLBtn" runat="server" OnClick="AllLBtn_Click">全部</asp:LinkButton></li>
                                <li id="ManagerLi"  runat="server"><asp:LinkButton ID="ManagerLBtn" runat="server" OnClick="ManagerLBtn_Click">团队主管</asp:LinkButton></li>
                                <li id="SkillerLi"  runat="server"><asp:LinkButton ID="SkillerLBtn" runat="server" OnClick="SkillerLBtn_Click">开发团队</asp:LinkButton></li>
                                <li id="SpecialerLi"  runat="server"><asp:LinkButton ID="SpecialerLBtn" runat="server" OnClick="SpecialerLBtn_Click">视觉特效团队</asp:LinkButton></li>
                                <li id="TesterLi"  runat="server"><asp:LinkButton ID="TesterLBtn" runat="server" OnClick="TesterLBtn_Click">测试团队</asp:LinkButton></li>
                            </ul>
                       </div>
                       <div class="search">
                           <asp:DropDownList CssClass="select" ID="YearList" OnTextChanged="YearList_TextChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                            <div class="include">
                                <input id="MemberNameText" runat="server"  type="text" value="请输入姓名....." onfocus="javascript:if(this.value=='请输入姓名.....')this.value='';"/>
                                <asp:Button CssClass="button" ID="Button1" runat="server" Text="搜索" OnClick="Button1_Click" />
                            </div>
                        </div>
                       <div style="clear:both"></div> 
                    </div> 
                    <div class="people"> 
                    <div class="gallery">
            <!--***********************************************************************************-->
                        <div class="people_out">  
                            <asp:DataList ID="ManagerList" runat="server" RepeatColumns="5">
                                <HeaderTemplate>
                                    <div class="top">
                                        <span class="nick">团队主管</span><span class="theme"></span>
                                    </div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="main">
                                        <div class="figure">
                                            <img src="<%#ResolveUrl(DataBinder.Eval(Container.DataItem,"userPic").ToString()==""? "~/FrontState/Member/HeadImg/NoPic.jpg":DataBinder.Eval(Container.DataItem,"userPic").ToString())%>" />
                                            <p><%#DataBinder.Eval(Container.DataItem,"name") %></p>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <br /><p class="hrList"></p><br />
                                </FooterTemplate>
                            </asp:DataList>
                            <asp:DataList ID="AndroiderList" runat="server" RepeatColumns="5">
                                <HeaderTemplate>
                                    <div class="top">
                                        <span class="nick">Android组</span><span class="theme"></span>
                                    </div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="main">
                                        <div class="figure">
                                            <img src="<%#ResolveUrl(DataBinder.Eval(Container.DataItem,"userPic").ToString()==""? "~/FrontState/Member/HeadImg/NoPic.jpg":DataBinder.Eval(Container.DataItem,"userPic").ToString())%>" />
                                            <p><%#DataBinder.Eval(Container.DataItem,"name") %></p>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <br /><p class="hrList"></p><br />
                                </FooterTemplate>
                            </asp:DataList>
                            <asp:DataList ID="ASPNETerList" runat="server" RepeatColumns="5">
                                <HeaderTemplate>
                                    <div class="top">
                                        <span class="nick">ASP.NET组</span><span class="theme"></span>
                                    </div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="main">
                                        <div class="figure">
                                            <img src="<%#ResolveUrl(DataBinder.Eval(Container.DataItem,"userPic").ToString()==""? "~/FrontState/Member/HeadImg/NoPic.jpg":DataBinder.Eval(Container.DataItem,"userPic").ToString())%>" />
                                            <p><%#DataBinder.Eval(Container.DataItem,"name") %></p>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <br /><p class="hrList"></p><br />
                                </FooterTemplate>
                            </asp:DataList>
                            <asp:DataList ID="PHPerList" runat="server" RepeatColumns="5">
                                <HeaderTemplate>
                                    <div class="top">
                                        <span class="nick">PHP组</span><span class="theme"></span>
                                    </div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="main">
                                        <div class="figure">
                                            <img src="<%#ResolveUrl(DataBinder.Eval(Container.DataItem,"userPic").ToString()==""? "~/FrontState/Member/HeadImg/NoPic.jpg":DataBinder.Eval(Container.DataItem,"userPic").ToString())%>" />
                                            <p><%#DataBinder.Eval(Container.DataItem,"name") %></p>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <br /><p class="hrList"></p><br />
                                </FooterTemplate>
                            </asp:DataList>
                            <asp:DataList ID="JavaerList" runat="server" RepeatColumns="5">
                                <HeaderTemplate>
                                    <div class="top">
                                        <span class="nick">Java组</span><span class="theme"></span>
                                    </div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="main">
                                        <div class="figure">
                                            <img src="<%#ResolveUrl(DataBinder.Eval(Container.DataItem,"userPic").ToString()==""? "~/FrontState/Member/HeadImg/NoPic.jpg":DataBinder.Eval(Container.DataItem,"userPic").ToString())%>" />
                                            <p><%#DataBinder.Eval(Container.DataItem,"name") %></p>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <br /><p class="hrList"></p><br />
                                </FooterTemplate>
                            </asp:DataList>
                            <asp:DataList ID="PSerList" runat="server" RepeatColumns="5">
                                <HeaderTemplate>
                                    <div class="top">
                                        <span class="nick">美工组</span><span class="theme"></span>
                                    </div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="main">
                                        <div class="figure">
                                            <img src="<%#ResolveUrl(DataBinder.Eval(Container.DataItem,"userPic").ToString()==""? "~/FrontState/Member/HeadImg/NoPic.jpg":DataBinder.Eval(Container.DataItem,"userPic").ToString())%>" />
                                            <p><%#DataBinder.Eval(Container.DataItem,"name") %></p>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <br /><p class="hrList"></p><br />
                                </FooterTemplate>
                            </asp:DataList>
                            <asp:DataList ID="UIerList" runat="server" RepeatColumns="5">
                                <HeaderTemplate>
                                    <div class="top">
                                        <span class="nick">UI组</span><span class="theme"></span>
                                    </div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="main">
                                        <div class="figure">
                                            <img src="<%#ResolveUrl(DataBinder.Eval(Container.DataItem,"userPic").ToString()==""? "~/FrontState/Member/HeadImg/NoPic.jpg":DataBinder.Eval(Container.DataItem,"userPic").ToString())%>" />
                                            <p><%#DataBinder.Eval(Container.DataItem,"name") %></p>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <br /><p class="hrList"></p><br />
                                </FooterTemplate>
                            </asp:DataList>
                            <asp:DataList ID="TesterList" runat="server" RepeatColumns="5">
                                <HeaderTemplate>
                                    <div class="top">
                                        <span class="nick">测试组</span><span class="theme"></span>
                                    </div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="main">
                                        <div class="figure">
                                            <img src="<%#ResolveUrl(DataBinder.Eval(Container.DataItem,"userPic").ToString()==""? "~/FrontState/Member/HeadImg/NoPic.jpg":DataBinder.Eval(Container.DataItem,"userPic").ToString())%>" />
                                            <p><%#DataBinder.Eval(Container.DataItem,"name") %></p>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <br /><p class="hrList"></p><br />
                                </FooterTemplate>
                            </asp:DataList>
					    </div>

                      </div>
                </div>
            </div>  
    </div>            
    <footer>
	<img src="../../Image/foot.png">
    <p>2011(C) Powered by LingHang Studio, All Rights Reserved</p>
    <div class="clear"></div>
    </footer>
</div>    
    </div>
        </div>
    </form>
</body>
</html>
