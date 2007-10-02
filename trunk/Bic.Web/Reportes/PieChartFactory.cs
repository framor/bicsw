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

		#endregion
	}
}
