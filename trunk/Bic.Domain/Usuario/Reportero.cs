namespace Bic.Domain.Usuario
{
	/// <summary>
	/// Descripción breve de Reportero.
	/// </summary>
	public class Reportero : Rol
	{
		private static Reportero INSTANCE;
		public static Reportero Instance
		{
			get
			{
				if (INSTANCE == null)
				{
					INSTANCE = new Reportero();
				}
				return INSTANCE;
			}
		}

		private Reportero()
		{
		}

		protected override string GetId()
		{
			return Rol.ID_REPORTERO;
		}

		public override bool PuedeAccederAProyectos()
		{
			return true;
		}

		public override bool PuedeAccederAReportes()
		{
			return true;
		}

		public override bool PuedeAccederAMetricas()
		{
			return true;
		}

		public override bool PuedeAccederAFiltros()
		{
			return true;
		}

		protected override string GetNombre()
		{
			return "Reportero";
		}

	}
}
