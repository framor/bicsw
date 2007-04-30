using System;

namespace SqlBuilder.Model
{
	/// <summary>
	/// Modela una relación entre atributos de diferentes tablas.
	/// </summary>
	public class Relacion
	{
		#region Constructor

		public Relacion(Atributo atributo1, Atributo atributo2)
		{
			this.atributo1 = atributo1;
			this.atributo2 = atributo2;
		}

		#endregion

		#region Atributos privados

		private Atributo atributo1 = null;
		private Atributo atributo2 = null;

		#endregion

		#region Propiedades

		public Atributo Atributo1
		{
			get
			{
				return this.atributo1;
			}
		}

		public Atributo Atributo2
		{
			get
			{
				return this.atributo2;
			}
		}

		#endregion

		#region Métodos públicos

		public Tabla GetTablaDestino(Tabla tablaOrigen)
		{
			if ( this.atributo1.Tabla.Equals(tablaOrigen))
			{
				return this.atributo2.Tabla;
			}
			else
			{
				return this.atributo1.Tabla;
			}
		}

		#endregion
	}
}
