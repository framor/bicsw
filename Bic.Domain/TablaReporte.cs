using System;
using System.Collections;
using Bic.Domain.Catalogo;

namespace Bic.Domain
{
	/// <summary>
	/// Descripción breve de TablaReporte.
	/// </summary>
	public class TablaReporte : IComparable
	{
		private Tabla tabla;
		private IList caminos;

		public TablaReporte(Tabla tabla,IList listaCaminos)
		{
			this.tabla = tabla;
			this.caminos = listaCaminos;
		}

		/// <summary>
		/// Necesaria para poder implementar IComparable
		/// y asi ordenar por la tabla de menor peso.
		/// </summary>
		/// <param name="objeto"></param>
		/// <returns></returns>
		public int CompareTo(Object objeto)
		{
			if(objeto is TablaReporte)
			{
				return this.tabla.Peso - ((TablaReporte)objeto).Tabla.Peso;
			}
			throw new ArgumentException(  "El objeto no es una TablaReporte" );
		}

		public Tabla Tabla
		{
			get { return this.tabla; }
		}

		/// <summary>
		/// Genera el SQL necesario para ejecutar.
		/// Compuesto por el from y el where
		/// </summary>
		/// <returns></returns>
		public string DameSql()
		{
			string sql = "from\n";
            
			// Primero agrego la tabla Fact.
			sql += this.tabla.NombreBD + "." + this.tabla.Nombre + " as " + this.tabla.Nombre + ",\n";

            // Por cada camino le pido que me de su from,
			// o sea las tablas de cada uno de ellos.
			foreach(Camino camino in this.caminos)
			{
				sql += camino.DameFromClause() + ",\n";
			}

			// Agrego la clausula where.
			sql += "where\n1=1\n";

			// A cada camino le pido que me de el join con la Fact.
			// O sea la lkp de primer nivel y la fact.
			foreach(Camino camino in this.caminos)
			{
				sql += "and " + camino.DameJoinFact(this.tabla.Nombre) + "\n";
			}
			
	
            // Devuelve el resto de las condiciones de join entre las 
			// tablas intermedias.
			foreach(Camino camino in this.caminos)
			{
				sql += "and " + camino.DameWhereClause() + "\n";
			}
			sql +=";";

			return sql;
		}
	}
}
