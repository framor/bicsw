<%@ Page language="c#" Codebehind="Login.aspx.cs" AutoEventWireup="false" Inherits="Bic.Web.Login" %>
	<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
	<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
	<title>BIC - Business Intelligence Client</title>
	<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
	<link href="style.css" rel="stylesheet" type="text/css" />	
	<script language=javascript>
		function setFocus() {
			var u = document.getElementById('txtUsuario');
			if (u) u.focus();
		}
	</script>
	</head>	
	<body onload="javascript:setFocus();">
	<form id="form1" method="post" runat="server">
	
	<div id="container">

	<div style="height:450px;width: 746px;
	  margin: 0 auto;
	  font-family: Verdana, Arial, Helvetica, sans-serif;
	  font-size: 11px;
	  line-height: 1.6em;
	  color: #666666;
	  background-color: #FFFFFF;">

		<br/><br/><br/><br/><br/><br/><br/>
		<table width="50%" cellspacing="0" cellpadding="10" border="1" align="center">
		<tr><td align="center">

		<table width="100%" cellspacing="0" cellpadding="0" border="0">
			<tr>
				<td style="text-align:left"><img src="./img/logo-small.jpg" /></td>
			</tr>
		</table>

		</td></tr>
		<tr><td align="center">

		<table width="100%" cellspacing="0" cellpadding="5" border="0">
			<tr>
				<td>Usuario</td>
				<td><asp:TextBox ID="txtUsuario" Runat="server" Width="150px" MaxLength="45"></asp:TextBox></td>
			</tr>
			<tr>
				<td>Contraseña</td>
				<td><asp:TextBox ID="txtContrasena" Runat="server" TextMode="Password" Width="150px" MaxLength="45"></asp:TextBox></td>
			</tr>
			<tr>
				<td>&nbsp;</td>
				<td style="text-align:right"><asp:Button id="btnIniciar" Runat=server Text="Iniciar sesión"></asp:Button></td>
			</tr>
			<tr>
				<td colspan=2><asp:CustomValidator ID="valLogin" Runat="server"></asp:CustomValidator></td>
			</tr>
		</table>

		</td></tr></table>
		<br/><br/><br/><br/><br/><br/><br/>

	</div>

	</div>
	
	</form>
	</body>
</html>


