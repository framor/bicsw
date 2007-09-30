using System.Collections;
using Bic.Domain;

namespace Bic.Application
{
	/// <summary>
	/// Todos los servicios expuestos para el manejo de Metricas.
	/// </summary>
	public interface MetricaService
	{
		/// <summary>
		/// Persiste un atributo
		/// </summary>
		/// <param name="unMetrica">EL atributo a ser grabado</param>
		void Save(Metrica unMetrica); 

		/// <summary>
		/// Obtiene un atributo a través de su id
		/// </summary>
		/// <param name="id">El id de atributo</param>
		/// <returns>El atributo correspondiente</returns>
		Metrica Retrieve(long id);

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
