using System;
using System.Collections;
using System.Web.UI.WebControls;
using Bic.Application;
using Bic.Domain;
using Bic.Domain.Catalogo;
using Bic.WebControls;
using Bic.Framework.Exception;

namespace Bic.Web
{
	/// <summary>
	/// Descripci�n breve de EdicionAtributo.
	/// </summary>
	public class EdicionAtributo : BasePage
	{
		protected TextBox txtNombre;
		protected DropDownList ddlTablaLookup;
		protected DropDownList ddlHijo;

		protected Button btnAceptar;
		protected RequiredFieldValidator reqNombre;
		protected RequiredFieldValidator reqColumnaId;
		protected RequiredFieldValidator reqColumnaDescripcion;
		protected RequiredFieldValidator reqTablaLookup;
		protected ValidationSummary valSummary;
		protected CustomValidator valNombre;
		protected DropDownList ddlColumnaId;
		protected ListBox lstDescripciones;
		protected Header bicHeader;
		protected Menu bicMenu;
		protected Button btnCancelar;


		private void Page_Load(object sender, EventArgs e)
		{
			BaseLoad();
			if (!Page.IsPostBack) 
			{
				this.ddlTablaLookup.DataSource = BICContext.Instance.TablaService.Select(Proyecto.Id);
				this.ddlTablaLookup.DataBind();
				
				long id = long.Parse(Request.Params["id"]);
				ViewState["id"] = id;
				if (id != -1)
				{
					Atributo a = BICContext.Instance.AtributoService.Retrieve(id);
					this.txtNombre.Text = a.Nombre;
					BindColumnas(a.TablaLookup.Id);
					this.ddlColumnaId.SelectedValue = a.ColumnaId.Id.ToString();
					
					foreach (ListItem i in this.lstDescripciones.Items)
					{
						Columna c = BICContext.Instance.TablaService.ObtenerColumna(long.Parse(i.Value));
						i.Selected = a.ColumnasDescripciones.Contains(c);
					}
					this.ddlTablaLookup.SelectedValue = a.TablaLookup.Id.ToString();
					this.ddlTablaLookup.Enabled = false;
					this.ddlColumnaId.Enabled = false;
				}
				else
				{
					BindColumnas(long.Parse(this.ddlTablaLookup.SelectedValue));
					
				}
				BindHijos();
			}

		}

		private void BindHijos()
		{	
			// Subi esto aca arriba para poder obtener el atributo y luego eliminarlo de los posibles hijos
			// ya que si es hijo de si mismo entra en un bucle infinito.
			long id = (long) ViewState["id"];
			Atributo a = BICContext.Instance.AtributoService.Retrieve(id);

			Columna colId = BICContext.Instance.TablaService.ObtenerColumna(long.Parse(this.ddlColumnaId.SelectedValue));
			IList hijos = new ArrayList(BICContext.Instance.AtributoService.SelectPosiblesHijos(Proyecto.Id,  colId));
			if (hijos != null && hijos.Count > 0)
			{
				hijos.Remove(a);
				this.ddlHijo.DataSource = hijos;
				this.ddlHijo.DataBind();
				ListItem nullItem = new ListItem(string.Empty, "0");
				this.ddlHijo.Items.Insert(0, nullItem);
			} 
			else
			{
				this.ddlHijo.DataSource = new ArrayList();
				this.ddlHijo.DataBind();
			}

			
			if (id != -1)
			{
				this.ddlHijo.SelectedValue = a.Hijo == null ? "0" : a.Hijo.Id.ToString();
			} else
			{
				this.ddlHijo.SelectedValue = "0";
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
			this.ddlTablaLookup.SelectedIndexChanged += new EventHandler(this.ddlTablaLookup_SelectedIndexChanged);
			this.ddlColumnaId.SelectedIndexChanged += new EventHandler(this.ddlColumnaId_SelectedIndexChanged);
			this.btnAceptar.Click += new EventHandler(this.btnAceptar_Click);
			this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
			this.Load += new EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			long id = (long) ViewState["id"];
			Atributo a;
			if (id == -1)
			{
				a = new Atributo();
			} 
			else 
			{
				a = BICContext.Instance.AtributoService.Retrieve(id);
			}			
			
			a.ColumnaId = BICContext.Instance.TablaService.ObtenerColumna(long.Parse(this.ddlColumnaId.SelectedValue));
			foreach (ListItem i in this.lstDescripciones.Items)
			{
				Columna c = BICContext.Instance.TablaService.ObtenerColumna(long.Parse(i.Value));
				if (i.Selected)
				{
					a.RemoverColumnaDescripcion(c);
					a.AgregarColumnaDescripcion(c);
				}
				else
				{
					a.RemoverColumnaDescripcion(c);
				}
			}
			a.TablaLookup = BICContext.Instance.TablaService.Retrieve(long.Parse(this.ddlTablaLookup.SelectedValue));
			a.Proyecto = Proyecto;
			a.Nombre = this.txtNombre.Text;
			a.Hijo = this.ddlHijo.SelectedValue == string.Empty ? 
				null : BICContext.Instance.AtributoService.Retrieve(long.Parse(this.ddlHijo.SelectedValue));
			try 
			{
				BICContext.Instance.AtributoService.Save(a);
				Response.Redirect("ListaAtributo.aspx");
			} 
			catch (ServiceException se)
			{
				this.valNombre.IsValid = false;
				this.valNombre.ErrorMessage = se.Message;
			}	
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("ListaAtributo.aspx");
		}

		protected override bool TienePermisosSuficientes()
		{
			return this.Usuario.Rol.PuedeAccederAAtributos();
		}

		private void ddlTablaLookup_SelectedIndexChanged(object sender, EventArgs e)
		{
			BindColumnas(long.Parse(this.ddlTablaLookup.SelectedValue));
			BindHijos();
		}

		private void ddlColumnaId_SelectedIndexChanged(object sender, EventArgs e)
		{
			BindHijos();
		}

		private void BindColumnas(long idTabla)
		{
			Tabla t = BICContext.Instance.TablaService.Retrieve(idTabla);
			ArrayList columnas = new ArrayList(t.Columnas);
			columnas.Sort();

			this.ddlColumnaId.DataSource = columnas;
			this.ddlColumnaId.DataBind();

			this.lstDescripciones.DataSource = columnas;
			this.lstDescripciones.DataBind();

		}

	}
}
