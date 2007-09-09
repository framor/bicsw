namespace ar.com.bic.domain.usuario
{
	/// <summary>
	/// Descripción breve de Administrador.
	/// </summary>
	public class Administrador : Rol
	{
		private static Administrador INSTANCE;
		public static Administrador Instance
		{
			get
			{
				if (INSTANCE == null)
				{
					INSTANCE = new Administrador();
				}
				return INSTANCE;
			}
		}

		private Administrador()
		{
		}

		protected override string GetId()
		{
			return Rol.ID_ADMINISTRADOR;
		}

		public override bool EsAdministrador()
		{
			return true;
		}

		public override bool PuedeAccederAUsuarios()
		{
			return true;
		}

		public override bool PuedeAccederAAtributos()
		{
			return true;
		}

		protected override string GetNombre()
		{
			return "Administrador";
		}

	}
}
