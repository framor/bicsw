using System;

namespace Bic.Web
{
	/// <summary>
	/// Descripción breve de Home.
	/// </summary>
	public class Home : BasePage
	{

		private void Page_Load(object sender, EventArgs e)
		{
			BaseLoad();
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
		}
		#endregion

		protected override bool TienePermisosSuficientes()
		{
			return true;
		}
	}
}
