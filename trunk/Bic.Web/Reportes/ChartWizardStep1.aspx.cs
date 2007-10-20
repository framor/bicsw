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

		protected System.Web.UI.WebControls.Panel pnlBars;
		protected System.Web.UI.WebControls.Panel pnlColumns;
		protected System.Web.UI.WebControls.Panel pnlArea;
		protected System.Web.UI.WebControls.Panel pnlPie;
		protected System.Web.UI.WebControls.Panel pnlLines;

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

			this.imgBtnIconAreaChart.ImageUrl = this.GetImageURL(ReportManager.GraphTypes.Area);
			this.imgBtnIconBarsChart.ImageUrl = this.GetImageURL(ReportManager.GraphTypes.Bars);
			this.imgBtnIconColumnsChart.ImageUrl = this.GetImageURL(ReportManager.GraphTypes.Columns);
			this.imgBtnIconLinesChart.ImageUrl = this.GetImageURL(ReportManager.GraphTypes.Lines);
			this.imgBtnIconPieChart.ImageUrl = this.GetImageURL(ReportManager.GraphTypes.Pie);

			this.btnNext.Enabled = ReportManager.GetInstance(this.Session).ChartTypesSelectedManager.GetSelectedCharts().Count !=0;
		
		}


		private string GetImageURL(ReportManager.GraphTypes graphType)
		{
			if(ReportManager.GetInstance(this.Session).ChartTypesSelectedManager.IsSelectedGraphType(graphType))
			{
				return this.GetSelectedImage(graphType);
			}
			else if (ReportManager.GetInstance(this.Session).ChartTypesSelectedManager.IsCompatibleGraphType(graphType))
			{
				return this.GetEnabledImage(graphType);
			}
			else
			{
				return this.GetDisabledImage(graphType);
			}
		}
		

		private string GetSelectedImage (ReportManager.GraphTypes graphType)
		{
			switch(graphType)
			{
				case ReportManager.GraphTypes.Area:
					this.pnlArea.Enabled = true;					
					return "../img/iconAreaChartSelected.PNG";
				case ReportManager.GraphTypes.Bars:
					this.pnlBars.Enabled = true;
					return "../img/iconBarsChartSelected.PNG";
				case ReportManager.GraphTypes.Columns:
					this.pnlColumns.Enabled = true;
					return "../img/iconColumnsChartSelected.PNG";
				case ReportManager.GraphTypes.Lines:
					this.pnlLines.Enabled = true;
					return "../img/iconLinesChartSelected.PNG";
				case ReportManager.GraphTypes.Pie:
					this.pnlPie.Enabled = true;
					return "../img/iconPieChartSelected.PNG";
				default:
					return string.Empty;
			}
		}


		private string GetEnabledImage (ReportManager.GraphTypes graphType)
		{
			switch(graphType)
			{
				case ReportManager.GraphTypes.Area:
					this.pnlArea.Enabled = true;
					return "../img/iconAreaChart.PNG";
				case ReportManager.GraphTypes.Bars:
					this.pnlBars.Enabled = true;
					return "../img/iconBarsChart.PNG";
				case ReportManager.GraphTypes.Columns:
					this.pnlColumns.Enabled = true;
					return "../img/iconColumnsChart.PNG";
				case ReportManager.GraphTypes.Lines:
					this.pnlLines.Enabled = true;
					return "../img/iconLinesChart.PNG";
				case ReportManager.GraphTypes.Pie:
					this.pnlPie.Enabled = true;
					return "../img/iconPieChart.PNG";
				default:
					return string.Empty;
			}
		}


		private string GetDisabledImage (ReportManager.GraphTypes graphType)
		{
			switch(graphType)
			{
				case ReportManager.GraphTypes.Area:
					this.pnlArea.Enabled = false;
					return "../img/iconAreaChartDisabled.PNG";
				case ReportManager.GraphTypes.Bars:
					this.pnlBars.Enabled = false;
					return "../img/iconBarsChartDisabled.PNG";
				case ReportManager.GraphTypes.Columns:
					this.pnlColumns.Enabled = false;
					return "../img/iconColumnsChartDisabled.PNG";
				case ReportManager.GraphTypes.Lines:
					this.pnlLines.Enabled = false;
					return "../img/iconLinesChartDisabled.PNG";
				case ReportManager.GraphTypes.Pie:
					this.pnlPie.Enabled = false;
					return "../img/iconPieChartDisabled.PNG";
				default:
					return string.Empty;
			}
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
		

		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

			this.imgBtnIconAreaChart.Click+=new ImageClickEventHandler(imgBtnIconAreaChart_Click);
			this.imgBtnIconBarsChart.Click+=new ImageClickEventHandler(imgBtnIconBarsChart_Click);
			this.imgBtnIconColumnsChart.Click+=new ImageClickEventHandler(imgBtnIconColumnsChart_Click);
			this.imgBtnIconLinesChart.Click+=new ImageClickEventHandler(imgBtnIconLinesChart_Click);
			this.imgBtnIconPieChart.Click +=new ImageClickEventHandler(imgBtnIconPieChart_Click);

			this.pnlArea.Controls.Add(this.imgBtnIconAreaChart);
			this.pnlBars.Controls.Add(this.imgBtnIconBarsChart);
			this.pnlColumns.Controls.Add(this.imgBtnIconColumnsChart);
			this.pnlLines.Controls.Add(this.imgBtnIconLinesChart);
			this.pnlPie.Controls.Add(this.imgBtnIconPieChart);


			this.IsFirstPage = true;
		}


		#endregion
	}
}
