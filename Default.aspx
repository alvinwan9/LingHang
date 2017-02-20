<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Src="~/UserControl/MyEditBox.ascx" TagPrefix="uc1" TagName="MyEditBox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="CSS/HomeCSS/index.css" rel="stylesheet" />
    <link href="CSS/css.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.11.1.js"></script>
    <title>领航工作室</title>
    <script type="text/javascript">
        var i = 1
        $(function a() {
            //	for(i=1;i++;i<4)
            var photo_in_wid = $(".photo-in").width()
            var img_wid = $(".photo-in img").width()
            var n = $(".photo-in img").size()
            var time = 2000
            var time_1 = 1000

            var c = setInterval(function () {
                $(".photo-in").animate({ "left": -1 * i * img_wid }, time_1)
                i++
                $(".photo-bottom li").mouseover
                (
                    function () {
                        i = $(this).index()
                        $(".photo-in").css({ "left": "-1*i*img_wid" })
                        time_1 = 300
                    }
                 )
                time_1 = 1000
                time = 1000
                if (i == n) {
                    i = 0;
                    $(".photo-in").css({ "left": "0" });
                }
            }, time)
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
            	<img src="Image/logo.png" alt="nav-photo" />
            </a> 
        </div>
    </div>
   <div id="containerr">        

            <div class="nav">
                <div class="nav1">                  
                   <a href="#"><li class="one">首页</li></a>  
                   <a href="FrontState/TeamIntroduce/team.html"><li class="two">团队简介</li></a>  
                   <a href="FrontState/Member/Member.aspx"><li class="three">团队成员</li></a>  
                   <a href="FrontState/ExampleShow/Example.aspx" ><li class="four">案例展示</li></a>  
                   <a href="FrontState/LinkUs/Link.aspx"><li class="five">联系我们</li></a>  
                   <a href="FrontState/LeaveMsg/LeaveMsg.aspx"><li class="six">留言板</li></a>  
                   <a href="FrontState/Blogs/Logon.aspx" target="_blank"><li class="seven">个人中心</li></a>  
                <div class="clear"></div>
                </div>
                <div class="photo">
                    <div class="photo-in">
                       <a href="FrontState/TeamIntroduce/team.html"><img src="Image/team-info.jpg" /></a>  
                       <a href="FrontState/Member/Member.aspx"><img src="Image/team-member.jpg" /></a>  
                       <a href="FrontState/ExampleShow/Example.aspx"><img src="Image/example-show.jpg" /></a>  
                       <a href="FrontState/LinkUs/Link.aspx"><img src="Image/link-us.jpg" /></a>  
                       <a href="FrontState/LeaveMsg/LeaveMsg.aspx"><img src="Image/leave-msg.jpg" /></a>  
                    </div>
                    <div style="clear:both;"></div>
                </div>

                <div class="photo-bottom">
                    <li class="ph_bo_1">1</li>
                    <li>2</li>
                    <li>3</li>
                    <li>4</li>
                    <li>5</li>
                    <div class="clear"></div>
                </div>
            </div>
<!--************************************************************-->                
            <div class="middle">
                <div class="aboutus">
                    <div class="topbar">
                    	<h4>About us</h4><span>关于我们</span>
						<p class="hr"></p>
                        <div class="clear"></div>
                    </div>
                    <p>领航工作室隶属于计算机学院,是一支致力于开发各类互联
                        网应用系统和应用软件,并兼顾网络安全、程序设计、web开发、
                        计算机维护等业务的技术团队。领航工作室成立于2010年11月，
                        是武汉科技大学技术支持较为雄厚的学生团体。工作室现有开
                        发、视觉特效和测试三个团队,开发团队有PHP、Java、.NET<br />(C#)、
                        Android四个技术小组,视觉特效团队有美工设计组、UI设计组两个设计小组,测试团队有测试组...<a href="FrontState/TeamIntroduce/team.html">详情>></a></p>
             </div>



                <div class="gonggao">
                    <div class="topbar">
                    	<h4>New</h4><span>站内公告</span>
                        <p class="hr"></p>
                        <div class="clear"></div>
                    </div>
                    <div class="gonggao-out">
                        <asp:Repeater ID="NoticeList" runat="server">
                            <ItemTemplate>
                    	    <div class="gonggao-in">
                        	    <li><a href="#"><%#DataBinder.Eval(Container.DataItem,"title").ToString().Length>12?DataBinder.Eval(Container.DataItem,"title").ToString().Substring(0,10)+".....":DataBinder.Eval(Container.DataItem,"title") %></a></li>
                                <li class="gg-time">[<%#DataBinder.Eval(Container.DataItem,"time","{0:yyyy-MM-dd}") %>]</li>
                                <div class="clear"></div>
                            </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <div class="clear"></div>
                
           </div>
<!------------------------------middle-2----------------------------------------->
           <div class="middle-2">
               <div class="m-2-photo">
               		<div class="m-2-photo_1">
                        <a href="FrontState/TeamIntroduce/team.html">
                    	<img src="Image/team-after.png"  onmouseover="this.src='Image/team.png'" onmouseout="this.src='Image/team-after.png'"  />
                        </a>
                    </div>
               		<div class="m-2-photo_1">
                        <a href="FrontState/ExampleShow/Example.aspx" >
                    	<img src="Image/case-after.png" onmouseover="this.src='Image/case.png'" onmouseout="this.src='Image/case-after.png'" />
                        </a>
                    </div>
               		<div class="m-2-photo_1">
                        <a href="FrontState/Member/Member.aspx">
                    	<img src="Image/experience-after.png" onmouseover="this.src='Image/experience.png'" onmouseout="this.src='Image/experience-after.png'" />
                        </a>
                    </div>
                     <div class="clear"></div>
               </div>
           </div>
<!--  ***********************************bottom********************************************************-->         
           <div class="bottom">

<!--****************************************************
-->           	<div class="bo-left">
                    <div class="topbar">
                    	<h4>New</h4><span>最新动态</span>
                        <p class="hr"></p>
                        <div class="clear"></div>
                    </div>
                   <div class="gonggao-out dongtai">
                        <asp:Repeater ID="ArticleList" runat="server">
                            <ItemTemplate>
                    	    <div class="gonggao-in">
                        	    <li>
                                    <a href='FrontState/Blogs/Blog.aspx?id=<%#DataBinder.Eval(Container.DataItem,"id")%>&qq=<%#DataBinder.Eval(Container.DataItem,"qq")%>' title='<%#DataBinder.Eval(Container.DataItem,"title")%>'>
                                        <%#DataBinder.Eval(Container.DataItem,"title").ToString().Length>15?DataBinder.Eval(Container.DataItem,"title").ToString().Substring(0,13)+".....":DataBinder.Eval(Container.DataItem,"title") %>
                        	        </a>
                        	    </li>
                                <li class="gg-time">[<%#DataBinder.Eval(Container.DataItem,"time","{0:yyyy-MM-dd}") %>]</li>
                                <div class="clear"></div>
                            </div>
                            </ItemTemplate>
                        </asp:Repeater>
                   </div>
                   <img src="Image/decorate.png" />
                 </div>
<!--     ************************************************            
-->               
				<div class="bo-right">
                    <div class="topbar">
                    	<h4>Contact</h4><span>联系我们</span>

                        <div class="clear"></div>
                    </div>
                    <a href="#">
                    	<img src="Image/callus.png" alt="" title="工作室招新" />
                    </a>
                    <table style="text-align:center; width:210px;">
                      <tr>
                        <th>联系人</th>
                        <th>电话</th>
                        <th>QQ</th>
                      </tr>
                      <tr>
                        <td>骆科杨</td>
                        <td>12345678</td>
                        <td>12345678</td>
                      </tr>
                    </table>
                </div>
                
                <div class="clear"></div>  
           </div>
    <footer>
	<img src="Image/foot.png">
    <p>2011(C) Powered by LingHang Studio, All Rights Reserved</p>
    <div class="clear"></div>
    </footer>

    </div>
</div>
    </div>
    </form>
</body>
</html>
