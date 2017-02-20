<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Blog.aspx.cs" Inherits="FrontState_Blogs_Blog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../../CSS/Blog/blog.css" rel="stylesheet" />
    <title>领航博客</title>
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
                    <div class="rili">
                        <asp:Calendar ID="Calendar1"  runat="server" BorderWidth="0">
                            <TodayDayStyle BackColor="White" />
                            <DayHeaderStyle BackColor="#111c24" />
                            <TitleStyle BackColor="#080f15" />
                            <DayStyle BackColor="#16242f" />
                        </asp:Calendar>
                    </div> 
<!--**************************************************************-->                   
                   <div class="left-top">
                        <div class="topbar">
                    	    <h4>Data</h4><span>个人资料</span>
                            <p class="hr"></p>
                        </div>
                        <div style="clear:both"></div>
                    	<a href="#"><img src="../../Image/top-blog.jpg" id="photo"/></a>
                        <p class="data">
                            <span>昵称:<asp:Label  ID="name" runat="server"></asp:Label></span><br />
                            <span><asp:Label  ID="Dept" runat="server"></asp:Label></span><br />
                            <span>博客数:8</span><br />
                            <span>QQ:<asp:Label   ID ="QQ" runat="server"></asp:Label></span><br />
                            <span>浏览量:100</span>
                        </p>
                        <div style="clear:both"></div>
                   </div>
                   <div class="left-center">
                     <div class="topbar">
                    	<h4>Hot</h4><span>热门链接</span>
                        <p class="hr"></p>
                     </div>
                      <div class="search">
                         <div>
                              <div class="include">
                                  <input id="UserNameText" runat="server"  type="text" value=" 请输入作者名" onfocus="javascript:if(this.value==' 请输入作者名')this.value='';"/>
                                  <asp:Button ID="UserSearchBox" runat="server" CssClass="button" Text="搜索" OnClick="UserSearchBox_Click" />
                              </div>
                        </div>
                      </div>
                       <div class="clear"></div> 
                       <div>
                            <asp:Repeater ID="HotArticleList" runat="server">
                                <ItemTemplate>
                    	        <div class="blog-best">
                        	        <li>
                                        <a href='?id=<%#DataBinder.Eval(Container.DataItem,"id")%>&qq=<%#DataBinder.Eval(Container.DataItem,"qq")%>' title='<%#DataBinder.Eval(Container.DataItem,"title")%>'>
                                            <%#DataBinder.Eval(Container.DataItem,"title").ToString().Length>17?DataBinder.Eval(Container.DataItem,"title").ToString().Substring(0,13)+".....":DataBinder.Eval(Container.DataItem,"title") %>
                        	            </a>
                        	        </li>
                                    <div class="gg-mount"><a title='阅读量：<%#DataBinder.Eval(Container.DataItem,"readedTotal")%>'>&nbsp;<%#DataBinder.Eval(Container.DataItem,"readedTotal")%>&nbsp; </a></div>   
                                    <div class="clear"></div>        
                                </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                       <div class="clear"></div>
                   </div>
                   <div class="left-bottom">
                        <div class="topbar">
                    	    <h4>Exceffent</h4><span>精品博文</span>
                            <p class="hr"></p>
                        </div>
                        <div class="clear"></div> 
                        <div>
                            <asp:Repeater ID="GreatArticleList" runat="server">
                                <ItemTemplate>
                    	        <div class="blog-best">
                        	        <li>
                                        <a href='?id=<%#DataBinder.Eval(Container.DataItem,"id")%>&qq=<%#DataBinder.Eval(Container.DataItem,"qq")%>' title='<%#DataBinder.Eval(Container.DataItem,"title")%>'>
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
                    <div style="clear:both;"></div>
	            </div>
<!--*************************************左半部分***************************-->  
<!--*************************************右半部分***************************-->          
                <div class="middle-right">
                    <div class="top">
                    <div class="topbar">
                    	<h4>Articles</h4><span>博文</span>
                        <p class="hr"></p>
                        <div style="clear:both"></div>
                    </div>
                    <div class="search">
                        <div class="include">
                            <input id="KeyText" runat="server"  type="text" value=" 请输入关键字....." onfocus="javascript:if(this.value==' 请输入关键字.....')this.value='';"/>
                            <asp:Button ID="KeySearchBtn" runat="server" CssClass="button" OnClick="KeySearchBtn_Click" Text="搜索" />
                        </div>
                    </div>
                    </div>
<!--***************************************************博文模板*************************************-->
                   <div class="right-top">
                       <div id="singleBlogDiv" runat="server">
                           <div class="single-title">
                               <br />
                               <p style="font-size:20px;"><%=info.Title %></p>
                               <p style="font-size:12px;">发布日期：<%=info.Time.ToShortDateString() %>   |   发布人：<%=info.Name %>   |   阅读量：<%=info.ReadedTotal %></p><br />
                           </div>
                           <div style="font-size:14px;">
                               <%=info.Info %>
                           </div>
                       </div>
                       <div id="MainContentDiv" runat="server">
                           <asp:Repeater ID="MainContentList" runat="server">
                               <ItemTemplate>
                                    <div class="article">
                                       <a href='?id=<%#DataBinder.Eval(Container.DataItem,"id")%>&qq=<%#DataBinder.Eval(Container.DataItem,"qq")%>' title='<%#DataBinder.Eval(Container.DataItem,"title")%>'>
                                            <div class="title">
                                                    <%#DataBinder.Eval(Container.DataItem,"title")%>
                                              <span style="font-size:15px; color:#000;">[<%#DataBinder.Eval(Container.DataItem,"time","{0:yyyy-MM-dd}") %>]</span>
                                            </div>
                        	                <div class="content">
                                                <%#DataBinder.Eval(Container.DataItem,"info").ToString().Length>100?DataBinder.Eval(Container.DataItem,"info").ToString().Substring(0,98)+".....":DataBinder.Eval(Container.DataItem,"info")%>
                                                <%#DataBinder.Eval(Container.DataItem,"info").ToString().Equals("")?"内容为空...":""%>
                        	                </div>
                                       </a>
                                        <div style="clear:both"></div>
                                    </div>
                               </ItemTemplate>
                           </asp:Repeater>
                           <div style="text-align:right;">
                               <p>
                                <asp:LinkButton ID="PrePageLBtn" Enabled="false" runat="server" OnClick="PrePageLBtn_Click">上一页</asp:LinkButton>
                                |当前第<b style="color:#fff;"><asp:Label ID="CurrentPageLbl" runat="server" Text="1"></asp:Label></b>页 | 共<b style="color:#fff;"><asp:Label ID="TotalPageLbl" runat="server" Text=""></asp:Label></b>页|
                                <asp:LinkButton ID="NextPageLBtn" runat="server" OnClick="NextPageLBtn_Click">下一页</asp:LinkButton>
                               </p>
                           </div>
                       </div>
                       </div>
<!--***************************************************博文模板*************************************-->
                   <div style="clear:both"></div>
                 </div>
             </div>
<!--*************************************右半部分***************************-->
                <div style="clear:both"></div>
             </div>
    <footer>
        <img src="../../Image/foot.png" />
    <p>2011(C) Powered by LingHang Studio, All Rights Reserved</p>
    <div style="clear:both"></div>
    </footer>
    </div>
</div>
       
    </form>
</body>
</html>
