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
		/// <param name="nombre">alias de la tabla</param>
		/// <returns>la tabla encontrada o null</returns>
		Tabla ObtenerByAlias(long idProyecto, string alias);

	}
}
