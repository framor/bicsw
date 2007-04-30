using System;
using System.Collections;

namespace SqlBuilder.Model
{
	/// <summary>
	/// Modela una tabla look up.
	/// </summary>
	public class LookUpTable : Tabla
	{
		#region Constructor

		public LookUpTable( String nombre, ArrayList relaciones )
			: base(nombre,relaciones)
		{}

		#endregion		

		#region Propiedades

		public override bool IsFact
		{
			get
			{
				return false;
			}
		}


		#endregion
	}
}
