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

namespace Bic.Web
{
	public class ChartWizardStep1 : WizardBasePage
	{
		#region Web controls

		protected System.Web.UI.WebControls.ImageButton imgBtnIconBarsChart;
		protected System.Web.UI.WebControls.ImageButton imgBtnIconColumnsChart;
		protected System.Web.UI.WebControls.ImageButton imgBtnIconAreaChart;
		protected System.Web.UI.WebControls.ImageButton imgBtnIconPieChart;
		protected System.Web.UI.WebControls.ImageButton imgBtnIconLinesChart;
		protected System.Web.UI.WebControls.Label lblChartTypeSelected;		

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


		private void imgBtnIconAreaChart_Click(object sender, ImageClickEventArgs e)
		{
			ReportManager.GetInstance(this.Session).AddSelectedChart(ReportManager.GraphTypes.Area);
			this.PopulateView();			
		}


		private void imgBtnIconBarsChart_Click(object sender, ImageClickEventArgs e)
		{
			ReportManager.GetInstance(this.Session).AddSelectedChart(ReportManager.GraphTypes.Bars);
			this.PopulateView();
		}


		private void imgBtnIconColumnsChart_Click(object sender, ImageClickEventArgs e)
		{
			ReportManager.GetInstance(this.Session).AddSelectedChart(ReportManager.GraphTypes.Columns);
			this.PopulateView();
		}


		private void imgBtnIconLinesChart_Click(object sender, ImageClickEventArgs e)
		{
			ReportManager.GetInstance(this.Session).AddSelectedChart(ReportManager.GraphTypes.Lines);
			this.PopulateView();
		}


		private void imgBtnIconPieChart_Click(object sender, ImageClickEventArgs e)
		{
			ReportManager.GetInstance(this.Session).AddSelectedChart(ReportManager.GraphTypes.Pie);
			this.PopulateView();
		}
		

		#endregion

		#region Protected methods

		protected override String NextPage
		{
			get
			{
				return "ChartWizardStep2.aspx";
			}
		}


		protected override String PreviousPage
		{
			get
			{
				throw new Exception("Boton no utilizado.");
			}
		}


		protected override void PopulateView()
		{
			this.lblChartTypeSelected.Text = ReportManager.GetInstance(this.Session).ChartTypesSelectedManager.GetSelectedChartsStringDescription();			
			this.btnNext.Enabled = this.lblChartTypeSelected.Text.Length != 0;
		
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
			this.imgBtnIconAreaChart.Click+=new ImageClickEventHandler(imgBtnIconAreaChart_Click);
			this.imgBtnIconBarsChart.Click+=new ImageClickEventHandler(imgBtnIconBarsChart_Click);
			this.imgBtnIconColumnsChart.Click+=new ImageClickEventHandler(imgBtnIconColumnsChart_Click);
			this.imgBtnIconLinesChart.Click+=new ImageClickEventHandler(imgBtnIconLinesChart_Click);
			this.imgBtnIconPieChart.Click +=new ImageClickEventHandler(imgBtnIconPieChart_Click);

			this.IsFirstPage = true;
		}

		#endregion
	}
}
