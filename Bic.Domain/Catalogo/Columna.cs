namespace Bic.Domain.Catalogo
{
	/// <summary>
	/// Una columna es una representación de una columna de la BD. 
	/// Tiene un nombre, un tipo. 
	/// </summary>
	public class Columna
	{
		private long id;
		private string nombre;
		private string tipo;

		private Columna() {}

		public Columna(string nombre, string tipo)
		{
			this.nombre = nombre;
			this.tipo = tipo;
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

	}
}
