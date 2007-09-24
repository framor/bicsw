using System;
using System.Data;
using System.Drawing;
using System.Collections;
using WebChart;
using WebChart.Design;

namespace Bic.Web
{
	/// <summary>
	/// Summary description for BarChartHelper.
	/// </summary>
	public class BarChartHelper : ChartHelper
	{
		public BarChartHelper()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public override WebChart.Chart GetChart(String dataColumn, String descriptionColumn, DataSet reportCache)
		{
			ColumnChart chart = new ColumnChart();
			chart.Fill.Color = Color.FromArgb(50, Color.Red);
			chart.Shadow.Visible = true;
			chart.Legend = "Pri 0";

			chart.DataLabels.Visible=true;
			chart.MaxColumnWidth = 40;
			chart.Fill.Color=System.Drawing.Color.Red;
 			
			try 
			{
				foreach(DataRow dataRow in reportCache.Tables[0].Rows)
				{
					//ElementType element = (ElementType)enumerator.Current;
					
					chart.Data.Add(new ChartPoint(dataRow[descriptionColumn].ToString(), int.Parse( dataRow[dataColumn].ToString() ))); ;
				}
			}
			catch(ArgumentNullException)
			{
				throw new ChartNotGeneratedException("Celda nula.");
			}
			catch(System.ArgumentException)
			{
				throw new ChartNotGeneratedException("Formato de dato inválido");
			}
			catch(System.FormatException)
			{
				throw new ChartNotGeneratedException("Formato de dato inválido");
			}
			catch(System.OverflowException)
			{
				throw new ChartNotGeneratedException("Tamaño de dato inválido");
			}


			//TODO : Ver el tema de los labels en los charts ( podria ser un campo obligatorio )
			

			return chart;
		}

	}
}
