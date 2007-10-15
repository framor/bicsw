using System;
using System.Web.UI.WebControls;
using Bic.Application;
using Bic.Framework.Exception;

namespace Bic.Web
{
	/// <summary>
	/// Descripción breve de ListaTabla.
	/// </summary>
	public class ListaTabla : BasePage
	{
		protected Label lblProyecto;
		protected DataGrid dgTablas;
		protected Button btnNuevo;
		protected CustomValidator valEliminar;

		private void Page_Load(object sender, EventArgs e)
		{
			BaseLoad();
			if (!Page.IsPostBack) 
			{
				ListTablas();
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
			this.dgTablas.ItemCommand += new DataGridCommandEventHandler(this.dgTablas_ItemCommand);
			this.dgTablas.ItemCreated += new DataGridItemEventHandler(this.dgTablas_ItemCreated);
			this.dgTablas.PageIndexChanged += new DataGridPageChangedEventHandler(this.dgTablas_PageChanger);
		}
		#endregion

		private void dgTablas_ItemCreated(object sender, DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || 
				e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.EditItem)
			{
				TableCell myTableCell;
				myTableCell = e.Item.Cells[4];
				LinkButton myDeleteButton; 
				myDeleteButton = (LinkButton) myTableCell.Controls[0];
				myDeleteButton.Attributes.Add("onclick", 
					"return confirm('¿Está seguro que desea eliminar la tabla?');");

			}
		}

		private void dgTablas_ItemCommand(object sender, DataGridCommandEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || 
				e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.EditItem)
			{
				long id = (long) this.dgTablas.DataKeys[e.Item.ItemIndex];
				try 
				{
					BICContext.Instance.TablaService.Delete(id);
					this.dgTablas.CurrentPageIndex = 0;
					ListTablas();
				} 
				catch (ServiceException se) 
				{
					this.valEliminar.IsValid = false;
					this.valEliminar.ErrorMessage = se.Message;
				}			
			}
		}

		private void dgTablas_PageChanger(object source, DataGridPageChangedEventArgs e)
		{
			this.dgTablas.CurrentPageIndex = e.NewPageIndex;
			ListTablas();
		}

		private void ListTablas()
		{
			dgTablas.DataSource = BICContext.Instance.TablaService.Select(Proyecto.Id);
			dgTablas.DataBind();
		}

		private void btnNuevo_Click(object sender, EventArgs e)
		{
			Response.Redirect("EdicionTabla.aspx?id=-1");
		}

		protected override bool TienePermisosSuficientes()
		{
			return this.Usuario.Rol.PuedeAccederATablas();
		}
	}
}
