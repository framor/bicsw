using System;
using System.Web.UI.WebControls;
using Bic.Application;
using Bic.Domain;
using Bic.Framework;
using Bic.Framework.Exception;

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
		protected CustomValidator valNombre;
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
					this.txtNombreReporte.Text = Server.HtmlDecode(r.Nombre);

					BindLists();

					foreach (ListItem i in this.lstAtributos.Items)
					{
						Atributo a = BICContext.Instance.AtributoService.Retrieve(long.Parse(i.Value));
						i.Selected = r.Atributos.Contains(a);
					}
					foreach (ListItem i in this.lstMetricas.Items)
					{
						Metrica m = BICContext.Instance.MetricaService.Retrieve(long.Parse(i.Value));
						i.Selected = r.Metricas.Contains(m);
					}
					foreach (ListItem i in this.lstFiltros.Items)
					{
						Filtro f = BICContext.Instance.FiltroService.Retrieve(long.Parse(i.Value));
						i.Selected = r.Filtros.Contains(f);
					}					
				}
				else
				{
					BindLists();
					
				}
			}
		}

		
		private void BindLists() 
		{
			this.lstAtributos.DataSource = BICContext.Instance.AtributoService.Select(Proyecto.Id);
			this.lstAtributos.DataBind();

			this.lstFiltros.DataSource = BICContext.Instance.FiltroService.Select(Proyecto.Id);
			this.lstFiltros.DataBind();

			this.lstMetricas.DataSource = BICContext.Instance.MetricaService.Select(Proyecto.Id);
			this.lstMetricas.DataBind();
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

		}
		#endregion

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			long id = (long) ViewState["id"];
			Reporte r;
			if (id == -1)
			{
				r = new Reporte();
			} 
			else 
			{
				r = BICContext.Instance.ReporteService.Retrieve(id);
			}			
			r.Nombre = StringUtils.TrimSpecialCharacters(this.txtNombreReporte.Text);
			r.Proyecto = Proyecto;
			foreach (ListItem i in this.lstAtributos.Items)
			{
				Atributo a = BICContext.Instance.AtributoService.Retrieve(long.Parse(i.Value));
				if (i.Selected)
				{
					r.RemoverAtributo(a);
					r.AgregarAtributo(a);
				}
				else
				{
					r.RemoverAtributo(a);
				}
			}
			foreach (ListItem i in this.lstMetricas.Items)
			{
				Metrica m = BICContext.Instance.MetricaService.Retrieve(long.Parse(i.Value));
				if (i.Selected)
				{
					r.RemoverMetrica(m);
					r.AgregarMetrica(m);
				}
				else
				{
					r.RemoverMetrica(m);
				}
			}
			foreach (ListItem i in this.lstFiltros.Items)
			{
				Filtro f = BICContext.Instance.FiltroService.Retrieve(long.Parse(i.Value));
				if (i.Selected)
				{
					r.RemoverFiltro(f);
					r.AgregarFiltro(f);
				}
				else
				{
					r.RemoverFiltro(f);
				}
			}

			try 
			{
				BICContext.Instance.ReporteService.Save(r);
				Response.Redirect("ListaReporte.aspx");
			} 
			catch (ServiceException se)
			{
				this.valNombre.IsValid = false;
				this.valNombre.ErrorMessage = se.Message;
			}	
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("ListaReporte.aspx");
		}

		protected override bool TienePermisosSuficientes()
		{
			return this.Usuario.Rol.PuedeAccederAReportes();
		}

		
	}
}
