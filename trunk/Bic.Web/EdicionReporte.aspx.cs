using System;
using System.Web.UI.WebControls;
using Bic.Application;
using Bic.Domain;
using Bic.Domain.Catalogo;
using Bic.Framework;

namespace Bic.Web
{
	/// <summary>
	/// Descripción breve de EdicionMetrica.
	/// </summary>
	public class EdicionReporte : BasePage
	{
		#region Web controls

		protected TextBox txtNombreReporte;

		protected ListBox lstAtributos;
		protected ListBox lstMetricas;
		protected ListBox lstFiltros;

		protected RequiredFieldValidator reqNombreReporte;
		protected ValidationSummary valSummary;
		protected Button btnAceptar;
		protected Button btnCancelar;

		#endregion

		#region Event handlers

		private void Page_Load(object sender, EventArgs e)
		{			  
			BaseLoad();
			if (!Page.IsPostBack) 
			{
				long id = long.Parse(Request.Params["id"]);
				ViewState["id"] = id;
				if (id != -1)
				{
					Reporte r = BICContext.Instance.ReporteService.Retrieve(id);
					this.txtNombre.Text = r.Nombre;

					this.lstAtributos.DataSource = BICContext.Instance.AtributoService.Select(Proyecto.Id);
					this.lstAtributos.DataBind();

					this.lstFiltros.DataSource = BICContext.Instance.FiltroService.Select(Proyecto.Id);
					this.lstFiltros.DataBind();

					this.lstMetricas.DataSource = BICContext.Instance.MetricaService.Select(Proyecto.Id);
					this.lstMetricas.DataBind();

					this.ddlColumnaId.SelectedValue = a.ColumnaId.Id.ToString();
					
					foreach (ListItem i in this.lstDescripciones.Items)
					{
						Columna c = BICContext.Instance.TablaService.ObtenerColumna(long.Parse(i.Value));
						i.Selected = a.ColumnasDescripciones.Contains(c);
					}
					this.ddlTablaLookup.SelectedValue = a.TablaLookup.Id.ToString();
				}
				else
				{
					BindColumnas(long.Parse(this.ddlTablaLookup.SelectedValue));
					
				}
				BindHijos();
			}
		}

		
		#endregion



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
			this.lnkBtnAddAttToColumn.Click+=new EventHandler(lnkBtnAddAttToColumn_Click);
			this.lnkBtnAddAttToRow.Click +=new EventHandler(lnkBtnAddAttToRow_Click);
			this.lnkBtnRemoveAtt.Click+=new EventHandler(lnkBtnRemoveAtt_Click);

		}
		#endregion

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			long id = (long) ViewState["id"];
//			string nombre = this.txtNombre.Text;
//			string funcion = this.ddlFuncion.SelectedValue;
//			Hecho h = BICContext.Instance.HechoService.Retrieve(long.Parse(this.ddlHecho.SelectedValue));
//
//			if (id == -1)
//			{
//
//				Metrica m = new Metrica(nombre, funcion, h);
//				m.Proyecto = Proyecto;
//				BICContext.Instance.MetricaService.Save(m);
//			} 
//			else 
//			{
//				Metrica m = BICContext.Instance.MetricaService.Retrieve(id);
//				m.Nombre = nombre;
//				m.Funcion = funcion;
//				m.Hecho = h;
//				BICContext.Instance.MetricaService.Save(m);
//			}			
			Response.Redirect("ListaMetrica.aspx");
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("ListaMetrica.aspx");
		}

		protected override bool TienePermisosSuficientes()
		{
			return this.Usuario.Rol.PuedeAccederAReportes();
		}

		
	}
}
