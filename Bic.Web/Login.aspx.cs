using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bic.Application;
using Bic.Domain.Usuario;
using Bic.Framework;

namespace Bic.Web
{
	/// <summary>
	/// Descripción breve de Login.
	/// </summary>
	public class Login : Page
	{

		protected TextBox txtUsuario;
		protected TextBox txtContrasena;
		protected Button btnIniciar;
		protected CustomValidator valLogin;

		private void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				Session.Clear();
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
			this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnIniciar_Click(object sender, EventArgs e)
		{
			string usuario = StringUtils.TrimSpecialCharacters(this.txtUsuario.Text);
			string contrasena = StringUtils.TrimSpecialCharacters(this.txtContrasena.Text);
			Usuario u = BICContext.Instance.UsuarioService.Login(usuario, contrasena);
			if (u != null)
			{
				Session["usuario"] = u;
				if (u.Rol.EsAdministrador())
				{
					Response.Redirect("ListaUsuario.aspx");					
				}
				else
				{
					Response.Redirect("ListaProyecto.aspx");
				}
			} 
			else
			{
				this.valLogin.ErrorMessage = "Usuario o contraseña inválidos. Por favor intente nuevamente.";
				this.valLogin.IsValid = false;
			}

		}
	}
}
