<%@ Page language="c#" Codebehind="GeneradorGraficos.aspx.cs" AutoEventWireup="false" Inherits="Bic.Web.Reportes.GeneradorGraficos" %>
<%@ Register TagPrefix="web" Namespace="WebChart" Assembly="WebChart" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<title>BIC - Business Intelligence Client</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="../lib/bic.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="form1" method="post" runat="server">
			<div id="container">
				<div id="header">
					<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
						<tr>
							<td><IMG src="../img/logo-small.jpg">
							</td>
							<td align="right">
								<h1>&nbsp;</h1>
								<p><asp:label id="lblUsuario" Runat="server"></asp:label>&nbsp;<A href="Login.aspx"><IMG alt="Cerrar sesión" src="../img/logout.png"></A></p>
							</td>
						</tr>
					</table>
				</div>
				<div id="tabs10"></div>
				<div id="container2" style="HEIGHT: 450px">
					<div id="content" style="HEIGHT: 83%">
						<h2>Grafico</h2>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr vAlign="bottom">
								<td align="left">
								
								<web:chartcontrol id="chartControl" Width="682px" Height="540px" Padding="10" ChartPadding="25" TopPadding="18" runat="server" >
									<YTitle ForeColor="Black" Font="Tahoma, 8pt"></YTitle>
									<ChartTitle ForeColor="White" Text="Salary" Font="Tahoma, 10pt, style=Bold"></ChartTitle>
									<XTitle ForeColor="Black" Font="Tahoma, 8pt"></XTitle>
									<Background Type="Solid" StartPoint="0, 0" ForeColor="Black" EndPoint="100, 100" Color="RosyBrown" HatchStyle="Shingle"></Background>
									<Border EndCap="Flat" DashStyle="Solid" StartCap="Flat" Color="Black" Width="0" LineJoin="Miter"></Border>
									<PlotBackground Type="Solid" StartPoint="0, 0" ForeColor="Black" EndPoint="100, 100" Color="White" HatchStyle="Shingle"></PlotBackground>
									<YAxisFont ForeColor="Black" Font="Tahoma, 8pt"></YAxisFont>
									<XAxisFont ForeColor="Black" Font="Tahoma, 8pt"></XAxisFont>
									<Legend Width="80" Font="Tahoma, 8pt">
										<Border EndCap="Flat" DashStyle="Solid" StartCap="Flat" Color="Brown" Width="1" LineJoin="Miter"></Border>
										<Background Type="Solid" StartPoint="0, 0" ForeColor="Black" EndPoint="100, 100" Color="White" HatchStyle="Shingle"></Background>
									</Legend>
									
									</web:chartcontrol></td>
							</tr>
						</table>
					</div>
					<div id="sidebar">
						<h2 style="TEXT-ALIGN: right">Ayuda</h2>
						<p>¡Bievenido a BIC!
							<br>
							Como administrador solo podrá administrar los usuarios.</p>
						<p>Si desea añadir un usuario haga click en el boton Agregar nuevo.</p>
						<p>Si que desea ir a la pantalla de edicion de usuario haga click en el boton 
							Editar.</p>
						<p>Para eliminar un usuario haga click en el boton Borrar.</p>
					</div>
					<div id="footer">
						<p><a href="http://validator.w3.org/check?uri=referer">Valid XHTML 1.0</a> | 
							Copyright © BIC | Design by <A href="#">BIC Design</A>
						</p>
					</div>
				</div>
			</div>
		</form>
	</body>
</HTML>
