using System;
using System.Web.UI.WebControls;
using Bic.Application;

namespace Bic.Web
{
	/// <summary>
	/// Descripción breve de ListaReporte.
	/// </summary>
	public class ListaReporte : BasePage
	{
		#region Web Controls

		protected DataGrid dgReportes;
		protected Button btnNuevo;

		#endregion

		#region Event handlers

		private void Page_Load(object sender, EventArgs e)
		{
			this.BaseLoad();

			if (!Page.IsPostBack) 
			{
				this.ListReportes();
			}
		}


		private void dgReportes_ItemCreated(object sender, DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || 
				e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.EditItem)
			{
				TableCell myTableCell;
				myTableCell = e.Item.Cells[2];
				LinkButton myDeleteButton; 
				myDeleteButton = (LinkButton) myTableCell.Controls[0];
				myDeleteButton.Attributes.Add("onclick", 
					"return confirm('¿Está seguro que desea eliminar el reporte?');");

			}
		}


		private void dgReportes_ItemCommand(object sender, DataGridCommandEventArgs e)
		{
			long id = (long) this.dgReportes.DataKeys[e.Item.ItemIndex];

			if (e.CommandName.Equals("Borrar"))
			{				
				BICContext.Instance.ReporteService.Delete(id);
				
			}
			else if(e.CommandName.Equals("Ejecutar"))
			{				
				ReportManager.GetInstance(this.Session).ReportCache = BICContext.Instance.ReporteService.Ejecutar(id);
				Response.Redirect("Reportes/AdministracionReportes.aspx");
			}
			
			this.ListReportes();
		}


		private void btnNuevo_Click(object sender, EventArgs e)
		{
			Response.Redirect("EdicionReporte.aspx?id=-1");
		}


		#endregion       

		#region Private methods

		private void ListReportes()
		{
			dgReportes.DataSource = BICContext.Instance.ReporteService.Select(Proyecto.Id);
			dgReportes.DataBind();
		}


		#endregion		

		#region Protected methods

		protected override bool TienePermisosSuficientes()
		{
			return this.Usuario.Rol.PuedeAccederAReportes();
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
			this.Load += new EventHandler(this.Page_Load);
			this.btnNuevo.Click += new EventHandler(this.btnNuevo_Click);
			this.dgReportes.ItemCommand += new DataGridCommandEventHandler(this.dgReportes_ItemCommand);
			this.dgReportes.ItemCreated += new DataGridItemEventHandler(this.dgReportes_ItemCreated);
		}
		#endregion
	}
}
