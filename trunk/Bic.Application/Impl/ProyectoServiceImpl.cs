using System.Collections;
using Bic.Domain;
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

		public ProyectoServiceImpl()
		{
		}

		/// <summary>
		/// Implementacion de ProyectoService.save
		/// </summary>
		public void Save(Proyecto unProyecto) 
		{
			if (unProyecto.Id  == 0) 
			{
				Proyecto p = this.ProyectoDAO.ObtenerByNombre(unProyecto.Nombre);
				if (p != null) 
				{
					throw new ServiceException("No se puede crear el proyecto ya que existe uno con el mismo nombre.");
				}
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
			this.GenericDAO.Delete(typeof(Proyecto), id);
		}

	}
}
