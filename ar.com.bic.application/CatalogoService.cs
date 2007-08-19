using System.Collections;

namespace ar.com.bic.application
{
	/// <summary>
	/// Todos los servicios expuestos para el manejo de Catalogo.
	/// </summary>
	public interface CatalogoService
	{
		/// <summary>
		/// Obtiene las tablas que existene en la bd configurada
		/// </summary>
		/// <param name="idProyecto">El id del proyecto</param>
		/// <returns></returns>
		IList SelectTablasDisponibles(long idProyecto);

	}
}
