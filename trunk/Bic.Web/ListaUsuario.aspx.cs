using System;
using System.Web.UI.WebControls;
using Bic.Application;

namespace Bic.Web
{
	/// <summary>
	/// Descripción breve de WebForm1.
	/// </summary>
	public class ListaUsuario : BasePage
	{
		protected Button btnNuevo;
		protected Label lblUsuario;
		protected DataGrid dgUsuarios;
	
		private void Page_Load(object sender, EventArgs e)
		{
			BaseLoad();
			if (!Page.IsPostBack) 
			{
				this.lblUsuario.Text = Usuario.Nombre;
				ListarUsuarios();
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
			this.dgUsuarios.ItemCommand += new DataGridCommandEventHandler(this.dgUsuarios_ItemCommand);
			this.btnNuevo.Click += new EventHandler(this.btnNuevo_Click);
			this.Load += new EventHandler(this.Page_Load);

		}
		#endregion


		private void dgUsuarios_ItemCommand(object sender, DataGridCommandEventArgs e)
		{
			long id = (long) this.dgUsuarios.DataKeys[e.Item.ItemIndex];
			BICContext.Instance.UsuarioService.Delete(id);
			ListarUsuarios();
		}

		private void ListarUsuarios()
		{
			dgUsuarios.DataSource = BICContext.Instance.UsuarioService.Select();
			dgUsuarios.DataBind();
		}

		private void btnNuevo_Click(object sender, EventArgs e)
		{
			Response.Redirect("EdicionUsuario.aspx?id=-1");
		}

		protected override bool TienePermisosSuficientes()
		{
			return this.Usuario.Rol.PuedeAccederAUsuarios();
		}
	}
}
