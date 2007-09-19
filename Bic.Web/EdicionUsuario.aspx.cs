using System;
using System.Collections;
using System.Web.UI.WebControls;
using Bic.Application;
using Bic.Domain.Usuario;
using Bic.Framework.Exception;

namespace Bic.Web
{
	/// <summary>
	/// Descripción breve de EdicionUsuario.
	/// </summary>
	public class EdicionUsuario : BasePage
	{
		protected TextBox txtNombre;
		protected TextBox txtAlias;
		protected TextBox txtEMail;
		protected TextBox txtContrasena;
		protected DropDownList ddlRol;
		
		protected Label lblUsuario;
		protected Button btnCancelar;
		protected RequiredFieldValidator reqNombre;
		protected RequiredFieldValidator reqContrasena;
		protected CustomValidator valAlias;
		protected ValidationSummary valSummary;
		protected Button btnAceptar;
	
		private void Page_Load(object sender, EventArgs e)
		{
			BaseLoad();
			if (!Page.IsPostBack) 
			{
				BindCombo();
				this.lblUsuario.Text = Usuario.Nombre;

				long id = long.Parse(Request.Params["id"]);
				ViewState["id"] = id;
				if (id != -1)
				{
					Usuario u = BICContext.Instance.UsuarioService.Retrieve(id);
					this.txtAlias.ReadOnly = true;
					this.txtNombre.Text = u.Nombre;
					this.txtAlias.Text = u.Alias;
					this.txtContrasena.Text = u.Clave;
					this.txtEMail.Text = u.EMail;
					this.ddlRol.SelectedValue = u.Rol.Id;
				}
			}
		}

		private void BindCombo()
		{
			IList src = new ArrayList();
			src.Add(Administrador.Instance);
			src.Add(Arquitecto.Instance);
			src.Add(Reportero.Instance);
			this.ddlRol.DataSource = src;
			this.ddlRol.DataBind();
			this.ddlRol.SelectedValue = Rol.ID_REPORTERO; // reportero por defecto
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
			this.btnAceptar.Click += new EventHandler(this.btnAceptar_Click);
			this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
			this.Load += new EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			long id = (long) ViewState["id"];
			Usuario u;
			if (id == -1)
			{
				u = new Usuario();
			} 
			else 
			{
				u = BICContext.Instance.UsuarioService.Retrieve(id);
			}			
			u.Nombre = this.txtNombre.Text;
			u.Alias = this.txtAlias.Text;
			u.Clave = this.txtContrasena.Text;
			u.EMail = this.txtEMail.Text;
			u.Rol = Rol.ObtenerRol(this.ddlRol.SelectedValue);

			try 
			{
				BICContext.Instance.UsuarioService.Save(u);
				Response.Redirect("ListaUsuario.aspx");
			} 
			catch (ServiceException se)
			{
				this.valAlias.IsValid = false;
				this.valAlias.ErrorMessage = se.Message;
			}
			
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Response.Redirect("ListaUsuario.aspx");
		}

		protected override bool TienePermisosSuficientes()
		{
			return this.Usuario.Rol.PuedeAccederAUsuarios();
		}
	}
}
