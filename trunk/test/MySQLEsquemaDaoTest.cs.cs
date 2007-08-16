using ar.com.bic.domain.esquema;
using NUnit.Framework;
using ar.com.bic.dao;

namespace test
{
	/// <summary>
	/// Descripción breve de MySQLEsquemaDaoTest.
	/// </summary>
	[TestFixture]
	public class MySQLEsquemaDaoTest
	{

		public MySQLEsquemaDaoTest() {}

		private MySQLEsquemaDAO dao = new MySQLEsquemaDAO();

		[Test]
		public void GetEsquemaTest()
		{
			Catalogo c = dao.GetCatalogo("localhost", "bic", "root", "bic");
			Assert.IsNotNull(c);
			Assert.IsNotEmpty(c.Tablas);
		}
	}
}
