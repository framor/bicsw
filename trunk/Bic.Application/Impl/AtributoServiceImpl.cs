using System.Collections;
using Bic.Application;
using Bic.Domain;
using Bic.Domain.Dao;

namespace Bic.Application.Impl
{
	/// <summary>
	/// Implementación de AtributoService
	/// </summary>
	public class AtributoServiceImpl : BaseService, AtributoService
	{
		private IProyectoDAO proyectoDAO;
		public IProyectoDAO ProyectoDAO 
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
			return this.ProyectoDAO.SelectAtributos(proyectoId);
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
