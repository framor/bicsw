using System.Collections;
using Bic.Domain.Catalogo;

namespace Bic.Application
{
	/// <summary>
	/// Todos los servicios expuestos para el manejo de Tablas.
	/// </summary>
	public interface TablaService
	{
	
		/// <summary>
		/// Persiste un tabla
		/// </summary>
		/// <param name="unTabla">EL tabla a ser grabado</param>
		void Save(Tabla unTabla); 

		/// <summary>
		/// Obtiene un tabla a través de su id
		/// </summary>
		/// <param name="id">El id de tabla</param>
		/// <returns>El tabla correspondiente</returns>
		Tabla Retrieve(long id);

		/// <summary>
		/// Obtiene todos los tablas
		/// </summary>
		/// <param name="proyectoId">El id de proyecto</param>
		/// <returns>Una coleccion de tablas</returns>
		ICollection Select(long proyectoId);

		/// <summary>
		/// Elimina un tabla
		/// </summary>
		/// <param name="id">El id de tabla</param>
		void Delete(long id);

		/// <summary>
		/// Obtiene las tablas que existene en la bd configurada
		/// </summary>
		/// <param name="idProyecto">El id del proyecto</param>
		/// <returns></returns>
		IList SelectTablasDisponibles(long idProyecto);
	}
}
