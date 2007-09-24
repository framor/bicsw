<%@ Page language="c#" Codebehind="Home.aspx.cs" AutoEventWireup="false" Inherits="Bic.Web.Home" %>
<%@ Register TagPrefix="cc1" Namespace="Bic.WebControls" Assembly="Bic.WebControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
	<title>BIC - Business Intelligence Client</title>
	<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
	<link href="./lib/bic.css" rel="stylesheet" type="text/css" />
	</head>
	<body>
	<form id="Form1" method="post" runat="server">
	<div id="container">

	<cc1:Header id="bicHeader" runat="server"></cc1:Header>
	<cc1:Menu id="bicMenu" runat="server"></cc1:Menu>

	<div id="container2" style="height:450px">

	<div id="content" style="height:83%">
	</div>

	<div id="sidebar">
	<h2 style="text-align:right">Ayuda</h2>
	<p>Aquí encontrará todo lo correspondiente al proyecto seleccionado.</p>
	<p>Para crear o ejecutar un reporte haga click en Reportes.</p>
	<p>Para salir del proyecto haga click en quien sabe donde.</p>
	</div>

	<div id="footer">
	<p>
	<a href="http://validator.w3.org/check?uri=referer">Valid XHTML 1.0</a> | Copyright &copy; BIC | Design by <a href="#">BIC Design</a>
	</p>
	</div>

	</div>

	</div>
	</form>
	</body>
</html>


