using System.Collections;
using Bic.Domain;
using Bic.Domain.Dao;

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
