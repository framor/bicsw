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
	}
}
