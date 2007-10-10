using System;
using System.Web.UI.WebControls;
using Bic.Application;
using Bic.Domain;
using Bic.Domain.Catalogo;
using Bic.Framework;
using Bic.Framework.Exception;

namespace Bic.Web
{
	/// <summary>
	/// Descripción breve de EdicionMetrica.
	/// </summary>
	public class EdicionMetrica : BasePage
	{
		protected TextBox txtNombre;
		protected DropDownList ddlFuncion;
		protected DropDownList ddlHecho;

		protected Button btnAceptar;
		protected RequiredFieldValidator reqNombre;
		protected RequiredFieldValidator reqFuncion;
		protected RequiredFieldValidator reqHecho;
		protected ValidationSummary valSummary;
		protected CustomValidator valNombre;
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
					this.ddlFuncion.SelectedValue = m.Funcion;
					datasource = new Hecho[] {m.Hecho};
				} 
				else 
				{
					datasource = BICContext.Instance.HechoService.Select(Proyecto.Id);
				}

				this.ddlHecho.DataSource = datasource;
				this.ddlHecho.DataBind();

				this.ddlFuncion.Items.Add(new ListItem("Promedio", Metrica.PROMEDIO));
				this.ddlFuncion.Items.Add(new ListItem("Total de registros", Metrica.CANTIDAD));
				this.ddlFuncion.Items.Add(new ListItem("Maximo", Metrica.MAXIMO));
				this.ddlFuncion.Items.Add(new ListItem("Minimo", Metrica.MINIMO));
				this.ddlFuncion.Items.Add(new ListItem("Sumatoria", Metrica.SUMATORIA));
				this.ddlFuncion.DataBind();
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
			string funcion = this.ddlFuncion.SelectedValue;
			Hecho h = BICContext.Instance.HechoService.Retrieve(long.Parse(this.ddlHecho.SelectedValue));

			try 
			{
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
			catch (ServiceException se)
			{
				this.valNombre.IsValid = false;
				this.valNombre.ErrorMessage = se.Message;
			}	
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
