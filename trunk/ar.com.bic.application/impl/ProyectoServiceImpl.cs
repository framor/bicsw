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
		public void Save(Proyecto unProyecto) 
		{
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
