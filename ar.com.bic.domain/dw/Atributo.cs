using System;

namespace SqlBuilder.Model
{
	/// <summary>
	/// Modela una columna de una tabla.
	/// </summary>
	public class Atributo : ReportItem 
	{
		#region Construnctor

		public Atributo(String nombre,String alias, Tabla tabla, bool mostrable)
			:base(nombre,alias,tabla,mostrable){}

		#endregion
	}
}
