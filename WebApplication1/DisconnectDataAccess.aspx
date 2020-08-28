<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisconnectDataAccess.aspx.cs" Inherits="WebApplication1.DisconnectDataAccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btngetdata" runat="server" Text="Get Data From Database" BackColor="#E6E6E6" BorderColor="Black" Font-Bold="True" OnClick="btngetdata_Click" />
        <asp:Button ID="btnundo" runat="server" OnClick="Button1_Click" Text="Undo" />
        <br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="3" AutoGenerateColumns="False" DataKeyNames="Sid" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="Sid" HeaderText="Sid" ReadOnly="True" SortExpression="Sid" />
                <asp:BoundField DataField="Sname" HeaderText="Sname" SortExpression="Sname" />
                <asp:BoundField DataField="Sbranch" HeaderText="Sbranch" SortExpression="Sbranch" />
                <asp:BoundField DataField="Sphone" HeaderText="Sphone" SortExpression="Sphone" />
                <asp:BoundField DataField="Sfees" HeaderText="Sfees" SortExpression="Sfees" />
                <asp:BoundField DataField="Dname" HeaderText="Dname" SortExpression="Dname" />
                <asp:BoundField DataField="Slevel" HeaderText="Slevel" SortExpression="Slevel" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        <br />
        <asp:Button ID="btnupdate" runat="server" Text="Update Database" BackColor="#E6E6E6" BorderColor="#003300" Font-Bold="True" OnClick="btnupdate_Click" />

        <asp:Label ID="lblmsg" runat="server" ></asp:Label>

        
        
    </div>
    </form>
</body>
</html>
