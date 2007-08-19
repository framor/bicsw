using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.bic.application;
using ar.com.bic.domain;

namespace bic
{
	/// <summary>
	/// Descripción breve de EdicionUsuario.
	/// </summary>
	public class EdicionUsuario : Page
	{
		protected Button btnCancelar;
		protected TextBox txtNombre;
		protected TextBox txtClave;
		protected Button btnAceptar;
	
		private void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack) 
			{
				long id = long.Parse(Request.Params["id"]);
				ViewState["id"] = id;
				if (id != -1)
				{
					Usuario u = BICContext.Instance.UsuarioService.Retrieve(id);
					this.txtNombre.Text = u.Nombre;
					this.txtClave.Text = u.Clave;
				}
			}
		}

		#region Código generado por el Diseñador de Web Forms
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: llamada requerida por el Diseñador de Web Forms ASP.NET.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnAceptar.Click += new EventHandler(this.btnAceptar_Click);
			this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
			this.Load += new EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			long id = (long) ViewState["id"];
			Usuario u;
			if (id == -1)
			{
				u = new Usuario();
				u.Nombre = this.txtNombre.Text;
			} 
			else 
			{
				u = BICContext.Instance.UsuarioService.Retrieve(id);
			}			
			u.Clave = this.txtClave.Text;
			BICContext.Instance.UsuarioService.Save(u);
			Response.Redirect("ListaUsuario.aspx");
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("ListaUsuario.aspx");
		}
	}
}
