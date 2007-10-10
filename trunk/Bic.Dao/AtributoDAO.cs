using System.Collections;
using Bic.Domain;
using Bic.Domain.Catalogo;
using Bic.Domain.Dao;
using Spring.Data.NHibernate.Support;

namespace Bic.Dao
{
	public class AtributoDAO: HibernateDaoSupport, IAtributoDAO
	{
		public AtributoDAO()
		{
		}

		public ICollection ObtenerPadres(long idAtributo)
		{
			IList ret = 
				HibernateTemplate.Find("from " + typeof(Atributo).Name + " a where a.hijo.id = ? ", 
				new object[]{idAtributo});
			
			if (ret != null)
			{
				return ret;
			}
			else
			{
				return new ArrayList();
			}
		}

	}
}
