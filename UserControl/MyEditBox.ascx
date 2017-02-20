<%@ Control Language="C#" ValidateRequestMode="Disabled" AutoEventWireup="true" CodeFile="MyEditBox.ascx.cs" Inherits="UserControl_MyEditBox" %>

<script src='<%=ResolveUrl("~/UserControl/xhEditor/jquery/jquery-1.4.4.min.js")%>'></script>
<script src='<%=ResolveUrl("~/UserControl/xhEditor/xheditor-1.1.14-en.min.jss")%>'></script>
<script src='<%=ResolveUrl("~/UserControl/xhEditor/xheditor-1.1.14-zh-cn.min.js")%>'></script>
<script src='<%=ResolveUrl("~/UserControl/xhEditor/xheditor-1.1.14-zh-tw.min.js")%>'></script>



<fieldset id="MyBoder" runat="server" style="width:0px; height:auto;">
    <legend>编辑内容</legend>
        <asp:TextBox ID="MyEditBox" Width="400px" Height="400px" TextMode="MultiLine" runat="server"></asp:TextBox>
    
        <script type="text/javascript">
        <!--
            
            $(pageInit);
            
        //-->
        </script>
</fieldset>