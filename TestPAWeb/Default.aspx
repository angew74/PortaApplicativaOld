<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestPAWeb._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Pagina senza titolo</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="Verifiche" onclick="Button1_Click" />       
               <asp:Button ID="ButtonVABIS" runat="server" Text="VABIS" onclick="ButtonVABIS_Click" />
         <asp:Button ID="ButtonVABIS2" runat="server" Text="VABIS2" onclick="ButtonVABIS2_Click" />
                   <asp:Button ID="ButtonNetTerr" runat="server" Text="NETTERR" onclick="ButtonNETTERR_Click" />
           <asp:Button ID="ButtonNETSEPP" runat="server" Text="NETSEPP" onclick="ButtonNETSEPP_Click" />
                   <asp:Button ID="Button3" runat="server" Text="NETTERR" onclick="ButtonNETTERR_Click" />
    <asp:Button ID="btnEventi" Text="EVE" runat="server" OnClick="ButtonNETEVE_Click" />
            <asp:TextBox
            ID="TextResult" runat="server" Height="400px" Width="400px" TextMode="MultiLine"></asp:TextBox>          
    </div>
    </form>
</body>
</html>
