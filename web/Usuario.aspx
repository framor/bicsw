<%@ Page language="c#" Codebehind="Usuario.aspx.cs" AutoEventWireup="false" Inherits="bic.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Usuario</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Button id="Button1" style="Z-INDEX: 100; LEFT: 472px; POSITION: absolute; TOP: 88px" runat="server"
				Text="Crear usuario"></asp:Button>
			<asp:Label id="Label3" style="Z-INDEX: 109; LEFT: 184px; POSITION: absolute; TOP: 200px" runat="server">Id</asp:Label>
			<asp:TextBox id="txtId" style="Z-INDEX: 101; LEFT: 232px; POSITION: absolute; TOP: 200px" runat="server"></asp:TextBox>
			<asp:Button id="btnGetById" style="Z-INDEX: 102; LEFT: 408px; POSITION: absolute; TOP: 200px"
				runat="server" Text="GetById"></asp:Button>
			<asp:Label id="lblUsuario" style="Z-INDEX: 103; LEFT: 240px; POSITION: absolute; TOP: 240px"
				runat="server" Width="328px"></asp:Label>
			<asp:TextBox id="txtClave" style="Z-INDEX: 104; LEFT: 280px; POSITION: absolute; TOP: 104px"
				runat="server" TextMode="Password"></asp:TextBox>
			<asp:TextBox id="txtNombre" style="Z-INDEX: 105; LEFT: 280px; POSITION: absolute; TOP: 72px"
				runat="server"></asp:TextBox>
			<asp:Label id="Label1" style="Z-INDEX: 106; LEFT: 200px; POSITION: absolute; TOP: 72px" runat="server">Nombre</asp:Label>
			<asp:Label id="Label2" style="Z-INDEX: 108; LEFT: 208px; POSITION: absolute; TOP: 104px" runat="server">Clave</asp:Label>
		</form>
	</body>
</HTML>
