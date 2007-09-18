using System;
using System.Web.UI.WebControls;
using Bic.Application;
using Bic.Domain;
using Bic.Domain.Catalogo;

namespace Bic.Web
{
	/// <summary>
	/// Descripción breve de EdicionHecho.
	/// </summary>
	public class EdicionHecho : BasePage
	{
		protected Label lblUsuario;
		protected Label lblProyecto;

		protected TextBox txtNombre;
		protected DropDownList ddlColumna;

		protected Button btnAceptar;
		protected RequiredFieldValidator reqNombre;
		protected RequiredFieldValidator reqColumna;
		protected ValidationSummary valSummary;
		protected Button btnCancelar;


		private void Page_Load(object sender, EventArgs e)
		{
			BaseLoad();
			if (!Page.IsPostBack) 
			{
				this.lblUsuario.Text = Usuario.Nombre;
				this.lblProyecto.Text = Proyecto.Nombre;
				object datasource = null;
				
				long id = long.Parse(Request.Params["id"]);
				ViewState["id"] = id;
				if (id != -1)
				{
					Hecho h = BICContext.Instance.HechoService.Retrieve(id);
					this.ddlColumna.SelectedValue = h.Columna.Nombre;
					this.txtNombre.Text = h.Nombre;
					datasource = new Columna[] {h.Columna};
				} 
				else 
				{
					datasource = BICContext.Instance.CatalogoService.SelectColumnasDisponibles(Proyecto.Id);
				}

				this.ddlColumna.DataSource = datasource;
				this.ddlColumna.DataBind();

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

			if (id == -1)
			{
				Columna c = BICContext.Instance.CatalogoService.ObtenerColumna(this.ddlColumna.SelectedValue, Proyecto.Id);
				Hecho h = new Hecho(nombre, c);
				h.Proyecto = Proyecto;
				BICContext.Instance.HechoService.Save(h);
			} 
			else 
			{
				Hecho h = BICContext.Instance.HechoService.Retrieve(id);
				h.Nombre = nombre;
				BICContext.Instance.HechoService.Save(h);
			}			

			
			Response.Redirect("ListaHecho.aspx");
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("ListaHecho.aspx");
		}

		protected override bool TienePermisosSuficientes()
		{
			return this.Usuario.Rol.PuedeAccederAHechos();
		}
	}
}
