<%@ Page language="c#" Codebehind="EdicionFiltro.aspx.cs" AutoEventWireup="false" Inherits="Bic.Web.EdicionFiltro" %>
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
						<h2>Filtros</h2>
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
								<td><b>Atributo</b></td>
								<td>
									<asp:DropDownList id="ddlAtributo" runat="server" DataTextField="Nombre" DataValueField="Id" AutoPostBack="True" Width="150px"></asp:DropDownList>
								</td>
							</tr>	
							<tr>
								<td><b>Descripcion</b></td>
								<td>
									<asp:DropDownList id="ddlDescripcion" runat="server" DataTextField="Nombre" DataValueField="Id" Width="150px"></asp:DropDownList>
									<asp:RequiredFieldValidator ID="reqColumna" Runat="server" ControlToValidate="ddlDescripcion" ErrorMessage="Por favor complete la Descripcion.">*</asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td><b>Operador</b></td>
								<td>
									<asp:DropDownList id="ddlOperador" runat="server" Width="150px"></asp:DropDownList>
									<asp:RequiredFieldValidator ID="reqOperador" Runat="server" ControlToValidate="ddlOperador" ErrorMessage="Por favor complete el operador.">*</asp:RequiredFieldValidator>
								</td>
							</tr>						
							<tr>
								<td><b>Valor</b></td>
								<td>
									<asp:TextBox id="txtValor" runat="server" MaxLength="45"></asp:TextBox>
									<asp:RequiredFieldValidator ID="reqValor" Runat="server" ControlToValidate="txtValor" ErrorMessage="Por favor complete el Valor.">*</asp:RequiredFieldValidator>
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
					<p>Especifique el criterio de filtrado.</p>
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
