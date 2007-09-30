using System.Collections;
using Bic.Domain;
using Bic.Domain.Dao;

namespace Bic.Application.Impl
{
	/// <summary>
	/// Implementación de MetricaService
	/// </summary>
	public class MetricaServiceImpl : BaseService, MetricaService
	{
		private IProyectoDAO proyectoDAO;
		public IProyectoDAO ProyectoDAO 
		{
			get { return this.proyectoDAO; }
			set { this.proyectoDAO = value; }
		}

		public MetricaServiceImpl()
		{
		}

		/// <summary>
		/// Implementacion de MetricaService.save
		/// </summary>
		public void Save(Metrica unMetrica) 
		{
			this.GenericDAO.Save(unMetrica);
		}

		/// <summary>
		/// Implementacion de MetricaService.retrieve
		/// </summary>
		public Metrica Retrieve(long id) 
		{
			return (Metrica) this.GenericDAO.Retrieve(typeof(Metrica), id); 
		}

		/// <summary>
		/// Implementacion de MetricaService.select
		/// </summary>
		public ICollection Select(long proyectoId) 
		{
			return this.ProyectoDAO.SelectMetricas(proyectoId);
		}

		/// <summary>
		/// Implementacion de MetricaService.delete
		/// </summary>
		public void Delete(long id)
		{
			this.GenericDAO.Delete(typeof(Metrica), id);
		}

	}
}
