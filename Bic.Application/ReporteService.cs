using System;
using Bic.Domain;
using System.Collections;


namespace Bic.Application
{
	public interface ReporteService
	{
		/// <summary>
		/// Persiste un reporte
		/// </summary>
		/// <param name="reporte">EL reporte a ser grabado</param>
		void Save(Reporte reporte); 

		/// <summary>
		/// Obtiene un reporte a través de su id
		/// </summary>
		/// <param name="id">El id de reporte</param>
		/// <returns>El reporte correspondiente</returns>
		Reporte Retrieve(long id);

		/// <summary>
		/// Obtiene todos los reportes
		/// </summary>
		/// <param name="proyectoId">El id de proyecto</param>
		/// <returns>Una coleccion de reportes</returns>
		ICollection Select(long proyectoId);

		/// <summary>
		/// Elimina un reporte
		/// </summary>
		/// <param name="id">El id del reporte</param>
		void Delete(long id);
	}
}
