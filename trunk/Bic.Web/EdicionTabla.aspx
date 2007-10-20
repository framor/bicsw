<%@ Page language="c#" Codebehind="EdicionTabla.aspx.cs" AutoEventWireup="false" Inherits="Bic.Web.EdicionTabla" %>
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
				<cc1:Menu id="bicMenu" runat="server"></cc1:Menu>
				<div id="container2" style="HEIGHT:450px">
					<div id="content" style="HEIGHT:83%">
						<h2>Tablas</h2>
						<table width="100%" cellspacing="1" cellpadding="0" border="0">
							<tr>
								<td><b>Alias</b></td>
								<td>
									<asp:TextBox id="txtAlias" runat="server" MaxLength="45"></asp:TextBox>
									<asp:CustomValidator Id="valAlias" runat="server">*</asp:CustomValidator>
									<asp:RequiredFieldValidator ID="reqAlias" Runat="server" ControlToValidate="txtAlias" ErrorMessage="Por favor complete el Alias.">*</asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td valign="top"><b>Nombre</b></td>
								<td>
									<asp:ListBox id="lstNombre" runat="server" DataTextField="Nombre" DataValueField="Nombre"
										Width="150px" Height="150px"></asp:ListBox>
									<asp:RequiredFieldValidator ID="reqNombre" Runat="server" ControlToValidate="lstNombre" ErrorMessage="Por favor complete el Nombre.">*</asp:RequiredFieldValidator>
								</td>
							</tr>						
							<tr>
								<td><b>Peso</b></td>
								<td>
									<asp:TextBox id="txtPeso" runat="server"></asp:TextBox>									
									<asp:RangeValidator id="RangeValidator1" runat="server" ErrorMessage="El Peso debe ser un número entero entre 0 y 10." 
										Type="Integer" MaximumValue="10" MinimumValue="0" ControlToValidate="txtPeso">*</asp:RangeValidator>
									<asp:RequiredFieldValidator ID="reqPeso" Runat="server" ControlToValidate="txtPeso"
										ErrorMessage="Por favor complete el Peso.">*</asp:RequiredFieldValidator>
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
					<h2 style="text-align:right">Ayuda</h2>
					<p>Defina un alias para la tabla y luego seleccione la correspondiente a la base de datos.</p>
					<p>Para guardar los cambios haga click en Aceptar.</p>
					<p>Para cancelar los cambios haga click en Cancelar.</p>					
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
