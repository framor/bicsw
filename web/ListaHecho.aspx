<%@ Page language="c#" Codebehind="ListaHecho.aspx.cs" AutoEventWireup="false" Inherits="bic.ListaHecho" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
	<title>BIC - Business Intelligence Client</title>
	<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
	<link href="./lib/bic.css" rel="stylesheet" type="text/css" />
	</head>
	<body>
    <form id="Form1" method="post" runat="server">	
	<div id="container">

	<div id="header">
		<table height="100%" width="100%" cellspacing="0" cellpadding="0" border="0">
			<tr>
				<td>
					<img src="./img/logo-small.jpg"/>
				</td>
				<td align="right">
					<h1><asp:Label ID="lblProyecto" Runat="server"></asp:Label></h1>
					<p><asp:Label ID="lblUsuario" Runat="server"></asp:Label>&nbsp;<a href="Login.aspx" ><img alt="Cerrar sesión" src="./img/logout.png"/></a></p>
				</td>
			</tr>
		</table>
	</div>

	<div id="tabs10">
	  <ul>
		<li><a href="ListaTabla.aspx" title="Tablas"><span>Tablas</span></a></li>	  
		<li><a href="ListaAtributo.aspx" title="Atributos"><span>Atributos</span></a></li>
		<li><a href="ListaHecho.aspx" title="Hechos"><span>Hechos</span></a></li>
		<li><a href="ListaFiltro.aspx" title="Filtros"><span>Filtros</span></a></li>
		<li><a href="ListaMetrica.aspx" title="Metricas"><span>Metricas</span></a></li>
		<li><a href="ListaRelacion.aspx" title="Relaciones"><span>Relaciones</span></a></li>
		<li><a href="ListaReporte.aspx" title="Reportes"><span>Reportes</span></a></li>
	  </ul>
	</div>

	<div id="container2" style="height:450px">

	<div id="content" style="height:83%">
	<h2>Hechos</h2>

		<asp:DataGrid id="dgHechos" runat="server" DataKeyField="Id" AutoGenerateColumns="False" CellSpacing="0"
			CellPadding="1" BorderStyle="None" width="100%">
			<HeaderStyle Font-Bold="True"></HeaderStyle>
			<Columns>
				<asp:BoundColumn DataField="Nombre" HeaderText="Nombre"></asp:BoundColumn>
				<asp:BoundColumn DataField="NombreColumna" HeaderText="Alias"></asp:BoundColumn>
 				<asp:HyperLinkColumn Text="Editar" Target="_self" DataNavigateUrlField="Id" DataNavigateUrlFormatString="EdicionHecho.aspx?id={0}"></asp:HyperLinkColumn>
				<asp:ButtonColumn Text="Borrar" CommandName="Borrar"></asp:ButtonColumn>
			</Columns>
		</asp:DataGrid>
		<br/><br/><br/>
		<table width="100%" cellspacing="0" cellpadding="0" border="0">
			<tr valign="bottom">
				<td align="right"><asp:Button id="btnNuevo" runat="server" Text="Agregar nuevo"></asp:Button></td-->
			</tr>
		</table>
	</div>

	<div id="sidebar">
	<h2 style="text-align:right">Ayuda</h2>
	<p>Los Hechos están definidos por una columna id y una descripción. blah blah bah...</p>
	<p>Si desea añadir un Hecho haga click en el boton Agregar nuevo.</p>
	<p>Si que desea ir a la pantalla de edicion de un Hecho haga click en el boton Editar.</p>
	<p>Para eliminar un Hecho del proyecto haga click en el boton Borrar.</p>
	</div>

	<div id="footer">
	<p>
	<a href="http://validator.w3.org/check?uri=referer">Valid XHTML 1.0</a> | Copyright &copy; BIC | Design by <a href="#">BIC Design</a>
	</p>
	</div>

	</div>

	</div>
	</form>
	</body>
</html>