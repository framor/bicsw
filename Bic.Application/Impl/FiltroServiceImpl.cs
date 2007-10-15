using System.Collections;
using Bic.Domain;
using Bic.Domain.Dao;
using Bic.Framework.Exception;

namespace Bic.Application.Impl
{
	/// <summary>
	/// Implementación de FiltroService
	/// </summary>
	public class FiltroServiceImpl : BaseService, FiltroService
	{
		private IProyectoDAO proyectoDAO;
		public IProyectoDAO ProyectoDAO 
		{
			get { return this.proyectoDAO; }
			set { this.proyectoDAO = value; }
		}

		public FiltroServiceImpl()
		{
		}

		/// <summary>
		/// Implementacion de FiltroService.save
		/// </summary>
		public void Save(Filtro unFiltro) 
		{
			Filtro f = (Filtro) this.GenericDAO.SelectByNombre(typeof(Filtro), unFiltro.Nombre);
			if (f != null) 
			{
				throw new ServiceException("No se puede crear el filtro ya que existe uno con el mismo nombre.");
			}
			this.GenericDAO.Save(unFiltro);
		}

		/// <summary>
		/// Implementacion de FiltroService.retrieve
		/// </summary>
		public Filtro Retrieve(long id) 
		{
			return (Filtro) this.GenericDAO.Retrieve(typeof(Filtro), id); 
		}

		/// <summary>
		/// Implementacion de FiltroService.select
		/// </summary>
		public ICollection Select(long proyectoId) 
		{
			return this.ProyectoDAO.SelectFiltros(proyectoId);
		}

		/// <summary>
		/// Implementacion de FiltroService.delete
		/// </summary>
		public void Delete(long id)
		{
			this.GenericDAO.Delete(typeof(Filtro), id);
		}

	}
}
