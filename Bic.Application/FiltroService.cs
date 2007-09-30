using System.Collections;
using Bic.Domain;

namespace Bic.Application
{
	/// <summary>
	/// Todos los servicios expuestos para el manejo de Filtros.
	/// </summary>
	public interface FiltroService
	{
		/// <summary>
		/// Persiste un atributo
		/// </summary>
		/// <param name="unFiltro">EL atributo a ser grabado</param>
		void Save(Filtro unFiltro); 

		/// <summary>
		/// Obtiene un atributo a través de su id
		/// </summary>
		/// <param name="id">El id de atributo</param>
		/// <returns>El atributo correspondiente</returns>
		Filtro Retrieve(long id);

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
