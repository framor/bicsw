using System.Collections;
using Bic.Domain.Catalogo;

namespace Bic.Domain.Dao
{
	/// <summary>
	/// Descripción breve de TablaDAO.
	/// </summary>
	public interface ITablaDAO
	{

		/// <summary>
		/// Obtiene una tabla por su alias
		/// </summary>
		/// <param name="alias">alias de la tabla</param>
		/// <returns>la tabla encontrada o null</returns>
		Tabla ObtenerByAlias(long idProyecto, string alias);

		/// <summary>
		/// Obtiene una tabla por su nombre
		/// </summary>
		/// <param name="nombre">nombre de la tabla</param>
		/// <returns>la tabla encontrada o null</returns>
		Tabla ObtenerByNombre(long idProyecto, string nombre);

		IList SelectColumnasDisponibles(long idProyecto); 

		/// <summary>
		/// Obtiene todas las tablas que contienen la columna
		/// </summary>
		/// <param name="idProyecto">id de proyecto</param>
		/// <param name="col">columna</param>
		/// <returns></returns>
		IList SelectTablasConColumna(long idProyecto, Columna col); 

		/// <summary>
		/// Obtiene todas las tablas dadas de alta en el proyecto
		/// </summary>
		/// <param name="idProyecto">id de proyecto</param>
		/// <returns></returns>
		IList SelectTablasDisponibles(long idProyecto); 
	}
}
