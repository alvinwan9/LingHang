<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Example-Child.aspx.cs" Inherits="FrontState_ExampleShow_Example_Child" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../../CSS/ExampleCSS/example-child.css" rel="stylesheet" />
    <link href="../../CSS/css.css" rel="stylesheet" />
    <title>案例展示</title>
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
                   <a href="../ExampleShow/Example.aspx" ><li class="four">案例展示</li></a>  
                   <a href="../LinkUs/Link.aspx"><li class="five">联系我们</li></a>  
                   <a href="../LeaveMsg/LeaveMsg.aspx"><li class="six">留言板</li></a>  
                   <a href="../Blogs/Logon.aspx" target="_blank"><li class="seven">个人中心</li></a>  
                <div class="clear"></div>
                </div>
                <div class="clear"></div>
            </div>
      <div class="middle">
          <div class="photo1">
                <a href="#" ><img src="ExampleImg/example.jpg" /></a>
          </div> 
          <div class="jianjie">      
              <div class="return">
              	<button type="button" onclick="javascript:history.go(-1);">返回</button>
              </div>
              <p>
              客户名称：商业动力网<br />
              网址：<a href="#">http://www.mychinahost.cn</a><br />
              所属行业：虚拟主机 域名<br />
              行业特点：云主机 服务器租用、传统服务器租用、托管、机柜租用、大带宽租用、主机域名。<br />
              </p>
          <div style="clear:both"></div>
          </div>
          <div style="clear:both"></div>
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
