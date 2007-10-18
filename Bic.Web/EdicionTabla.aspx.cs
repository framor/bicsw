using System;
using System.Web.UI.WebControls;
using Bic.Application;
using Bic.Domain.Catalogo;
using Bic.Framework.Exception;

namespace Bic.Web
{
	/// <summary>
	/// Descripción breve de EdicionTabla.
	/// </summary>
	public class EdicionTabla : BasePage
	{
		protected TextBox txtAlias;
		protected TextBox txtPeso;
		protected ListBox lstNombre;

		protected Button btnAceptar;
		protected RequiredFieldValidator reqNombre;
		protected RequiredFieldValidator reqAlias;
		protected CustomValidator valAlias;
		protected RequiredFieldValidator reqPeso;
		protected ValidationSummary valSummary;
		protected Button btnCancelar;


		private void Page_Load(object sender, EventArgs e)
		{
			BaseLoad();
			if (!Page.IsPostBack) 
			{
				long id = long.Parse(Request.Params["id"]);
				ViewState["id"] = id;
				if (id != -1)
				{
					Tabla t = BICContext.Instance.TablaService.Retrieve(id);
					this.lstNombre.SelectedValue = t.Nombre;
					this.lstNombre.Enabled = false;
					this.txtAlias.Text = t.Alias;
					this.txtPeso.Text = t.Peso.ToString();
				} 
				else 
				{
					this.txtPeso.Text = "0";
				}

				try 
				{
					this.lstNombre.DataSource = BICContext.Instance.CatalogoService.SelectTablasDisponibles(Proyecto.Id);
					this.lstNombre.DataBind();
				} 
				catch (ServiceException se)
				{					
					Page.RegisterStartupScript("errorCatalgo", string.Format(@"<script>alert('No se pudo obtener la información del catálogo de datos. Causa: {0}');</script>", se.Message));
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
			this.btnAceptar.Click += new EventHandler(this.btnAceptar_Click);
			this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
			this.Load += new EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			long id = (long) ViewState["id"];
			string alias = this.txtAlias.Text;
			int peso = Int32.Parse(this.txtPeso.Text);
			Tabla t = null;
			if (id == -1)
			{
				t = BICContext.Instance.CatalogoService.ObtenerTabla(this.lstNombre.SelectedValue, Proyecto.Id);
				t.Alias = alias;
				t.Peso = peso;
				t.Proyecto = Proyecto;
			} 
			else 
			{
				t = BICContext.Instance.TablaService.Retrieve(id);
				t.Alias = alias;
				t.Peso = peso;
			}			

			try 
			{
				BICContext.Instance.TablaService.Save(t);
				Response.Redirect("ListaTabla.aspx");
			} 
			catch (ServiceException se)
			{
				this.valAlias.IsValid = false;
				this.valAlias.ErrorMessage = se.Message;
			}		
			
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("ListaTabla.aspx");
		}

		protected override bool TienePermisosSuficientes()
		{
			return this.Usuario.Rol.PuedeAccederATablas();
		}
	}
}
