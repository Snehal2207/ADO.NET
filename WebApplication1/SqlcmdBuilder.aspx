<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SqlcmdBuilder.aspx.cs" Inherits="WebApplication1.SqlcmdBuilder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1
        {
            height: 26px;
        }
        .auto-style2
        {
            width: 255px;
        }
        .auto-style3
        {
            height: 26px;
            width: 255px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="1" style="width: 330px" title="Update Form">
        <tr>
            <td>Studen Id:</td>
            <td class="auto-style2">
                <asp:TextBox ID="txtid" runat="server"></asp:TextBox><asp:Button ID="btnid" runat="server" Text="Submit" OnClick="btnid_Click" />
            </td>
        </tr>
        <tr>
            <td>Name:</td>
            <td class="auto-style2">
                <asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Department:</td>
            <td class="auto-style2">
                <asp:DropDownList ID="ddldname" runat="server">
                    <asp:ListItem Text="Mechanical" Value="Mechanical">Mechanical</asp:ListItem>
                    <asp:ListItem Text="Civil" Value="Civil">Civil</asp:ListItem>
                    <asp:ListItem Text="chemical" Value="chemical">chemical</asp:ListItem>
                    <asp:ListItem Text="Computer" Value="Computer">Computer</asp:ListItem>
                    <asp:ListItem Text="Mechanical" Value="Mechanical">Electrical</asp:ListItem>
                    <asp:ListItem Text="EC" Value="EC">EC</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="auto-style1">Total Fess:</td>
            <td class="auto-style3">
                <asp:TextBox ID="txtfees" runat="server" BorderColor="#339966"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="btnupdate_Click" />
                <asp:Label ID="lblmsg" runat="server" Text="Status"></asp:Label>
            </td>
            
        </tr>
     </table>
    </div>
    </form>
</body>
</html>
