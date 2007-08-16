using System;
using System.Collections;

namespace ar.com.bic.domain.esquema
{
	/// <summary>
	/// Un campo es la unificación de todas las columnas que tienen el 
	/// mismo nombre en la BD. Por ej. en todo el catálogo pueden existir
	/// varias columnas llamadas nombre_id en distintas tablas, sin embargo
	/// solo existira un Campo para nombre_id. Esto permite que se pueda 
	/// obtener el dato de la tabla más conveniente.
	/// </summary>
	public class Campo
	{
		private string nombre;
		private ArrayList columnas = new ArrayList();

		public string Nombre
		{
			get {return this.nombre; }
			set {this.nombre = value;}
		}
		/// <summary>
		/// Columnas que corresponden a este campo
		/// </summary>
		public ArrayList Columnas
		{
			get {return new ArrayList(this.columnas);}
		}
		
		public void AgregarColumnas(Columna col)
		{
			this.columnas.Add(col);
		}


		public Campo(Columna col)
		{
			this.nombre = col.Nombre;
			this.columnas.Add(col);
		}

		public override bool Equals(object obj)
		{
			return this.nombre.Equals(((Campo) obj).Nombre);
		}
		public override int GetHashCode()
		{
			return this.nombre.GetHashCode ();
		}

	}
}
