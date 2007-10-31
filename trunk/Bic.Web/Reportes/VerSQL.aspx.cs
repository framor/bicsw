using System;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Bic.Application;
using Bic.Framework.Exception;

namespace Bic.Web
{
	public class VerSQL : WizardBasePage
	{
		#region Web controls

		protected System.Web.UI.WebControls.Label lblSQLString;		

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

		#region Protected methods

		protected override void PopulateView()
		{
			string sql = string.Empty;
			try
			{
				sql = BICContext.Instance.ReporteService.GetReportSQL(ReportManager.GetInstance(this.Session).Reporte);
			}
			catch (ServiceException se)
			{
				this.lblSQLString.Text = se.Message;
				return;
			}
			sql = sql.Replace("\n", "<br>");
			sql = sql.Replace("select", "<span style='color:blue'><b>select</b></span>");
			sql = sql.Replace("from", "<span style='color:blue'><b>from</b></span>");
			sql = sql.Replace("where", "<span style='color:blue'><b>where</b></span>");
			sql = sql.Replace("and ", "<span style='color:blue'><b>and </b></span>");
			sql = sql.Replace("Group By", "<span style='color:blue'><b>group by</b></span>");
			this.lblSQLString.Text = sql.Replace("\n", "<br>");
		}
		
		protected override String NextPage
		{
			get
			{
				return string.Empty;
			}
		}


		protected override String PreviousPage
		{
			get
			{
				return string.Empty;
			}
		}

				
		#endregion	

		#region Web Form Designer generated code

		override protected void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit(e);
		}
		

		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
			this.btnBack.Visible = false;
			this.btnNext.Visible = false;
		}


		#endregion
	}
}
