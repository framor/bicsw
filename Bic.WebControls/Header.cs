using System.ComponentModel;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bic.Domain;
using Bic.Domain.Usuario;

namespace Bic.WebControls
{
	/// <summary>
	/// Descripción breve de Header.
	/// </summary>
	[DefaultProperty("Text"), 
	ToolboxData("<{0}:Header runat=server></{0}:Header>")]
	public class Header : WebControl
	{

		/// <summary> 
		/// Procesar este control en el parámetro de salida especificado.
		/// </summary>
		/// <param name="output"> Programa de escritura HTML para escribir </param>
		protected override void Render(HtmlTextWriter output)
		{
			StringBuilder sb = new StringBuilder();

			Usuario u = (Usuario) this.Page.Session["usuario"];
			Proyecto p = (Proyecto) this.Page.Session["proyecto"];

			sb.Append(@"<div id=""header"">");
			sb.Append(@"<table height=""100%"" width=""100%"" cellspacing=""0"" cellpadding=""0"" border=""0"">");
			sb.Append(@"<tr>");
			sb.Append(@"<td>");
			sb.Append(@"<img src=""./img/logo-small.jpg""/>");
			sb.Append(@"</td>");
			sb.Append(@"<td align=""right"">");
			sb.Append(@"<h1>");
			if (p != null) 
			{
				sb.Append(p.Nombre + @"&nbsp;<a href=""ListaProyecto.aspx"" ><img alt=""Cerrar proyecto"" src=""./img/logout.png""/></a>");
			}
			else
			{
				sb.Append(@"&nbsp;");
			}
			sb.Append(@"</h1>");
			sb.Append(@"<p>" + u.Nombre + @"&nbsp;<a href=""Login.aspx"" ><img alt=""Cerrar sesión"" src=""./img/logout.png""/></a></p>");
			sb.Append(@"</td>");
			sb.Append(@"</tr>");
			sb.Append(@"</table>");
			sb.Append(@"</div>");

			output.Write(sb.ToString());
		}
	}
}
