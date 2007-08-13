using System;
using System.Collections;
using ar.com.bic.domain.interfaces;
using ar.com.bic.domain.esquema;

namespace ar.com.bic.domain
{
	/// <summary>
	/// Descripción breve de Hecho.
	/// </summary>
	public class Hecho : ITablaMapeable
	{
		
		private string nombre;
		private Columna ColumnaHecho;

		public Hecho(string nombre, Columna columna)
		{
			this.nombre = nombre;
			this.ColumnaHecho = columna;
		}

		#region Metodos Publicos
			
		public ArrayList GetTablas()
		{
			return this.ColumnaHecho.Tablas;
		}

		public Columna GetColumna()
		{
			return this.ColumnaHecho;
		}

		#endregion

	}
}
