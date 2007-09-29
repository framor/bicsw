using System.Collections;
using Bic.Domain;
using Bic.Domain.Catalogo;

namespace Bic.Application
{
	/// <summary>
	/// Todos los servicios expuestos para el manejo de Atributos.
	/// </summary>
	public interface AtributoService
	{
		/// <summary>
		/// Persiste un atributo
		/// </summary>
		/// <param name="unAtributo">EL atributo a ser grabado</param>
		void Save(Atributo unAtributo); 

		/// <summary>
		/// Obtiene un atributo a través de su id
		/// </summary>
		/// <param name="id">El id de atributo</param>
		/// <returns>El atributo correspondiente</returns>
		Atributo Retrieve(long id);

		/// <summary>
		/// Obtiene todos los atributos
		/// </summary>
		/// <param name="proyectoId">El id de proyecto</param>
		/// <returns>Una coleccion de atributos</returns>
		ICollection Select(long proyectoId);

		/// <summary>
		/// Obtiene todos los atributo que podrían ser hijos
		/// </summary>
		/// <param name="proyectoId">Id de proyecto</param>
		/// <param name="colId">columna id del atributo padre</param>
		/// <returns></returns>
		ICollection SelectPosiblesHijos(long proyectoId, Columna colId);

		/// <summary>
		/// Elimina un atributo
		/// </summary>
		/// <param name="id">El id de atributo</param>
		void Delete(long id);

	}
}
