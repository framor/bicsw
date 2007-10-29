using Bic.Domain.Catalogo;

namespace Bic.Domain.Interfaces
{
	/// <summary>
	/// Descripción breve de ICamino.
	/// </summary>
	public interface ICamino
	{

		/// <summary>
		/// Genera el camino desde el campo hasta la tabla pasado por parametro.
		/// </summary>
		/// <param name="tabla"></param>
		/// <returns></returns>
		Camino GeneraCamino(Tabla tabla); 

		/// <summary>
		/// Genera todo el camino desde el Atributo hasta el ultimo atributo de la jerarquia.
		/// </summary>
		/// <returns></returns>
		Camino GeneraCamino(); 
	
	}
}
