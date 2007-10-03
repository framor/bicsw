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
								</td>
							</tr>
							<tr>
								<td width="30%" nowrap="nowrap"><b>Atributos disponibles:&nbsp; </b></td>
								<td width="10%">
									<asp:ListBox id="lstBoxAttDisponibles" runat="server"></asp:ListBox>
								</td>
								<td width="40%" nowrap="nowrap">
									<asp:LinkButton id="lnkBtnAddAttToColumn" Text="Agregar como columna" runat="server" ></asp:LinkButton><br>
									<asp:LinkButton id="lnkBtnAddAttToRow" Text="Agregar como fila" runat="server" ></asp:LinkButton><br>
									<asp:LinkButton id="lnkBtnRemoveAtt" Text="Remover" runat="server" ></asp:LinkButton>
								</td>
								<td width="10%">
									<asp:ListBox id="lstBoxAttSeleccionados" runat="server"></asp:ListBox>
								</td>
								<td width="10%">
									<asp:ListBox id="lstBoxAttDescriptions" runat="server"></asp:ListBox>
								</td>
							</tr>						
							<tr>
								<td width="30%" nowrap="nowrap"><b>Lista métricas:&nbsp; </b></td>
								<td width="10%">
									<asp:ListBox id="lstBoxMetricasDisponibles" runat="server"></asp:ListBox>
								</td>
								<td width="55%" nowrap="nowrap">
									<asp:LinkButton id="lnkBtnAddMetrica" Text="Agregar métrica" runat="server" ></asp:LinkButton><br>
									<asp:LinkButton id="lnkBtnRemoveMetrica" Text="Remover métrica" runat="server" ></asp:LinkButton><br>
								</td>
								<td width="10%">
									<asp:ListBox id="lstBoxMetricasSeleccionadas" runat="server"></asp:ListBox>
								</td>
							</tr>							
							<tr>
								<td width="30%" nowrap="nowrap"><b>Lista filtros:&nbsp; </b></td>
								<td width="10%">
									<asp:ListBox id="lstBoxFiltrosDisponibles" runat="server"></asp:ListBox>
								</td>
								<td width="55%" nowrap="nowrap">
									<asp:LinkButton id="lnkBtnAddFiltro" Text="Agregar filtro" runat="server" ></asp:LinkButton><br>
									<asp:LinkButton id="lnkBtnRemoveFiltro" Text="Remover filtro" runat="server" ></asp:LinkButton><br>
								</td>
								<td width="10%">
									<asp:ListBox id="lstBoxFiltrosSeleccionados" runat="server"></asp:ListBox>
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
							<p>Los Metricas están definidos por una columna. blah blah 
								bah...</p>
							<p>Si desea añadir un metrica haga click en el boton Agregar nuevo.</p>
							<p>Si que desea ir a la pantalla de edicion de un metrica haga click en el boton 
								Editar.</p>
							<p>Para eliminar un metrica del proyecto haga click en el boton Borrar.</p>
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
