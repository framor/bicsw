using System;

namespace Bic.Domain.Usuario
{
	/// <summary>
	/// Descripción breve de Rol.
	/// </summary>
	public abstract class Rol
	{
		public const string ID_ADMINISTRADOR = "D";
		public const string ID_ARQUITECTO = "A";
		public const string ID_REPORTERO = "R";

		public static Rol ObtenerRol(string idRol)
		{
			switch (idRol)
			{
				case Rol.ID_ADMINISTRADOR : { return Administrador.Instance;}
				case Rol.ID_ARQUITECTO : { return Arquitecto.Instance; }
				case Rol.ID_REPORTERO : { return Reportero.Instance; }
			}			
			throw new InvalidOperationException("No se puede obtener el rol para el id " + idRol);
		}

		public string Id
		{
			get {return this.GetId(); }
		}
		protected abstract string GetId();

		public string Nombre
		{
			get { return this.GetNombre(); }
		}
		protected abstract string GetNombre();

		public virtual bool EsAdministrador()
		{
			return false;
		}

		public virtual bool PuedeAccederAUsuarios()
		{
			return false;
		}

		public virtual bool PuedeAccederAProyectos()
		{
			return false;
		}

		public virtual bool PuedeEditarProyectos()
		{
			return false;
		}

		public virtual bool PuedeAccederAAtributos()
		{
			return false;
		}

		public virtual bool PuedeAccederATablas()
		{
			return false;
		}

		public virtual bool PuedeAccederAHechos()
		{
			return false;
		}

		public virtual bool PuedeAccederAMetricas()
		{
			return false;
		}

		public virtual bool PuedeAccederAFiltros()
		{
			return false;
		}

		public virtual bool PuedeAccederAReportes()
		{
			return true;
		}

	}
}
