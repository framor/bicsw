using ar.com.bic.domain;
using ar.com.bic.domain.catalogo;
using ar.com.bic.domain.exception;
using System.Collections;
using System;
using NUnit.Framework;

namespace test
{
	[TestFixture]
	public class ReporteTest
	{

		private Reporte reporte = new Reporte();
		private Hashtable tablasFact = new Hashtable();
		private Hashtable tablasLkp = new Hashtable();
		private Hashtable campos = new Hashtable();
		private Hashtable atributos = new Hashtable();
		private Hashtable metricas = new Hashtable();
		private Hashtable hechos = new Hashtable();

		public ReporteTest()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		#region Test

		[Test]
		public void Prueba()
		{
			//			IList lista1 = new ArrayList();
			//			SortedList lista2 = new SortedList();
			//
			//			String a = new String('a',2);
			//			String b = new String('b',2);
			//			String c = new String('c',2);
			//			String d = new String('d',2);
			//			String e = new String('e',2);
			//
			//			lista1.Add(b);
			//			Console.WriteLine(lista1.Count);
			//			lista1.Add(c);
			//			Console.WriteLine(lista1.Count);
			//			lista1.Add(e);
			//			Console.WriteLine(lista1.Count);
			//			lista1.Add(d);
			//			Console.WriteLine(lista1.Count);
			//			lista1.Add(a);
			//			Console.WriteLine(lista1.Count);
			//			lista1.Add(b);
			//			Console.WriteLine(lista1.Count);
			//			lista1.Add(c);
			//			Console.WriteLine(lista1.Count);
			//			lista1.Add(e);
			//			Console.WriteLine(lista1.Count);
			//			lista1.Add(d);
			//			Console.WriteLine(lista1.Count);
			//			lista1.Add(a);
			//			lista1.Add(b);
			//			lista1.Add(c);
			//			lista1.Add(e);
			//			lista1.Add(d);
			//			lista1.Add(a);
			//			lista1.Add(b);
			//			lista1.Add(c);
			//			lista1.Add(e);
			//			lista1.Add(d);
			//			lista1.Add(a);
			//
			//			lista2.Add(b,b);
			//			lista2.Add(c,c);
			//			lista2.Add(e,e);
			//			lista2.Add(d,d);
			//			lista2.Add(a,a);
			//
			//			lista2.TrimToSize();
			//
			//			foreach(String x in lista1)
			//			{
			//				Console.WriteLine(x);
			//			}
			//
			//			Console.WriteLine(lista1.Count + " " + lista1.IndexOf(a));
			//			Console.WriteLine(lista2.Count + " " + lista2.IndexOfValue(a));

			


		}


		[Test]
		[ExpectedException(typeof(NoExisteCaminoException))]
		public void GeneraCaminosException()
		{
			//Genero el ambiente
			this.LimpiarAmbiente();
			this.GenerarAmbiente2();

			IList atributos = new ArrayList();
			atributos.Add(this.atributos["Atributo a"]);
			// Esto deberia tirar una excepcion de que no existe ningun camino.
			this.reporte.GeneraCaminos((Tabla) this.tablasFact["Tabla Fact 1"],atributos);

		}


		[Test]
		public void DameTablasCandidatas()
		{

			//Genero el ambiente necesario
			this.LimpiarAmbiente();
			this.GenerarAmbiente1();


			//Agrego metricas al reporte

			this.reporte.AgregarMetrica((Metrica) this.metricas["Metrica a"]);
			this.reporte.AgregarMetrica((Metrica) this.metricas["Metrica j"]);
            
			//Le pido las tablas fact que tienen todas las metricas o sea las candidatas
			ArrayList tablasCandidatas = this.reporte.DameTablasCandidatas();
			
			//Verifico que se alla elegido bien las tablas candidatas
			Assert.Contains(this.tablasFact["Tabla Fact 1"],tablasCandidatas);
			Assert.Contains(this.tablasFact["Tabla Fact 3"],tablasCandidatas);
			Assert.Contains(this.tablasFact["Tabla Fact 5"],tablasCandidatas);

			//Verifico que no se allan elegido tablas que no tenian esas metricas

			Assert.IsFalse(tablasCandidatas.Contains(this.tablasFact["Tabla Fact 2"]));
			Assert.IsFalse(tablasCandidatas.Contains(this.tablasFact["Tabla Fact 4"]));
			Assert.IsFalse(tablasCandidatas.Contains(this.tablasFact["Tabla Fact 6"]));

		}


