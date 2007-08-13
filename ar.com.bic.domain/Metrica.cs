using System;
using System.Collections;
using ar.com.bic.domain.interfaces;
using ar.com.bic.domain.esquema;

namespace ar.com.bic.domain
{
	/// <summary>
	/// Descripción breve de Metrica.
	/// </summary>
	public class Metrica : ITablaMapeable
	{

		#region Miembros privados
		
		private string nombre;
		private string funcion;
		private Hecho hecho;
			
		#endregion

		public Metrica(string nombre, string funcion, Hecho hecho)
		{
			this.nombre = nombre;
			this.funcion = funcion;
			this.hecho = hecho;
		}

		#region Metodos Publicos
			
		public ArrayList GetTablas()
		{
			return this.hecho.GetTablas();
		}
		
		public Columna GetColumna()
		{
			return this.hecho.GetColumna();
		}
		#endregion

	}
}
