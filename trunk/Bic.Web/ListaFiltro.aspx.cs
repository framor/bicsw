using System;
using System.Web.UI.WebControls;
using Bic.Application;
using System.Collections;

namespace Bic.Web
{
	/// <summary>
	/// Descripción breve de ListaFiltro.
	/// </summary>
	public class ListaFiltro : BasePage
	{
		protected DataGrid dgFiltros;
		protected Button btnNuevo;
		protected CustomValidator valAtributosExistentes;

		private void Page_Load(object sender, EventArgs e)
		{
			BaseLoad();
			if (!Page.IsPostBack) 
			{
				ListFiltros();
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
			this.Load += new EventHandler(this.Page_Load);
			this.btnNuevo.Click += new EventHandler(this.btnNuevo_Click);
			this.dgFiltros.ItemCommand += new DataGridCommandEventHandler(this.dgFiltros_ItemCommand);
			this.dgFiltros.ItemCreated += new DataGridItemEventHandler(this.dgFiltros_ItemCreated);
			this.dgFiltros.PageIndexChanged += new DataGridPageChangedEventHandler(this.dgFiltros_PageChanger);
		}
		#endregion

		private void dgFiltros_ItemCreated(object sender, DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || 
				e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.EditItem)
			{
				TableCell myTableCell;
				myTableCell = e.Item.Cells[3];
				LinkButton myDeleteButton; 
				myDeleteButton = (LinkButton) myTableCell.Controls[0];
				myDeleteButton.Attributes.Add("onclick", 
					"return confirm('¿Está seguro que desea eliminar el filtro?');");

			}
		}

		private void dgFiltros_ItemCommand(object sender, DataGridCommandEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || 
				e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.EditItem)
			{
				long id = (long) this.dgFiltros.DataKeys[e.Item.ItemIndex];
				BICContext.Instance.FiltroService.Delete(id);
				this.dgFiltros.CurrentPageIndex = 0;
				ListFiltros();
			}
		}

		private void dgFiltros_PageChanger(object source, DataGridPageChangedEventArgs e)
		{
			this.dgFiltros.CurrentPageIndex = e.NewPageIndex;
			ListFiltros();
		}

		private void ListFiltros()
		{
			dgFiltros.DataSource = BICContext.Instance.FiltroService.Select(Proyecto.Id);
			dgFiltros.DataBind();
		}

		private void btnNuevo_Click(object sender, EventArgs e)
		{
			ICollection ds = BICContext.Instance.AtributoService.Select(Proyecto.Id);
			if( ds.Count == 0)
			{
				this.valAtributosExistentes.IsValid = false;
				this.valAtributosExistentes.ErrorMessage = "No existe ningun Atributo para filtrar";
			}
			else
			{
				Response.Redirect("EdicionFiltro.aspx?id=-1");
			}
		}

		protected override bool TienePermisosSuficientes()
		{
			return this.Usuario.Rol.PuedeAccederAFiltros();
		}
	}
}
