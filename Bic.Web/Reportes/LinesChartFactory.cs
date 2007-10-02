using System;
using WebChart;
using System.Data;

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

		#endregion


	}
}
