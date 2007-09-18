using System;
using System.Collections;

namespace Bic.Domain.Dao
{
	/// <summary>
	/// Este dao contiene los métodos genéricos a todas las entidades. 
	/// Si se necesita un método específico de una entidad se deberá crear
	/// el dao específico.
	/// </summary>
	public interface IGenericDAO
	{
		/// <summary>
		/// Persiste un objeto a través de NHibernate
		/// </summary>
		/// <param name="persistentObject">el objecto a grabar</param>
		void Save(Object persistentObject);

		/// <summary>
		/// Obtiene un objeto de la session de NHibernate
		/// </summary>
		/// <param name="entityType">El tipo de objeto</param>
		/// <param name="id">El id de objeto</param>
		/// <returns>El objeto obtenido</returns>
		Object Retrieve(Type entityType, long id); 

		/// <summary>
		/// Obtiene todos los objetos de un tipo de la sesión de NHibernate
		/// </summary>
		/// <param name="entityType">El tipo de objeto</param>
		/// <returns>Una coleccion de los objetos</returns>
		ICollection Select(Type entityType); 

		/// <summary>
		/// Elimina un objeto de la sesión de Hibernate
		/// </summary>
		/// <param name="entityType">El tipo de objeto</param>
		/// <param name="id">El id del objeto </param>
		void Delete(Type entityType, long id); 
	}
}
