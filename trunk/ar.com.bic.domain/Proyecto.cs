using System.Collections;
using ar.com.bic.domain.catalogo;

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
		private string nombreBD;
		private string usuario;
		private string password;

		public Proyecto()
		{
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

		public string NombreBD
		{
			get { return nombreBD; }
			set { nombreBD = value; }
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
