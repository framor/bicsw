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
using ar.com.bic.domain.catalogo;

namespace bic
{
	/// <summary>
	/// Descripción breve de EdicionHecho.
	/// </summary>
	public class EdicionHecho : BasePage
	{
		protected System.Web.UI.WebControls.Label lblUsuario;
		protected System.Web.UI.WebControls.Label lblProyecto;

		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.DropDownList ddlColumna;

		protected System.Web.UI.WebControls.Button btnAceptar;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqNombre;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqColumna;
		protected System.Web.UI.WebControls.ValidationSummary valSummary;
		protected System.Web.UI.WebControls.Button btnCancelar;


		private void Page_Load(object sender, System.EventArgs e)
		{
			BaseLoad();
			if (!Page.IsPostBack) 
			{
				this.lblUsuario.Text = Usuario.Nombre;
				this.lblProyecto.Text = Proyecto.Nombre;
				object datasource = null;
				
				long id = long.Parse(Request.Params["id"]);
				ViewState["id"] = id;
				if (id != -1)
				{
					Hecho h = BICContext.Instance.HechoService.Retrieve(id);
					this.ddlColumna.SelectedValue = h.Columna.Nombre;
					this.txtNombre.Text = h.Nombre;
					datasource = new Columna[] {h.Columna};
				} 
				else 
				{
					datasource = BICContext.Instance.CatalogoService.SelectColumnasDisponibles(Proyecto.Id);
				}

				this.ddlColumna.DataSource = datasource;
				this.ddlColumna.DataBind();

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
			string nombre = this.txtNombre.Text;

			if (id == -1)
			{
				Columna c = BICContext.Instance.CatalogoService.ObtenerColumna(this.ddlColumna.SelectedValue, Proyecto.Id);
				Hecho h = new Hecho(nombre, c);
				h.Proyecto = Proyecto;
				BICContext.Instance.HechoService.Save(h);
			} 
			else 
			{
				Hecho h = BICContext.Instance.HechoService.Retrieve(id);
				h.Nombre = nombre;
				BICContext.Instance.HechoService.Save(h);
			}			

			
			Response.Redirect("ListaHecho.aspx");
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ListaHecho.aspx");
		}

		protected override bool TienePermisosSuficientes()
		{
			return this.Usuario.Rol.PuedeAccederAHechos();
		}
	}
}
