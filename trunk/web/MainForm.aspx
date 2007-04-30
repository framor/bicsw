<%@ Page language="c#" Codebehind="MainForm.aspx.cs" AutoEventWireup="false" Inherits="SqlBuilder.MainForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="Label1" style="Z-INDEX: 101; LEFT: 40px; POSITION: absolute; TOP: 24px" runat="server"
				Width="64px" Height="16px">Hechos</asp:Label>
			<asp:Button id="btnRemoverAtributo" style="Z-INDEX: 111; LEFT: 264px; POSITION: absolute; TOP: 368px"
				runat="server" Width="88px" Text="Remover"></asp:Button>
			<asp:Button id="btnAgregarAtributo" style="Z-INDEX: 110; LEFT: 264px; POSITION: absolute; TOP: 304px"
				runat="server" Width="88px" Text="Agregar"></asp:Button>
			<asp:ListBox id="lstBoxAtributosSeleccionados" style="Z-INDEX: 109; LEFT: 400px; POSITION: absolute; TOP: 280px"
				runat="server" Width="184px" Height="184px"></asp:ListBox>
			<asp:ListBox id="lstBoxAtributosDisponibles" style="Z-INDEX: 108; LEFT: 32px; POSITION: absolute; TOP: 280px"
				runat="server" Width="184px" Height="184px"></asp:ListBox>
			<asp:Label id="Label2" style="Z-INDEX: 107; LEFT: 40px; POSITION: absolute; TOP: 256px" runat="server"
				Width="64px" Height="16px">Atributos</asp:Label>
			<asp:ListBox id="ListBox1" style="Z-INDEX: 102; LEFT: 32px; POSITION: absolute; TOP: 48px" runat="server"
				Width="184px" Height="184px"></asp:ListBox>
			<asp:ListBox id="lstBoxHechosSeleccionados" style="Z-INDEX: 105; LEFT: 400px; POSITION: absolute; TOP: 48px"
				runat="server" Width="184px" Height="184px"></asp:ListBox>
			<asp:ListBox id="lstBoxHechosDisponibles" style="Z-INDEX: 103; LEFT: 32px; POSITION: absolute; TOP: 48px"
				runat="server" Width="184px" Height="184px"></asp:ListBox>
			<asp:Button id="btnAddHecho" style="Z-INDEX: 104; LEFT: 272px; POSITION: absolute; TOP: 80px"
				runat="server" Width="88px" Text="Agregar"></asp:Button>
			<asp:Button id="btnRemoverHecho" style="Z-INDEX: 106; LEFT: 272px; POSITION: absolute; TOP: 120px"
				runat="server" Width="88px" Text="Remover"></asp:Button>
			<asp:Button id="btnGenerarConsulta" style="Z-INDEX: 112; LEFT: 240px; POSITION: absolute; TOP: 512px"
				runat="server" Width="136px" Height="32px" Text="Generar Consulta"></asp:Button>
			<asp:TextBox id="txtConsulta" style="Z-INDEX: 113; LEFT: 32px; POSITION: absolute; TOP: 568px"
				runat="server" Width="552px" Height="128px" TextMode="MultiLine"></asp:TextBox>
		</form>
	</body>
</HTML>
