using System.Collections;
using Bic.Domain.Catalogo;

namespace Bic.Domain.Dao
{
	/// <summary>
	/// Descripción breve de ProyectoDAO.
	/// </summary>
	public interface IProyectoDAO
	{

		/// <summary>
		/// Obtiene los atributos para un id de proyecto
		/// </summary>
		/// <param name="proyectoId">el id de proyecto</param>
		/// <returns>IList de Atributos</returns>
		IList SelectAtributos(long proyectoId);

		/// <summary>
		/// Obtiene las tablas para un id de proyecto
		/// </summary>
		/// <param name="proyectoId">el id de proyecto</param>
		/// <returns>IList de Atributos</returns>
		IList SelectTablas(long proyectoId);

		/// <summary>
		/// Obtiene las tablas para un id de proyecto en las que esta la columna
		/// </summary>
		/// <param name="proyectoId">el id de proyecto</param>
		/// <param name="col">columna</param>
		/// <returns>IList de Tablas</returns>
		IList SelectTablas(long proyectoId, Columna col);

		/// <summary>
		/// Obtiene los hechos para un id de proyecto
		/// </summary>
		/// <param name="proyectoId">el id de proyecto</param>
		/// <returns>IList de Hechos</returns>
		IList SelectHechos(long proyectoId);

		/// <summary>
		/// Obtiene un proyecto por su nombre
		/// </summary>
		/// <param name="nombre">nombre del proyecto</param>
		/// <returns>el proyecto encontrado o null</returns>
		Proyecto ObtenerByNombre(string nombre);

	}
}
