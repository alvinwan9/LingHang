<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="UserControl_test" %>

<%@ Register Src="~/UserControl/VerifyImage.ascx" TagPrefix="uc1" TagName="VerifyImage" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:VerifyImage runat="server" ID="VerifyImage" />
    </div>
    </form>
</body>
</html>
