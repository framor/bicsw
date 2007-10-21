using System;
using WebChart;
using System.Data;

namespace Bic.Web
{
	public class PieChartFactory: ChartAbstractFactory
	{
		#region Constructor

		public PieChartFactory()
		{			
		}

		#endregion

		#region Protected methods

		public override Chart CreateChart()
		{
			return new PieChart();
		}

		protected override void CustomChart(Chart chart)
		{
			base.CustomChart (chart);
			chart.Engine.Legend.Position = LegendPosition.Right;
			chart.Engine.Legend.Background.Type = WebChart.InteriorType.Hatch;
			chart.Engine.Legend.Background.StartPoint = new System.Drawing.Point(0,0);
			chart.Engine.Legend.Background.EndPoint  = new System.Drawing.Point(100,100);
			chart.Engine.Legend.Width = 100;
		}

		protected override void CustomChart(Chart chart,ReportManager reportManager)
		{
			base.CustomChart(chart);
			chart.Engine.Legend.Position = LegendPosition.Right;
			chart.Engine.Legend.Background.Type = WebChart.InteriorType.Hatch;
			chart.Engine.Legend.Background.StartPoint = new System.Drawing.Point(0,0);
			chart.Engine.Legend.Background.EndPoint  = new System.Drawing.Point(100,100);
			chart.Engine.Legend.Width = 100;
		}

		#endregion
	}
}
