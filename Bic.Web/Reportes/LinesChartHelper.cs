using System;
using System.Data;
using System.Collections;
using WebChart;

namespace Bic.Web
{
	/// <summary>
	/// Summary description for LinesChartHelper.
	/// </summary>
	public class LinesChartHelper:ChartHelper
	{
		public LinesChartHelper()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public override WebChart.Chart GetChart(String dataColumn, String descriptionColumn, DataSet reportCache)
		{
			LineChart chart = new LineChart();
			chart.DataSource = GetDataSet(dataColumn,descriptionColumn,reportCache).Tables[0].DefaultView;
			chart.DataXValueField = descriptionColumn;
			chart.DataYValueField = dataColumn;
			chart.DataLabels.Visible = true;
			chart.DataLabels.ForeColor = System.Drawing.Color.Blue;
			chart.Shadow.Visible = true;
			chart.DataBind();
			
			
			return chart;
		}

		//TODO : Ver que tan generico es este metodo para subirlo al base.
		DataSet GetDataSet(String dataColumn, String descriptionColumn, DataSet reportCache) 
		{
			DataSet ds = new DataSet();
			DataTable table = ds.Tables.Add("My Table");
			table.Columns.Add(new DataColumn(descriptionColumn));
			table.Columns.Add(new DataColumn(dataColumn, typeof(int)));
 
			Random rnd = new Random();
			for (int i = 0; i < 10; i++) 
			{
				DataRow row = table.NewRow();
				row[descriptionColumn] = reportCache.Tables[0].Rows[i][descriptionColumn].ToString();
				row[dataColumn] = reportCache.Tables[0].Rows[i][dataColumn].ToString();
				table.Rows.Add(row);
			}
			return ds;

		}

	}
}
