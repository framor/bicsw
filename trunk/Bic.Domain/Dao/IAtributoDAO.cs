using System.Collections;
using Bic.Domain.Catalogo;

namespace Bic.Domain.Dao
{
	/// <summary>
	/// Descripción breve de AtributoDAO.
	/// </summary>
	public interface IAtributoDAO
	{
		/// <summary>
		/// Obtiene los padres del atributo por su id
		/// </summary>
		/// <param name="idAtributo">id del atributo</param>
		/// <returns>la coleccion de padres</returns>
		ICollection ObtenerPadres(long idAtributo);
	}
}
