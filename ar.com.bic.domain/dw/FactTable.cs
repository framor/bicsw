using System;
using System.Collections;

namespace SqlBuilder.Model
{
	/// <summary>
	/// Modela una tabla de hechos.
	/// </summary>
	public class FactTable : Tabla
	{
		#region	Constructor

		public FactTable(String nombre, ArrayList relaciones, ArrayList hechos)
			: base (nombre,relaciones)
		{
			this.hechos = hechos;
		}

		#endregion			

		#region	Miembros privados

		private ArrayList hechos = null;

		#endregion

		#region Propiedades

		public ArrayList Hechos
		{
			get
			{
				return this.hechos;
			}
		}

		public override bool IsFact
		{
			get
			{
				return true;
			}
		}

		#endregion

		#region Métodos públicos

		public bool ContainsAllFacts(ArrayList hechosElegidos)
		{
			bool flag = true;

			foreach ( Hecho hecho in hechosElegidos )
			{
				if (! this.hechos.Contains(hecho))
				{
					flag = false;
					break;
				}
			}

			return flag;
		}

		#endregion
	}
}
