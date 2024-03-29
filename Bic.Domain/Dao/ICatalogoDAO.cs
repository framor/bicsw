using System.Collections;
using System.Data;
using Bic.Domain.Catalogo;

namespace Bic.Domain.Dao
{
	/// <summary>
	/// Descripción breve de CatalogoDAO.
	/// </summary>
	public interface ICatalogoDAO
	{
		/// <summary>
		/// Obtiene el catalogo de la BD
		/// </summary>
		/// <param name="conexion">Parametros de conexion</param>
		/// <returns></returns>
		Bic.Domain.Catalogo.Catalogo ObtenerCatalogo(Conexion conexion);

		/// <summary>
		/// Intenta realizar una conexion a la BD
		/// </summary>
		/// <param name="conexion">Parametros de conexion</param>
		/// <returns>El resultado de la conexion</returns>
		string ProbarConexion(Conexion conexion);

		/// <summary>
		/// Obtiene todas las columnas que tiene la tabla en la BD
		/// </summary>
		/// <param name="t">una tabla</param>
		/// <returns>IList de columnas</returns>
		IList ObtenerColumnas(Tabla t);

		/// <summary>
		/// Ejecuta un string de sql en la conexion dada
		/// </summary>
		/// <param name="c">parámetros de conexion</param>
		/// <param name="sql">sql</param>
		/// <returns>dataset resultante</returns>
		DataSet EjecutarSql(Conexion c, string sql);
	}
}
