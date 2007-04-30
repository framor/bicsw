using System;

namespace SqlBuilder.Model
{
	/// <summary>
	/// Summary description for ReportItem.
	/// </summary>
	public abstract class ReportItem
	{		
		#region Constructor

		protected ReportItem(String nombre ,String alias, Tabla tabla, bool mostrable)
		{
			this.nombre = nombre;
			this.alias = alias;
			this.tabla = tabla;
			this.mostrable = mostrable;
		}

		
		#endregion		

		#region Miembros privados

		private String alias;
		private String nombre;
		private Tabla tabla;
		private bool mostrable;

		#endregion

		#region	Propiedades

		public String Nombre
		{
			get
			{
				return this.nombre;
			}
		}

		public String Alias
		{
			get
			{
				return this.alias;
			}
		}

		public Tabla Tabla
		{
			get
			{
				return this.tabla;
			}
		}

		public virtual bool EsMostrable
		{
			get
			{
				return this.mostrable;
			}
		}

		#endregion
	}
}
