using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


namespace Bic.Web
{
	/// <summary>
	/// Summary description for AdministracionReportes.
	/// </summary>
	public class AdministracionReportes : System.Web.UI.Page
	{
		#region	Web controls

		protected System.Web.UI.WebControls.DataGrid dtgReport;

		#endregion
	
		#region Event handlers

		private void Page_Load(object sender, System.EventArgs e)
		{		
			this.dtgReport.DataSource = DataSourcerMockProvider.GetDataSource();
			this.dtgReport.DataBind();			
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
			

		}
		#endregion
	}
}
