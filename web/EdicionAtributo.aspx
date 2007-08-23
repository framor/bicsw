<%@ Page language="c#" Codebehind="EdicionAtributo.aspx.cs" AutoEventWireup="false" Inherits="bic.EdicionAtributo" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<title>BIC - Business Intelligence Client</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<link href="./lib/bic.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<div id="container">
				<div id="header">
					<table height="100%" width="100%" cellspacing="0" cellpadding="0" border="0">
						<tr>
							<td>
								<img src="./img/logo-small.jpg">
							</td>
							<td align="right">
								<h1><asp:Label ID="lblProyecto" Runat="server"></asp:Label></h1>
								<p><asp:Label ID="lblUsuario" Runat="server"></asp:Label>&nbsp;<a href="Login.aspx"><img alt="Cerrar sesi�n" src="./img/logout.png"></a></p>
							</td>
						</tr>
					</table>
				</div>
				<div id="tabs10">
					<ul>
						<li>
							<a href="ListaAtributo.aspx" title="Atributos">
								<span>Atributos</span></a>
						<li>
							<a href="ListaHecho.aspx" title="Hechos">
								<span>Hechos</span></a>
						<li>
							<a href="ListaFiltro.aspx" title="Filtros">
								<span>Filtros</span></a>
						<li>
							<a href="ListaMetrica.aspx" title="Metricas">
								<span>Metricas</span></a>
						<li>
							<a href="ListaRelacion.aspx" title="Relaciones">
								<span>Relaciones</span></a>
						<li>
							<a href="ListaReporte.aspx" title="Reportes">
								<span>Reportes</span></a></li>
					</ul>
				</div>
				<div id="container2" style="HEIGHT:450px">
					<div id="content" style="HEIGHT:83%">
						<h2>Atributos</h2>
						<table width="100%" cellspacing="1" cellpadding="0" border="0">
							<tr>
								<td><b>Nombre</b></td>
								<td>
									<asp:TextBox id="txtNombre" runat="server"></asp:TextBox>
									<asp:RequiredFieldValidator ID="reqNombre" Runat="server" ControlToValidate="txtNombre" ErrorMessage="Por favor complete el Nombre.">*</asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td><b>ID</b></td>
								<td>
									<asp:DropDownList id="ddlCampoId" runat="server" DataTextField="Nombre" DataValueField="Id"></asp:DropDownList>
									<asp:RequiredFieldValidator ID="reqCampoId" Runat="server" ControlToValidate="ddlCampoId" ErrorMessage="Por favor complete el Campo Id.">*</asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td><b>DESC</b></td>
								<td>
									<asp:DropDownList id="ddlCampoDescripcion" runat="server" DataTextField="Nombre" DataValueField="Id"></asp:DropDownList>
									<asp:RequiredFieldValidator ID="reqCampoDescripcion" Runat="server" ControlToValidate="ddlCampoDescripcion"
										ErrorMessage="Por favor complete el Campo Descripcion.">*</asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td><b>LookUp Table</b></td>
								<td>
									<asp:DropDownList id="ddlTablaLookup" runat="server" DataTextField="Nombre" DataValueField="Id"></asp:DropDownList>
									<asp:RequiredFieldValidator ID="reqTablaLookup" Runat="server" ControlToValidate="ddlTablaLookup" ErrorMessage="Por favor complete la Tabla Lookup.">*</asp:RequiredFieldValidator>
									
								</td>
							</tr>
							<tr>
								<td colspan="2">
									<asp:ValidationSummary ID="valSummary" Runat="server"></asp:ValidationSummary>
								</td>
							</tr>
						</table>
						<br>
						<br>
						<br>
						<table width="100%" cellspacing="0" cellpadding="0" border="0">
							<tr valign="bottom">
								<td align="right">
									<asp:Button id="btnAceptar" runat="server" Text="Aceptar"></asp:Button>
									<asp:Button id="btnCancelar" runat="server" Text="Cancelar" CausesValidation="False"></asp:Button>
								</td>
							</tr>
						</table>
					</div>
					<div id="sidebar">
						<h2 style="TEXT-ALIGN:right"><span onclick="toggleHelp();"> Ayuda</span></h2>
						<div id="helpBody" style="DISPLAY:none">
							<p>Los atributos est�n definidos por una columna id y una descripci�n. blah blah 
								bah...</p>
							<p>Si desea a�adir un atributo haga click en el boton Agregar nuevo.</p>
							<p>Si que desea ir a la pantalla de edicion de un atributo haga click en el boton 
								Editar.</p>
							<p>Para eliminar un atributo del proyecto haga click en el boton Borrar.</p>
						</div>
					</div>
					<div id="footer">
						<p>
							<a href="http://validator.w3.org/check?uri=referer">Valid XHTML 1.0</a> | 
							Copyright � BIC | Design by <a href="#">BIC Design</a>
						</p>
					</div>
				</div>
			</div>
		</form>
	</body>
</HTML>
