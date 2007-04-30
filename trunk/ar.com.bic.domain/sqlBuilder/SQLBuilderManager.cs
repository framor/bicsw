using System;
using System.Collections;
using SqlBuilder.Model;


namespace SqlBuilder
{
	/// <summary>
	/// Entidad que tiene la responsabilidad de crear las sentencias SQL.
	/// </summary>
	public class SQLBuilderManager
	{
		#region Constructor

		public SQLBuilderManager()
		{
			this.factTables = MockHelper.GetInstance().GetFactTables();
		}

		#endregion

		#region Atributos privados

		private ArrayList factTables = null;

		#endregion

		#region Metodos publicos

		public string GetSQLSentence(ArrayList hechos, ArrayList atributos, ArrayList filtros)
		{
			ArrayList factTablesByFacts = this.GetFactTablesByFacts(hechos);
			SQLBuilder sqlBuilder = null;
			String sql = String.Empty;

			foreach ( FactTable factTable in factTablesByFacts )
			{
				sqlBuilder = new SQLBuilder(factTable,atributos,hechos,filtros);				
				
				try
				{
					sql = sqlBuilder.BuildSQLSentence();
				}
				catch(RelationNotFoundException)
				{
					continue;
				}				
			}

			if ( sql.Length.Equals(0) )
			{
				throw new ReportNotSupportedException();
			}

			return sql;
		}


		#endregion      
     	
		#region Metodos privados

		public ArrayList GetFactTablesByFacts(ArrayList hechos)
		{
			ArrayList someFactTables = new ArrayList();

			foreach(FactTable tabla in this.factTables)
			{			
				if (tabla.ContainsAllFacts(hechos))
				{
					someFactTables.Add(tabla);
				}
			}

			return someFactTables;
		}

		#endregion       
	}
}
