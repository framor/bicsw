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
	/// Descripción breve de EdicionTabla.
	/// </summary>
	public class EdicionTabla : BasePage
	{
		protected System.Web.UI.WebControls.Label lblUsuario;
		protected System.Web.UI.WebControls.Label lblProyecto;

		protected System.Web.UI.WebControls.TextBox txtAlias;
		protected System.Web.UI.WebControls.TextBox txtPeso;
		protected System.Web.UI.WebControls.DropDownList ddlNombre;

		protected System.Web.UI.WebControls.Button btnAceptar;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqNombre;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqAlias;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqPeso;
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
					Tabla t = BICContext.Instance.TablaService.Retrieve(id);
					this.ddlNombre.SelectedValue = t.Nombre;
					this.txtAlias.Text = t.Alias;
					this.txtPeso.Text = t.Peso.ToString();
					datasource = new string[] {t.Nombre};
				} 
				else 
				{
					datasource = BICContext.Instance.CatalogoService.SelectTablasDisponibles(Proyecto.Id);
				}

				this.ddlNombre.DataSource = datasource;
				this.ddlNombre.DataBind();

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
			string alias = this.txtAlias.Text;
			int peso = Int32.Parse(this.txtPeso.Text);

			if (id == -1)
			{
				BICContext.Instance.TablaService.Save(Proyecto, this.ddlNombre.SelectedValue, alias, peso);
			} 
			else 
			{
				Tabla t = BICContext.Instance.TablaService.Retrieve(id);
				t.Alias = alias;
				t.Peso = peso;
				BICContext.Instance.TablaService.Save(t);
			}			

			
			Response.Redirect("ListaTabla.aspx");
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ListaTabla.aspx");
		}

		protected override bool TienePermisosSuficientes()
		{
			return this.Usuario.Rol.PuedeAccederATablas();
		}
	}
}
