using System.Collections;
using ar.com.bic.domain;

namespace ar.com.bic.application
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
		void save(Atributo unAtributo); 

		/// <summary>
		/// Obtiene un atributo a través de su id
		/// </summary>
		/// <param name="id">El id de atributo</param>
		/// <returns>El atributo correspondiente</returns>
		Atributo retrieve(long id);

		/// <summary>
		/// Obtiene todos los atributos
		/// </summary>
		/// <param name="proyectoId">El id de proyecto</param>
		/// <returns>Una coleccion de atributos</returns>
		ICollection select(long proyectoId);

		/// <summary>
		/// Elimina un atributo
		/// </summary>
		/// <param name="id">El id de atributo</param>
		void delete(long id);
	}
}
