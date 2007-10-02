using System;
using WebChart;
using System.Data;

namespace Bic.Web
{
	public class AreaChartFactory: ChartAbstractFactory
	{
		#region Constructor

		public AreaChartFactory()
		{			
		}


		#endregion

		#region Protected methods

		public override Chart CreateChart()
		{
			return new AreaChart();
		}

		#endregion
	}
}
