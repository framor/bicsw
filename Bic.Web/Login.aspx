<%@ Page language="c#" Codebehind="Login.aspx.cs" AutoEventWireup="false" Inherits="Bic.Web.Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<title>BIC - Business Intelligence Client</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<link href="style.css" rel="stylesheet" type="text/css">
			<script language="javascript">
		function setFocus() {
			var u = document.getElementById('txtUsuario');
			if (u) u.focus();
		}
			</script>
	</HEAD>
	<body onload="javascript:setFocus();">
		<form id="form1" method="post" runat="server">
			<div id="container">
				<div style="FONT-SIZE:11px;MARGIN:0px auto;WIDTH:746px;COLOR:#666666;LINE-HEIGHT:1.6em;FONT-FAMILY:Verdana, Arial, Helvetica, sans-serif;HEIGHT:450px;BACKGROUND-COLOR:#ffffff">
					<br>
					<br>
					<br>
					<br>
					<br>
					<br>
					<br>
					<table width="50%" cellspacing="0" cellpadding="10" border="1" align="center">
						<tr>
							<td align="center">
								<table width="100%" cellspacing="0" cellpadding="0" border="0">
									<tr>
										<td><img src="./img/logo-small.jpg"></td>
									</tr>
								</table>
							</td>
						</tr>
						<tr>
							<td align="center">
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
										<td><asp:Button id="btnIniciar" Runat="server" Text="Iniciar sesión"></asp:Button></td>
									</tr>
									<tr>
										<td colspan="2"><asp:CustomValidator ID="valLogin" Runat="server"></asp:CustomValidator></td>
									</tr>
								</table>
							</td>
						</tr>
					</table>
					<br>
					<br>
					<br>
					<br>
					<br>
					<br>
					<br>
				</div>
			</div>
		</form>
	</body>
</HTML>
