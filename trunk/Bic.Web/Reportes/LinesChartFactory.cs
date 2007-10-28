using System;
using WebChart;
using System.Data;
using System.Drawing;

namespace Bic.Web
{
	public class LinesChartFactory: ChartAbstractFactory
	{
		#region Constructor

		public LinesChartFactory()
		{			
		}

		#endregion

		#region Protected methods

		public override Chart CreateChart()
		{
			return new LineChart();			
		}

		protected override void CustomChart(Chart chart, ReportManager reportManager)
		{
			base.CustomChart(chart);

			chart.LineMarker = new XLineMarker(10, Color.Black, Color.LightGray);			
			chart.Line.Color = chart.Fill.Color;
		}


		#endregion


	}
}
