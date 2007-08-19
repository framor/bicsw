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

		public bool Login(string usuario, string contrasena)
		{
			Usuario u = this.usuarioDAO.getByNombre(usuario);
			return u != null && u.Clave.Equals(contrasena);
		}
	}
}
