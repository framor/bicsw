using System.Collections;
using Bic.Domain.Catalogo;
using Bic.Domain.Exception;
using Bic.Domain.Interfaces;
using Bic.Framework;

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
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}
		

		#endregion

		#region Miembros privados
	
		private IList atributos = new ArrayList();
		private IList metricas = new ArrayList();
		private IList filtros = new ArrayList();
		private TablaReporte tablaReporte;

	
		#endregion		

		#region Metodos publicos

		public void AgregarAtributo(Atributo atributo)
		{
			this.atributos.Add(atributo);
		}


		public void AgregarMetrica(Metrica metrica)
		{
			this.metricas.Add(metrica);
		}


		public void AgregarFiltro(Filtro filtro)
		{
			this.filtros.Add(filtro);
		}


		public void GeneraConsulta()
		{
			ArrayList tablasReporte = new ArrayList();
			// Le pido las tablas candidatas a elegir - Son las que tienen todas las metricas
			ArrayList tablasFactCandidatas = this.DameTablasCandidatas();
			            
			foreach(Tabla tabla in tablasFactCandidatas)
			{
				try
				{
					//Creo el objeto TablaReporte con la tabla Fact destino y todos sus caminos
					TablaReporte tablaReporte = new TablaReporte(tabla,this.GeneraCaminos(tabla,this.atributos));

					// La agrego a la coleccion de tablasReporte, para ser tenidas en cuenta
					// por tener todos los caminos.
					tablasReporte.Add(tablaReporte);
				}
				catch (NoExisteCaminoException)
				{
                    
				}
			}

			// Verifico que aunque sea exista alguna alternativa de reporte
			if(tablasReporte.Count == 0)
				throw new ReporteInvalidoException("Imposible generar el reporte, no existe combinacion entre los atributos y las metricas seleccionadas");

			// Ordeno todas las alternativas por el comparador CompareTo
			// que elige la de menor peso.
			tablasReporte.Sort();
			
			// Tomo la primera y la agrego al reporte.
			this.tablaReporte = (TablaReporte)tablasReporte[0];

			return;

		}
		

		/// <summary>
		/// Genera todos los caminos entre los campos y la tabla fact
		/// </summary>
		/// <param name="tabla">Tabla Fact destino de caminos</param>
		/// <param name="campos">Campos de inicio de caminos</param>
		/// <returns>Devuelve un ArrayList con los caminos</returns>
		public ArrayList GeneraCaminos(Tabla tabla,IList campos)
		{
			ArrayList caminos = new ArrayList();
			//Por cada campo que cumpla con la interfaz TablaMapeable le pido que genere camino
			foreach(ICamino campo in campos)
			{	//TODO aca me llegaria la exepcion de que no hay camino desde el atributo
				try
				{
					caminos.Add(campo.GeneraCamino(tabla));
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


		public IList DameTablas(IList campos)
		{
			
			ArrayList tablas = new ArrayList();
			// Le pido a todos los campos que me den las tablas donde estan presentes
			foreach(ITablaMapeable campo in campos)
			{
				tablas.AddRange(campo.ObtenerTablas());//TODO todas las clases que tengan tablas pueden aparecer aca
				
			};
			
			// Con esta funcion quito los repetidos
			return Util.ConvertirSet(tablas);
		}


		public TablaReporte TablaReporte
		{
			get { return this.tablaReporte; }
		}


		public string DameSql()
		{
			string listaCampos ="";
			string listaMetricas = "";

			foreach(Atributo atrib in this.atributos)
			{
				string alias = atrib.TablaLookup.Nombre + this.tablaReporte.GetIdCamino(atrib);
				listaCampos += alias + "." + atrib.ColumnaId.Nombre;

				// Mientras no sea el ultimo agregar la coma y el enter
				if(this.atributos.IndexOf(atrib) < this.atributos.Count - 1)
					listaCampos += ",\n";

			}

			foreach(Metrica metrica in this.metricas)
			{
				// Le pido el nombre de la tabla Fact a la TablaReporte
				string alias = this.tablaReporte.Tabla.Nombre;
				listaMetricas += metrica.Funcion + "(" + alias + "." + metrica.Columna.Nombre + ")";
				// Mientras no sea el ultimo agregar la coma y el enter
				if(this.metricas.IndexOf(metrica) < this.metricas.Count - 1)
					listaMetricas += ",\n";
			}


			string sql = "select\n" + listaCampos + ",\n" + listaMetricas + this.tablaReporte.DameSql() + "Group By\n" + listaCampos + ";";

			return sql;
		}


		#endregion

	}
}
