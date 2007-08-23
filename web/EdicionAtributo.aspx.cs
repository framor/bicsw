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
	/// Descripción breve de EdicionAtributo.
	/// </summary>
	public class EdicionAtributo : BasePage
	{
		protected System.Web.UI.WebControls.Label lblUsuario;
		protected System.Web.UI.WebControls.Label lblProyecto;

		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.DropDownList ddlTablaLookup;

		protected System.Web.UI.WebControls.Button btnAceptar;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqNombre;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqCampoId;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqCampoDescripcion;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqTablaLookup;
		protected System.Web.UI.WebControls.ValidationSummary valSummary;
		protected System.Web.UI.WebControls.DropDownList ddlCampoId;
		protected System.Web.UI.WebControls.DropDownList ddlCampoDescripcion;
		protected System.Web.UI.WebControls.Button btnCancelar;


		private void Page_Load(object sender, System.EventArgs e)
		{
			BaseLoad();
			if (!Page.IsPostBack) 
			{
				this.lblUsuario.Text = Usuario.Nombre;
				this.lblProyecto.Text = Proyecto.Nombre;

				this.ddlTablaLookup.DataSource = BICContext.Instance.CatalogoService.SelectTablasDisponibles(Proyecto.Id);
				this.ddlTablaLookup.DataBind();
				IList campos = BICContext.Instance.CatalogoService.SelectCamposDisponibles(Proyecto.Id);
				this.ddlCampoDescripcion.DataSource = campos;
				this.ddlCampoDescripcion.DataBind();
				this.ddlCampoId.DataSource = campos;
				this.ddlCampoId.DataBind();

				long id = long.Parse(Request.Params["id"]);
				ViewState["id"] = id;
				if (id != -1)
				{
					Atributo a = BICContext.Instance.AtributoService.Retrieve(id);
					this.txtNombre.Text = a.Nombre;
					//this.txtCampoId.Text = a.CampoId.Nombre;
					//this.txtCampoDescripcion.Text = a.CampoDescripcion;
					//this.ddlTablaLookup.SelectedValue = a.TablaLookup.Nombre;
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
			Atributo a;
			if (id == -1)
			{
				a = new Atributo();
			} 
			else 
			{
				a = BICContext.Instance.AtributoService.Retrieve(id);
			}			
			a.Nombre = this.txtNombre.Text;
			//a.CampoId.Nombre = this.txtCampoId.Text;
			//a.CampoDescripcion = this.txtCampoDescripcion.Text;
			//a.TablaLookup = BICContext.Instance..txtTablaLookup.Text;
			a.Proyecto = Proyecto;

			BICContext.Instance.AtributoService.Save(a);
			Response.Redirect("ListaAtributo.aspx");
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ListaAtributo.aspx");
		}
	
	}
}
