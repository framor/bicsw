using System;

namespace SqlBuilder.Model
{
	/// <summary>
	/// Modela un hecho. Definir si formara parte del modelo o no.
	/// </summary>
	public class Hecho: ReportItem
	{
		#region Constructor

		public Hecho(String nombre, String alias, Tabla tabla)
			:base(nombre,alias,tabla,true){}

		#endregion		

		#region Propiedades

		public override bool EsMostrable
		{
			get
			{
				return true;
			}
		}

		#endregion		
	}
}
