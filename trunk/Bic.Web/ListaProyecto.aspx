<%@ Page language="c#" Codebehind="ListaProyecto.aspx.cs" AutoEventWireup="false" Inherits="Bic.Web.ListaProyecto" %>
<%@ Register TagPrefix="cc1" Namespace="Bic.WebControls" Assembly="Bic.WebControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>BIC - Business Intelligence Client</title>
	<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
	<link href="./lib/bic.css" rel="stylesheet" type="text/css" />	
	<script>
		function ConfirmarEliminacion() 
		{
			if(confirm('¿Está seguro que desea eliminar el proyecto?'))
			{
				return confirm('Si elimina el proyecto se eliminarán todos los Tablas, Atributos, Hechos, Filtros, Métricas, Reportes y  que le pertenezcan. ¿Desea continuar?');
			}
			return false;				
		}
	</script>
</head>
<body>
	<form id="form1" method="post" runat="server">
	<div id="container">

	<cc1:Header id="bicHeader" runat="server"></cc1:Header>

	<div id="tabs10">
	</div>

	<div id="container2" style="height:450px">

	<div id="content" style="height:83%">
	<h2>Proyectos</h2>

		<asp:DataGrid id="dgProyectos" runat="server" DataKeyField="Id" AutoGenerateColumns="False" CellSpacing="0"
			CellPadding="1" BorderStyle="None" width="100%" AllowPaging="true" PageSize="5" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Center">
			<HeaderStyle Font-Bold="True"></HeaderStyle>
			<Columns>
				<asp:BoundColumn DataField="Nombre" HeaderText="Nombre"></asp:BoundColumn>
				<asp:BoundColumn DataField="Descripcion" HeaderText="Descripcion"></asp:BoundColumn>
				<asp:ButtonColumn Text="Seleccionar" CommandName="Seleccionar"></asp:ButtonColumn>
				<asp:HyperLinkColumn Text="Editar" Target="_self" DataNavigateUrlField="Id" DataNavigateUrlFormatString="EdicionProyecto.aspx?id={0}"></asp:HyperLinkColumn>
				<asp:ButtonColumn Text="Borrar" CommandName="Borrar"></asp:ButtonColumn>
			</Columns>
		</asp:DataGrid><BR>

		<br/><br/><br/>
		<table width="100%" cellspacing="0" cellpadding="0" border="0">
			<tr valign="bottom">
				<td align="right"><asp:Button id="btnNuevo" runat="server" Text="Agregar nuevo"></asp:Button></td>
			</tr>
		</table>
	</div>

	<div id="sidebar">
	<h2 style="text-align:right">Ayuda</h2>
	<p>¡Bievenido a BIC! <br>Para poder usar BIC primero debe seleccionar el proyecto sobre el que desea trabajar.</p>
	<p>Si desea añadir un proyecto haga click en el boton Agregar nuevo.</p>
	<p>Si que desea ir a la pantalla de edicion de proyecto haga click en el boton Editar.</p>
	<p>Para eliminar un proyecto haga click en el boton Borrar.</p>
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
