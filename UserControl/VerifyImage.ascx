<%@ Control Language="C#" AutoEventWireup="true" CodeFile="VerifyImage.ascx.cs" Inherits="UserControl_VerifyImage" %>

<div>
    <asp:Image ID="VerifyImg" Width="75px" Height="20px" Visible="false" ImageUrl='<%=ResolveUrl("~/UserControl/VerifyImage.aspx")%>' runat="server" />
    <asp:LinkButton ID="ChangeImageLBtn" runat="server" OnClick="ChangeImageLBtn_Click">获取验证码</asp:LinkButton>
    <asp:Label ID="VerifyTextLbl" Visible="false" runat="server" Text="Label"></asp:Label>
</div>
