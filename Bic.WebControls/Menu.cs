using System.ComponentModel;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bic.Domain.Usuario;

namespace Bic.WebControls
{
	/// <summary>
	/// Descripción breve de Menu.
	/// </summary>
	[DefaultProperty("Text"), 
		ToolboxData("<{0}:Menu runat=server></{0}:Menu>")]
	public class Menu : WebControl
	{

		/// <summary> 
		/// Procesar este control en el parámetro de salida especificado.
		/// </summary>
		/// <param name="output"> Programa de escritura HTML para escribir </param>
		protected override void Render(HtmlTextWriter output)
		{
			StringBuilder sb = new StringBuilder();

			Usuario u = (Usuario) this.Page.Session["usuario"];
			if (u != null)
			{
				Rol rolActual = u.Rol;

				sb.Append(@"<div id=""tabs10"">");
				sb.Append(@"<ul>");
				if (rolActual.PuedeAccederATablas())
					sb.Append(@"<li><a href=""ListaTabla.aspx"" title=""Tablas""><span>Tablas</span></a></li>");	  
				if (rolActual.PuedeAccederAAtributos())
					sb.Append(@"<li><a href=""ListaAtributo.aspx"" title=""Atributos""><span>Atributos</span></a></li>");
				if (rolActual.PuedeAccederAHechos())
					sb.Append(@"<li><a href=""ListaHecho.aspx"" title=""Hechos""><span>Hechos</span></a></li>");
				if (rolActual.PuedeAccederAFiltros())
					sb.Append(@"<li><a href=""ListaFiltro.aspx"" title=""Filtros""><span>Filtros</span></a></li>");
				if (rolActual.PuedeAccederAMetricas())
					sb.Append(@"<li><a href=""ListaMetrica.aspx"" title=""Metricas""><span>Metricas</span></a></li>");
				if (rolActual.PuedeAccederAReportes())
					sb.Append(@"<li><a href=""Reportes/ListaReportes.aspx"" title=""Reportes""><span>Reportes</span></a></li>");
				sb.Append("</div>");

			}

			output.Write(sb.ToString());
		}
	}
}
