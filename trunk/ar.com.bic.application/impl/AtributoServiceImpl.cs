using System;
using System.Collections;
using ar.com.bic.dao;
using ar.com.bic.domain;

namespace ar.com.bic.application.impl
{
	/// <summary>
	/// Implementación de AtributoService
	/// </summary>
	public class AtributoServiceImpl : BaseService, AtributoService
	{
		private ProyectoDAO proyectoDAO;
		public ProyectoDAO ProyectoDAO 
		{
			get { return this.proyectoDAO; }
			set { this.proyectoDAO = value; }
		}

		public AtributoServiceImpl()
		{
		}

		/// <summary>
		/// Implementacion de AtributoService.save
		/// </summary>
		public void save(Atributo unAtributo) 
		{
			this.GenericDAO.save(unAtributo);
		}

		/// <summary>
		/// Implementacion de AtributoService.retrieve
		/// </summary>
		public Atributo retrieve(long id) 
		{
			return (Atributo) this.GenericDAO.retrieve(typeof(Atributo), id); 
		}

		/// <summary>
		/// Implementacion de AtributoService.select
		/// </summary>
		public ICollection select(long proyectoId) 
		{
			return this.ProyectoDAO.selectAtributos(proyectoId);
		}

		/// <summary>
		/// Implementacion de AtributoService.delete
		/// </summary>
		public void delete(long id)
		{
			this.GenericDAO.delete(typeof(Atributo), id);
		}

	}
}
