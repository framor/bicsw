<%@ Page language="c#" Codebehind="AdministracionReportes.aspx.cs" AutoEventWireup="false" Inherits="Bic.Web.AdministracionReportes" %>
<%@ Register TagPrefix="cc1" Namespace="Bic.WebControls" Assembly="Bic.WebControls" %>
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
				<cc1:Header id="bicHeader" runat="server"></cc1:Header>
				<cc1:Menu id="bicMenu" runat="server"></cc1:Menu>
				<div id="tabs10">
				</div>
				<div id="container2">
					<div id="content" style="HEIGHT:83%">
						<h2>Exportar y graficar</h2>
						<table width="100%" cellspacing="0" cellpadding="0" border="0">
							<tr>
								<td>
									<asp:imagebutton id="imgBtnExcel" Runat="server" ImageUrl="../img/iconExcel.JPG" style="border:none"></asp:imagebutton>
									<asp:imagebutton id="imgBtnWord" Runat="server" ImageUrl="../img/iconWord.JPG" style="border:none"></asp:imagebutton>
									<asp:imagebutton id="imgBtnPDF" Runat="server" ImageUrl="../img/iconPDF.jpg" style="border:none"></asp:imagebutton>
									<asp:imagebutton id="imgBtnText" Runat="server" ImageUrl="../img/iconNotepad.JPG" style="border:none"></asp:imagebutton>
								</td>
								<td>
									<input type="button"  value="Asistente de gráficos" onClick="window.open('ChartWizardStep1.aspx' , 'Asistente' , 'width= 800 ,height=730 ,directories= no ,location= no ,menubar= no ,scrollbars= no ,status=no ,toolbar= no,resizable=no')">
								</td>
								<td>
									<input type="button"  value="Ver SQL" onClick="window.open('VerSQL.aspx' , 'Ver SQL' , 'width= 800 ,height=400 ,directories= no ,location= no ,menubar= no ,scrollbars= no ,status=no ,toolbar= no,resizable=no')">
								</td>
							</tr>
						</table>
						<br>
						<h2>Reporte</h2>
						<table width="100%" cellspacing="0" cellpadding="0" border="0">
							<tr valign="bottom">
								<td align="left">
									Drill down
									<asp:DropDownList id="ddlDrillDown" runat="server" AutoPostBack="True"></asp:DropDownList>
								</td>
								<td align="left">
									Drill up
									<asp:DropDownList id="ddlDrillUp" runat="server" AutoPostBack="True"></asp:DropDownList>
								</td>
							</tr>
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