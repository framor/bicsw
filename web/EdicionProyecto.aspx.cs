using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.bic.application;
using ar.com.bic.domain;

namespace bic
{
	/// <summary>
	/// Descripción breve de EdicionProyecto.
	/// </summary>
	public class EdicionProyecto : Page
	{
		protected TextBox txtNombre;
		protected TextBox txtDescripcion;
		protected TextBox txtServidor;
		protected TextBox txtPuerto;
		protected TextBox txtEsquema;
		protected TextBox txtUsuario;
		protected TextBox txtPassword;
		
		protected Label lblUsuario;
		protected Button btnCancelar;
		protected RequiredFieldValidator reqNombre;
		protected RequiredFieldValidator reqDescripcion;
		protected RequiredFieldValidator reqServidor;
		protected RequiredFieldValidator reqPuerto;
		protected RequiredFieldValidator reqEsquema;
		protected RequiredFieldValidator reqUsuario;
		protected RequiredFieldValidator reqPassword;
		protected ValidationSummary valSummary;
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
					this.txtPuerto.Text = p.Puerto.ToString();
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
			p.Puerto = Int32.Parse(this.txtPuerto.Text);
			p.NombreBD = this.txtEsquema.Text;
			p.Usuario = this.txtUsuario.Text;
			p.Password = this.txtPassword.Text;

			BICContext.Instance.ProyectoService.Save(p);
			Response.Redirect("ListaProyecto.aspx");
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("ListaProyecto.aspx");
		}
	}
}
