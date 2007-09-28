using System.Collections;
using Bic.Domain.Catalogo;

namespace Bic.Application
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

		/// <summary>
		/// Obtiene las columnas que existene en la bd configurada
		/// </summary>
		/// <param name="idProyecto">El id del proyecto</param>
		/// <returns></returns>
		IList SelectColumnasDisponibles(long idProyecto);
		
		/// <summary>
		/// Intenta una conexion con los datos que se proveen
		/// </summary>
		/// <param name="servidor"></param>
		/// <param name="esquema"></param>
		/// <param name="usuario"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		string ProbarConexion(string servidor, string esquema, string usuario, string password);

		/// <summary>
		/// Obtiene una tabla del catalog de la bd configurada para el proyecto
		/// </summary>
		/// <param name="nombreTabla"></param>
		/// <param name="idProyecto"></param>
		/// <returns></returns>
		Tabla ObtenerTabla(string nombreTabla, long idProyecto);
	}
}
