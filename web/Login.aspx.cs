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

namespace bic
{
	/// <summary>
	/// Descripción breve de Login.
	/// </summary>
	public class Login : System.Web.UI.Page
	{

		protected System.Web.UI.WebControls.TextBox txtUsuario;
		protected System.Web.UI.WebControls.TextBox txtContrasena;
		protected System.Web.UI.WebControls.Button btnIniciar;
		protected System.Web.UI.WebControls.CustomValidator valLogin;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				Session["usuario"] = null;
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
			this.Load += new System.EventHandler(this.Page_Load);
			this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
		}
		#endregion

		private void btnIniciar_Click(object sender, System.EventArgs e)
		{
			string usuario = this.txtUsuario.Text;
			string contrasena = this.txtContrasena.Text;
			if (BICContext.Instance.UsuarioService.login(usuario, contrasena))
			{
				Session["usuario"] = usuario;
				Response.Redirect("ListaProyecto.aspx");
			} 
			else
			{
				this.valLogin.ErrorMessage = "Usuario o contraseña inválidos. Por favor intente nuevamente.";
				this.valLogin.IsValid = false;
			}

		}
	}
}
