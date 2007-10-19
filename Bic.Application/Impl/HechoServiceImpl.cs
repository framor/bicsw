using System.Collections;
using Bic.Domain;
using Bic.Domain.Dao;
using Bic.Framework.Exception;

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
			IList hechos = this.ProyectoDAO.SelectHechos(unHecho.Proyecto.Id);
			if (hechos.Contains(unHecho))  
			{
				throw new ServiceException("No se puede crear el hecho ya que existe uno con el mismo nombre.");
			}
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
			Hecho h = (Hecho) this.GenericDAO.Retrieve(typeof(Hecho), id);
			Proyecto p = h.Proyecto;
			if (p.PuedeEliminarHecho(h)) 
			{
				this.GenericDAO.Delete(typeof(Hecho), id);
			} 
			else 
			{
				throw new ServiceException("No se puede eliminar el hecho ya que está siendo utilizado por una métrica.");
			}
		}

	}
}
