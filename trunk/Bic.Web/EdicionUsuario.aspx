<%@ Page language="c#" Codebehind="EdicionUsuario.aspx.cs" AutoEventWireup="false" Inherits="Bic.Web.EdicionUsuario" %>
<%@ Register TagPrefix="cc1" Namespace="Bic.WebControls" Assembly="Bic.WebControls" %>
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
				<cc1:Header id="bicHeader" runat="server"></cc1:Header>			
				<div id="tabs10">
				</div>
				<div id="container2" style="HEIGHT:450px">
					<div id="content" style="HEIGHT:83%">
						<h2>Usuarios</h2>
						<table width="100%" cellspacing="1" cellpadding="0" border="0">
							<tr>
								<td><b>Nombre de usuario</b></td>
								<td>
									<asp:TextBox id="txtNombre" runat="server" MaxLength="45"></asp:TextBox>
									<asp:RequiredFieldValidator ID="reqNombre" Runat="server" ControlToValidate="txtNombre" ErrorMessage="Por favor complete el Nombre.">*</asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td><b>Usuario</b></td>
								<td>
									<asp:TextBox id="txtAlias" runat="server" MaxLength="45"></asp:TextBox>
									<asp:CustomValidator Id="valAlias" runat="server">*</asp:CustomValidator>
									<asp:RequiredFieldValidator ID="reqAlias" Runat="server" ControlToValidate="txtAlias" ErrorMessage="Por favor complete el Usuario.">*</asp:RequiredFieldValidator>
								</td>
							</tr>							
							<tr>
								<td><b>Contraseña</b></td>
								<td>
									<asp:TextBox id="txtContrasena" runat="server" MaxLength="45"></asp:TextBox>
									<asp:RequiredFieldValidator ID="reqContrasena" Runat="server" ControlToValidate="txtContrasena" ErrorMessage="Por favor complete la contraseña.">*</asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td><b>Correo electrónico</b></td>
								<td>
									<asp:TextBox id="txtEMail" runat="server" MaxLength="45"></asp:TextBox>									
									<asp:RegularExpressionValidator runat="server" id="valEmail" ControlToValidate="txtEMail"
										ValidationExpression="^[\w-]+@[\w-]+\.(com|net|org|edu|mil)$" errormessage="El formato del correo electrónico es incorrecto." Display="Dynamic">*</asp:RegularExpressionValidator>									
								</td>
							</tr>
							<tr>
								<td><b>Perfil</b></td>
								<td>
									<asp:DropDownList id="ddlRol" runat="server" DataTextField="Nombre" DataValueField="Id"></asp:DropDownList>
									<asp:RequiredFieldValidator ID="reqRol" Runat="server" ControlToValidate="ddlRol" ErrorMessage="Por favor complete el perfil.">*</asp:RequiredFieldValidator>
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
							<p>Los usuarios son quienes estan autorizados a utilizar BIC.</p>
							<p>describir roles blah blah blah blah blah blah blah blah blah </p>
							<p>blah blah blah blah blah blah blah blah blah blah blah blah blah </p>
							<p>blah blah blah blah blah blah blah blah blah blah blah blah blah blah </p>
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
