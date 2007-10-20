using System;
using System.Web.UI.WebControls;
using Bic.Application;
using Bic.Domain;
using Bic.Framework;
using Bic.Framework.Exception;

namespace Bic.Web
{
	/// <summary>
	/// Descripción breve de EdicionProyecto.
	/// </summary>
	public class EdicionProyecto : BasePage
	{
		protected TextBox txtNombre;
		protected TextBox txtDescripcion;
		protected TextBox txtServidor;
		protected TextBox txtEsquema;
		protected TextBox txtUsuario;
		protected TextBox txtPassword;
		
		protected Button btnCancelar;
		protected RequiredFieldValidator reqNombre;
		protected RequiredFieldValidator reqDescripcion;
		protected RequiredFieldValidator reqServidor;
		protected RequiredFieldValidator reqEsquema;
		protected RequiredFieldValidator reqUsuario;
		protected RequiredFieldValidator reqPassword;
		protected CustomValidator valNombre;
		protected ValidationSummary valSummary;
		protected Button btnProbarConexion;
		protected Label lblEstadoConexion;
		protected Button btnAceptar;
	
		private void Page_Load(object sender, EventArgs e)
		{
			BaseLoad();
			if (!Page.IsPostBack) 
			{
				long id = long.Parse(Request.Params["id"]);
				ViewState["id"] = id;
				if (id != -1)
				{
					Proyecto p = BICContext.Instance.ProyectoService.Retrieve(id);
					this.txtNombre.Text = Server.HtmlDecode(p.Nombre);
					this.txtDescripcion.Text = Server.HtmlDecode(p.Descripcion);
					this.txtServidor.Text = Server.HtmlDecode(p.Servidor);
					this.txtEsquema.Text = Server.HtmlDecode(p.NombreBD);
					this.txtUsuario.Text = Server.HtmlDecode(p.Usuario);
					this.txtPassword.Text = Server.HtmlDecode(p.Password);
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
			this.btnProbarConexion.Click += new EventHandler(this.btnProbarConexion_Click);
			this.btnAceptar.Click += new EventHandler(this.btnAceptar_Click);
			this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
			this.Load += new EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			long id = (long) ViewState["id"];
			Proyecto p;
			if (id == -1)
			{
				p = new Proyecto();
			} 
			else 
			{
				p = BICContext.Instance.ProyectoService.Retrieve(id);
			}			
			p.Nombre = StringUtils.TrimSpecialCharacters(this.txtNombre.Text);
			p.Descripcion = StringUtils.TrimSpecialCharacters(this.txtDescripcion.Text);
			p.Servidor = StringUtils.TrimSpecialCharacters(this.txtServidor.Text);
			p.NombreBD = StringUtils.TrimSpecialCharacters(this.txtEsquema.Text);
			p.Usuario = StringUtils.TrimSpecialCharacters(this.txtUsuario.Text);
			p.Password = StringUtils.TrimSpecialCharacters(this.txtPassword.Text);

			try 
			{
				BICContext.Instance.ProyectoService.Save(p);
				Response.Redirect("ListaProyecto.aspx");
			} 
			catch (ServiceException se)
			{
				this.valNombre.IsValid = false;
				this.valNombre.ErrorMessage = se.Message;
			}

		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("ListaProyecto.aspx");
		}

		private void btnProbarConexion_Click(object sender, EventArgs e)
		{
			string servidor = this.txtServidor.Text;
			string nombreBD = this.txtEsquema.Text;
			string usuario = this.txtUsuario.Text;
			string password = this.txtPassword.Text;
			try 
			{
				this.lblEstadoConexion.Text = 
					BICContext.Instance.CatalogoService.ProbarConexion(servidor, nombreBD, usuario, password);
			} 
			catch (ServiceException se)
			{
				this.lblEstadoConexion.Text = se.Message;
			}
		}

		protected override bool TienePermisosSuficientes()
		{
			return this.Usuario.Rol.PuedeAccederAProyectos() &&
				this.Usuario.Rol.PuedeEditarProyectos();
		}
	}
}
