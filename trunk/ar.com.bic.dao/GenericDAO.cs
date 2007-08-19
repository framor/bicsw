using System;
using System.Collections;
using Spring.Data.NHibernate.Support;

namespace ar.com.bic.dao
{
	/// <summary>
	/// Este dao contiene los métodos genéricos a todas las entidades. 
	/// Si se necesita un método específico de una entidad se deberá crear
	/// el dao específico.
	/// </summary>
	public class GenericDAO : HibernateDaoSupport 
	{
		public GenericDAO()
		{
		}

		/// <summary>
		/// Persiste un objeto a través de NHibernate
		/// </summary>
		/// <param name="persistentObject">el objecto a grabar</param>
		public void Save(Object persistentObject)  
		{
			HibernateTemplate.SaveOrUpdate(persistentObject);
		}

		/// <summary>
		/// Obtiene un objeto de la session de NHibernate
		/// </summary>
		/// <param name="entityType">El tipo de objeto</param>
		/// <param name="id">El id de objeto</param>
		/// <returns>El objeto obtenido</returns>
		public Object Retrieve(Type entityType, long id) 
		{			
			return HibernateTemplate.Get(entityType, id);
		}

		/// <summary>
		/// Obtiene todos los objetos de un tipo de la sesión de NHibernate
		/// </summary>
		/// <param name="entityType">El tipo de objeto</param>
		/// <returns>Una coleccion de los objetos</returns>
		public ICollection Select(Type entityType) 
		{
			return HibernateTemplate.Find("from " + entityType.Name);
		}

		/// <summary>
		/// Elimina un objeto de la sesión de Hibernate
		/// </summary>
		/// <param name="entityType">El tipo de objeto</param>
		/// <param name="id">El id del objeto </param>
		public void Delete(Type entityType, long id) 
		{
			HibernateTemplate.Delete("from " + entityType.Name + " o where o.id =" + id);
		}
	}
}
