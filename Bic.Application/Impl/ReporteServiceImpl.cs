using System;
using Bic.Domain;
using System.Collections;
using Bic.Domain.Dao;

namespace Bic.Application.Impl
{
	public class ReporteServiceImpl: BaseService, ReporteService 
	{
		private IProyectoDAO proyectoDAO;
		public IProyectoDAO ProyectoDAO 
		{
			get { return this.proyectoDAO; }
			set { this.proyectoDAO = value; }
		}
		#region Constructor

		public ReporteServiceImpl()
		{

		}

		#endregion

		#region Inherited methods

		public void Save(Reporte reporte)
		{
			this.GenericDAO.Save(reporte);	
		}

		
		public Reporte Retrieve(long id)
		{
			return this.GenericDAO.Retrieve(typeof(Reporte), id) as Reporte;
		}

		
		public ICollection Select(long proyectoId)
		{
			return this.ProyectoDAO.SelectReportes(proyectoId);
		}

		public void Delete(long id)
		{
			this.GenericDAO.Delete(typeof(Reporte), id);
		}

		#endregion
	}
}
