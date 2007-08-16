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
	public class EdicionProyecto : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.TextBox txtServidor;
		protected System.Web.UI.WebControls.TextBox txtPuerto;
		protected System.Web.UI.WebControls.TextBox txtEsquema;
		protected System.Web.UI.WebControls.TextBox txtUsuario;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		
		protected System.Web.UI.WebControls.Label lblUsuario;
		protected System.Web.UI.WebControls.Button btnCancelar;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqNombre;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqDescripcion;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqServidor;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqPuerto;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqEsquema;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqUsuario;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqPassword;
		protected System.Web.UI.WebControls.ValidationSummary valSummary;
		protected System.Web.UI.WebControls.Button btnAceptar;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack) 
			{
				this.lblUsuario.Text = Session["usuario"].ToString();

				long id = long.Parse(Request.Params["id"]);
				ViewState["id"] = id;
				if (id != -1)
				{
					Proyecto p = BICContext.Instance.ProyectoService.retrieve(id);
					this.txtNombre.Text = p.Nombre;
					this.txtDescripcion.Text = p.Descripcion;
					this.txtServidor.Text = p.Servidor;
					this.txtPuerto.Text = p.Puerto.ToString();
					this.txtEsquema.Text = p.Database;
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
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			long id = (long) ViewState["id"];
			Proyecto p;
			if (id == -1)
			{
				p = new Proyecto();
			} 
			else 
			{
				p = BICContext.Instance.ProyectoService.retrieve(id);
			}			
			p.Nombre = this.txtNombre.Text;
			p.Descripcion = this.txtDescripcion.Text;
			p.Servidor = this.txtServidor.Text;
			p.Puerto = Int32.Parse(this.txtPuerto.Text);
			p.Database = this.txtEsquema.Text;
			p.Usuario = this.txtUsuario.Text;
			p.Password = this.txtPassword.Text;

			BICContext.Instance.ProyectoService.save(p);
			Response.Redirect("ListaProyecto.aspx");
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ListaProyecto.aspx");
		}
	}
}
