using Bic.Dao;
using Bic.Domain.Catalogo;
using NUnit.Framework;

namespace Bic.Test
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
			Conexion con = new Conexion("localhost", "bic", "bic", "bic");
			Catalogo c = dao.ObtenerCatalogo(con);
			Assert.IsNotNull(c);
			Assert.IsNotEmpty(c.Tablas);
		}
	}
}
