<%@ Page language="c#" Codebehind="AdministracionReportes.aspx.cs" AutoEventWireup="false" Inherits="Bic.Web.AdministracionReportes" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<title>BIC - Business Intelligence Client</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<link href="../lib/bic.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body>
		<form id="form1" method="post" runat="server">
			<div id="container">
				<div id="header">
					<table height="100%" width="100%" cellspacing="0" cellpadding="0" border="0">
						<tr>
							<td>
								<img src="../img/logo-small.jpg">
							</td>
							<td align="right">
								<h1>&nbsp;</h1>
								<p><asp:Label ID="lblUsuario" Runat="server"></asp:Label>&nbsp;<a href="Login.aspx"><img alt="Cerrar sesión" src="../img/logout.png"></a></p>
							</td>
						</tr>
					</table>
				</div>
				<div id="tabs10">
				</div>
				<div id="container2">
					<div id="content" style="HEIGHT:83%">
						<h2>Reporte</h2>
						<table width="100%" cellspacing="0" cellpadding="0" border="0">
							<tr valign="bottom">
								<td align="left">
									<asp:datagrid id="dtgReport" Runat="server" CellPadding="5" Font-Names="Verdana" Width="100%"
										UseAccessibleHeader="True">
										<AlternatingItemStyle Font-Names="Verdana" ForeColor="Black" BackColor="Gainsboro"></AlternatingItemStyle>
										<ItemStyle Font-Names="Verdana" ForeColor="Black" BackColor="PapayaWhip"></ItemStyle>
										<HeaderStyle Font-Names="Verdana" ForeColor="Black" BackColor="LightBlue"></HeaderStyle>
									</asp:datagrid>
								</td>
							</tr>
						</table>
						<br>
						<h2>Exportar</h2>
						<table width="100%" cellspacing="0" cellpadding="0" border="0">
							<tr>
								<td>
									<asp:imagebutton id="imgBtnExcel" Runat="server" ImageUrl="../img/iconExcel.JPG"></asp:imagebutton>
									<asp:imagebutton id="imgBtnWord" Runat="server" ImageUrl="../img/iconWord.JPG"></asp:imagebutton>
									<asp:imagebutton id="imgBtnPDF" Runat="server" ImageUrl="../img/iconPDF.jpg"></asp:imagebutton>
									<asp:imagebutton id="imgBtnText" Runat="server" ImageUrl="../img/iconNotepad.JPG"></asp:imagebutton>
								</td>
							</tr>
						</table>
						<br>
						<h2>Graficar</h2>
						<table width="100%" cellspacing="0" cellpadding="0" border="0">
							<tr>
								<td>
									Tipo de gráfico<asp:DropDownList id="ddlTipoGrafico" Runat="server"></asp:DropDownList>
								</td>
							</tr>
							<tr>
								<td>
									Fuente de datos<asp:DropDownList id="ddlColumna" Runat="server"></asp:DropDownList>
								</td>
							</tr>
							<tr>
								<td>
									Fuente de descripciones<asp:DropDownList id="ddlDescripciones" Runat="server"></asp:DropDownList>
								</td>
							</tr>
							<tr>
								<td>
									<asp:Button id="btnContinuar" runat="server" Text="Continuar"></asp:Button>
								</td>
							</tr>
						</table>
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
