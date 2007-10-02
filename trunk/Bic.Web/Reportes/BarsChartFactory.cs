using System;
using WebChart;
using System.Data;

namespace Bic.Web
{
	public class BarsChartFactory: ChartAbstractFactory
	{
		#region Constructor

		public BarsChartFactory()
		{			
		}

		#endregion

		#region Protected methods

		public override Chart CreateChart()
		{
			return new ColumnChart();
		}

		protected override void CustomChart(Chart chart)
		{
			base.CustomChart (chart);
			chart.Engine.RenderHorizontally = true;
		}

		protected override void CustomPreviewChart(Chart chart)
		{
			base.CustomPreviewChart (chart);
			chart.Engine.RenderHorizontally = true;
		}



		#endregion


	}
}
