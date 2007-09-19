namespace Bic.Domain.Dao
{
	/// <summary>
	/// Descripción breve de UsuarioDAO.
	/// </summary>
	public interface IUsuarioDAO
	{
		/// <summary>
		/// Obtiene un usuario por el nombre
		/// </summary>
		/// <param name="nombre">nombre de usuario</param>
		/// <returns>el usuario o null si no existe</returns>
		Bic.Domain.Usuario.Usuario ObtenerByAlias(string alias);
	}
}
