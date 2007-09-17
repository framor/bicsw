using System;
using System.Collections;
using ar.com.bic.dao;
using ar.com.bic.domain;
using ar.com.bic.domain.catalogo;

namespace ar.com.bic.application.impl
{
	/// <summary>
	/// Implementación de CatalogoService
	/// </summary>
	public class CatalogoServiceImpl : BaseService , CatalogoService
	{

		private MySQLDAO mySQLDAO;
		public MySQLDAO MySQLDAO 
		{
			get { return this.mySQLDAO; }
			set { this.mySQLDAO = value; }
		}

		private ProyectoDAO proyectoDAO;
		public ProyectoDAO ProyectoDAO 
		{
			get { return this.proyectoDAO; }
			set { this.proyectoDAO = value; }
		}

		public CatalogoServiceImpl() {}

		/// <summary>
		/// Implementacion de CatalogoServiceImpl.SelectTablasDisponibles
		/// </summary>
		public IList SelectTablasDisponibles(long idProyecto)
		{
			Proyecto p = (Proyecto) this.GenericDAO.Retrieve(typeof(Proyecto), idProyecto);
			Catalogo c = this.mySQLDAO.GetCatalogo(p.Servidor, p.NombreBD, p.Usuario, p.Password);
			return c.Tablas;
		}

		/// <summary>
		/// Implementacion de CatalogoServiceImpl.SelectCamposDisponibles
		/// </summary>
		public IList SelectColumnasDisponibles(long idProyecto)
		{
			ArrayList ret = new ArrayList();
			IList tablas = this.proyectoDAO.SelectTablas(idProyecto);
			foreach (Tabla t in tablas)
			{
				ret.AddRange(t.Columnas);
			}
			// TODO: hacer un hash y evitar duplicados
			return ret;
		}

		/// <summary>
		/// Implementacion de CatalogoService.ProbarConexion
		/// </summary>
		public string ProbarConexion(string servidor, string esquema, string usuario, string password)
		{
			return this.mySQLDAO.ProbarConexion(servidor, esquema, usuario, password);
		}

		/// <summary>
		/// Implementacion CatalogoService.ObtenerTabla
		/// </summary>
		public Tabla ObtenerTabla(string nombreTabla, long idProyecto)
		{
			IList tablas = SelectTablasDisponibles(idProyecto);
			foreach (Tabla t in tablas)
			{
				if (t.Nombre == nombreTabla)
				{
					return t;
				}
			}
			return null;
		}

		/// <summary>
		/// Implementacion CatalogoService.ObtenerColumna
		/// </summary>
		public Columna ObtenerColumna(string nombreColumna, long idProyecto)
		{
			IList columnas = SelectColumnasDisponibles(idProyecto);
			foreach (Columna c in columnas)
			{
				if (c.Nombre == nombreColumna)
				{
					return c;
				}
			}
			return null;
		}
	}
}
