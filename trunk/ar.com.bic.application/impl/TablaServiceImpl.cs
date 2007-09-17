using System;
using System.Collections;
using ar.com.bic.dao;
using ar.com.bic.domain;
using ar.com.bic.domain.catalogo;

namespace ar.com.bic.application.impl
{
	/// <summary>
	/// Implementación de TablaService
	/// </summary>
	public class TablaServiceImpl : BaseService, TablaService
	{
		private ProyectoDAO proyectoDAO;
		public ProyectoDAO ProyectoDAO 
		{
			get { return this.proyectoDAO; }
			set { this.proyectoDAO = value; }
		}

		private MySQLDAO mySQLDAO;
		public MySQLDAO MySQLDAO 
		{
			get { return this.mySQLDAO; }
			set { this.mySQLDAO = value; }
		}

		public TablaServiceImpl()
		{
		}

		/// <summary>
		/// Implementacion de TablaService.save
		/// </summary>
		public void Save(Tabla t) 
		{
			this.GenericDAO.Save(t);
		}

		/// <summary>
		/// Implementacion de TablaService.retrieve
		/// </summary>
		public Tabla Retrieve(long id) 
		{
			return (Tabla) this.GenericDAO.Retrieve(typeof(Tabla), id); 
		}

		/// <summary>
		/// Implementacion de TablaService.select
		/// </summary>
		public ICollection Select(long proyectoId) 
		{
			return this.ProyectoDAO.SelectTablas(proyectoId);
		}

		/// <summary>
		/// Implementacion de TablaService.delete
		/// </summary>
		public void Delete(long id)
		{
			this.GenericDAO.Delete(typeof(Tabla), id);
		}

		/// <summary>
		/// Implementacion de TablaServiceImpl.SelectTablasDisponibles
		/// </summary>
		public IList SelectTablasDisponibles(long idProyecto)
		{
			Proyecto p = (Proyecto) this.GenericDAO.Retrieve(typeof(Proyecto), idProyecto);
			Catalogo c = this.mySQLDAO.GetCatalogo(p.Servidor, p.NombreBD, p.Usuario, p.Password);
			return c.Tablas;
		}
	}
}
