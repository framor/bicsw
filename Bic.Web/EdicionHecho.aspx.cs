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
	/// Descripción breve de EdicionHecho.
	/// </summary>
	public class EdicionHecho : BasePage
	{
		protected TextBox txtNombre;
		protected DropDownList ddlColumna;

		protected Button btnAceptar;
		protected RequiredFieldValidator reqNombre;
		protected RequiredFieldValidator reqColumna;
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
					Hecho h = BICContext.Instance.HechoService.Retrieve(id);
					this.ddlColumna.SelectedValue = h.Columna.Id.ToString();
					this.ddlColumna.Enabled = false;
					this.txtNombre.Text = h.Nombre;
					datasource = new Columna[] {h.Columna};
				} 
				else 
				{
					datasource = Util.ConvertirSet(BICContext.Instance.TablaService.SelectColumnasDisponibles(Proyecto.Id));
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

			try 
			{
				if (id == -1)
				{
					Columna c = BICContext.Instance.TablaService.ObtenerColumna(long.Parse(this.ddlColumna.SelectedValue));
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
			catch (ServiceException se)
			{
				this.valNombre.IsValid = false;
				this.valNombre.ErrorMessage = se.Message;
			}	
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
