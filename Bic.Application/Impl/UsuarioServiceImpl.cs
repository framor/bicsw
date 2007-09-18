using System.Collections;
using Bic.Domain.Dao;
using Bic.Domain.Usuario;

namespace Bic.Application.Impl
{
	/// <summary>
	/// Implementación de UsuarioService
	/// </summary>
	public class UsuarioServiceImpl : BaseService, UsuarioService
	{

		private IUsuarioDAO usuarioDAO;
		public IUsuarioDAO UsuarioDAO 
		{
			get { return this.usuarioDAO; }
			set { this.usuarioDAO = value; }
		}

		public UsuarioServiceImpl()
		{
		}

		/// <summary>
		/// Implementacion de UsuarioService.save
		/// </summary>
		public void Save(Usuario unUsuario) 
		{
			this.GenericDAO.Save(unUsuario);
		}

		/// <summary>
		/// Implementacion de UsuarioService.retrieve
		/// </summary>
		public Usuario Retrieve(long id) 
		{
			return (Usuario) this.GenericDAO.Retrieve(typeof(Usuario), id); 
		}

		/// <summary>
		/// Implementacion de UsuarioService.select
		/// </summary>
		public ICollection Select() 
		{
			return this.GenericDAO.Select(typeof(Usuario));
		}

		/// <summary>
		/// Implementacion de UsuarioService.delete
		/// </summary>
		public void Delete(long id)
		{
			this.GenericDAO.Delete(typeof(Usuario), id);
		}

		public Usuario Login(string usuario, string contrasena)
		{
			Usuario u = this.usuarioDAO.getByNombre(usuario);
			if (u != null && u.Clave.Equals(contrasena))
			{
				return u;
			}
			return null;
		}
	}
}
