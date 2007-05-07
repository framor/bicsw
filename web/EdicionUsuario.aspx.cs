using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using ar.com.bic.application;
using ar.com.bic.domain;

namespace bic
{
	/// <summary>
	/// Descripción breve de EdicionUsuario.
	/// </summary>
	public class EdicionUsuario : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.TextBox txtClave;
		protected System.Web.UI.WebControls.Button btnCancelar;
		protected System.Web.UI.WebControls.Button btnAceptar;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			long id = long.Parse(Request.Params["id"]);
			ViewState["id"] = id;
			if (id != -1)
			{
				Usuario u = BICContext.Instance.UsuarioService.retrieve(id);
				this.txtNombre.Text = u.Nombre;
				this.txtClave.Text = u.Clave;
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
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAceptar_Click(object sender, System.EventArgs e)
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
				u = BICContext.Instance.UsuarioService.retrieve(id);
			}			
			u.Clave = this.txtClave.Text;
			BICContext.Instance.UsuarioService.save(u);
			Response.Redirect("ListaUsuario.aspx");
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ListaUsuario.aspx");
		}
	}
}
