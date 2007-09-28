using System.Collections;
using Bic.Application;
using Bic.Domain;
using Bic.Domain.Catalogo;
using Bic.Domain.Dao;

namespace Bic.Application.Impl
{
	/// <summary>
	/// Implementación de CatalogoService
	/// </summary>
	public class CatalogoServiceImpl : BaseService , CatalogoService
	{

		private ICatalogoDAO catalogoDAO;
		public ICatalogoDAO CatalogoDAO 
		{
			get { return this.catalogoDAO; }
			set { this.catalogoDAO = value; }
		}

		private IProyectoDAO proyectoDAO;
		public IProyectoDAO ProyectoDAO 
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
			Catalogo c = this.catalogoDAO.ObtenerCatalogo(p.Conexion);
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
			Conexion con = new Conexion(servidor, esquema, usuario, password);
			return this.catalogoDAO.ProbarConexion(con);
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
	}
}
