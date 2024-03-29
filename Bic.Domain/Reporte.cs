using System.Collections;
using Bic.Domain.Catalogo;
using Bic.Domain.Exception;
using Bic.Domain.Interfaces;
using Bic.Framework;
using Iesi.Collections;

namespace Bic.Domain
{
	/// <summary>
	/// Descripción breve de Reporte.
	/// </summary>
	public class Reporte
	{
		#region Constructor

		public Reporte()
		{
			this.atributos = new HashedSet();
			this.metricas = new HashedSet();
			this.filtros = new HashedSet();
			this.nombre = string.Empty;
			this.tablaReporte = null;
			this.proyecto = null;
		}
		
		public Reporte(IList atributos, IList metricas, IList filtros)
		{
			this.atributos = new HashedSet(atributos);
			this.metricas = new HashedSet(metricas);
			this.filtros = new HashedSet(filtros);
		}
		#endregion

		#region Properties

		public long Id 
		{
			get 
			{
				return this.id; 
			}

			set 
			{ 
				this.id = value; 
			}
		}


		public string Nombre 
		{
			get
			{
				return this.nombre;
			}

			set
			{
				this.nombre = value;
			}
		}


		public Proyecto Proyecto 
		{
			get
			{
				return this.proyecto;
			}

			set
			{
				this.proyecto = value;
			}
		}


		public IList Atributos 
		{
			get { return new ArrayList(this.atributos); }
		}

		public IList Metricas
		{
			get { return new ArrayList(this.metricas);}
		}

		public IList Filtros
		{
			get { return new ArrayList(this.filtros); }
		}


		#endregion

		#region Private members
	
		private long id;
		private Proyecto proyecto;
		private string nombre;
		private ISet atributos;
		private ISet metricas; 
		private ISet filtros; 
		private TablaReporte tablaReporte;
	
		#endregion		

		#region Public methods

		public void AgregarAtributo(Atributo atributo)
		{
			this.atributos.Add(atributo);
		}

		public void RemoverAtributo(Atributo atributo)
		{
			this.atributos.Remove(atributo);
		}


		public void AgregarMetrica(Metrica metrica)
		{
			this.metricas.Add(metrica);
		}


		public void RemoverMetrica(Metrica metrica)
		{
			this.metricas.Remove(metrica);
		}

		public void AgregarFiltro(Filtro filtro)
		{
			this.filtros.Add(filtro);
		}

		public void RemoverFiltro(Filtro filtro)
		{
			this.filtros.Remove(filtro);
		}


		public void GeneraConsulta()
		{
			ArrayList tablasReporte = new ArrayList();
			ArrayList tablasFactCandidatas = new ArrayList();

			if (this.Metricas.Count == 0 && this.Atributos.Count == 0)
			{
				throw new ReporteInvalidoException("Por favor seleccione por lo menos un atributo o una metrica");
			}
			// Le pido las tablas candidatas a elegir - Son las que tienen todas las metricas
			try
			{
				if (this.Metricas.Count != 0)
				{
					tablasFactCandidatas = this.DameTablasCandidatas();
				}
			} // Si no existe tabla Fact candidata Subo de Nivel la Excepcion y lanzo la de ReporteInvalido
			catch (NoExisteTablaCandidataException)
			{
				throw new ReporteInvalidoException("Imposible generar el reporte, no existe combinacion entre los atributos y las metricas seleccionadas");
			}

			if (this.Metricas.Count != 0)
			{
				foreach(Tabla tabla in tablasFactCandidatas)
				{
					try
					{
						//Creo el objeto TablaReporte con la tabla Fact destino y todos sus caminos
						TablaReporte tablaReporte = new TablaReporte(tabla,this.GeneraCaminos(tabla,this.atributos));
						tablaReporte.AgregarCaminos(this.GeneraCaminos(tabla,this.filtros));

						// La agrego a la coleccion de tablasReporte, para ser tenidas en cuenta
						// por tener todos los caminos.
						tablasReporte.Add(tablaReporte);
					}
					catch (NoExisteCaminoException)
					{
                    
					}
				}
			}
			else
			{
				TablaReporte tablaReporte = new TablaReporte(null,this.GeneraCaminos(null,this.atributos));
				tablaReporte.AgregarCaminos(this.GeneraCaminos(null,this.filtros));
				tablasReporte.Add(tablaReporte);
			}

			// Verifico que aunque sea exista alguna alternativa de reporte
			if(tablasReporte.Count == 0)
				throw new ReporteInvalidoException("Imposible generar el reporte, no existe combinacion entre los atributos y las metricas seleccionadas");

			// Ordeno todas las alternativas por el comparador CompareTo
			// que elige la de menor peso.
			tablasReporte.Sort();
			
			// Tomo la primera y la agrego al reporte.
			this.tablaReporte = (TablaReporte)tablasReporte[0];

			this.tablaReporte.MergeCaminos();

			if (this.Metricas.Count == 0 && this.tablaReporte.Caminos.Count > 1)
			{
				throw new ReporteInvalidoException("Imposible generar el reporte, los atributos y/o los filtros seleccionados no pertenecen a la misma dimension");
			}

			return;

		}
		

