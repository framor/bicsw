using System;
using System.Collections;
using ar.com.bic.dao;
using ar.com.bic.domain;

namespace ar.com.bic.application.impl
{
	/// <summary>
	/// Implementación de ProyectoService
	/// </summary>
	public class ProyectoServiceImpl : BaseService, ProyectoService
	{

		public ProyectoServiceImpl()
		{
		}

		/// <summary>
		/// Implementacion de ProyectoService.save
		/// </summary>
		public void save(Proyecto unProyecto) 
		{
			this.GenericDAO.save(unProyecto);
		}

		/// <summary>
		/// Implementacion de ProyectoService.retrieve
		/// </summary>
		public Proyecto retrieve(long id) 
		{
			return (Proyecto) this.GenericDAO.retrieve(typeof(Proyecto), id); 
		}

		/// <summary>
		/// Implementacion de ProyectoService.select
		/// </summary>
		public ICollection select() 
		{
			return this.GenericDAO.select(typeof(Proyecto));
		}

		/// <summary>
		/// Implementacion de ProyectoService.delete
		/// </summary>
		public void delete(long id)
		{
			this.GenericDAO.delete(typeof(Proyecto), id);
		}

	}
}
