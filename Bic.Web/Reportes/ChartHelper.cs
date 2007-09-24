using System;
using System.Data;
using System.Collections;
using WebChart;

namespace Bic.Web
{
	/// <summary>
	/// Summary description for ChartHelper.
	/// </summary>
	public abstract class ChartHelper
	{
		public ChartHelper()
		{}


		public abstract Chart GetChart(String dataColumn, String descriptionColumn, DataSet reportCache);		
	}
}
