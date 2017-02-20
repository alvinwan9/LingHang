<%@ Control Language="C#" ValidateRequestMode="Disabled" AutoEventWireup="true" CodeFile="MyEditBoxWithouBorder.ascx.cs" Inherits="UserControl_MyEditBoxWithouBorder" %>


<script src='<%=ResolveUrl("~/UserControl/xhEditor/jquery/jquery-1.4.4.min.js")%>'></script>
<script src='<%=ResolveUrl("~/UserControl/xhEditor/xheditor-1.1.14-en.min.jss")%>'></script>
<script src='<%=ResolveUrl("~/UserControl/xhEditor/xheditor-1.1.14-zh-cn.min.js")%>'></script>
<script src='<%=ResolveUrl("~/UserControl/xhEditor/xheditor-1.1.14-zh-tw.min.js")%>'></script>


<table style="border:0;padding:0;margin:0;">
        <tr  style="border:0;padding:0;margin:0;">
            <td rowspan="2"  style="border:0;padding:0;margin:0;"><asp:TextBox ID="MyEditBox" Width="400px" Height="400px" TextMode="MultiLine" runat="server"></asp:TextBox></td>
            <td  style="border:0;padding:0;margin:0;"><asp:Label ID="MyEditBoxLbl" runat="server" Text=""></asp:Label></td>
        </tr>
</table>
<script type="text/javascript">
        <!--
            
            $(pageInit);
            
        //-->
</script>