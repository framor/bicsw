<%@ Register TagPrefix="cc1" Namespace="Bic.WebControls" Assembly="Bic.WebControls" %>
<%@ Page language="c#" Codebehind="ChartWizardStep1.aspx.cs" AutoEventWireup="false" Inherits="Bic.Web.ChartWizardStep1" %>
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
						<h2>Paso 1: Escoja el estilo de su gráfico</h2>
						<table width="100%" cellspacing="0" cellpadding="0" border="0">
							<tr>
								<td width="60%">
									<asp:Panel id="pnlBars" runat="server"></asp:Panel>
									<asp:Panel id="pnlColumns" runat="server"></asp:Panel>
									<asp:Panel id="pnlArea" runat="server"></asp:Panel>
									<asp:Panel id="pnlPie" runat="server"></asp:Panel>
									<asp:Panel id="pnlLines" runat="server"></asp:Panel>
							
							<!--<asp:ImageButton id="imgBtnIconBarsChart" Runat="server" style="border:none"></asp:ImageButton>
									<asp:ImageButton id="imgBtnIconColumnsChart"  Runat="server" style="border:none"></asp:ImageButton>
									<asp:ImageButton id="imgBtnIconAreaChart"  Runat="server" style="border:none"></asp:ImageButton>
									<asp:ImageButton id="imgBtnIconPieChart" Runat="server" style="border:none"></asp:ImageButton>
									<asp:ImageButton id="imgBtnIconLinesChart" Runat="server" style="border:none"></asp:ImageButton> -->
								</td>
								<td align="left" >
								
									<asp:Label id="lblChartTypeSelected" Runat="server" style=:"align:left" ></asp:Label>
								</td>								
							</tr>
						</table> 	
						<br>	
						<br>
						<table width="100%" cellspacing="0" cellpadding="0" border="0">							
								<tr valign="bottom">
									<td align="left">
										<asp:Button ID="btnCancel" Runat="server" Text ="Cancelar"></asp:Button>
										<asp:Button ID="btnBack" Runat="server" Text ="&lt; Anterior"></asp:Button>
										<asp:Button ID="btnNext" Runat="server" Text ="Siguiente &gt;"></asp:Button>
									</td>
								</tr>
						</table>			
					</div>
					<div id="sidebar">
						<h2 style="TEXT-ALIGN:left">Ayuda</h2>
						<p>
							Seleccione los tipos de gráfico que desea generar.
						</p>
						<p>
							Puede escoger mas de un tipo de grafico siempre y cuando, estos sean compatibles: por ejemplo lineas y barras.							
						</p>
						<p>
							Para continuar con la generación de su gáfico, haga click en siguiente.
						</p>
						<p>
							Para salir del asistente de generación de gráficos, haga click en cancelar.
						</p>
					</div>
					<!--<div id="footer">
						<p>
							<a href="http://validator.w3.org/check?uri=referer">Valid XHTML 1.0</a> | 
							Copyright © BIC | Design by <a href="#">BIC Design</a>
						</p>
					</div>-->
				</div>
			</div>
		</form>
	</body>
</html>



