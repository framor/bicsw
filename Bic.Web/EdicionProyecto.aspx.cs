using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bic.Application;
using Bic.Domain;
using Bic.Framework.Exception;

namespace Bic.Web
{
	/// <summary>
	/// Descripción breve de EdicionProyecto.
	/// </summary>
	public class EdicionProyecto : Page
	{
		protected TextBox txtNombre;
		protected TextBox txtDescripcion;
		protected TextBox txtServidor;
		protected TextBox txtEsquema;
		protected TextBox txtUsuario;
		protected TextBox txtPassword;
		
		protected Label lblUsuario;
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
			if (!Page.IsPostBack) 
			{
				this.lblUsuario.Text = Session["usuario"].ToString();

				long id = long.Parse(Request.Params["id"]);
				ViewState["id"] = id;
				if (id != -1)
				{
					Proyecto p = BICContext.Instance.ProyectoService.Retrieve(id);
					this.txtNombre.Text = p.Nombre;
					this.txtDescripcion.Text = p.Descripcion;
					this.txtServidor.Text = p.Servidor;
					this.txtEsquema.Text = p.NombreBD;
					this.txtUsuario.Text = p.Usuario;
					this.txtPassword.Text = p.Password;
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
			p.Nombre = this.txtNombre.Text;
			p.Descripcion = this.txtDescripcion.Text;
			p.Servidor = this.txtServidor.Text;
			p.NombreBD = this.txtEsquema.Text;
			p.Usuario = this.txtUsuario.Text;
			p.Password = this.txtPassword.Text;

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
			this.lblEstadoConexion.Text = 
				BICContext.Instance.CatalogoService.ProbarConexion(servidor, nombreBD, usuario, password);
		}
	}
}
