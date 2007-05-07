using System;
using System.Collections;
using ar.com.bic.domain;
using ar.com.bic.dao;

namespace ar.com.bic.application.impl
{
	/// <summary>
	/// Descripción breve de UsuarioService.
	/// </summary>
	public class UsuarioServiceImpl : UsuarioService
	{
		private UsuarioDAO usuarioDAO;
		public UsuarioDAO UsuarioDAO 
		{
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
			this.usuarioDAO.save(unUsuario);
		}

		/// <summary>
		/// Implementacion de UsuarioService.retrieve
		/// </summary>
		public Usuario retrieve(long id) 
		{
			return this.usuarioDAO.retrieve(id); 
		}

		/// <summary>
		/// Implementacion de UsuarioService.select
		/// </summary>
		public ICollection select() 
		{
			return this.usuarioDAO.select();
		}

		/// <summary>
		/// Implementacion de UsuarioService.delete
		/// </summary>
		public void delete(long id)
		{
			this.usuarioDAO.delete(id);
		}
	}
}
