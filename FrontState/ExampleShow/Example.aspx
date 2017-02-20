<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Example.aspx.cs" Inherits="FrontState_ExampleShow_Example" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../../CSS/css.css" rel="stylesheet" />
    <link href="../../CSS/ExampleCSS/example.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.9.0.min.js"></script>
    <title>案例展示</title>
<script type="text/javascript">
    $(function () {
            $(".change").hover(
                function () {
                    $(this).find(".dask").stop().delay(50).animate({ "bottom": 0, opacity: 0.7 }, 300)
                },
                function () {
                    $(this).find(".dask").stop().animate({ "bottom": -200, opacity: 0 }, 300)
                }
            )
        })
</script>
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
                   <a href="../Member/Member.aspx"><li class="three">团队成员</li></a>  
                   <a href="#" ><li class="four">案例展示</li></a>  
                   <a href="../LinkUs/Link.aspx"><li class="five">联系我们</li></a>  
                   <a href="../LeaveMsg/LeaveMsg.aspx"><li class="six">留言板</li></a>  
                   <a href="../Blogs/Logon.aspx" target="_blank"><li class="seven">个人中心</li></a>  
                <div class="clear"></div>
                </div>
                <div class="photo">
                    <div class="photo-in">
                        <a href="#" ><img src="../../Image/example-show.jpg" /></a>
                    </div>
                    <div style="clear:both;"></div>
                </div>
            </div>
            <div class="middle">
                <div class="double"> 
                    <div class="topbar">
                    	<h4>Example</h4><span>案例展示</span>
                        <p class="hr"></p>
                        <div class="clear"></div>
                    </div>
<!--***************************************作品展示模板****************************************************-->
                    <asp:DataList ID="ExampleList" runat="server" RepeatDirection="Vertical" RepeatColumns="2">
                        <ItemTemplate>     
                            <div class="figure">
                    	        <div class="change" >
                        	        <a href="Example-Child.aspx">
                                        <img src="<%#ResolveUrl(DataBinder.Eval(Container.DataItem,"pic").ToString()==""? "~/FrontState/ExampleShow/ExampleImg/NoPic.jpg":DataBinder.Eval(Container.DataItem,"pic").ToString())%>"/>
                        	        </a>
                                    <div class="dask">
	                      		        <p><%#DataBinder.Eval(Container.DataItem,"name")%></p>
		                            </div>
                                </div>
                                <p>
                                    <span><%#DataBinder.Eval(Container.DataItem,"name")%></span><br />
                                    <span class="time-css">date:<%#DataBinder.Eval(Container.DataItem,"time","{0:yyyy-MM-dd}")%></span><br />
                                    网站类型：<%#DataBinder.Eval(Container.DataItem,"type")%><br />
                                    核心技术：<%#DataBinder.Eval(Container.DataItem,"mainGroup")%><br />
                                    <a href="#"><%#DataBinder.Eval(Container.DataItem,"url")%></a>
                                </p>
                            </div>
                            <br /><br />
                            <div style="clear:both"></div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <div class="nextpage">
                    <p>
                        <asp:LinkButton ID="PrePageLBtn" Enabled="false" runat="server" OnClick="PrePageLBtn_Click">上一页</asp:LinkButton>
                        |当前第<b style="color:#fff;"><asp:Label ID="CurrentPageLbl" runat="server" Text="1"></asp:Label></b>页 | 共<b style="color:#fff;"><asp:Label ID="TotalPageLbl" runat="server" Text=""></asp:Label></b>页|
                        <asp:LinkButton ID="NextPageLBtn" runat="server" OnClick="NextPageLBtn_Click">下一页</asp:LinkButton>
                    </p>
                </div>
            </div>               
    <footer>
	<img src="../../Image/foot.png">
    <p>2011(C) Powered by LingHang Studio, All Rights Reserved</p>
    <div class="clear"></div>
    </footer>
</div> 
    </div>
    </form>
</body>
</html>
