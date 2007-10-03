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

		protected ListBox lstBoxAttDisponibles;
		protected ListBox lstBoxAttSeleccionados;
		protected ListBox lstBoxAttDescriptions;
		
		protected LinkButton lnkBtnAddAttToColumn;
		protected LinkButton lnkBtnAddAttToRow;
		protected LinkButton lnkBtnRemoveAtt;

		protected ListBox lstBoxMetricasDisponibles;
		protected ListBox lstBoxMetricasSeleccionadas;

		protected LinkButton lnkBtnAddMetrica;
		protected LinkButton lnkBtnRemoveMetrica;

		protected ListBox lstBoxFiltrosDisponibles;
		protected ListBox lstBoxFiltrosSeleccionados;

		protected LinkButton lnkBtnAddFiltro;
		protected LinkButton lnkBtnRemoveFiltro;

		protected RequiredFieldValidator reqNombreReporte;
		protected ValidationSummary valSummary;
		protected Button btnAceptar;
		protected Button btnCancelar;

		#endregion

		#region Event handlers

		private void Page_Load(object sender, EventArgs e)
		{			  
			this.BaseLoad();

			if (!Page.IsPostBack) 
			{
				long id = this.Proyecto.Id;

				this.lstBoxAttDisponibles.DataSource = BICContext.Instance.AtributoService.Select(id);
				this.lstBoxAttDisponibles.DataTextField = "Nombre";
				this.lstBoxAttDisponibles.DataValueField ="Id";
				this.lstBoxAttDisponibles.DataBind();

				this.lstBoxAttSeleccionados.DataSource = BICContext.Instance.AtributoService.Select(id);
				this.lstBoxAttSeleccionados.DataTextField = "Nombre";
				this.lstBoxAttSeleccionados.DataValueField = "Id";
				this.lstBoxAttSeleccionados.DataBind();

				this.lstBoxAttDescriptions.DataSource = BICContext.Instance.AtributoService.Select(id);
				this.lstBoxAttDescriptions.DataTextField = "Nombre";
				this.lstBoxAttDescriptions.DataValueField ="Id";
				this.lstBoxAttDescriptions.DataBind();

				this.lstBoxMetricasDisponibles.DataSource = BICContext.Instance.AtributoService.Select(id);
				this.lstBoxMetricasDisponibles.DataTextField = "Nombre";
				this.lstBoxMetricasDisponibles.DataValueField ="Id";
				this.lstBoxMetricasDisponibles.DataBind();

				this.lstBoxAttDescriptions.DataSource = BICContext.Instance.AtributoService.Select(id);
				this.lstBoxAttDescriptions.DataTextField = "Nombre";
				this.lstBoxAttDescriptions.DataValueField ="Id";
				this.lstBoxAttDescriptions.DataBind();

				this.lstBoxAttDescriptions.DataSource = BICContext.Instance.AtributoService.Select(id);
				this.lstBoxAttDescriptions.DataTextField = "Nombre";
				this.lstBoxAttDescriptions.DataValueField ="Id";
				this.lstBoxAttDescriptions.DataBind();

				this.lstBoxAttDescriptions.DataSource = BICContext.Instance.AtributoService.Select(id);
				this.lstBoxAttDescriptions.DataTextField = "Nombre";
				this.lstBoxAttDescriptions.DataValueField ="Id";
				this.lstBoxAttDescriptions.DataBind();
			}
		}

		private void lnkBtnAddAttToColumn_Click(object sender, EventArgs e)
		{
			
		}

		private void lnkBtnAddAttToRow_Click(object sender, EventArgs e)
		{

		}

		private void lnkBtnRemoveAtt_Click(object sender, EventArgs e)
		{

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
			return this.Usuario.Rol.PuedeAccederAMetricas();
		}

		
	}
}
