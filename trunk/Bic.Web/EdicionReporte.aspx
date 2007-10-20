<%@ Page language="c#" Codebehind="EdicionReporte.aspx.cs" AutoEventWireup="false" Inherits="Bic.Web.EdicionReporte" %>
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
						<h2>Configurando reporte</h2>
						<table width="100%" cellspacing="1" cellpadding="0" border="0">
							<tr>
								<td width="30%" nowrap="nowrap"><b>Nombre reporte:&nbsp;</b></td>
								<td width="70%" colspan="4">
									<asp:TextBox id="txtNombreReporte" runat="server"></asp:TextBox>
									<asp:RequiredFieldValidator ID="reqNombreReporte" Runat="server" ControlToValidate="txtNombreReporte" ErrorMessage="Por favor complete el Nombre del reporte.">*</asp:RequiredFieldValidator>
									<asp:CustomValidator Id="valNombre" runat="server">*</asp:CustomValidator>
								</td>
							</tr>
							<tr>
								<td><b>Atributos</b></td>
								<td>
									<asp:ListBox id="lstAtributos" runat="server" DataTextField="Nombre" DataValueField="Id"
										Width="150px" SelectionMode="Multiple"></asp:ListBox>
								</td>
							</tr>
							<tr>
								<td><b>Metricas</b></td>
								<td>
									<asp:ListBox id="lstMetricas" runat="server" DataTextField="Nombre" DataValueField="Id"
										Width="150px" SelectionMode="Multiple"></asp:ListBox>
								</td>
							</tr>
							<tr>
								<td><b>Filtros</b></td>
								<td>
									<asp:ListBox id="lstFiltros" runat="server" DataTextField="Nombre" DataValueField="Id"
										Width="150px" SelectionMode="Multiple"></asp:ListBox>
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
					<p>Seleccione los atributos y metricas a mostrar.</p>
					<p>Si desea acotar la búsqueda también puede seleccionar filtros.</p>
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
