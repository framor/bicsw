using System.Collections;
using Bic.Domain;

namespace Bic.Application
{
	/// <summary>
	/// Todos los servicios expuestos para el manejo de Hechos.
	/// </summary>
	public interface HechoService
	{
		/// <summary>
		/// Persiste un atributo
		/// </summary>
		/// <param name="unHecho">EL atributo a ser grabado</param>
		void Save(Hecho unHecho); 

		/// <summary>
		/// Obtiene un atributo a través de su id
		/// </summary>
		/// <param name="id">El id de atributo</param>
		/// <returns>El atributo correspondiente</returns>
		Hecho Retrieve(long id);

		/// <summary>
		/// Obtiene todos los atributos
		/// </summary>
		/// <param name="proyectoId">El id de proyecto</param>
		/// <returns>Una coleccion de atributos</returns>
		ICollection Select(long proyectoId);

		/// <summary>
		/// Elimina un atributo
		/// </summary>
		/// <param name="id">El id de atributo</param>
		void Delete(long id);

	}
}
