using System;
using ar.com.bic.domain;

namespace bic
{
	/// <summary>
	/// Descripción breve de BasePage.
	/// </summary>
	public class BasePage : System.Web.UI.Page
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
			//TODO: validar permisos
		}
	}
}
