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
		public void Save(Atributo unAtributo) 
		{
			this.GenericDAO.Save(unAtributo);
		}

		/// <summary>
		/// Implementacion de AtributoService.retrieve
		/// </summary>
		public Atributo Retrieve(long id) 
		{
			return (Atributo) this.GenericDAO.Retrieve(typeof(Atributo), id); 
		}

		/// <summary>
		/// Implementacion de AtributoService.select
		/// </summary>
		public ICollection Select(long proyectoId) 
		{
			return this.ProyectoDAO.selectAtributos(proyectoId);
		}

		/// <summary>
		/// Implementacion de AtributoService.delete
		/// </summary>
		public void Delete(long id)
		{
			this.GenericDAO.Delete(typeof(Atributo), id);
		}

	}
}
