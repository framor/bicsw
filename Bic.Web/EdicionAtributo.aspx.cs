using System;
using System.Collections;
using System.Web.UI.WebControls;
using Bic.Application;
using Bic.Domain;
using Bic.Domain.Catalogo;
using Bic.WebControls;

namespace Bic.Web
{
	/// <summary>
	/// Descripción breve de EdicionAtributo.
	/// </summary>
	public class EdicionAtributo : BasePage
	{
		protected TextBox txtNombre;
		protected DropDownList ddlTablaLookup;

		protected Button btnAceptar;
		protected RequiredFieldValidator reqNombre;
		protected RequiredFieldValidator reqColumnaId;
		protected RequiredFieldValidator reqColumnaDescripcion;
		protected RequiredFieldValidator reqTablaLookup;
		protected ValidationSummary valSummary;
		protected DropDownList ddlColumnaId;
		protected ListBox lstDescripciones;
		protected Header bicHeader;
		protected Menu bicMenu;
		protected Button btnCancelar;


		private void Page_Load(object sender, EventArgs e)
		{
			BaseLoad();
			if (!Page.IsPostBack) 
			{
				this.ddlTablaLookup.DataSource = BICContext.Instance.TablaService.Select(Proyecto.Id);
				this.ddlTablaLookup.DataBind();
				ddlTablaLookup_SelectedIndexChanged(null, null);

				long id = long.Parse(Request.Params["id"]);
				ViewState["id"] = id;
				if (id != -1)
				{
					Atributo a = BICContext.Instance.AtributoService.Retrieve(id);
					this.txtNombre.Text = a.Nombre;
					this.ddlColumnaId.SelectedValue = a.ColumnaId.Id.ToString();

					
					foreach (ListItem i in this.lstDescripciones.Items)
					{
						// TODO: esto apesta
						Columna c = BICContext.Instance.TablaService.ObtenerColumna(long.Parse(i.Value));
						i.Selected = a.ColumnasDescripciones.Contains(c);
					}
					this.ddlTablaLookup.SelectedValue = a.TablaLookup.Id.ToString();
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
			this.ddlTablaLookup.SelectedIndexChanged += new EventHandler(this.ddlTablaLookup_SelectedIndexChanged);
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
			a.ColumnaId = BICContext.Instance.TablaService.ObtenerColumna(long.Parse(this.ddlColumnaId.SelectedValue));
			foreach (ListItem i in this.lstDescripciones.Items)
			{
				// TODO: esto apesta
				Columna c = BICContext.Instance.TablaService.ObtenerColumna(long.Parse(i.Value));

				if (i.Selected)
				{
					a.RemoverColumnaDescripcion(c);
					a.AgregarColumnaDescripcion(c);
				}
				else
				{
					a.RemoverColumnaDescripcion(c);
				}
			}
			a.TablaLookup = BICContext.Instance.TablaService.Retrieve(long.Parse(this.ddlTablaLookup.SelectedValue));
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

		private void ddlTablaLookup_SelectedIndexChanged(object sender, EventArgs e)
		{
			Tabla t = BICContext.Instance.TablaService.Retrieve(long.Parse(this.ddlTablaLookup.SelectedValue));

			this.ddlColumnaId.DataSource = t.Columnas;
			this.ddlColumnaId.DataBind();

			this.lstDescripciones.DataSource = t.Columnas;
			this.lstDescripciones.DataBind();
		}
	}
}