		[Test]
		[ExpectedException(typeof(NoExisteTablaCandidataException))]
		public void DameTablasCandidatasExcepcion()
		{
			// Genero el ambiente necesario
			this.LimpiarAmbiente();
			this.GenerarAmbiente1();
			
			//Agrego metricas al reporte

			this.reporte.AgregarMetrica((Metrica) this.metricas["Metrica a"]);
			this.reporte.AgregarMetrica((Metrica) this.metricas["Metrica j"]);
			this.reporte.AgregarMetrica((Metrica) this.metricas["Metrica e"]);

			// Esto deberia tirar una excepcion de que no hay tablas candidatas.
			this.reporte.DameTablasCandidatas();
		}
		

		#endregion

		#region Generadores de Ambientes

		public void LimpiarAmbiente()
		{
			this.reporte = new Reporte();
			this.tablasFact = new Hashtable();
			this.tablasLkp = new Hashtable();
			this.campos = new Hashtable();
			this.atributos = new Hashtable();
			this.metricas = new Hashtable();
			this.hechos = new Hashtable();
		}


		public void GenerarAmbiente1()
		{
			// Creo las tablas fact
			Tabla tablaFact1 = new Tabla("Tabla Fact 1","db","TablaFact1");
			Tabla tablaFact2 = new Tabla("Tabla Fact 2","db","TablaFact2");
			Tabla tablaFact3 = new Tabla("Tabla Fact 3","db","TablaFact3");
			Tabla tablaFact4 = new Tabla("Tabla Fact 4","db","TablaFact4");
			Tabla tablaFact5 = new Tabla("Tabla Fact 5","db","TablaFact5");
			Tabla tablaFact6 = new Tabla("Tabla Fact 6","db","TablaFact6");
			
			// Creo las columnas

			Columna columna1  = new Columna("campo_a","char",tablaFact1 );
			Columna columna2  = new Columna("campo_b","char",tablaFact1 );
			Columna columna3  = new Columna("campo_c","char",tablaFact1 );
			Columna columna4  = new Columna("campo_d","char",tablaFact1 );
			Columna columna5  = new Columna("campo_j","char",tablaFact1 );
			Columna columna6  = new Columna("campo_a","char",tablaFact2 );
			Columna columna7  = new Columna("campo_b","char",tablaFact2 );
			Columna columna8  = new Columna("campo_c","char",tablaFact2 );
			Columna columna9  = new Columna("campo_e","char",tablaFact2 );
			Columna columna10  = new Columna("campo_a","char",tablaFact3 );
			Columna columna11  = new Columna("campo_b","char",tablaFact3 );
			Columna columna12  = new Columna("campo_c","char",tablaFact3 );
			Columna columna13  = new Columna("campo_f","char",tablaFact3 );
			Columna columna14  = new Columna("campo_j","char",tablaFact3 );
			Columna columna15  = new Columna("campo_a","char",tablaFact4 );
			Columna columna16  = new Columna("campo_b","char",tablaFact4 );
			Columna columna17  = new Columna("campo_c","char",tablaFact4 );
			Columna columna18  = new Columna("campo_g","char",tablaFact4 );
			Columna columna19  = new Columna("campo_a","char",tablaFact5 );
			Columna columna20  = new Columna("campo_b","char",tablaFact5 );
			Columna columna21  = new Columna("campo_c","char",tablaFact5 );
			Columna columna22  = new Columna("campo_h","char",tablaFact5 );
			Columna columna23  = new Columna("campo_j","char",tablaFact5 );
			Columna columna24  = new Columna("campo_a","char",tablaFact6 );
			Columna columna25  = new Columna("campo_b","char",tablaFact6 );
			Columna columna26  = new Columna("campo_c","char",tablaFact6 );
			Columna columna27  = new Columna("campo_i","char",tablaFact6 );

			// Creo los campos con las columnas

			Campo campo_a = new Campo(columna1);
			Campo campo_b = new Campo(columna2);
			Campo campo_c = new Campo(columna3);
			Campo campo_d = new Campo(columna4);
			Campo campo_e = new Campo(columna9);
			Campo campo_f = new Campo(columna13);
			Campo campo_g = new Campo(columna18);
			Campo campo_h = new Campo(columna22);
			Campo campo_i = new Campo(columna27);
			Campo campo_j = new Campo(columna5);
			
			// Agrego el resto de las columnas a los campos del mismo nombre

			campo_a.AgregarColumnas(columna6);
			campo_a.AgregarColumnas(columna10);
			campo_a.AgregarColumnas(columna15);
			campo_a.AgregarColumnas(columna19);
			campo_a.AgregarColumnas(columna24);
			
			campo_b.AgregarColumnas(columna7);
			campo_b.AgregarColumnas(columna11);
			campo_b.AgregarColumnas(columna16);
			campo_b.AgregarColumnas(columna20);
			campo_b.AgregarColumnas(columna25);
			
			campo_c.AgregarColumnas(columna8);
			campo_c.AgregarColumnas(columna12);
			campo_c.AgregarColumnas(columna17);
			campo_c.AgregarColumnas(columna21);
			campo_c.AgregarColumnas(columna26);
			
			campo_j.AgregarColumnas(columna14);
			campo_j.AgregarColumnas(columna23);

			// Agrego las columnas a sus correspondientes tablas

			tablaFact1.AgregarColumna(columna1); 
			tablaFact1.AgregarColumna(columna2); 
			tablaFact1.AgregarColumna(columna3); 
			tablaFact1.AgregarColumna(columna4); 
			tablaFact1.AgregarColumna(columna5); 
			
			tablaFact2.AgregarColumna(columna6); 
			tablaFact2.AgregarColumna(columna7); 
			tablaFact2.AgregarColumna(columna8); 
			tablaFact2.AgregarColumna(columna9); 
			
			tablaFact3.AgregarColumna(columna10);
			tablaFact3.AgregarColumna(columna11);
			tablaFact3.AgregarColumna(columna12);
			tablaFact3.AgregarColumna(columna13);
			tablaFact3.AgregarColumna(columna14);
			
			tablaFact4.AgregarColumna(columna15);
			tablaFact4.AgregarColumna(columna16);
			tablaFact4.AgregarColumna(columna17);
			tablaFact4.AgregarColumna(columna18);
			
			tablaFact5.AgregarColumna(columna19);
			tablaFact5.AgregarColumna(columna20);
			tablaFact5.AgregarColumna(columna21);
			tablaFact5.AgregarColumna(columna22);
			tablaFact5.AgregarColumna(columna23);
			
			tablaFact6.AgregarColumna(columna24);
			tablaFact6.AgregarColumna(columna25);
			tablaFact6.AgregarColumna(columna26);
			tablaFact6.AgregarColumna(columna27);

			// Creo los hechos en base a las campos

			Hecho hecho_a = new Hecho("Hecho a",campo_a);
			Hecho hecho_b = new Hecho("Hecho b",campo_b);
			Hecho hecho_c = new Hecho("Hecho c",campo_c);
			Hecho hecho_d = new Hecho("Hecho d",campo_d);
			Hecho hecho_e = new Hecho("Hecho e",campo_e);
			Hecho hecho_f = new Hecho("Hecho f",campo_f);
			Hecho hecho_g = new Hecho("Hecho g",campo_g);
			Hecho hecho_h = new Hecho("Hecho h",campo_h);
			Hecho hecho_i = new Hecho("Hecho i",campo_i);
			Hecho hecho_j = new Hecho("Hecho j",campo_j);

			// Creo las metricas de esos echos para el reporte

			Metrica metrica_a = new Metrica("Metrica a","sum",hecho_a);
			Metrica metrica_b = new Metrica("Metrica b","sum",hecho_b);
			Metrica metrica_c = new Metrica("Metrica c","sum",hecho_c);
			Metrica metrica_d = new Metrica("Metrica d","sum",hecho_d);
			Metrica metrica_e = new Metrica("Metrica e","sum",hecho_e);
			Metrica metrica_f = new Metrica("Metrica f","sum",hecho_f);
			Metrica metrica_g = new Metrica("Metrica g","sum",hecho_g);
			Metrica metrica_h = new Metrica("Metrica h","sum",hecho_h);
			Metrica metrica_i = new Metrica("Metrica i","sum",hecho_i);
			Metrica metrica_j = new Metrica("Metrica j","sum",hecho_j);

			// Agrego todos los componentes al test
			// Agrego las tablas

			this.tablasFact.Add("Tabla Fact 1",tablaFact1);
			this.tablasFact.Add("Tabla Fact 2",tablaFact2);
			this.tablasFact.Add("Tabla Fact 3",tablaFact3);
			this.tablasFact.Add("Tabla Fact 4",tablaFact4);
			this.tablasFact.Add("Tabla Fact 5",tablaFact5);
			this.tablasFact.Add("Tabla Fact 6",tablaFact6);

			// Agrego los campos

			this.campos.Add("campo_a",campo_a);
			this.campos.Add("campo_b",campo_b);
			this.campos.Add("campo_c",campo_c);
			this.campos.Add("campo_d",campo_d);
			this.campos.Add("campo_e",campo_e);
			this.campos.Add("campo_f",campo_f);
			this.campos.Add("campo_g",campo_g);
			this.campos.Add("campo_h",campo_h);
			this.campos.Add("campo_i",campo_i);
			this.campos.Add("campo_j",campo_j);

			// Agrego los hechos

			this.hechos.Add("Hecho a",hecho_a);
			this.hechos.Add("Hecho b",hecho_b);
			this.hechos.Add("Hecho c",hecho_c);
			this.hechos.Add("Hecho d",hecho_d);
			this.hechos.Add("Hecho e",hecho_e);
			this.hechos.Add("Hecho f",hecho_f);
			this.hechos.Add("Hecho g",hecho_g);
			this.hechos.Add("Hecho h",hecho_h);
			this.hechos.Add("Hecho i",hecho_i);
			this.hechos.Add("Hecho j",hecho_j);

			// Agrego las metricas

			this.metricas.Add("Metrica a",metrica_a);
			this.metricas.Add("Metrica b",metrica_b);
			this.metricas.Add("Metrica c",metrica_c);
			this.metricas.Add("Metrica d",metrica_d);
			this.metricas.Add("Metrica e",metrica_e);
			this.metricas.Add("Metrica f",metrica_f);
			this.metricas.Add("Metrica g",metrica_g);
			this.metricas.Add("Metrica h",metrica_h);
			this.metricas.Add("Metrica i",metrica_i);
			this.metricas.Add("Metrica j",metrica_j);




		}


