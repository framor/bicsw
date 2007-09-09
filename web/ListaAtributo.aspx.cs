using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ar.com.bic.application;

namespace bic
{
	/// <summary>
	/// Descripción breve de ListaAtributo.
	/// </summary>
	public class ListaAtributo : BasePage
	{
		protected Label lblUsuario;
		protected Label lblProyecto;
		protected DataGrid dgAtributos;
		protected Button btnNuevo;

		private void Page_Load(object sender, EventArgs e)
		{
			BaseLoad();
			if (!Page.IsPostBack) 
			{
				this.lblUsuario.Text = Usuario.Nombre;
				this.lblProyecto.Text = Proyecto.Nombre;
				ListAtributos();
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
			this.dgAtributos.ItemCommand += new DataGridCommandEventHandler(this.dgAtributos_ItemCommand);
			this.dgAtributos.ItemCreated += new DataGridItemEventHandler(this.dgAtributos_ItemCreated);
		}
		#endregion

		private void dgAtributos_ItemCreated(object sender, DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || 
				e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.EditItem)
			{
				TableCell myTableCell;
				myTableCell = e.Item.Cells[4];
				LinkButton myDeleteButton; 
				myDeleteButton = (LinkButton) myTableCell.Controls[0];
				myDeleteButton.Attributes.Add("onclick", 
					"return confirm('¿Está seguro que desea eliminar el atributo?');");

			}
		}

		private void dgAtributos_ItemCommand(object sender, DataGridCommandEventArgs e)
		{
			long id = (long) this.dgAtributos.DataKeys[e.Item.ItemIndex];
			BICContext.Instance.AtributoService.Delete(id);
			ListAtributos();
		}

		private void ListAtributos()
		{
			dgAtributos.DataSource = BICContext.Instance.AtributoService.Select(Proyecto.Id);
			dgAtributos.DataBind();
		}

		private void btnNuevo_Click(object sender, EventArgs e)
		{
			Response.Redirect("EdicionAtributo.aspx?id=-1");
		}

		protected override bool TienePermisosSuficientes()
		{
			return this.Usuario.Rol.PuedeAccederAAtributos();
		}
	}
}
