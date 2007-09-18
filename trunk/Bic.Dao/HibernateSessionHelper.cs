using System;
using NHibernate;
using NHibernate.Cfg;

namespace ar.com.bic.dao
{
	/// <summary>
	/// Descripción breve de Session.
	/// </summary>
	public class HibernateSessionHelper
	{
		private static HibernateSessionHelper instance = new HibernateSessionHelper();

		private ISessionFactory sessionFactory;

		public static HibernateSessionHelper Instance 
		{
			get { return instance; }
		}

		private HibernateSessionHelper()
		{
			Configuration cfg = new Configuration();
			cfg.AddAssembly("ar.com.bic.domain"); // busca todos los hbm

			this.sessionFactory = cfg.BuildSessionFactory();
		}

		public ISession Session 
		{
			get { return this.sessionFactory.OpenSession(); }
		}

	}
}
