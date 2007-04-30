using System;
using System.Collections;
using System.Text;

namespace SqlBuilder.Model
{
	/// <summary>
	/// Modela una tabla genérica.
	/// </summary>
	public abstract class Tabla
	{
		#region	Constructor

		protected Tabla(String nombre, ArrayList relaciones)
		{
			this.relaciones = relaciones;
			this.nombre = nombre;
		}

		
		#endregion		

		#region	Atributos privados

		private String nombre;
		private ArrayList relaciones = null;

		#endregion

		#region	Propiedades

		public String Nombre
		{
			get
			{
				return this.nombre;
			}
		}

		public ArrayList Relaciones
		{
			get
			{
				return this.relaciones;
			}
		}

		public abstract bool IsFact
		{
			get;
		}
		
		#endregion					
	}
}
