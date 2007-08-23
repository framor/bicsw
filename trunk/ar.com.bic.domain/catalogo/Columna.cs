namespace ar.com.bic.domain.catalogo
{
	/// <summary>
	/// Una columna es una representación de una columna de la BD. 
	/// Tiene un nombre, un tipo y la referencia a la tabla q pertence. 
	/// </summary>
	public class Columna
	{
		private long id;
		private string nombre;
		private string tipo;
		private Tabla tabla;

		private Columna() {}

		public Columna(string nombre, string tipo, Tabla tabla)
		{
			this.nombre = nombre;
			this.tipo = tipo;
			this.tabla = tabla;
		}

		public long Id 
		{
			get { return this.id; }
			set { this.id = value; }
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
