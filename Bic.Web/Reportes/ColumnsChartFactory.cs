using System;
using System.Data;
using WebChart;

namespace Bic.Web
{
	public class ColumnsChartFactory: ChartAbstractFactory
	{
		#region Constructor

		public ColumnsChartFactory()
		{			
		}

		#endregion

		#region Protected methods

		public override Chart CreateChart()
		{
			return new ColumnChart();
		}

		#endregion


	}
}
