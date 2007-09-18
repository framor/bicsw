using System.Collections;
using Bic.Domain;
using Bic.Domain.Dao;

namespace Bic.Application.Impl
{
	/// <summary>
	/// Implementación de HechoService
	/// </summary>
	public class HechoServiceImpl : BaseService, HechoService
	{
		private IProyectoDAO proyectoDAO;
		public IProyectoDAO ProyectoDAO 
		{
			get { return this.proyectoDAO; }
			set { this.proyectoDAO = value; }
		}

		public HechoServiceImpl()
		{
		}

		/// <summary>
		/// Implementacion de HechoService.save
		/// </summary>
		public void Save(Hecho unHecho) 
		{
			this.GenericDAO.Save(unHecho);
		}

		/// <summary>
		/// Implementacion de HechoService.retrieve
		/// </summary>
		public Hecho Retrieve(long id) 
		{
			return (Hecho) this.GenericDAO.Retrieve(typeof(Hecho), id); 
		}

		/// <summary>
		/// Implementacion de HechoService.select
		/// </summary>
		public ICollection Select(long proyectoId) 
		{
			return this.ProyectoDAO.SelectHechos(proyectoId);
		}

		/// <summary>
		/// Implementacion de HechoService.delete
		/// </summary>
		public void Delete(long id)
		{
			this.GenericDAO.Delete(typeof(Hecho), id);
		}

	}
}
