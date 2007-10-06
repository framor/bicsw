<%@ Page language="c#" Codebehind="ReporteTest.aspx.cs" AutoEventWireup="false" Inherits="Bic.Web.test.ReporteTest" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ReporteTest</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label ID="consola" Runat="server" style="Z-INDEX: 101; LEFT: 24px; POSITION: absolute; TOP: 240px"></asp:Label>
			<asp:Button id="GeneraConsulta" style="Z-INDEX: 102; LEFT: 16px; POSITION: absolute; TOP: 24px"
				runat="server" Width="152px" Text="Genera Consulta"></asp:Button>
			<asp:RangeValidator id="RangeValidator1" style="Z-INDEX: 103; LEFT: 320px; POSITION: absolute; TOP: 328px"
				runat="server" ErrorMessage="El Peso debe ser un número entero entre 0 y 10." Type="Integer" MaximumValue="10"
				MinimumValue="0" ControlToValidate="txtPeso">*</asp:RangeValidator>
			<asp:TextBox id="TextBox1" style="Z-INDEX: 104; LEFT: 432px; POSITION: absolute; TOP: 160px"
				runat="server"></asp:TextBox>
			<asp:Panel id="Panel1" style="Z-INDEX: 105; LEFT: 704px; POSITION: absolute; TOP: 384px" runat="server">Panel</asp:Panel>
		</form>
	</body>
</HTML>
