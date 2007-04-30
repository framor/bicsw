using System;
using SqlBuilder.Model;
using System.Collections;
using System.Text;

namespace SqlBuilder
{
	/// <summary>
	/// Objeto responsable de crear la sentencia SQL.
	/// </summary>
	public class SQLBuilder
	{
		#region Constructor

		public SQLBuilder(FactTable factTable, ArrayList atributos, ArrayList hechos, ArrayList filtros)
		{
			this.factTable = factTable;
			this.atributos = atributos;
			this.hechos = hechos;
			this.filtros = filtros;

			this.tablesSection = new ArrayList();
			this.joinsSection = new ArrayList();
		}

		#endregion

		#region Miembros privados

		private ArrayList hechos;
		private ArrayList atributos;
		private FactTable factTable;
		private ArrayList filtros;

		private ArrayList tablesSection = null;
		private ArrayList joinsSection = null;

		#endregion

		#region Metodos publicos

		public string BuildSQLSentence()
		{
			this.ProcesarAtributos(); 
			
			return this.ConvertObjectsToSql();
		}

		#endregion

		#region Metodos privados

		private void ProcesarAtributos()
		{
			foreach(Atributo atributo in this.atributos)
			{
				if (!this.CrearRelacionEntreTablas(atributo.Tabla, this.factTable,null))
				{
					throw new RelationNotFoundException(); 
				}
			}
		}

		
		private bool CrearRelacionEntreTablas(Tabla tablaOrigen, Tabla tablaDestino, Relacion relacionUsada)
		{
			// Se remueve la relacion para evitar loops en el modelo estrella.
			if ( relacionUsada != null )
			{
				tablaOrigen.Relaciones.Remove(relacionUsada);
			}

			foreach(Relacion relacion in tablaOrigen.Relaciones)
			{
				Tabla proximaTabla = relacion.GetTablaDestino(tablaOrigen);
				if ( proximaTabla.Equals(tablaDestino) )
				{
					this.joinsSection.Add(relacion);
					this.tablesSection.Add(tablaOrigen); 

					if (!this.tablesSection.Contains(this.factTable))
					{
						this.tablesSection.Add(this.factTable);
					}

					return true;
				}
				else
				{
					if ( this.CrearRelacionEntreTablas(proximaTabla,tablaDestino,relacion))
					{
						this.joinsSection.Add(relacion);
						this.tablesSection.Add(tablaOrigen);
						return true;
					}
				}
			}

			return false;
		}

		private string ConvertObjectsToSql()
		{
			StringBuilder sql = new StringBuilder();

			sql.Append("SELECT ");

			foreach(Hecho hecho in this.hechos)
			{
				sql.Append(hecho.Tabla.Nombre + "." +hecho.Nombre +", ");
			}

			foreach(Atributo atributo in this.atributos)
			{
				sql.Append(atributo.Tabla.Nombre + "." +atributo.Nombre +", ");
			}			

			if (this.atributos.Count != 0)
			{
				//Quita la última coma con su respectivo espacio
				sql.Remove(sql.Length-2,2);
			}
			

			sql.Append(" FROM ");

			foreach ( Tabla tabla in this.tablesSection)
			{
				sql.Append(tabla.Nombre +", ");
			}

			if (this.tablesSection.Count != 0)
			{
				//Quita la última coma y su correspondiente espacio
				sql.Remove(sql.Length-2,2);
			}
			

			sql.Append(" WHERE ");
			
			foreach(Relacion relacion in this.joinsSection)
			{
				sql.Append(relacion.Atributo1.Tabla.Nombre + "." + relacion.Atributo1.Nombre + " = " +
						   relacion.Atributo2.Tabla.Nombre + "." + relacion.Atributo2.Nombre+" and ");
			}

			foreach ( Filtro filtro in this.filtros)
			{
				sql.Append( filtro.ReportItem.Tabla.Nombre + "." + filtro.ReportItem.Nombre + " " + filtro.Operador + " " + filtro.Valor + " and ");
			}

			if (this.filtros.Count != 0 || this.joinsSection.Count!= 0 )
			{
				sql.Remove(sql.Length-5,5);
			}

			return sql.ToString();
		}
		#endregion
	}
}
