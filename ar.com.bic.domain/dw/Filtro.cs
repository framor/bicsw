using System;

namespace SqlBuilder.Model
{
	/// <summary>
	/// Modela un filtro a aplicar sobre una consulta SQL.
	/// </summary>
	public class Filtro
	{
		#region Constructor

		public Filtro(ReportItem item, String valor, String operador)
		{
			this.reportItem = item;
			this.valor = valor;
			this.operador = operador;
		}

		#endregion
		
		#region Miembros privados

		private ReportItem reportItem;
		private String valor;
		private String operador;

		#endregion

		#region Propiedades públicas

		public ReportItem ReportItem
		{
			get
			{
				return this.reportItem;
			}
		}

		public String Valor
		{
			get
			{
				return this.valor;
			}
		}

		public String Operador
		{
			get
			{
				return this.operador;
			}
		}

		#endregion
	}
}
