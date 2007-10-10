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
		/// Obtiene las metricas para un id de proyecto
		/// </summary>
		/// <param name="proyectoId">el id de proyecto</param>
		/// <returns>IList de Metricas</returns>
		IList SelectMetricas(long proyectoId);

		/// <summary>
		/// Obtiene los filtros para un id de proyecto
		/// </summary>
		/// <param name="proyectoId">el id de proyecto</param>
		/// <returns>IList de Filtros</returns>
		IList SelectFiltros(long proyectoId);

		/// <summary>
		/// Obtiene los reportes para un id de proyecto
		/// </summary>
		/// <param name="proyectoId">el id de proyecto</param>
		/// <returns>IList de Reporte</returns>
		IList SelectReportes(long proyectoId);

	}
}
