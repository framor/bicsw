using System;
using System.Web.UI.WebControls;
using Bic.Application;
using Bic.Domain;
using Bic.Domain.Catalogo;
using Bic.Framework;

namespace Bic.Web
{
	/// <summary>
	/// Descripción breve de EdicionFiltro.
	/// </summary>
	public class EdicionFiltro : BasePage
	{
		protected TextBox txtNombre;
		protected DropDownList ddlAtributo;
		protected DropDownList ddlDescripcion;
		protected DropDownList ddlOperador;
		protected TextBox txtValor;

		protected Button btnAceptar;
		protected ValidationSummary valSummary;
		protected Button btnCancelar;


		private void Page_Load(object sender, EventArgs e)
		{
			BaseLoad();
			if (!Page.IsPostBack) 
			{
				this.ddlAtributo.DataSource = BICContext.Instance.AtributoService.Select(Proyecto.Id);
				this.ddlAtributo.DataBind();
				
				long id = long.Parse(Request.Params["id"]);
				ViewState["id"] = id;
				if (id != -1)
				{
					Filtro f = BICContext.Instance.FiltroService.Retrieve(id);
					this.txtNombre.Text = f.Nombre;
					this.txtValor.Text = f.Valor;
					this.ddlDescripcion.SelectedValue = f.Columna.Id.ToString();
					this.ddlAtributo.SelectedValue = f.Atributo.Id.ToString();
					this.ddlOperador.SelectedValue = f.Operador;
				} 

				Atributo a = BICContext.Instance.AtributoService.Retrieve(long.Parse(this.ddlAtributo.SelectedValue));
				this.ddlDescripcion.DataSource = a.TablaLookup.Columnas;
				this.ddlDescripcion.DataBind();

				this.ddlOperador.Items.Add(new ListItem("<", "<"));
				this.ddlOperador.Items.Add(new ListItem("<=", "<="));
				this.ddlOperador.Items.Add(new ListItem("=", "="));
				this.ddlOperador.Items.Add(new ListItem(">", ">"));
				this.ddlOperador.Items.Add(new ListItem(">=", ">="));
				this.ddlOperador.Items.Add(new ListItem("LIKE", "LIKE"));
				this.ddlOperador.DataBind();
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
			this.ddlAtributo.SelectedIndexChanged += new EventHandler(this.ddlAtributo_SelectedIndexChanged);
			this.Load += new EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			long id = (long) ViewState["id"];
			string nombre = this.txtNombre.Text;
			string operador = this.ddlOperador.SelectedValue;
			string valor = this.txtValor.Text;
			Atributo atributo = BICContext.Instance.AtributoService.Retrieve(long.Parse(this.ddlAtributo.SelectedValue));
			Columna desc = BICContext.Instance.TablaService.ObtenerColumna(long.Parse(this.ddlDescripcion.SelectedValue));

			if (id == -1)
			{				
				Filtro f = new Filtro();
				f.Columna = desc;
				f.Atributo = atributo;
				f.Nombre = nombre;
				f.Valor = valor;
				f.Operador = operador;
				f.Proyecto = Proyecto;
				BICContext.Instance.FiltroService.Save(f);
			} 
			else 
			{
				Filtro f = BICContext.Instance.FiltroService.Retrieve(id);
				f.Nombre = nombre;
				f.Valor = valor;
				f.Atributo = atributo;
				f.Columna = desc;
				f.Operador = operador;
				f.Proyecto = Proyecto;
				BICContext.Instance.FiltroService.Save(f);
			}
			
			Response.Redirect("ListaFiltro.aspx");
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("ListaFiltro.aspx");
		}

		protected override bool TienePermisosSuficientes()
		{
			return this.Usuario.Rol.PuedeAccederAFiltros();
		}

		private void ddlAtributo_SelectedIndexChanged(object sender, EventArgs e)
		{
			Atributo a = BICContext.Instance.AtributoService.Retrieve(long.Parse(this.ddlAtributo.SelectedValue));
			this.ddlDescripcion.DataSource = a.TablaLookup.Columnas;
			this.ddlDescripcion.DataBind();
		}
	}
}
