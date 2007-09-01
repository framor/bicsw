using ar.com.bic.dao;
using ar.com.bic.domain.catalogo;
using NUnit.Framework;

namespace test
{
	/// <summary>
	/// Descripción breve de MySQLEsquemaDaoTest.
	/// </summary>
	[TestFixture]
	public class MySQLEsquemaDaoTest
	{

		public MySQLEsquemaDaoTest() {}

		private MySQLDAO dao = new MySQLDAO();

		[Test]
		public void GetEsquemaTest()
		{
			Catalogo c = dao.GetCatalogo("localhost", "bic", "bic", "bic");
			Assert.IsNotNull(c);
			Assert.IsNotEmpty(c.Tablas);
		}
	}
}
