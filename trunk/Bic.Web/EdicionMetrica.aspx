<%@ Page language="c#" Codebehind="EdicionMetrica.aspx.cs" AutoEventWireup="false" Inherits="Bic.Web.EdicionMetrica" %>
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
						<h2>Metricas</h2>
						<table width="100%" cellspacing="1" cellpadding="0" border="0">
							<tr>
								<td><b>Nombre</b></td>
								<td>
									<asp:TextBox id="txtNombre" runat="server" MaxLength="45"></asp:TextBox>
									<asp:CustomValidator Id="valNombre" runat="server">*</asp:CustomValidator>
									<asp:RequiredFieldValidator ID="reqNombre" Runat="server" ControlToValidate="txtNombre" ErrorMessage="Por favor complete el Nombre.">*</asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td><b>Hecho</b></td>
								<td>
									<asp:DropDownList id="ddlHecho" runat="server" DataTextField="Nombre" DataValueField="Id"></asp:DropDownList>
									<asp:RequiredFieldValidator ID="reqHecho" Runat="server" ControlToValidate="ddlHecho" ErrorMessage="Por favor complete el Hecho.">*</asp:RequiredFieldValidator>
								</td>
							</tr>						
							<tr>
								<td><b>Funcion</b></td>
								<td>
									<asp:DropDownList id="ddlFuncion" runat="server"></asp:DropDownList>
									<asp:RequiredFieldValidator ID="reqFuncion" Runat="server" ControlToValidate="ddlFuncion" ErrorMessage="Por favor complete la Funcion.">*</asp:RequiredFieldValidator>
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
					<p>Seleccione el hecho y la función que se le aplicará.</p>
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
