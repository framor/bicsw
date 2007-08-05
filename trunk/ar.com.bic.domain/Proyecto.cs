namespace ar.com.bic.domain
{
	/// <summary>
	/// Descripción breve de Proyecto.
	/// </summary>
	public class Proyecto
	{
		private long id;
		private string nombre;
		private string descripcion;

		/* Conexion a BD */
		private string servidor;
		private int puerto;
		private string esquema;
		private string usuario;
		private string password;

		public Proyecto()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		public long Id 
		{
			get { return this.id; }
			set { this.id = value; }
		}

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		public string Descripcion
		{
			get { return descripcion; }
			set { descripcion = value; }
		}

		public string Servidor
		{
			get { return servidor; }
			set { servidor = value; }
		}

		public int Puerto
		{
			get { return puerto; }
			set { puerto = value; }
		}

		public string Esquema
		{
			get { return esquema; }
			set { esquema = value; }
		}

		public string Usuario
		{
			get { return usuario; }
			set { usuario = value; }
		}

		public string Password
		{
			get { return password; }
			set { password = value; }
		}
	}
}
