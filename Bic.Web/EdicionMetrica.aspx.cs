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
	public class EdicionMetrica : BasePage
	{
		protected TextBox txtNombre;
		protected TextBox txtFuncion;
		protected DropDownList ddlHecho;

		protected Button btnAceptar;
		protected RequiredFieldValidator reqNombre;
		protected RequiredFieldValidator reqFuncion;
		protected RequiredFieldValidator reqHecho;
		protected ValidationSummary valSummary;
		protected Button btnCancelar;


		private void Page_Load(object sender, EventArgs e)
		{
			BaseLoad();
			if (!Page.IsPostBack) 
			{
				object datasource = null;
				
				long id = long.Parse(Request.Params["id"]);
				ViewState["id"] = id;
				if (id != -1)
				{
					Metrica m = BICContext.Instance.MetricaService.Retrieve(id);
					this.ddlHecho.SelectedValue = m.Hecho.Id.ToString();
					this.txtNombre.Text = m.Nombre;
					this.txtFuncion.Text = m.Funcion;
					datasource = new Hecho[] {m.Hecho};
				} 
				else 
				{
					datasource = BICContext.Instance.HechoService.Select(Proyecto.Id);
				}

				this.ddlHecho.DataSource = datasource;
				this.ddlHecho.DataBind();

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
			string nombre = this.txtNombre.Text;
			string funcion = this.txtFuncion.Text;
			Hecho h = BICContext.Instance.HechoService.Retrieve(long.Parse(this.ddlHecho.SelectedValue));

			if (id == -1)
			{

				Metrica m = new Metrica(nombre, funcion, h);
				m.Proyecto = Proyecto;
				BICContext.Instance.MetricaService.Save(m);
			} 
			else 
			{
				Metrica m = BICContext.Instance.MetricaService.Retrieve(id);
				m.Nombre = nombre;
				m.Funcion = funcion;
				m.Hecho = h;
				BICContext.Instance.MetricaService.Save(m);
			}			
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
