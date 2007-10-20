using System.Collections;
using System.Data;
using Bic.Domain;
using Bic.Domain.Catalogo;
using Bic.Domain.Dao;
using Bic.Framework.Exception;

namespace Bic.Application.Impl
{
	/// <summary>
	/// Implementación de ProyectoService
	/// </summary>
	public class ProyectoServiceImpl : BaseService, ProyectoService
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

		public ProyectoServiceImpl()
		{
		}

		/// <summary>
		/// Implementacion de ProyectoService.save
		/// </summary>
		public void Save(Proyecto unProyecto) 
		{
			Proyecto p = (Proyecto) this.GenericDAO.SelectByNombre(typeof(Proyecto), unProyecto.Id, unProyecto.Nombre);
			if (p != null && !p.Equals(unProyecto)) 
			{
				throw new ServiceException("No se puede crear el proyecto ya que existe uno con el mismo nombre.");
			}
			try 
			{
				this.catalogoDAO.ProbarConexion(unProyecto.Conexion);
			}
			catch (DataException)
			{
				throw new ServiceException("No se puede grabar el proyecto con una conexión inválida. Verifique los parámetros de la misma.");
			}
			this.GenericDAO.Save(unProyecto);
		}

		/// <summary>
		/// Implementacion de ProyectoService.retrieve
		/// </summary>
		public Proyecto Retrieve(long id) 
		{
			return (Proyecto) this.GenericDAO.Retrieve(typeof(Proyecto), id); 
		}

		/// <summary>
		/// Implementacion de ProyectoService.select
		/// </summary>
		public ICollection Select() 
		{
			return this.GenericDAO.Select(typeof(Proyecto));
		}

		/// <summary>
		/// Implementacion de ProyectoService.delete
		/// </summary>
		public void Delete(long id)
		{
			IList metricas = this.proyectoDAO.SelectMetricas(id);
			foreach (Metrica m in metricas) this.GenericDAO.Delete(typeof(Metrica), m.Id);
			IList hechos = this.proyectoDAO.SelectHechos(id);
			foreach (Hecho h in hechos) this.GenericDAO.Delete(typeof(Hecho), h.Id);
			IList filtros = this.proyectoDAO.SelectFiltros(id);
			foreach (Filtro f in filtros) this.GenericDAO.Delete(typeof(Filtro), f.Id);
			IList atributos = this.proyectoDAO.SelectAtributos(id);
			foreach (Atributo a in atributos) this.GenericDAO.Delete(typeof(Atributo), a.Id);
			IList tablas = this.proyectoDAO.SelectTablas(id);
			foreach (Tabla t in tablas) this.GenericDAO.Delete(typeof(Tabla), t.Id);
			this.GenericDAO.Delete(typeof(Proyecto), id);
		}
	}
}
