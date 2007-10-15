using System;
using System.Data;
using WebChart;
using Bic.Application;

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

		public virtual Chart GetChart(ReportManager reportManager, ChartEngine chartEngine,DataSourceItem dataSourceItem)
		{
			Chart chart = this.CreateChart();

			chart.Engine = chartEngine;
			chart.DataSource = this.GetDataSet(reportManager,dataSourceItem).Tables[0].DefaultView;
			chart.DataXValueField = dataSourceItem.DescriptionField;
			chart.DataYValueField = dataSourceItem.DataField; 
			chart.Legend = dataSourceItem.Name; 
			chart.Fill.Color = reportManager.GetChartColor();
			chart.DataLabels.Visible = false;
			chart.DataLabels.ForeColor = System.Drawing.Color.Blue;
			chart.Shadow.Visible = true;

			this.CustomChart(chart);

			chart.DataBind();
		
			return chart;
		}


		public virtual Chart GetPreviewChart(ReportManager reportManager, ChartEngine chartEngine,DataSourceItem dataSourceItem)
		{
			Chart chart = this.CreateChart();

			chart.Engine = chartEngine;
			chart.DataSource = this.GetDataSet(reportManager,dataSourceItem).Tables[0].DefaultView;
			chart.DataXValueField = dataSourceItem.DescriptionField;
			chart.DataYValueField = dataSourceItem.DataField; 
			chart.Legend = dataSourceItem.Name; 
			chart.Fill.Color = reportManager.GetChartColor();
			chart.LineMarker = new SquareLineMarker(6, chart.Fill.Color, chart.Line.Color);
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

		protected virtual DataSet GetDataSet(ReportManager reportManager,DataSourceItem dataSourceItem) 
		{
			DataSet dsSource = reportManager.ReportSourceCache; 
			DataSet ds = new DataSet();
			DataTable table = ds.Tables.Add("My Table");
			table.Columns.Add(new DataColumn(dataSourceItem.DescriptionField));
			table.Columns.Add(new DataColumn(dataSourceItem.DataField, dsSource.Tables[0].Columns[dataSourceItem.DataField].DataType ));


			if(reportManager.GraphFilter == ReportManager.GraphFilters.Top.ToString() )
			{
				int maxRows = dsSource.Tables[0].Rows.Count>100?100:dsSource.Tables[0].Rows.Count; 

				for (int i = 0; i < maxRows; i++) 
				{
					DataRow row = table.NewRow();
					row[dataSourceItem.DescriptionField] = dsSource.Tables[0].Rows[i][dataSourceItem.DescriptionField].ToString();
					row[dataSourceItem.DataField] = dsSource.Tables[0].Rows[i][dataSourceItem.DataField];
					table.Rows.Add(row);
				}
			}
			else if(reportManager.GraphFilter == ReportManager.GraphFilters.Bottom.ToString() )
			{
				int startRow = dsSource.Tables[0].Rows.Count>100?dsSource.Tables[0].Rows.Count-100:0; 

				for (int i = startRow; i < dsSource.Tables[0].Rows.Count; i++) 
				{
					DataRow row = table.NewRow();
					row[dataSourceItem.DescriptionField] = dsSource.Tables[0].Rows[i][dataSourceItem.DescriptionField].ToString();
					row[dataSourceItem.DataField] = dsSource.Tables[0].Rows[i][dataSourceItem.DataField];
					table.Rows.Add(row);
				}
			}
			else if(reportManager.GraphFilter == ReportManager.GraphFilters.All.ToString() )
			{
				for (int i = 0; i < dsSource.Tables[0].Rows.Count; i++) 
				{
					DataRow row = table.NewRow();
					row[dataSourceItem.DescriptionField] = dsSource.Tables[0].Rows[i][dataSourceItem.DescriptionField].ToString();
					row[dataSourceItem.DataField] = dsSource.Tables[0].Rows[i][dataSourceItem.DataField];
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
