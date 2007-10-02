<%@ Register TagPrefix="cc1" Namespace="Bic.WebControls" Assembly="Bic.WebControls" %>
<%@ Register TagPrefix="web" Namespace="WebChart" Assembly="WebChart" %>
<%@ Page language="c#" Codebehind="ChartWizardStep2.aspx.cs" AutoEventWireup="false" Inherits="Bic.Web.ChartWizardStep2" %>
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
						<h2>Paso 1 : determine el origen de datos</h2>
						<table width="100%" cellspacing="0" cellpadding="1" border="0" >
							<tr>
								<td>
									Fuente de datos
								</td>
								<td align="right">
									<asp:DropDownList id="ddlColumna" Runat="server" style="width:200px" AutoPostback ="true" ></asp:DropDownList>
								</td>
							</tr>
							<tr>
								<td>
									Fuente de descripciones
								</td>
								<td align="right">
									<asp:DropDownList id="ddlDescripciones" Runat="server" style="width:200px" AutoPostback ="true" ></asp:DropDownList>
								</td>
							</tr>							
							<tr >
								<td colspan="2">
									<asp:RadioButtonList ID="rdoBtnLstFilterOptions" Runat="server" AutoPostback ="true"></asp:RadioButtonList>
								</td>
							</tr>
						</table> 
						<br>	
						<h2>Previsualización</h2>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr vAlign="bottom">
								<td align="left">
									<asp:imagebutton id="imgBtnPreviewChart" Runat="server" ImageUrl="PreviewChartRenderPage.aspx" style="border:none"></asp:imagebutton>
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
					<div id="sidebar">
						<h2 style="TEXT-ALIGN:left">Ayuda</h2>
						<p>
							Seleccione el origen de datos para el gráfico.
						</p>
						<p>
							Para continuar con la generación de su gáfico, haga click en siguiente.
						</p>
						<p>
							Para salir del asistente de generación de gráficos, haga click en cancelar.
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


