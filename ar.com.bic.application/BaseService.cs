using System;
using ar.com.bic.dao;

namespace ar.com.bic.application
{
	/// <summary>
	/// Clase base para todos los servicios.
	/// </summary>
	public abstract class BaseService
	{
		public BaseService()
		{
		}

		private GenericDAO genericDAO;
		public GenericDAO GenericDAO 
		{
			get { return this.genericDAO; }
			set { this.genericDAO = value; }
		}

	}
}
