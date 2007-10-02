using System;
using WebChart;
using System.Data;

namespace Bic.Web
{
	public class UtilsChartFactory : ChartAbstractFactory
	{
		#region Constructor

		public UtilsChartFactory()
		{}

		#endregion

		#region Public methods

		public override Chart CreateChart()
		{
			//TODO : Hay que crear un grafico vacio.
			return null;
		}


		#endregion
	}
}
