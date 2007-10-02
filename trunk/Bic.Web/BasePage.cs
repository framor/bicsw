using System.Web.UI;
using Bic.Domain;
using Bic.Domain.Usuario;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using Bic.WebControls;

namespace Bic.Web
{
	/// <summary>
	/// Descripción breve de BasePage.
	/// </summary>
	public abstract class BasePage : Page
	{
		#region Constructor

		public BasePage() {}


		#endregion

		#region	Properties

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


		#endregion 

		#region Abstract methods

		/// <summary>
		/// Valida si el usuario tiene permisos para acceder a la pagina actual
		/// </summary>
		/// <returns>true - false</returns>
		protected abstract bool TienePermisosSuficientes();

		#endregion
		
		#region Private methods

		private void InitializeComponent()
		{
			this.Page.PreRender+=new EventHandler(page_PreRenderEventHandler);
		}


		#endregion

		#region Protected methods

		protected Control FindControlByID(ControlCollection controls, string id)
		{
			Control found = null;

			foreach(Control control in controls)
			{
				if(control.HasControls())
				{
					found = FindControlByID(control.Controls, id);
					if(found != null)
					{
						break;
					}
				}

				if(control.ID == id)
				{
					found = control;
					break;
				}
			}

			return found;
		} 


		protected virtual void page_PreRenderEventHandler(object sender, EventArgs e)
		{
			//HACK : Como veran, el header siempre tiene que llamarseeeeee (GONE)
			Bic.WebControls.Header header = FindControlByID(this.Controls,"bicHeader") as Bic.WebControls.Header;
			try
			{
				header.PagePath = Request.Url.AbsolutePath;
			}
			catch(System.NullReferenceException)
			{
				throw new Exception(@"El header no está incluido en la pagina, o su id no es 'bicHeader'"); //UnableToCreateHeaderException(@"El header no está incluido en la pagina, o su id no es 'bicHeader'");
			}
		}


		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}


		protected void BaseLoad()
		{
			if (Usuario == null) // expiro la sesion?
			{
				Response.Redirect("~/Login.aspx");
			}
			if (!TienePermisosSuficientes())
			{
				Response.Write("Acción no permitida. Consulte al administrador para que le asgine los permisos necesarios para acceder a la pagina.");
				Response.End();
			}
		}


		#endregion
	}
}
