namespace Bic.Domain.Catalogo
{
	/// <summary>
	/// Descripción breve de Conexion.
	/// </summary>
	public class Conexion
	{
		private string server;
		private string database;
		private string user;
		private string password;

		public string Server
		{
			get { return server; }
			set { server = value; }
		}

		public string Database
		{
			get { return database; }
			set { database = value; }
		}

		public string User
		{
			get { return user; }
			set { user = value; }
		}

		public string Password
		{
			get { return password; }
			set { password = value; }
		}

		public Conexion()
		{
		}
		public Conexion(string server, string database, string user, string password)
		{
			this.server = server;
			this.database = database;
			this.user = user;
			this.password = password;
		}


	}
}
