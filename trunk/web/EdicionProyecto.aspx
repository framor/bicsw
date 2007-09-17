<%@ Page language="c#" Codebehind="EdicionProyecto.aspx.cs" AutoEventWireup="false" Inherits="bic.EdicionProyecto" %>
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
								<h1>&nbsp;</h1>
								<p><asp:Label ID="lblUsuario" Runat="server"></asp:Label>&nbsp;<a href="Login.aspx"><img alt="Cerrar sesión" src="./img/logout.png"></a></p>
							</td>
						</tr>
					</table>
				</div>
				<div id="tabs10">
				</div>
				<div id="container2" style="HEIGHT:450px">
					<div id="content" style="HEIGHT:83%">
						<h2>Proyectos</h2>
						<table width="100%" cellspacing="1" cellpadding="0" border="0">
							<tr>
								<td><b>Nombre</b></td>
								<td>
									<asp:TextBox id="txtNombre" runat="server"></asp:TextBox>
									<asp:RequiredFieldValidator ID="reqNombre" Runat="server" ControlToValidate="txtNombre" ErrorMessage="Por favor complete el Nombre.">*</asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td><b>Descripcion</b></td>
								<td>
									<asp:TextBox id="txtDescripcion" runat="server"></asp:TextBox>
									<asp:RequiredFieldValidator ID="reqDescripcion" Runat="server" ControlToValidate="txtDescripcion" ErrorMessage="Por favor complete la Descripcion.">*</asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td><b>Servidor</b></td>
								<td>
									<asp:TextBox id="txtServidor" runat="server"></asp:TextBox>
									<asp:RequiredFieldValidator ID="reqServidor" Runat="server" ControlToValidate="txtServidor" ErrorMessage="Por favor complete el Servidor.">*</asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td><b>Puerto</b></td>
								<td>
									<asp:TextBox id="txtPuerto" runat="server"></asp:TextBox>
									<asp:RequiredFieldValidator ID="reqPuerto" Runat="server" ControlToValidate="txtPuerto" ErrorMessage="Por favor complete el Puerto.">*</asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td><b>Esquema</b></td>
								<td>
									<asp:TextBox id="txtEsquema" runat="server"></asp:TextBox>
									<asp:RequiredFieldValidator ID="reqEsquema" Runat="server" ControlToValidate="txtEsquema" ErrorMessage="Por favor complete el Esquema.">*</asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td><b>Usuario</b></td>
								<td>
									<asp:TextBox id="txtUsuario" runat="server"></asp:TextBox>
									<asp:RequiredFieldValidator ID="reqUsuario" Runat="server" ControlToValidate="txtUsuario" ErrorMessage="Por favor complete el Usuario.">*</asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td><b>Password</b></td>
								<td>
									<asp:TextBox id="txtPassword" runat="server"></asp:TextBox>
									<asp:RequiredFieldValidator ID="reqPassword" Runat="server" ControlToValidate="txtPassword" ErrorMessage="Por favor complete el Password.">*</asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td><asp:Button id="btnProbarConexion" runat="server" Text="Probar conexión"></asp:Button></td>
								<td>
									<asp:Label Runat="server" ID="lblEstadoConexion"></asp:Label>
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
							<p>Los atributos están definidos por una columna id y una descripción. blah blah 
								bah...</p>
							<p>Si desea añadir un atributo haga click en el boton Agregar nuevo.</p>
							<p>Si que desea ir a la pantalla de edicion de un atributo haga click en el boton 
								Editar.</p>
							<p>Para eliminar un atributo del proyecto haga click en el boton Borrar.</p>
						</div>
					</div>
					<div id="footer">
						<p>
							<a href="http://validator.w3.org/check?uri=referer">Valid XHTML 1.0</a> | 
							Copyright © BIC | Design by <a href="#">BIC Design</a>
						</p>
					</div>
				</div>
			</div>
		</form>
	</body>
</HTML>
