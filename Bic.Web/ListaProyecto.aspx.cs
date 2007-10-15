using System;
using System.Web.UI.WebControls;
using Bic.Application;

namespace Bic.Web
{
	/// <summary>
	/// Descripción breve de WebForm1.
	/// </summary>
	public class ListaProyecto : BasePage
	{
		protected Button btnNuevo;
		protected DataGrid dgProyectos;
		protected Panel pnlAgregarNuevo;
	
		private void Page_Load(object sender, EventArgs e)
		{
			BaseLoad();
			if (!Page.IsPostBack)
			{
				this.Session["proyecto"] = null;
				this.btnNuevo.Enabled = Usuario.Rol.PuedeEditarProyectos();
				ListProyectos();
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
			this.dgProyectos.ItemCommand += new DataGridCommandEventHandler(this.dgProyectos_ItemCommand);
			this.dgProyectos.ItemCreated += new DataGridItemEventHandler(this.dgProyectos_ItemCreated);
			this.btnNuevo.Click += new EventHandler(this.btnNuevo_Click);
			this.dgProyectos.PageIndexChanged += new DataGridPageChangedEventHandler(this.dgProyectos_PageChanger);
			this.Load += new EventHandler(this.Page_Load);

		}
		#endregion

		private void dgProyectos_ItemCreated(object sender, DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || 
				e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.EditItem)
			{
				TableCell myTableCell;

				if (!Usuario.Rol.PuedeEditarProyectos())
				{
					myTableCell = e.Item.Cells[3];
					HyperLink myEditButton = (HyperLink) myTableCell.Controls[0];
					myEditButton.Enabled = false;

					myTableCell = e.Item.Cells[4];
					LinkButton myDeleteButton = (LinkButton) myTableCell.Controls[0];
					myDeleteButton.Enabled = false;
				} 
				else 
				{
					myTableCell = e.Item.Cells[4];
					LinkButton myDeleteButton; 
					myDeleteButton = (LinkButton) myTableCell.Controls[0];
					myDeleteButton.Attributes.Add("onclick", 
						"return ConfirmarEliminacion();");
				}
			}
		}

		
		private void dgProyectos_ItemCommand(object sender, DataGridCommandEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || 
				e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.EditItem)
			{
				long id = (long) this.dgProyectos.DataKeys[e.Item.ItemIndex];
				if (e.CommandName.Equals("Borrar"))
				{
					BICContext.Instance.ProyectoService.Delete(id);
					this.dgProyectos.CurrentPageIndex = 0;
					ListProyectos();
				}
				else if (e.CommandName.Equals("Seleccionar"))
				{
					Session["proyecto"] = BICContext.Instance.ProyectoService.Retrieve(id);
					Response.Redirect("Home.aspx");
				}
			}
		}

		private void dgProyectos_PageChanger(object source, DataGridPageChangedEventArgs e)
		{
			this.dgProyectos.CurrentPageIndex = e.NewPageIndex;
			ListProyectos();
		}

		private void ListProyectos()
		{
			dgProyectos.DataSource = BICContext.Instance.ProyectoService.Select();
			dgProyectos.DataBind();
		}

		private void btnNuevo_Click(object sender, EventArgs e)
		{
			Response.Redirect("EdicionProyecto.aspx?id=-1");
		}

		protected override bool TienePermisosSuficientes()
		{
			return this.Usuario.Rol.PuedeAccederAProyectos();
		}
	}
}