		/// <summary>
		/// Genera todos los caminos entre los campos y la tabla fact
		/// </summary>
		/// <param name="tabla">Tabla Fact destino de caminos</param>
		/// <param name="campos">Campos de inicio de caminos</param>
		/// <returns>Devuelve un ArrayList con los caminos</returns>
		public ArrayList GeneraCaminos(Tabla tabla, ICollection campos)
		{
			ArrayList caminos = new ArrayList();
			//Por cada campo que cumpla con la interfaz TablaMapeable le pido que genere camino
			foreach(ICamino campo in campos)
			{	
				try
				{
					if (this.Metricas.Count != 0)
					{
						caminos.Add(campo.GeneraCamino(tabla));
					}
					else
					{
						caminos.Add(campo.GeneraCamino());
					}
				}
					// Si me llega una excepcion al no encontrar hijos significa
					// que no encontro un camino hasta la Fact.
					// Capturo la Excepcion.
				catch(NoExisteHijoException nehe)
				{
					// Subo de nivel de Excepcion a una excepcion del dominio.
					// Mando un excepcion de que no encuentra por lo menos un camino.
					throw new NoExisteCaminoException("Por lo menos uno de los atributos no tiene camino hasta la tabla Fact",nehe);
				}
			}

			return caminos;
		}


		public ArrayList DameTablasCandidatas()
		{

			ArrayList tablas = new ArrayList();

			// Le pido las tablas donde estan estas metricas
			IList tablasFact = this.DameTablas(this.metricas);
			
			// Itero en la colleccion de Tablas preguntandole si tiene a todas las metricas
			foreach(Tabla tabla in tablasFact)
			{
				if(tabla.Tenes(this.metricas)) 
					tablas.Add(tabla);
			}
			
			if(tablas.Count == 0)
				throw new NoExisteTablaCandidataException("No existe ninguna Fact Table que tenga todas las metricas");

			return tablas;
		}


		public IList DameTablas(ICollection campos)
		{
			
			ArrayList tablas = new ArrayList();
			// Le pido a todos los campos que me den las tablas donde estan presentes
			foreach(ITablaMapeable campo in campos)
			{
				tablas.AddRange(campo.ObtenerTablas());
				
			};
			
			// Con esta funcion quito los repetidos
			return CollectionUtils.ConvertirSet(tablas);
		}


		public TablaReporte TablaReporte
		{
			get { return this.tablaReporte; }
		}


		public string DameSql()
		{
			this.GeneraConsulta();

			string listaCamposConAlias ="";
			string listaCampos ="";
			string listaMetricas = "";
			string filtrosWhere = "";

			ArrayList ats = new ArrayList(this.atributos);
			foreach(Atributo atrib in ats)
			{
				//string alias = atrib.TablaLookup.Nombre + this.tablaReporte.GetIdCamino(atrib);
				//string alias = atrib.AliasSql;
				string alias = atrib.AliasSql + this.tablaReporte.GetIdCamino(atrib);
				IList columnasDesc = atrib.ColumnasDescripciones;
				

				foreach(Columna col in columnasDesc)
				{
					listaCamposConAlias += alias + "." + col.Nombre + " AS '" + atrib.Nombre + "." + col.Nombre +"' ";

					if (columnasDesc.IndexOf(col) < columnasDesc.Count - 1)
						listaCamposConAlias+= ",\n";

					listaCampos += alias + "." + col.Nombre;

					if (columnasDesc.IndexOf(col) < columnasDesc.Count - 1)
						listaCampos += ",\n";

				}
				
				// Mientras no sea el ultimo agregar la coma y el enter
				if (ats.IndexOf(atrib) < ats.Count - 1)	
				{
					listaCampos += ",\n";
					listaCamposConAlias+= ",\n";
				}
			}			

			ArrayList mets = new ArrayList(this.metricas);
			foreach(Metrica metrica in mets)
			{
				// Le pido el nombre de la tabla Fact a la TablaReporte
				string alias = this.tablaReporte.Tabla.Nombre;
				listaMetricas += metrica.SQLExpression(TablaReporte.Tabla.Nombre) + " AS '" + metrica.Nombre +"' ";
				// Mientras no sea el ultimo agregar la coma y el enter
				if(mets.IndexOf(metrica) < mets.Count - 1)
					listaMetricas += ",\n";
			}

			foreach(Filtro filtro in this.Filtros)
			{
				Atributo atributoFiltro = filtro.Atributo;

				string alias = atributoFiltro.AliasSql + this.tablaReporte.GetIdCamino(atributoFiltro);
				filtrosWhere += filtro.GetSql(alias) + "\n";

				if (this.Filtros.IndexOf(filtro) < this.Filtros.Count - 1)
				{
					filtrosWhere += "and ";
				}
				
			}


			string sql = "select\n";
			string fromTablaReporte = "from\n" + this.tablaReporte.DameFrom();
			string whereTablaReporte = this.tablaReporte.DameWhere();

			whereTablaReporte += !whereTablaReporte.Equals(string.Empty) && !filtrosWhere.Equals(string.Empty) ? "and " : string.Empty;

			whereTablaReporte += filtrosWhere;

//			if (this.Filtros.Count > 0)
//			{
//				fromTablaReporte += "and " + filtrosWhere;
//			}

			// Si no tiene Atributos es un reporte de solo metricas
			if (this.Atributos.Count == 0)
			{
				sql += listaMetricas + "\n" + fromTablaReporte + "\n";
				sql += !whereTablaReporte.Equals(string.Empty) ? "where\n" + whereTablaReporte : string.Empty;
				sql += ";";
			} // Si no tiene metricas es un reporte de solo atributos
			else if (this.Metricas.Count == 0)
			{
				sql += listaCamposConAlias + "\n" + fromTablaReporte + "\n";
				sql += !whereTablaReporte.Equals(string.Empty) ? "where\n" + whereTablaReporte : string.Empty;
				sql += "Group By\n" + listaCampos + ";";
			}
			else
			{
				sql += listaCamposConAlias + ",\n" + listaMetricas + "\n" + fromTablaReporte + "\n";
				sql += !whereTablaReporte.Equals(string.Empty) ? "where\n" + whereTablaReporte : string.Empty;
				sql += "Group By\n" + listaCampos + ";";
			}

			return sql;
		}

		#endregion

	}
}
