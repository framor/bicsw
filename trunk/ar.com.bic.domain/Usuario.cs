using System;

namespace ar.com.bic.domain
{
	/// <summary>
	/// Un usuario del sistema.
	/// </summary>
	public class Usuario
	{
		private long id;
		private String nombre;
		private String clave;

		public virtual long Id 
		{
			get { return this.id; }
			set { this.id = value; }
		}

		public virtual String Nombre 
		{
			get { return this.nombre; }
			set { this.nombre = value; }
		}

		public virtual String Clave
		{
			get { return this.clave; }
			set { this.clave = value; }
		}

		public Usuario()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
	}
}
