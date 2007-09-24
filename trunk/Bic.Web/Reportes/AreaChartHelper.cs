using System;
using System.Data;
using System.Collections;
using WebChart;

namespace Bic.Web
{
	/// <summary>
	/// Summary description for AreaChatHelper.
	/// </summary>
	public class AreaChartHelper:ChartHelper
	{
		public AreaChartHelper()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public override WebChart.Chart GetChart(String dataColumn, String descriptionColumn, System.Data.DataSet reportCache)
		{
			Chart chart = new AreaChart();
			
			chart.DataSource = GetDataSet(dataColumn,descriptionColumn,reportCache).Tables[0].DefaultView;
			chart.DataXValueField = descriptionColumn;
			chart.DataYValueField = dataColumn;
			chart.DataLabels.Visible = true;
			chart.DataLabels.ForeColor = System.Drawing.Color.Blue;
			chart.Shadow.Visible = true;
			chart.DataBind();
		
			return chart;

		}

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
