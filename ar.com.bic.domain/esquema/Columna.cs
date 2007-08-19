namespace ar.com.bic.domain.esquema
{
	/// <summary>
	/// Una columna es una representación de una columna de la BD. 
	/// Tiene un nombre, un tipo y la referencia a la tabla q pertence. 
	/// </summary>
	public class Columna
	{
		private string nombre;
		private string tipo;
		private Tabla tabla;

		public Columna(string nombre, string tipo, Tabla tabla)
		{
			this.nombre = nombre;
			this.tipo = tipo;
			this.tabla = tabla;
		}

		public string Nombre
		{
			get {return this.nombre; }
		}

		public string Tipo
		{
			get {return this.tipo; }
		}

		public Tabla Tabla
		{
			get {return this.tabla; }
		}
	}
}
