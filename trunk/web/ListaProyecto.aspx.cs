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
using ar.com.bic.domain;

namespace bic
{
	/// <summary>
	/// Descripción breve de WebForm1.
	/// </summary>
	public class ListaProyecto : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnNuevo;
		protected System.Web.UI.WebControls.DataGrid dgProyectos;
		protected System.Web.UI.WebControls.Label lblUsuario;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				listProyectos();
				this.lblUsuario.Text = Session["usuario"].ToString();
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
			this.dgProyectos.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgProyectos_ItemCommand);
			this.dgProyectos.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgProyectos_ItemCreated);
			this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void dgProyectos_ItemCreated(object sender, DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || 
				e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.EditItem)
			{
				TableCell myTableCell;
				myTableCell = e.Item.Cells[4];
				LinkButton myDeleteButton; 
				myDeleteButton = (LinkButton) myTableCell.Controls[0];
				myDeleteButton.Attributes.Add("onclick", 
					"return confirm('¿Está seguro que desea eliminar el proyecto?');");

			}
		}

		private void dgProyectos_ItemCommand(object sender, DataGridCommandEventArgs e)
		{
			long id = (long) this.dgProyectos.DataKeys[e.Item.ItemIndex];
			if (e.CommandName.Equals("Delete"))
			{
				BICContext.Instance.ProyectoService.delete(id);
				listProyectos();
			}
			else if (e.CommandName.Equals("Seleccionar"))
			{
				Response.Redirect("Home.aspx?id=" + id.ToString());
			}
		}

		private void listProyectos()
		{
			dgProyectos.DataSource = BICContext.Instance.ProyectoService.select();
			dgProyectos.DataBind();
		}

		private void btnNuevo_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("EdicionProyecto.aspx?id=-1");
		}
	}
}
