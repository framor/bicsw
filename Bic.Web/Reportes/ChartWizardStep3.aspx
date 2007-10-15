<%@ Register TagPrefix="cc1" Namespace="Bic.WebControls" Assembly="Bic.WebControls" %>
<%@ Register TagPrefix="web" Namespace="WebChart" Assembly="WebChart" %>
<%@ Page language="c#" Codebehind="ChartWizardStep3.aspx.cs" AutoEventWireup="false" Inherits="Bic.Web.ChartWizardStep3" %>
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
						<table width="100%" >
							<tr>
								<td>
									<h2>Paso 3 : visualice gráfico</h2>			
								</td>
								<td align="right">
									<a href="javascript:window.print();"><img src="../img/icon-print.jpg" /></a>
								</td>
							</tr>
						</table>
						
						<table width="100%" cellspacing="0" cellpadding="1" border="0" >
							<tr>
								<td>
								<asp:imagebutton id="imgBtnChart" Runat="server" ImageUrl="ChartRenderPage.aspx" style="border:none"></asp:imagebutton>
								</td>
							</tr>
						</table> 
						<br>	
						<table width="100%" cellspacing="0" cellpadding="0" border="0">							
								<tr valign="bottom">
									<td align="left">
										<asp:Button ID="btnCancel" Runat="server" Text ="Cancelar"></asp:Button>
										<asp:Button ID="btnBack" Runat="server" Text ="Anterior"></asp:Button>
										<asp:Button ID="btnNext" Runat="server" Text ="Siguiente"></asp:Button>
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
</html>


