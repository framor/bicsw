<%@ Page language="c#" Codebehind="EdicionAtributo.aspx.cs" AutoEventWireup="false" Inherits="Bic.Web.EdicionAtributo" %>
<%@ Register TagPrefix="cc1" Namespace="Bic.WebControls" Assembly="Bic.WebControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<title>BIC - Business Intelligence Client</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<link href="./lib/bic.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<div id="container">
				<cc1:Header id="bicHeader" runat="server"></cc1:Header>
				<cc1:Menu id="bicMenu" runat="server"></cc1:Menu>
				<div id="container2" style="HEIGHT:450px">
					<div id="content" style="HEIGHT:83%">
						<h2>Atributos</h2>
						<table width="100%" cellspacing="1" cellpadding="0" border="0">
							<tr>
								<td><b>Nombre</b></td>
								<td>
									<asp:TextBox id="txtNombre" runat="server" MaxLength="45"></asp:TextBox>
									<asp:CustomValidator Id="valNombre" runat="server">*</asp:CustomValidator>
									<asp:RequiredFieldValidator ID="reqNombre" Runat="server" ControlToValidate="txtNombre" ErrorMessage="Por favor complete el Nombre.">*</asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td><b>Tabla LookUp</b></td>
								<td>
									<asp:DropDownList id="ddlTablaLookup" runat="server" DataTextField="Alias" DataValueField="Id"
										AutoPostBack="True" Width="150px"></asp:DropDownList>
									<asp:RequiredFieldValidator ID="reqTablaLookup" Runat="server" ControlToValidate="ddlTablaLookup" ErrorMessage="Por favor complete la Tabla Lookup.">*</asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td><b>Id</b></td>
								<td>
									<asp:DropDownList id="ddlColumnaId" runat="server" DataTextField="Nombre" DataValueField="Id" Width="150px" AutoPostBack="True"></asp:DropDownList>
									<asp:RequiredFieldValidator ID="reqColumnaId" Runat="server" ControlToValidate="ddlColumnaId" ErrorMessage="Por favor complete la Columna Id.">*</asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td valign="top"><b>Descripciones</b></td>
								<td>
									<asp:ListBox id="lstDescripciones" runat="server" DataTextField="Nombre" DataValueField="Id"
										Width="150px" SelectionMode="Multiple" Height="150px"></asp:ListBox>
									<asp:RequiredFieldValidator ID="reqDescripciones" Runat="server" ControlToValidate="lstDescripciones" ErrorMessage="Por favor seleccione una o más descripciones.">*</asp:RequiredFieldValidator>										
								</td>
							</tr>
							<tr>
								<td><b>Hijo</b></td>
								<td>
									<asp:DropDownList id="ddlHijo" runat="server" DataTextField="Nombre" DataValueField="Id"
										Width="150px" Height="100px"></asp:DropDownList>
								</td>
							</tr>
							<tr>
								<td colspan="2">
									<asp:ValidationSummary ID="valSummary" Runat="server"></asp:ValidationSummary>
								</td>
							</tr>
						</table>
						<br>
						<br>
						<br>
						<table width="100%" cellspacing="0" cellpadding="0" border="0">
							<tr valign="bottom">
								<td align="right">
									<asp:Button id="btnAceptar" runat="server" Text="Aceptar"></asp:Button>
									<asp:Button id="btnCancelar" runat="server" Text="Cancelar" CausesValidation="False"></asp:Button>
								</td>
							</tr>
						</table>
					</div>
					<div id="sidebar">
					<h2 style="text-align:right">Ayuda</h2>
					<p>Seleccione la tabla que corresponde al atributo y luego su id y descripciones.</p>
					<p>Para guardar los cambios haga click en Aceptar.</p>
					<p>Para cancelar los cambios haga click en Cancelar.</p>					
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
