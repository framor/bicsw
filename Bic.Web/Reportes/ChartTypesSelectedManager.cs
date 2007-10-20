using System;
using System.Text;
using System.Collections;
using WebChart;

namespace Bic.Web
{
	/// <summary>
	/// Clase que tiene la responsabilidad de mantener de manera consistente
	/// el conjunto de graficos seleccionados que se graficaran postariormente,
	/// de acuerdo a su compatibilidad.
	/// </summary>
	public class ChartTypesSelectedManager
	{
		#region Constructor

		public ChartTypesSelectedManager()
		{
			this.selectedCharts = new Hashtable();
		}


		#endregion

		#region Private members

		private Hashtable selectedCharts;

		#endregion

		#region Public methods

		public void Add(ReportManager.GraphTypes graphType, ChartAbstractFactory chartAbstractFactory)
		{
			if(! this.selectedCharts.ContainsKey(graphType.ToString()))
			{
				this.selectedCharts.Add(graphType.ToString(),chartAbstractFactory);
			}
			else
			{
				this.selectedCharts.Remove (graphType.ToString());
			}

			this.UpdateChartCompatibility();
		}


		public ICollection GetSelectedCharts()
		{
			return this.selectedCharts.Values;
		}


		public string GetSelectedChartsStringDescription()
		{
			StringBuilder sb = new StringBuilder();
			
			foreach (Object key in this.selectedCharts.Keys)
			{
				string graphName = String.Empty;

				ReportManager.GraphTypes  graphType = (ReportManager.GraphTypes) Enum.Parse(typeof(ReportManager.GraphTypes), key.ToString());

				switch(graphType)
				{
					case ReportManager.GraphTypes.Area:
							graphName = "Area";
							break;
					case ReportManager.GraphTypes.Bars:
							graphName = "Barras";
							break;
					case ReportManager.GraphTypes.Columns:
							graphName = "Columnas";
							break;
					case ReportManager.GraphTypes.Lines:
							graphName = "Lineas";
							break;
					case ReportManager.GraphTypes.Pie:
							graphName = "Torta";
							break;
					default:
							break;
							
				}

				sb.Append (graphName + " - ");
			}

			if(sb.Length != 0)
			{
				sb.Remove(sb.Length-2,1);
			}

			return sb.ToString().Trim();
		}


		public void Clear()
		{
			this.selectedCharts.Clear();
		}


		public bool IsSelectedGraphType(ReportManager.GraphTypes graphType)
		{
			return this.selectedCharts.ContainsKey(graphType.ToString());
		}

		public bool IsCompatibleGraphType(ReportManager.GraphTypes graphType)
		{
			bool isCompatible = true;

			foreach(string key in this.selectedCharts.Keys)
			{
				if (!this.CompatibleCharts(key,graphType.ToString()))
				{
					isCompatible = false;
					break;
				}
			}

			return isCompatible;
		}

		#endregion

		#region Private methods

		private bool CompatibleCharts(string chatTypeA,string chatTypeB)
		{
			if(chatTypeA.Equals(ReportManager.GraphTypes.Area.ToString()))
			{
				if(chatTypeB.Equals(ReportManager.GraphTypes.Bars.ToString()))
				{
					return true;
				}
				else if (chatTypeB.Equals(ReportManager.GraphTypes.Columns.ToString()))
				{
					return true;
				}
				else if (chatTypeB.Equals(ReportManager.GraphTypes.Lines.ToString()))
				{
					return true;
				}
				else if (chatTypeB.Equals(ReportManager.GraphTypes.Pie.ToString()))
				{
					return false;
				}

				return false;
			}
			else if (chatTypeA.Equals(ReportManager.GraphTypes.Bars.ToString()))
			{
				if(chatTypeB.Equals(ReportManager.GraphTypes.Area.ToString()))
				{
					return true;
				}
				else if (chatTypeB.Equals(ReportManager.GraphTypes.Columns.ToString()))
				{
					return false;
				}
				else if (chatTypeB.Equals(ReportManager.GraphTypes.Lines.ToString()))
				{
					return true;
				}
				else if (chatTypeB.Equals(ReportManager.GraphTypes.Pie.ToString()))
				{
					return false;
				}

				return false;
			}
			else if(chatTypeA.Equals(ReportManager.GraphTypes.Columns.ToString()))
			{
				if(chatTypeB.Equals(ReportManager.GraphTypes.Bars.ToString()))
				{
					return false;
				}
				else if (chatTypeB.Equals(ReportManager.GraphTypes.Area.ToString()))
				{
					return true;
				}
				else if (chatTypeB.Equals(ReportManager.GraphTypes.Lines.ToString()))
				{
					return true;
				}
				else if (chatTypeB.Equals(ReportManager.GraphTypes.Pie.ToString()))
				{
					return false;
				}

				return false;
			}
			else if(chatTypeA.Equals(ReportManager.GraphTypes.Lines.ToString()))
			{
				if(chatTypeB.Equals(ReportManager.GraphTypes.Bars.ToString()))
				{
					return true;
				}
				else if (chatTypeB.Equals(ReportManager.GraphTypes.Area.ToString()))
				{
					return true;
				}
				else if (chatTypeB.Equals(ReportManager.GraphTypes.Columns.ToString()))
				{
					return true;
				}
				else if (chatTypeB.Equals(ReportManager.GraphTypes.Pie.ToString()))
				{
					return false;
				}

				return false;
			}
			else if(chatTypeA.Equals(ReportManager.GraphTypes.Pie.ToString()))
			{
				if(chatTypeB.Equals(ReportManager.GraphTypes.Bars.ToString()))
				{
					return false;
				}
				else if (chatTypeB.Equals(ReportManager.GraphTypes.Area.ToString()))
				{
					return false;
				}
				else if (chatTypeB.Equals(ReportManager.GraphTypes.Columns.ToString()))
				{
					return false;
				}
				else if (chatTypeB.Equals(ReportManager.GraphTypes.Lines.ToString()))
				{
					return false;
				}

				return false;
			}

			return false;
		}

		private void UpdateChartCompatibility()
		{
			if(this.selectedCharts[ReportManager.GraphTypes.Pie.ToString()] != null && this.selectedCharts.Keys.Count != 1)
			{
				this.selectedCharts.Remove(ReportManager.GraphTypes.Pie.ToString());
			}

			if(this.selectedCharts[ReportManager.GraphTypes.Bars.ToString()] != null && this.selectedCharts.Keys.Count != 1)
			{
				if(this.selectedCharts[ReportManager.GraphTypes.Columns.ToString()] != null)
				{
					this.selectedCharts.Remove(ReportManager.GraphTypes.Columns.ToString());
				}				

				if(this.selectedCharts[ReportManager.GraphTypes.Pie.ToString()] != null)
				{
					this.selectedCharts.Remove(ReportManager.GraphTypes.Pie.ToString());
				}
			}
		}


		#endregion
	}
}
