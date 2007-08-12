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
			Esquema e = dao.GetEsquema("localhost", "bic", "root", "bic");
			Assert.IsNotNull(e);
			Assert.IsNotEmpty(e.Tablas);
		}
	}
}
