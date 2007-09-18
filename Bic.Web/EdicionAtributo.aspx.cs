using System;
using System.Collections;
using System.Web.UI.WebControls;
using Bic.Application;
using Bic.Domain;

namespace Bic.Web
{
	/// <summary>
	/// Descripción breve de EdicionAtributo.
	/// </summary>
	public class EdicionAtributo : BasePage
	{
		protected Label lblUsuario;
		protected Label lblProyecto;

		protected TextBox txtNombre;
		protected DropDownList ddlTablaLookup;

		protected Button btnAceptar;
		protected RequiredFieldValidator reqNombre;
		protected RequiredFieldValidator reqColumnaId;
		protected RequiredFieldValidator reqColumnaDescripcion;
		protected RequiredFieldValidator reqTablaLookup;
		protected ValidationSummary valSummary;
		protected DropDownList ddlColumnaId;
		protected DropDownList ddlColumnaDescripcion;
		protected Button btnCancelar;


		private void Page_Load(object sender, EventArgs e)
		{
			BaseLoad();
			if (!Page.IsPostBack) 
			{
				this.lblUsuario.Text = Usuario.Nombre;
				this.lblProyecto.Text = Proyecto.Nombre;

				this.ddlTablaLookup.DataSource = BICContext.Instance.CatalogoService.SelectTablasDisponibles(Proyecto.Id);
				this.ddlTablaLookup.DataBind();
				IList columnas = BICContext.Instance.CatalogoService.SelectColumnasDisponibles(Proyecto.Id);
				this.ddlColumnaDescripcion.DataSource = columnas;
				this.ddlColumnaDescripcion.DataBind();
				this.ddlColumnaId.DataSource = columnas;
				this.ddlColumnaId.DataBind();

				long id = long.Parse(Request.Params["id"]);
				ViewState["id"] = id;
				if (id != -1)
				{
					Atributo a = BICContext.Instance.AtributoService.Retrieve(id);
					this.txtNombre.Text = a.Nombre;
					this.ddlColumnaId.SelectedValue = a.ColumnaId.Nombre;
					//this.ddlColumnaDescripcion.SelectedValue = a.ColumnasDescripciones
					this.ddlTablaLookup.SelectedValue = a.TablaLookup.Nombre;
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
			a.ColumnaId = BICContext.Instance.CatalogoService.ObtenerColumna(this.ddlColumnaId.SelectedValue, Proyecto.Id);
			//a.CampoDescripcion = this.txtCampoDescripcion.Text;
			a.TablaLookup = BICContext.Instance.CatalogoService.ObtenerTabla(this.ddlTablaLookup.SelectedValue, Proyecto.Id);
			a.Proyecto = Proyecto;

			BICContext.Instance.AtributoService.Save(a);
			Response.Redirect("ListaAtributo.aspx");
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("ListaAtributo.aspx");
		}

		protected override bool TienePermisosSuficientes()
		{
			return this.Usuario.Rol.PuedeAccederAAtributos();
		}
	}
}
