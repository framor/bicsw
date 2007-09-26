using System.Collections;
using Bic.Domain;

namespace Bic.Application
{
	/// <summary>
	/// Todos los servicios expuestos para el manejo de Proyectos.
	/// </summary>
	public interface ProyectoService
	{
		/// <summary>
		/// Persiste un proyecto
		/// </summary>
		/// <param name="unProyecto">EL proyecto a ser grabado</param>
		void Save(Proyecto unProyecto); 

		/// <summary>
		/// Obtiene un proyecto a través de su id
		/// </summary>
		/// <param name="id">El id de proyecto</param>
		/// <returns>El proyecto correspondiente</returns>
		Proyecto Retrieve(long id);

		/// <summary>
		/// Obtiene todos los proyectos
		/// </summary>
		/// <returns>Una coleccion de proyectos</returns>
		ICollection Select();

		/// <summary>
		/// Elimina un proyecto
		/// </summary>
		/// <param name="id">El id de proyecto</param>
		void Delete(long id);

	}
}
