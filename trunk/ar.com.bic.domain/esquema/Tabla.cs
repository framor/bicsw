using System;
using System.Collections;
using ar.com.bic.domain.interfaces;

namespace ar.com.bic.domain.esquema
{
	/// <summary>
	/// Descripción breve de Tabla.
	/// </summary>
	public class Tabla
	{
		private string alias;
		private string nombreBD;
		private string nombreTabla;
		private IList columnas = new ArrayList();

		public IList Columnas
		{
			get {return new ArrayList(this.columnas); }
		}
		public string Alias
		{
			get {return this.alias; }
			set {this.alias = value;}
		}

		public Tabla(string alias, string nombreBD, string nombreTabla)
		{
			this.alias = alias;
			this.nombreBD = nombreBD;
			this.nombreTabla = nombreTabla;
		}

		public void AgregarColumna(Columna col)
		{
			this.columnas.Add(col);
		}
		

		public bool Tenes(IList listaColumnas)
		{
			foreach(ITablaMapeable columna in listaColumnas)
			{
				if(!this.Tenes(columna.GetColumna()))
					return false;
			}

			return true;
		}

		public bool Tenes(Columna columna)
		{
			return this.Columnas.Contains(columna);
		}

	}
}
