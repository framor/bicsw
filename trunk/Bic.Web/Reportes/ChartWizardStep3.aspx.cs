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
using WebChart;

namespace Bic.Web
{
	public class ChartWizardStep3 : WizardBasePage
	{
		#region Web controls

		protected System.Web.UI.WebControls.ImageButton imgBtnChart;

		#endregion
	
		#region Event handlers

		private void Page_Load(object sender, System.EventArgs e)
		{
			this.BaseLoad();

			if(!IsPostBack)
			{
				this.PopulateView();
			}
		}


		#endregion

		#region Private methods

		#endregion

		#region Protected methods

		protected override String NextPage
		{
			get
			{
				throw new Exception("Boton no utilizado.");
			}
		}


		protected override String PreviousPage
		{
			get
			{
				return "ChartWizardStep2.aspx";
			}
		}


		protected override void PopulateView()
		{
			//TODO : en esta pagina se puede agregar una especie de panel de control para ajustar algunas caracteristicas
			// visuales del grafico.
		}

				
		#endregion	

		#region Web Form Designer generated code

		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);	
			this.IsLastPage = true;
		}

		#endregion		
	}
}
