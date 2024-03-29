using System;
using System.Collections;
using System.Web.UI.WebControls;
using Bic.Application;
using Bic.Framework.Exception;

namespace Bic.Web
{
	/// <summary>
	/// Descripci�n breve de ListaHecho.
	/// </summary>
	public class ListaHecho : BasePage
	{
		protected DataGrid dgHechos;
		protected Button btnNuevo;
		protected CustomValidator valEliminar;
		protected CustomValidator valTablas;

		private void Page_Load(object sender, EventArgs e)
		{
			BaseLoad();
			if (!Page.IsPostBack) 
			{
				ListHechos();
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
			this.Load += new EventHandler(this.Page_Load);
			this.btnNuevo.Click += new EventHandler(this.btnNuevo_Click);
			this.dgHechos.ItemCommand += new DataGridCommandEventHandler(this.dgHechos_ItemCommand);
			this.dgHechos.ItemCreated += new DataGridItemEventHandler(this.dgHechos_ItemCreated);
			this.dgHechos.PageIndexChanged += new DataGridPageChangedEventHandler(this.dgHechos_PageChanger);
		}
		#endregion

		private void dgHechos_ItemCreated(object sender, DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || 
				e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.EditItem)
			{
				TableCell myTableCell;
				myTableCell = e.Item.Cells[3];
				LinkButton myDeleteButton; 
				myDeleteButton = (LinkButton) myTableCell.Controls[0];
				myDeleteButton.Attributes.Add("onclick", 
					"return confirm('�Est� seguro que desea eliminar el hecho?');");

			}
		}

		private void dgHechos_ItemCommand(object sender, DataGridCommandEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || 
				e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.EditItem)
			{

				long id = (long) this.dgHechos.DataKeys[e.Item.ItemIndex];
				try
				{
					BICContext.Instance.HechoService.Delete(id);
					this.dgHechos.CurrentPageIndex = 0;
					ListHechos();
				}
				catch (ServiceException se)
				{
					this.valEliminar.IsValid = false;
					this.valEliminar.ErrorMessage = se.Message;
				}
			}
		}

		private void dgHechos_PageChanger(object source, DataGridPageChangedEventArgs e)
		{
			this.dgHechos.CurrentPageIndex = e.NewPageIndex;
			ListHechos();
		}

		private void ListHechos()
		{
			dgHechos.DataSource = BICContext.Instance.HechoService.Select(Proyecto.Id);
			dgHechos.DataBind();
		}

		private void btnNuevo_Click(object sender, EventArgs e)
		{
			ICollection ds = BICContext.Instance.TablaService.SelectTablasParaHechos(Proyecto.Id);
			if( ds.Count == 0)
			{
				this.valTablas.IsValid = false;
				this.valTablas.ErrorMessage = "No existen Tablas sobre las cuales se puede crear un Hecho.";
			}
			else
			{
				Response.Redirect("EdicionHecho.aspx?id=-1");
			}
		}

		protected override bool TienePermisosSuficientes()
		{
			return this.Usuario.Rol.PuedeAccederAHechos();
		}
	}
}
