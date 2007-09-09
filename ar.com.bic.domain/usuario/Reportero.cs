namespace ar.com.bic.domain.usuario
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

		protected override string GetNombre()
		{
			return "Reportero";
		}

	}
}
