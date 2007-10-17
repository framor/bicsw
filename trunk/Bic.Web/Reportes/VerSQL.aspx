<%@ Register TagPrefix="cc1" Namespace="Bic.WebControls" Assembly="Bic.WebControls" %>
<%@ Page language="c#" Codebehind="VerSQL.aspx.cs" AutoEventWireup="false" Inherits="Bic.Web.VerSQL" %>
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
				<div id="tabs10">
				</div>
				<div id="container2">
					<div id="content" style="HEIGHT:100%">
						<h2>SQL</h2>
						<table width="100%" cellspacing="0" cellpadding="0" border="0">
							<tr>
								<td >
									<asp:Label id="lblSQLString" Runat="server"></asp:Label>
								</td>								
							</tr>
						</table> 	
						<br>	
						<br>
						<table width="100%" cellspacing="0" cellpadding="0" border="0">							
								<tr valign="bottom">
									<td align="left">
										<asp:Button ID="btnBack" Runat="server" Text ="&lt; Anterior"></asp:Button>
										<asp:Button ID="btnNext" Runat="server" Text ="Siguiente &gt;"></asp:Button>
										<asp:Button ID="btnCancel" Runat="server" Text ="Cerrar"></asp:Button>
									</td>
								</tr>
						</table>			
					</div>
					<div id="sidebar">
						<h2 style="TEXT-ALIGN:left">Ayuda</h2>
						<p>
							Aqui puede visualizar la sentencia SQL responsable de la generación del reporte.
						</p>
						<p>
							Haga click en Cerrar para salir de esta ventana.
						</p>
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
</html>