		public void GenerarAmbiente2()
		{
			// Creo las tablas
			Tabla tablaFact1 = new Tabla("Tabla Fact 1","db","TablaFact1");
			Tabla tablaFact2 = new Tabla("Tabla Fact 2","db","TablaFact2");
			Tabla tablaLkp1 = new Tabla("Tabla Lkp 1","db","TablaLkp1");

			// Creo las columnas

			Columna columna1  = new Columna("campo_a","char",tablaFact1 );
			Columna columna2  = new Columna("campo_b","char",tablaFact1 );
			Columna columna3  = new Columna("campo_c","char",tablaFact1 );
			Columna columna4  = new Columna("campo_d","char",tablaFact1 );
			Columna columna5  = new Columna("campo_j","char",tablaFact1 );
			Columna columna6  = new Columna("campo_a","char",tablaFact2 );
			Columna columna7  = new Columna("campo_b","char",tablaFact2 );
			Columna columna8  = new Columna("campo_c","char",tablaFact2 );
			Columna columna9  = new Columna("campo_e","char",tablaFact2 );

			Columna columnaLkp1  = new Columna("campoLkp_a","char",tablaLkp1 );

			// Creo los campos con las columnas

			Campo campo_a = new Campo(columna1);
			Campo campo_b = new Campo(columna2);
			Campo campo_c = new Campo(columna3);
			Campo campo_d = new Campo(columna4);
			Campo campo_e = new Campo(columna9);
			Campo campo_j = new Campo(columna5);

			Campo campoLkp_a = new Campo(columnaLkp1);
		
			// Agrego el resto de las columnas a los campos del mismo nombre

			campo_a.AgregarColumnas(columna6);
			campo_b.AgregarColumnas(columna7);
			campo_c.AgregarColumnas(columna8);
			
			// Agrego las columnas a sus correspondientes tablas

			tablaFact1.AgregarColumna(columna1); 
			tablaFact1.AgregarColumna(columna2); 
			tablaFact1.AgregarColumna(columna3); 
			tablaFact1.AgregarColumna(columna4); 
			tablaFact1.AgregarColumna(columna5); 
			
			tablaFact2.AgregarColumna(columna6); 
			tablaFact2.AgregarColumna(columna7); 
			tablaFact2.AgregarColumna(columna8); 
			tablaFact2.AgregarColumna(columna9); 

			tablaLkp1.AgregarColumna(columnaLkp1);

			// Creo el atributo en base a el campo

			Atributo atributo_a = new Atributo("Atributo a",campoLkp_a,tablaLkp1,null);
			
			// Creo los hechos en base a las campos

			Hecho hecho_a = new Hecho("Hecho a",campo_a);
			Hecho hecho_b = new Hecho("Hecho b",campo_b);
			Hecho hecho_c = new Hecho("Hecho c",campo_c);
			Hecho hecho_d = new Hecho("Hecho d",campo_d);
			Hecho hecho_e = new Hecho("Hecho e",campo_e);
			Hecho hecho_j = new Hecho("Hecho j",campo_j);

			// Creo las metricas de esos echos para el reporte

			Metrica metrica_a = new Metrica("Metrica a","sum",hecho_a);
			Metrica metrica_b = new Metrica("Metrica b","sum",hecho_b);
			Metrica metrica_c = new Metrica("Metrica c","sum",hecho_c);
			Metrica metrica_d = new Metrica("Metrica d","sum",hecho_d);
			Metrica metrica_e = new Metrica("Metrica e","sum",hecho_e);
			Metrica metrica_j = new Metrica("Metrica j","sum",hecho_j);

			// Agrego las tablas
			this.tablasFact.Add("Tabla Fact 1",tablaFact1);
			this.tablasFact.Add("Tabla Fact 2",tablaFact2);
			this.tablasLkp.Add("Tabla Lkp 1",tablaLkp1);

			// Agrego los campos
			this.campos.Add("campo_a",campo_a);
			this.campos.Add("campo_b",campo_b);
			this.campos.Add("campo_c",campo_c);
			this.campos.Add("campo_d",campo_d);
			this.campos.Add("campo_e",campo_e);
			this.campos.Add("campo_j",campo_j);

			// Agrego los atributos
			this.atributos.Add("Atributo a",atributo_a);

			// Agrego los hechos
			this.hechos.Add("Hecho a",hecho_a);
			this.hechos.Add("Hecho b",hecho_b);
			this.hechos.Add("Hecho c",hecho_c);
			this.hechos.Add("Hecho d",hecho_d);
			this.hechos.Add("Hecho e",hecho_e);
			this.hechos.Add("Hecho j",hecho_j);

			// Agrego las metricas
			this.metricas.Add("Metrica a",metrica_a);
			this.metricas.Add("Metrica b",metrica_b);
			this.metricas.Add("Metrica c",metrica_c);
			this.metricas.Add("Metrica d",metrica_d);
			this.metricas.Add("Metrica e",metrica_e);
			this.metricas.Add("Metrica j",metrica_j);



		}

		#endregion
	}
}
