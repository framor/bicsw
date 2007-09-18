using System.Web.UI;
using Bic.Domain;
using Bic.Domain.Usuario;

namespace Bic.Web
{
	/// <summary>
	/// Descripción breve de BasePage.
	/// </summary>
	public abstract class BasePage : Page
	{
		public BasePage() {}

		protected Proyecto Proyecto
		{
			get { return (Proyecto) Session["proyecto"]; }
		}

		protected Usuario Usuario
		{
			get
			{
				return (Usuario) Session["usuario"];
			}
		}

		protected void BaseLoad()
		{
			if (Usuario == null) // expiro la sesion?
			{
				Response.Redirect("Login.aspx");
			}
			if (!TienePermisosSuficientes())
			{
				Response.Write("Acción no permitida. Consulte al administrador para que le asgine los permisos necesarios para acceder a la pagina.");
				Response.End();
			}
		}

		/// <summary>
		/// Valida si el usuario tiene permisos para acceder a la pagina actual
		/// </summary>
		/// <returns>true - false</returns>
		protected abstract bool TienePermisosSuficientes();
	}
}
