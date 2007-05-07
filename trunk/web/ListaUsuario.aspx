<%@ Page language="c#" Codebehind="ListaUsuario.aspx.cs" AutoEventWireup="false" Inherits="bic.ListaUsuario" %>
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
			<asp:DataGrid id="dgUsuarios" runat="server" AutoGenerateColumns="False" DataKeyField="Id">
				<Columns>
					<asp:BoundColumn DataField="Nombre"></asp:BoundColumn>
					<asp:BoundColumn DataField="Clave"></asp:BoundColumn>
					<asp:HyperLinkColumn HeaderText="Editar" DataNavigateUrlField="Id" DataNavigateUrlFormatString="EdicionUsuario.aspx?id={0}"
						Text="Editar" Target="_self" />
					<asp:ButtonColumn Text="Borrar" HeaderText="Borrar"></asp:ButtonColumn>
				</Columns>
			</asp:DataGrid>
			<a href="EdicionUsuario.aspx?id=-1">Nuevo</a>
		</form>
	</body>
</HTML>
