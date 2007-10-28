using Bic.Domain.Catalogo;
using Bic.Domain.Interfaces;
using Bic.Domain.Exception;

namespace Bic.Domain
{
	/// <summary>
	/// Descripción breve de Filtro.
	/// </summary>
	public class Filtro : ICamino
	{
		private long id;
		private string nombre;
		private Columna columna;
		private Atributo atributo;
		private string operador;
		private string valor;
		private Proyecto proyecto;

		public Filtro() {}

		public long Id
		{
			get { return this.id; }
			set { this.id = value; }
		}
		public string Nombre
		{
			get { return this.nombre; }
			set { this.nombre = value; }
		}
		public string Operador
		{
			get { return this.operador; }
			set
			{
				if((value.Equals("Empieza con") || value.Equals("Termina con") || value.Equals("Contiene")) 
					&& !this.Columna.Tipo.Equals("varchar") && !this.Columna.Tipo.Equals("char"))
				{
					throw new OperadorInvalidoException("El operador Seleccionado no se puede aplicar al tipo de dato del filtro");
				}
					this.operador = value; 
			}

			
		}
		public string Valor
		{
			get { return this.valor; }
			set { this.valor = value; }
		}
		public Columna Columna
		{
			get { return this.columna; }
			set { this.columna = value; }
		}
		public Atributo Atributo
		{
			get { return this.atributo; }
			set { this.atributo = value; }
		}
		public string NombreColumna
		{
			get { return this.columna.Nombre; }
		}
		public Proyecto Proyecto
		{
			get { return this.proyecto; }
			set { this.proyecto = value; }
		}

		public Camino GeneraCamino(Tabla tabla)
		{
			return this.Atributo.GeneraCamino(tabla);
		}

		public string GetSql(string alias)
		{
			string sql = alias + "." + this.Columna.Nombre + " ";
			
			if (this.Operador.Equals("Empieza con"))
			{
				sql += "LIKE " + "'" + this.Valor + "%'";
			}
			else if (this.Operador.Equals("Termina con"))
			{
				sql += "LIKE " + "'%" + this.Valor + "'";
			}
			else if (this.Operador.Equals("Contiene"))
			{
				sql += "LIKE " + "'%" + this.Valor + "%'";
			}
			else
			{
				sql += this.Operador + " " + this.Valor + " ";

			}
			return sql;

		}
	}
}
