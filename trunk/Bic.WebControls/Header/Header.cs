using System.ComponentModel;
using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bic.Domain;
using Bic.Domain.Usuario;
using System.IO;

namespace Bic.WebControls
{
	/// <summary>
	/// Descripción breve de Header.
	/// </summary>
	[DefaultProperty("Text"), 
	ToolboxData("<{0}:Header runat=server></{0}:Header>")]
	public class Header : WebControl
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

		#region Protected methods

		protected override void OnInit(System.EventArgs e)
		{
			this.pagePath = string.Empty;
			base.OnInit (e);
		}


		#endregion

		#region Private methods

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
			catch(Exception)
			{
				throw new UnableToCreateHeaderException("Page path no seteado. El header no puede renderizarse. Checkear si la pagina hereda de basepage.");
			}
		}

		#endregion

		/// <summary> 
		/// Procesar este control en el parámetro de salida especificado.
		/// </summary>
		/// <param name="output"> Programa de escritura HTML para escribir </param>
		protected override void Render(HtmlTextWriter output)
		{
			StringBuilder sb = new StringBuilder();

			try
			{
				string pageFolder = this.GetPageDeep();				

				Usuario u = (Usuario) this.Page.Session["usuario"];
				Proyecto p = (Proyecto) this.Page.Session["proyecto"];

				sb.Append(@"<div id=""header"">");
				sb.Append(@"<table height=""100%"" width=""100%"" cellspacing=""0"" cellpadding=""0"" border=""0"">");
				sb.Append(@"<tr>");
				sb.Append(@"<td>");
				sb.Append(@"<img src=""" + pageFolder + @"img/logo-small.jpg""/>");			
				sb.Append(@"</td>");
				sb.Append(@"<td align=""right"">");
				sb.Append(@"<h1>");
				if (p != null) 
				{
					sb.Append(p.Nombre + @"&nbsp;<a href=""" + pageFolder + @"ListaProyecto.aspx"" ><img alt=""Cerrar proyecto"" src=""" + pageFolder + @"img/logout.png""/></a>");
				}
				else
				{
					sb.Append(@"&nbsp;");
				}
				sb.Append(@"</h1>");
				sb.Append(@"<p>" + u.Nombre + @"&nbsp;<a href=""" + pageFolder + @"Login.aspx"" ><img alt=""Cerrar sesión"" src=""" + pageFolder + @"img/logout.png""/></a></p>");
				sb.Append(@"</td>");
				sb.Append(@"</tr>");
				sb.Append(@"</table>");
				sb.Append(@"</div>");			
			}
			catch(UnableToCreateHeaderException)
			{
				sb.Append(@"<div id=""header"">");
				sb.Append(@"</div>");
			}
			finally
			{
				output.Write(sb.ToString());
			}
		}
	}
}
