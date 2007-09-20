<%@ Page language="c#" Codebehind="AdministracionReportes.aspx.cs" AutoEventWireup="false" Inherits="Bic.Web.AdministracionReportes" %>
<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=9.1.5000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministracionReportes</title>
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<div id="container">
				<div id="header">
					<table height="100%" width="100%" cellspacing="0" cellpadding="0" border="0">
						<tr>
							<td>
								<img src="./img/logo-small.jpg">&nbsp;
							</td>
							<td align="right">
								<h1>&nbsp;</h1>
								<p>
									<asp:DataGrid id="DataGrid1" runat="server"></asp:DataGrid>&nbsp;<a href="Login.aspx"></a></p>
							</td>
						</tr>
					</table>
				</div>
			</div>
		</form>
	</body>
</HTML>
