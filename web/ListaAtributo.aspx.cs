using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using ar.com.bic.application;

namespace bic
{
	/// <summary>
	/// Descripción breve de ListaAtributo.
	/// </summary>
	public class ListaAtributo : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblUsuario;
		protected System.Web.UI.WebControls.Label lblProyecto;
		protected System.Web.UI.WebControls.DataGrid dgAtributos;
		protected System.Web.UI.WebControls.Button btnNuevo;

		private long ProyectoId
		{
			get { return (long) Session["proyectoId"]; }
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack) 
			{
				this.lblUsuario.Text = Session["usuario"].ToString();
				this.lblProyecto.Text = BICContext.Instance.ProyectoService.retrieve(ProyectoId).Nombre;
				listAtributos();
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
			this.Load += new System.EventHandler(this.Page_Load);
			this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
			this.dgAtributos.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgAtributos_ItemCommand);
			this.dgAtributos.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgAtributos_ItemCreated);
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
			BICContext.Instance.AtributoService.delete(id);
			listAtributos();
		}

		private void listAtributos()
		{
			dgAtributos.DataSource = BICContext.Instance.AtributoService.select(ProyectoId);
			dgAtributos.DataBind();
		}

		private void btnNuevo_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("EdicionAtributo.aspx?id=-1");
		}
	}
}
