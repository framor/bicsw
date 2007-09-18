using Bic.Domain.Dao;

namespace Bic.Application
{
	/// <summary>
	/// Clase base para todos los servicios.
	/// </summary>
	public abstract class BaseService
	{
		public BaseService()
		{
		}

		private IGenericDAO genericDAO;
		public IGenericDAO GenericDAO 
		{
			get { return this.genericDAO; }
			set { this.genericDAO = value; }
		}

	}
}
