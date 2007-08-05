using System;
using System.Collections;
using ar.com.bic.dao;
using ar.com.bic.domain;

namespace ar.com.bic.application.impl
{
	/// <summary>
	/// Implementación de UsuarioService
	/// </summary>
	public class UsuarioServiceImpl : BaseService, UsuarioService
	{

		private UsuarioDAO usuarioDAO;
		public UsuarioDAO UsuarioDAO 
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
		public void save(Usuario unUsuario) 
		{
			this.GenericDAO.save(unUsuario);
		}

		/// <summary>
		/// Implementacion de UsuarioService.retrieve
		/// </summary>
		public Usuario retrieve(long id) 
		{
			return (Usuario) this.GenericDAO.retrieve(typeof(Usuario), id); 
		}

		/// <summary>
		/// Implementacion de UsuarioService.select
		/// </summary>
		public ICollection select() 
		{
			return this.GenericDAO.select(typeof(Usuario));
		}

		/// <summary>
		/// Implementacion de UsuarioService.delete
		/// </summary>
		public void delete(long id)
		{
			this.GenericDAO.delete(typeof(Usuario), id);
		}

		public bool login(string usuario, string contrasena)
		{
			Usuario u = this.usuarioDAO.getByNombre(usuario);
			return u != null && u.Clave.Equals(contrasena);
		}
	}
}
