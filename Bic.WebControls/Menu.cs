using System.ComponentModel;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bic.Domain.Usuario;
using System.IO;
using System;

namespace Bic.WebControls
{
	/// <summary>
	/// Descripción breve de Menu.
	/// </summary>
	[DefaultProperty("Text"), 
		ToolboxData("<{0}:Menu runat=server></{0}:Menu>")]
	public class Menu : WebControl
	{

		#region Private members

		private string pagePath;

		#endregion

		#region Properties

		public virtual string PagePath
		{
			get
			{
				return this.pagePath;
			}

			set
			{
				this.pagePath = value;
			}
		}


		#endregion

		protected override void OnInit(System.EventArgs e)
		{
			this.pagePath = string.Empty;
			base.OnInit (e);
		}

		// TODO: es un copy paste de Header, mover!
		private string GetPageDeep()
		{
			try
			{
				// Evaluar alguna forma mas elegante de hacer esto (GONE)
				StringBuilder pageFolder = new StringBuilder();
			
				string[] pathSections = Path.GetDirectoryName(this.PagePath).Split(Path.DirectorySeparatorChar);

				//HACK : el 1 y el 2º elemento no van , son : "" y bic"
				for(int i = 2; i<pathSections.Length; i++)
				{		
					pageFolder.Append("..");									
					pageFolder.Append('/');
				}

				return pageFolder.ToString().Length==0?"./":pageFolder.ToString();
			}
			catch (Exception)
			{
				throw new ApplicationException("Page path no seteado. El header no puede renderizarse. Checkear si la pagina hereda de basepage.");
			}
		}

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
				string basePath = this.GetPageDeep();

				sb.Append(@"<div id=""tabs10"">");
				sb.Append(@"<ul>");
				if (rolActual.PuedeAccederATablas())
					sb.Append(string.Format(@"<li><a href=""{0}ListaTabla.aspx"" title=""Tablas""><span>Tablas</span></a></li>", basePath));	  
				if (rolActual.PuedeAccederAAtributos())
					sb.Append(string.Format(@"<li><a href=""{0}ListaAtributo.aspx"" title=""Atributos""><span>Atributos</span></a></li>", basePath));
				if (rolActual.PuedeAccederAHechos())
					sb.Append(string.Format(@"<li><a href=""{0}ListaHecho.aspx"" title=""Hechos""><span>Hechos</span></a></li>", basePath));
				if (rolActual.PuedeAccederAFiltros())
					sb.Append(string.Format(@"<li><a href=""{0}ListaFiltro.aspx"" title=""Filtros""><span>Filtros</span></a></li>", basePath));
				if (rolActual.PuedeAccederAMetricas())
					sb.Append(string.Format(@"<li><a href=""{0}ListaMetrica.aspx"" title=""Metricas""><span>Metricas</span></a></li>", basePath));
				if (rolActual.PuedeAccederAReportes())
					sb.Append(string.Format(@"<li><a href=""{0}ListaReporte.aspx"" title=""Reportes""><span>Reportes</span></a></li>", basePath));
				sb.Append(string.Format(@"<li><a href=""#"" onclick=""javascript:window.open('{0}/ayuda/index.html' , 'Ayuda' , 'width= 800 ,height=730 ,directories= no ,location= no ,menubar= no ,scrollbars= no ,status=no ,toolbar= no,resizable=yes');return false;"" title=""Ayuda""><span>Ayuda</span></a></li>", basePath));
				sb.Append("</div>");

			}

			output.Write(sb.ToString());
		}
	}
}
