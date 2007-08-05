<%@ Page language="c#" Codebehind="ListaUsuario.aspx.cs" AutoEventWireup="false" Inherits="bic.ListaUsuario" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<HEAD>
		<TITLE>Usuario</TITLE>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="./lib/bic.css" rel="stylesheet" type="text/css" />
	</HEAD>
	<body MS_POSITIONING="GridLayout">
	<FORM id="Form1" method="post" runat="server">
		<DIV id="container">
			<DIV id="header">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD><IMG src="./img/logo-small.jpg">
						</TD>
						<TD align="right">
							<H1>Personal Light</H1>
							<P>Fernando J. Aramendi</P>
						</TD>
					</TR>
				</TABLE>
			</DIV>
			<DIV id="tabs10">
				<UL>
					<LI>
						<A title="Link 1" href="#"><SPAN>Atributos</SPAN></A>
					<LI>
						<A title="Link 2" href="#"><SPAN>Hechos</SPAN></A>
					<LI>
						<A title="Link 3" href="#"><SPAN>Filtros</SPAN></A>
					<LI>
						<A title="Link 4" href="#"><SPAN>Metricas</SPAN></A>
					<LI>
						<A title="Link 5" href="#"><SPAN>Relaciones</SPAN></A>
					<LI>
						<A title="Link 6" href="#"><SPAN>Reportes</SPAN></A>
					</LI>
				</UL>
			</DIV>
			<DIV id="container2" style="HEIGHT: 450px">
				<DIV id="content" style="HEIGHT: 83%">
					<H2>Atributos</H2>
					<asp:DataGrid id="dgUsuarios" runat="server" DataKeyField="Id" AutoGenerateColumns="False" CellSpacing="1"
						CellPadding="1" BorderStyle="None" width="100%">
						<HeaderStyle Font-Bold="True"></HeaderStyle>
						<Columns>
							<asp:BoundColumn DataField="Nombre" HeaderText="Usuario"></asp:BoundColumn>
							<asp:BoundColumn DataField="Clave" HeaderText="Contraseña"></asp:BoundColumn>
							<asp:HyperLinkColumn Text="Editar" Target="_self" DataNavigateUrlField="Id" DataNavigateUrlFormatString="EdicionUsuario.aspx?id={0}"></asp:HyperLinkColumn>
							<asp:ButtonColumn Text="Borrar"></asp:ButtonColumn>
						</Columns>
					</asp:DataGrid><BR>
					<BR>
					<BR>
					<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
						<TR vAlign="bottom">
							<TD align="right">
								<asp:Button id="btnNuevo" runat="server" Text="Agregar nuevo"></asp:Button></TD>
						</TR>
					</TABLE>
				</DIV>
				<DIV id="sidebar">
					<H2 style="TEXT-ALIGN: right">Ayuda</H2>
					<P>Los atributos están definidos por una columna id y una descripción. blah blah 
						bah...</P>
					<P>Si desea añadir un atributo haga click en el boton Agregar nuevo.</P>
					<P>Si que desea ir a la pantalla de edicion de un atributo haga click en el boton 
						Editar.</P>
					<P>Para eliminar un atributo del proyecto haga click en el boton Borrar.</P>
				</DIV>
				<DIV id="footer">
					<P><A href="http://validator.w3.org/check?uri=referer">Valid XHTML 1.0</A> | 
						Copyright © BIC | Design by <A href="#">BIC Design</A></P>
				</DIV>
			</DIV>
		</DIV>
	</FORM>
	</body>
</HTML>
