using System.Collections;
using Bic.Domain;
using Bic.Domain.Catalogo;
using Bic.Domain.Dao;

namespace Bic.Application.Impl
{
	/// <summary>
	/// Implementación de TablaService
	/// </summary>
	public class TablaServiceImpl : BaseService, TablaService
	{
		private IProyectoDAO proyectoDAO;
		public IProyectoDAO ProyectoDAO 
		{
			get { return this.proyectoDAO; }
			set { this.proyectoDAO = value; }
		}

		private ICatalogoDAO catalogoDAO;
		public ICatalogoDAO CatalogoDAO 
		{
			get { return this.catalogoDAO; }
			set { this.catalogoDAO = value; }
		}

		public TablaServiceImpl()
		{
		}

		/// <summary>
		/// Implementacion de TablaService.save
		/// </summary>
		public void Save(Tabla t) 
		{
			this.GenericDAO.Save(t);
		}

		/// <summary>
		/// Implementacion de TablaService.retrieve
		/// </summary>
		public Tabla Retrieve(long id) 
		{
			return (Tabla) this.GenericDAO.Retrieve(typeof(Tabla), id); 
		}

		/// <summary>
		/// Implementacion de TablaService.select
		/// </summary>
		public ICollection Select(long proyectoId) 
		{
			return this.ProyectoDAO.SelectTablas(proyectoId);
		}

		/// <summary>
		/// Implementacion de TablaService.delete
		/// </summary>
		public void Delete(long id)
		{
			this.GenericDAO.Delete(typeof(Tabla), id);
		}

		/// <summary>
		/// Implementacion de TablaServiceImpl.SelectTablasDisponibles
		/// </summary>
		public IList SelectTablasDisponibles(long idProyecto)
		{
			Proyecto p = (Proyecto) this.GenericDAO.Retrieve(typeof(Proyecto), idProyecto);
			Catalogo c = this.catalogoDAO.ObtenerCatalogo(p.Conexion);
			return c.Tablas;
		}
	}
}
