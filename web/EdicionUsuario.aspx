<%@ Page language="c#" Codebehind="EdicionUsuario.aspx.cs" AutoEventWireup="false" Inherits="bic.EdicionUsuario" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EdicionUsuario</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:TextBox id="txtNombre" runat="server"></asp:TextBox>
			<asp:TextBox id="txtClave" runat="server"></asp:TextBox>
			<asp:Button id="btnAceptar" runat="server" Text="Aceptar"></asp:Button>
			<asp:Button id="btnCancelar" runat="server" Text="Cancelar"></asp:Button>
		</form>
	</body>
</HTML>
