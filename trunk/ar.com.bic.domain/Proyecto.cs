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

		private IList campos = new ArrayList();
		private IList tablas = new ArrayList();

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

		/// <summary>
		/// Campos existentes en el proyecto
		/// </summary>
		public IList Campos
		{
			get {return new ArrayList(this.campos); }
		}
		/// <summary>
		/// Las Tablas que se agregaron al proyecto (en la BD pueden existir más)
		/// </summary>
		public IList Tablas
		{
			get {return new ArrayList(this.tablas); }
		}

		public void AgregarTabla(Tabla tbl)
		{
			tbl.Proyecto = this;
			this.tablas.Add(tbl);
			foreach (Columna col in tbl.Columnas)
			{
				NotificarColumna(col);
			}
		}

		/// <summary>
		/// Informa al catálogo que se agregó una columna al mismo de forma
		/// de ir extrayendo los campos
		/// </summary>
		/// <param name="col"></param>
		private void NotificarColumna(Columna col)
		{
			foreach (Campo campo in this.campos)
			{
				if (campo.Nombre.Equals(col.Nombre))
				{
					return;
				}
			}
			// si no existe, lo creo y lo agrego al catalogo
			Campo nuevoCampo = new Campo(col);
			this.campos.Add(nuevoCampo);	
		}

	}
}
