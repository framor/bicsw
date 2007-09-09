using System;
using System.Collections;
using ar.com.bic.domain;
using ar.com.bic.dao;
using ar.com.bic.domain.usuario;

namespace ar.com.bic.application
{
	/// <summary>
	/// Todos los servicios expuestos para el manejo de Usuarios.
	/// </summary>
	public interface UsuarioService
	{
		/// <summary>
		/// Persiste un usuario
		/// </summary>
		/// <param name="unUsuario">EL usuario a ser grabado</param>
		void Save(Usuario unUsuario); 

		/// <summary>
		/// Obtiene un usuario a través de su id
		/// </summary>
		/// <param name="id">El id de usuario</param>
		/// <returns>El usuario correspondiente</returns>
		Usuario Retrieve(long id);

		/// <summary>
		/// Obtiene todos los usuarios
		/// </summary>
		/// <returns>Una coleccion de usuarios</returns>
		ICollection Select();

		/// <summary>
		/// Elimina un usuario
		/// </summary>
		/// <param name="id">El id de usuario</param>
		void Delete(long id);

		/// <summary>
		/// Valida un usuario y contraseña
		/// </summary>
		/// <param name="usuario">el nombre de usuario</param>
		/// <param name="contrasena">la contraseña</param>
		/// <returns>el Usuario logeado o null de tener datos invalidos</returns>
		Usuario Login(string usuario, string contrasena);
	}
}
