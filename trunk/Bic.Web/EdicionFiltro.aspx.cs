using System;
using System.Web.UI.WebControls;
using Bic.Application;
using Bic.Domain;
using Bic.Domain.Catalogo;
using Bic.Framework;

namespace Bic.Web
{
	/// <summary>
	/// Descripci�n breve de EdicionFiltro.
	/// </summary>
	public class EdicionFiltro : BasePage
	{
		protected TextBox txtNombre;
		protected DropDownList ddlColumna;
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
				object datasource = null;
				
				long id = long.Parse(Request.Params["id"]);
				ViewState["id"] = id;
				if (id != -1)
				{
					Filtro f = BICContext.Instance.FiltroService.Retrieve(id);
					this.txtNombre.Text = f.Nombre;
					this.txtValor.Text = f.Valor;
					this.ddlColumna.SelectedValue = f.Columna.Id.ToString();
					this.ddlOperador.SelectedValue = f.Operador;
					datasource = new Columna[] {f.Columna};
				} 
				else 
				{
					// TODO: mostrar solo columnas que son descripciones de atributos
					datasource = Util.ConvertirSet(BICContext.Instance.TablaService.SelectColumnasDisponibles(Proyecto.Id));
				}

				this.ddlColumna.DataSource = datasource;
				this.ddlColumna.DataBind();

				this.ddlOperador.Items.Add(new ListItem("<", "<"));
				this.ddlOperador.Items.Add(new ListItem("<=", "<="));
				this.ddlOperador.Items.Add(new ListItem("=", "="));
				this.ddlOperador.Items.Add(new ListItem(">", ">"));
				this.ddlOperador.Items.Add(new ListItem(">=", ">="));
				this.ddlOperador.Items.Add(new ListItem("LIKE", "LIKE"));
				this.ddlOperador.DataBind();
			}

		}

		#region C�digo generado por el Dise�ador de Web Forms
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: llamada requerida por el Dise�ador de Web Forms ASP.NET.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// M�todo necesario para admitir el Dise�ador. No se puede modificar
		/// el contenido del m�todo con el editor de c�digo.
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
			string operador = this.ddlOperador.SelectedValue;
			string valor = this.txtValor.Text;

			if (id == -1)
			{
				Columna c = BICContext.Instance.TablaService.ObtenerColumna(long.Parse(this.ddlColumna.SelectedValue));
				Filtro f = new Filtro();
				f.Columna = c;
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
	}
}