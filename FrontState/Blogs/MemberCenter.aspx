<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberCenter.aspx.cs" Inherits="FrontState_Blogs_MemberCenter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../CSS/Blog/blog.css" rel="stylesheet" />
    <title>个人中心</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="whole">
                <div id="top">
                    <div id="logo">
                        <a href="#">
                            <img src="../../Image/top-blog.jpg" />
                        </a>
                    </div>
                </div>
                <div id="containerr">
                    <div class="middle">
                        <!--*************************************左半部分***************************-->
                        <div class="middle-left">
                            <!--**************************日历*********************************-->
                            <div class="left-new-notice">
                                <div class="topbar">
                                    <h4>Notice</h4>
                                    <span>最新公告</span>
                                    <p class="hr"></p>
                                </div><div class="clear"></div> 
                                <div id="NoticeHTML" runat="server" style="color:white; padding-left:15px; padding-right:15px;"></div>
                            </div>
                            <!--**************************************************************-->
                            <div class="left-top">
                                <div class="topbar">
                                    <h4>Data</h4>
                                    <span>个人资料</span>
                                    <p class="hr"></p>
                                </div>
                                <div style="clear: both"></div>
                                <a href="#">
                                    <img src="../../Image/top-blog.jpg" id="photo" /></a>
                                <p class="data">
                                    <span>昵称:<asp:Label ID="name" runat="server"></asp:Label></span><br />
                                    <span>所属组:<asp:Label ID="Dept" runat="server"></asp:Label></span><br />
                                    <span>博客数:8</span><br />
                                    <span>QQ:<asp:Label ID="QQ" runat="server"></asp:Label></span><br />
                                    <span>浏览量:100</span>
                                </p>
                                <div style="clear: both"></div>
                            </div>
                            <div class="left-bottom">
                                <div class="topbar">
                                    <h4>Info</h4>
                                    <span>个人中心</span>
                                    <p class="hr">
                                    </p>
                                    <div style="padding:10px;width:150px; margin-left:20px;">
                                        <a href="InfoModify.aspx?qq=<%=member.QQ%>" target="mainframe">个人资料</a>
                                        
                                        <br />
                                        <p class="hr"></p>
                                        <a href="PasWModify.aspx?qq=<%=member.QQ %>" target="mainframe">密码重置</a>
                                        
                                        <br />
                                        <p class="hr"></p>
                                        <a href="WriteBlogs.aspx?qq=<%=member.QQ %>&name=<%=member.Name%>" target="mainframe">写博客</a>
                                        
                                        <br />
                                        <p class="hr"></p>
                                        <a href="Blog.aspx?id=0&qq=<%=member.QQ %>" target="_blank">我的博客</a>

                                        <br />
                                        <p class="hr"></p>
                                    </div>
                                </div>
                                <div>
                                </div>
                            </div>
                            <div class="left-bottom">
                                <div class="topbar">
                                    <h4>Exceffent</h4>
                                    <span>精品博文</span>
                                    <p class="hr"></p>
                                </div>
                                <div class="clear"></div> 
                                <div>
                                    <asp:Repeater ID="GreatArticleList" runat="server">
                                        <ItemTemplate>
                    	                <div class="blog-best">
                        	                <li>
                                                <a href='Blog.aspx?id=<%#DataBinder.Eval(Container.DataItem,"id")%>&qq=<%#DataBinder.Eval(Container.DataItem,"qq")%>' title='<%#DataBinder.Eval(Container.DataItem,"title")%>'>
                                                    <%#DataBinder.Eval(Container.DataItem,"title").ToString().Length>10?DataBinder.Eval(Container.DataItem,"title").ToString().Substring(0,8)+".....":DataBinder.Eval(Container.DataItem,"title") %>
                        	                    </a>
                        	                </li>
                                            <div class="gg-time">[<%#DataBinder.Eval(Container.DataItem,"time","{0:yyyy-MM-dd}") %>]</div>   
                                            <div class="clear"></div>        
                                        </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <div class="clear"></div>
                            </div>
                            <div style="clear: both;"></div>
                        </div>
                        <!--*************************************左半部分***************************-->
                        <!--*************************************右半部分***************************-->
                        <div class="middle-right">
                            <div class="top">
                                <div class="topbar">
                                    <h4>Platform</h4>
                                    <span>操作平台</span>
                                    <p class="hr"></p>
                                    <div style="clear: both"></div>
                                </div>
                            </div>
                            <!--***************************************************博文模板*************************************-->
                            <div class="member-right-top">
                                <iframe id="mainframe" name="mainframe" style="width: 100%; min-height: 700px;"></iframe>
                            </div>
                        </div>
                    </div>
                    <!--*************************************右半部分***************************-->
                    <div style="clear: both"></div>
                </div>
                <footer>
                    <img src="../../Image/foot.png" />
                    <p>2011(C) Powered by LingHang Studio, All Rights Reserved</p>
                    <div style="clear: both"></div>
                </footer>
            </div>
        </div>
    </form>
</body>
</html>
