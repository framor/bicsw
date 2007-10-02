using System;
using System.Data;
using WebChart;

namespace Bic.Web
{
	public abstract class ChartAbstractFactory
	{
		#region Constructor

		public ChartAbstractFactory()
		{}

		#endregion

		#region Public methods

		public abstract Chart CreateChart();		

		public virtual Chart GetChart(ReportManager reportManager, ChartEngine chartEngine)
		{
			Chart chart = this.CreateChart();

			chart.Engine = chartEngine;
			chart.DataSource = this.GetDataSet(reportManager).Tables[0].DefaultView;
			chart.DataXValueField = reportManager.DescriptionColumn;
			chart.DataYValueField = reportManager.DataColumn;
			chart.DataLabels.Visible = false;
			chart.DataLabels.ForeColor = System.Drawing.Color.Blue;
			chart.Shadow.Visible = true;

			this.CustomChart(chart);

			chart.DataBind();
		
			return chart;
		}


		public virtual Chart GetPreviewChart(ReportManager reportManager, ChartEngine chartEngine)
		{
			Chart chart = this.CreateChart();

			chart.Engine = chartEngine;
			chart.DataSource = this.GetDataSet(reportManager).Tables[0].DefaultView;
			chart.DataXValueField = reportManager.DescriptionColumn;
			chart.DataYValueField = reportManager.DataColumn;
			chart.DataLabels.Visible = false;
			chart.DataLabels.ForeColor = System.Drawing.Color.Blue;
			chart.Shadow.Visible = true;

			this.CustomPreviewChart(chart);

			chart.DataBind();
		
			return chart;
		}


		public static ChartAbstractFactory GetFactory(ReportManager.GraphTypes graphType)
		{
			switch (graphType)
			{
				case ReportManager.GraphTypes.Area: return new AreaChartFactory();
				case ReportManager.GraphTypes.Bars: return new BarsChartFactory();
				case ReportManager.GraphTypes.Columns: return new ColumnsChartFactory();
				case ReportManager.GraphTypes.Lines : return new LinesChartFactory();
				case ReportManager.GraphTypes.Pie : return new PieChartFactory();
				
				default: return null;
			}
		}

		#endregion 

		#region Protected methods

		protected virtual DataSet GetDataSet(ReportManager reportManager) 
		{
			DataSet ds = new DataSet();
			DataTable table = ds.Tables.Add("My Table");
			table.Columns.Add(new DataColumn(reportManager.DescriptionColumn));
			table.Columns.Add(new DataColumn(reportManager.DataColumn, reportManager.ReportCache.Tables[0].Columns[reportManager.DataColumn].DataType ));

			//TODO : aca se tienen que hacer casteos al tipo correspondiente. Ver si se puede hacer mediante el tipo de dato de la columna.
			// Se tiene que hacer uno por uno ? Demonios.

			if(reportManager.GraphFilter == ReportManager.GraphFilters.Top.ToString() )
			{
				for (int i = 0; i < 100; i++) 
				{
					DataRow row = table.NewRow();
					row[reportManager.DescriptionColumn] = reportManager.ReportCache.Tables[0].Rows[i][reportManager.DescriptionColumn].ToString();
					row[reportManager.DataColumn] = reportManager.ReportCache.Tables[0].Rows[i][reportManager.DataColumn].ToString().Length != 0 ? Int64.Parse( reportManager.ReportCache.Tables[0].Rows[i][reportManager.DataColumn].ToString()):0;
					table.Rows.Add(row);
				}
			}
			else if(reportManager.GraphFilter == ReportManager.GraphFilters.Bottom.ToString() )
			{
				for (int i = reportManager.ReportCache.Tables[0].Rows.Count - 100; i < reportManager.ReportCache.Tables[0].Rows.Count; i++) 
				{
					DataRow row = table.NewRow();
					row[reportManager.DescriptionColumn] = reportManager.ReportCache.Tables[0].Rows[i][reportManager.DescriptionColumn].ToString();
					row[reportManager.DataColumn] = reportManager.ReportCache.Tables[0].Rows[i][reportManager.DataColumn].ToString().Length != 0 ? Int64.Parse( reportManager.ReportCache.Tables[0].Rows[i][reportManager.DataColumn].ToString()):0;
					table.Rows.Add(row);
				}
			}
			else if(reportManager.GraphFilter == ReportManager.GraphFilters.All.ToString() )
			{
				for (int i = 0; i < reportManager.ReportCache.Tables[0].Rows.Count; i++) 
				{
					DataRow row = table.NewRow();
					row[reportManager.DescriptionColumn] = reportManager.ReportCache.Tables[0].Rows[i][reportManager.DescriptionColumn].ToString();
					row[reportManager.DataColumn] = reportManager.ReportCache.Tables[0].Rows[i][reportManager.DataColumn].ToString().Length != 0 ? Int64.Parse( reportManager.ReportCache.Tables[0].Rows[i][reportManager.DataColumn].ToString()):0;
					table.Rows.Add(row);
				}
			}
			
			
			return ds;

		}


		protected virtual void CustomPreviewChart(Chart chart)
		{}


		protected virtual void CustomChart(Chart chart)
		{}


		#endregion
	}
}
