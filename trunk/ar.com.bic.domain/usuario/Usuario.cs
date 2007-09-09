using System;

namespace ar.com.bic.domain.usuario
{
	/// <summary>
	/// Un usuario del sistema.
	/// </summary>
	public class Usuario
	{
		private long id;
		private String nombre;
		private String clave;
		private String eMail;
		private Rol rol;

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

		public virtual Rol Rol
		{
			get
			{
				// TODO: arreglar mapeo
				return Arquitecto.Instance;
			}
			set { this.rol = value; }
		}

		public virtual String EMail
		{
			get { return this.eMail; }
			set { this.eMail = value; }
		}

		public virtual String NombreRol
		{
			get { return this.Rol.Nombre; }
		}

		public Usuario()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
	}
}
