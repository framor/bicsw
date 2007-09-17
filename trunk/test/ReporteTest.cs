//using ar.com.bic.domain;
//using ar.com.bic.domain.catalogo;
//using ar.com.bic.domain.exception;
//using System.Collections;
//using System;
//using NUnit.Framework;
//
//namespace test
//{
//	[TestFixture]
//	public class ReporteTest
//	{
//
//		private Reporte reporte = new Reporte();
//		private Hashtable tablasFact = new Hashtable();
//		private Hashtable tablasLkp = new Hashtable();
//		private Hashtable campos = new Hashtable();
//		private Hashtable atributos = new Hashtable();
//		private Hashtable metricas = new Hashtable();
//		private Hashtable hechos = new Hashtable();
//
//		public ReporteTest()
//		{
//			//
//			// TODO: agregar aquí la lógica del constructor
//			//
//		}
//
//		#region Test
//
//		[Test]
//		public void GeneraConsulta()
//		{
//			//Genero el ambiente
//			this.LimpiarAmbiente();
//			this.GenerarAmbiente3();
//
//			IList atributos = new ArrayList();
//
//			//Agrego los atributos al reporte
//
//			this.reporte.AgregarAtributo((Atributo)this.atributos["Atributo d"]);
//			this.reporte.AgregarAtributo((Atributo)this.atributos["Atributo c"]);
//
//			//Agrego metricas al reporte
//
//			this.reporte.AgregarMetrica((Metrica) this.metricas["Metrica a"]);
//			this.reporte.AgregarMetrica((Metrica) this.metricas["Metrica c"]);
//
//			this.reporte.GeneraConsulta();
//
//			Assert.AreSame(this.tablasFact["Tabla Fact 2"],this.reporte.TablaReporte.Tabla);
//
//			Console.WriteLine(this.reporte.TablaReporte.DameSql());
//
//		}
//
//		[Test]
//		[ExpectedException(typeof(NoExisteCaminoException))]
//		public void GeneraCaminosException()
//		{
//			//Genero el ambiente
//			this.LimpiarAmbiente();
//			this.GenerarAmbiente2();
//
//			IList atributos = new ArrayList();
//			atributos.Add(this.atributos["Atributo a"]);
//			// Esto deberia tirar una excepcion de que no existe ningun camino.
//			this.reporte.GeneraCaminos((Tabla) this.tablasFact["Tabla Fact 1"],atributos);
//
//		}
//
//
//		[Test]
//		public void DameTablasCandidatas()
//		{
//
//			//Genero el ambiente necesario
//			this.LimpiarAmbiente();
//			this.GenerarAmbiente1();
//
//
//			//Agrego metricas al reporte
//
//			this.reporte.AgregarMetrica((Metrica) this.metricas["Metrica a"]);
//			this.reporte.AgregarMetrica((Metrica) this.metricas["Metrica j"]);
//            
//			//Le pido las tablas fact que tienen todas las metricas o sea las candidatas
//			ArrayList tablasCandidatas = this.reporte.DameTablasCandidatas();
//			
//			//Verifico que se alla elegido bien las tablas candidatas
//			Assert.Contains(this.tablasFact["Tabla Fact 1"],tablasCandidatas);
//			Assert.Contains(this.tablasFact["Tabla Fact 3"],tablasCandidatas);
//			Assert.Contains(this.tablasFact["Tabla Fact 5"],tablasCandidatas);
//
//			//Verifico que no se allan elegido tablas que no tenian esas metricas
//
//			Assert.IsFalse(tablasCandidatas.Contains(this.tablasFact["Tabla Fact 2"]));
//			Assert.IsFalse(tablasCandidatas.Contains(this.tablasFact["Tabla Fact 4"]));
//			Assert.IsFalse(tablasCandidatas.Contains(this.tablasFact["Tabla Fact 6"]));
//
//		}
//
//
//		[Test]
//		[ExpectedException(typeof(NoExisteTablaCandidataException))]
//		public void DameTablasCandidatasExcepcion()
//		{
//			// Genero el ambiente necesario
//			this.LimpiarAmbiente();
//			this.GenerarAmbiente1();
//			
//			//Agrego metricas al reporte
//
//			this.reporte.AgregarMetrica((Metrica) this.metricas["Metrica a"]);
//			this.reporte.AgregarMetrica((Metrica) this.metricas["Metrica j"]);
//			this.reporte.AgregarMetrica((Metrica) this.metricas["Metrica e"]);
//
//			// Esto deberia tirar una excepcion de que no hay tablas candidatas.
//			this.reporte.DameTablasCandidatas();
//		}
//		
//
//		#endregion
//
//		#region Generadores de Ambientes
//
//		public void LimpiarAmbiente()
//		{
//			this.reporte = new Reporte();
//			this.tablasFact = new Hashtable();
//			this.tablasLkp = new Hashtable();
//			this.campos = new Hashtable();
//			this.atributos = new Hashtable();
//			this.metricas = new Hashtable();
//			this.hechos = new Hashtable();
//		}
//
//
//		public void GenerarAmbiente1()
//		{
//			// Creo las tablas fact
//			Tabla tablaFact1 = new Tabla("Tabla Fact 1","db","TablaFact1");
//			Tabla tablaFact2 = new Tabla("Tabla Fact 2","db","TablaFact2");
//			Tabla tablaFact3 = new Tabla("Tabla Fact 3","db","TablaFact3");
//			Tabla tablaFact4 = new Tabla("Tabla Fact 4","db","TablaFact4");
//			Tabla tablaFact5 = new Tabla("Tabla Fact 5","db","TablaFact5");
//			Tabla tablaFact6 = new Tabla("Tabla Fact 6","db","TablaFact6");
//			
//			// Creo las columnas
//
//			Columna columna1  = new Columna("campo_a","char");
//			Columna columna2  = new Columna("campo_b","char");
//			Columna columna3  = new Columna("campo_c","char");
//			Columna columna4  = new Columna("campo_d","char");
//			Columna columna5  = new Columna("campo_j","char");
//			Columna columna6  = new Columna("campo_a","char");
//			Columna columna7  = new Columna("campo_b","char");
//			Columna columna8  = new Columna("campo_c","char");
//			Columna columna9  = new Columna("campo_e","char");
//			Columna columna10  = new Columna("campo_a","char");
//			Columna columna11  = new Columna("campo_b","char");
//			Columna columna12  = new Columna("campo_c","char");
//			Columna columna13  = new Columna("campo_f","char");
//			Columna columna14  = new Columna("campo_j","char");
//			Columna columna15  = new Columna("campo_a","char");
//			Columna columna16  = new Columna("campo_b","char");
//			Columna columna17  = new Columna("campo_c","char");
//			Columna columna18  = new Columna("campo_g","char");
//			Columna columna19  = new Columna("campo_a","char");
//			Columna columna20  = new Columna("campo_b","char");
//			Columna columna21  = new Columna("campo_c","char");
//			Columna columna22  = new Columna("campo_h","char");
//			Columna columna23  = new Columna("campo_j","char");
//			Columna columna24  = new Columna("campo_a","char");
//			Columna columna25  = new Columna("campo_b","char");
//			Columna columna26  = new Columna("campo_c","char");
//			Columna columna27  = new Columna("campo_i","char");
//
//			// Agrego las columnas a sus correspondientes tablas
//
//			tablaFact1.AgregarColumna(columna1); 
//			tablaFact1.AgregarColumna(columna2); 
//			tablaFact1.AgregarColumna(columna3); 
//			tablaFact1.AgregarColumna(columna4); 
//			tablaFact1.AgregarColumna(columna5); 
//			
//			tablaFact2.AgregarColumna(columna6); 
//			tablaFact2.AgregarColumna(columna7); 
//			tablaFact2.AgregarColumna(columna8); 
//			tablaFact2.AgregarColumna(columna9); 
//			
//			tablaFact3.AgregarColumna(columna10);
//			tablaFact3.AgregarColumna(columna11);
//			tablaFact3.AgregarColumna(columna12);
//			tablaFact3.AgregarColumna(columna13);
//			tablaFact3.AgregarColumna(columna14);
//			
//			tablaFact4.AgregarColumna(columna15);
//			tablaFact4.AgregarColumna(columna16);
//			tablaFact4.AgregarColumna(columna17);
//			tablaFact4.AgregarColumna(columna18);
//			
//			tablaFact5.AgregarColumna(columna19);
//			tablaFact5.AgregarColumna(columna20);
//			tablaFact5.AgregarColumna(columna21);
//			tablaFact5.AgregarColumna(columna22);
//			tablaFact5.AgregarColumna(columna23);
//			
//			tablaFact6.AgregarColumna(columna24);
//			tablaFact6.AgregarColumna(columna25);
//			tablaFact6.AgregarColumna(columna26);
//			tablaFact6.AgregarColumna(columna27);
//
//			// Creo los hechos en base a las campos
//
//			Hecho hecho_a = new Hecho("Hecho a",columna1);
//			Hecho hecho_b = new Hecho("Hecho b",columna2);
//			Hecho hecho_c = new Hecho("Hecho c",columna3);
//			Hecho hecho_d = new Hecho("Hecho d",columna4;
//			Hecho hecho_e = new Hecho("Hecho e",columna5);
//			Hecho hecho_f = new Hecho("Hecho f",columna6);
//			Hecho hecho_g = new Hecho("Hecho g",columna7);
//			Hecho hecho_h = new Hecho("Hecho h",columna8);
//			Hecho hecho_i = new Hecho("Hecho i",columna9;
//			Hecho hecho_j = new Hecho("Hecho j",columna10);
//
//			// Creo las metricas de esos echos para el reporte
//
//			Metrica metrica_a = new Metrica("Metrica a","sum",hecho_a);
//			Metrica metrica_b = new Metrica("Metrica b","sum",hecho_b);
//			Metrica metrica_c = new Metrica("Metrica c","sum",hecho_c);
//			Metrica metrica_d = new Metrica("Metrica d","sum",hecho_d);
//			Metrica metrica_e = new Metrica("Metrica e","sum",hecho_e);
//			Metrica metrica_f = new Metrica("Metrica f","sum",hecho_f);
//			Metrica metrica_g = new Metrica("Metrica g","sum",hecho_g);
//			Metrica metrica_h = new Metrica("Metrica h","sum",hecho_h);
//			Metrica metrica_i = new Metrica("Metrica i","sum",hecho_i);
//			Metrica metrica_j = new Metrica("Metrica j","sum",hecho_j);
//
//			// Agrego todos los componentes al test
//			// Agrego las tablas
//
//			this.tablasFact.Add("Tabla Fact 1",tablaFact1);
//			this.tablasFact.Add("Tabla Fact 2",tablaFact2);
//			this.tablasFact.Add("Tabla Fact 3",tablaFact3);
//			this.tablasFact.Add("Tabla Fact 4",tablaFact4);
//			this.tablasFact.Add("Tabla Fact 5",tablaFact5);
//			this.tablasFact.Add("Tabla Fact 6",tablaFact6);
//
//
//			// Agrego los hechos
//
//			this.hechos.Add("Hecho a",hecho_a);
//			this.hechos.Add("Hecho b",hecho_b);
//			this.hechos.Add("Hecho c",hecho_c);
//			this.hechos.Add("Hecho d",hecho_d);
//			this.hechos.Add("Hecho e",hecho_e);
//			this.hechos.Add("Hecho f",hecho_f);
//			this.hechos.Add("Hecho g",hecho_g);
//			this.hechos.Add("Hecho h",hecho_h);
//			this.hechos.Add("Hecho i",hecho_i);
//			this.hechos.Add("Hecho j",hecho_j);
//
//			// Agrego las metricas
//
//			this.metricas.Add("Metrica a",metrica_a);
//			this.metricas.Add("Metrica b",metrica_b);
//			this.metricas.Add("Metrica c",metrica_c);
//			this.metricas.Add("Metrica d",metrica_d);
//			this.metricas.Add("Metrica e",metrica_e);
//			this.metricas.Add("Metrica f",metrica_f);
//			this.metricas.Add("Metrica g",metrica_g);
//			this.metricas.Add("Metrica h",metrica_h);
//			this.metricas.Add("Metrica i",metrica_i);
//			this.metricas.Add("Metrica j",metrica_j);
//
//
//
//
//		}
//
//
//		public void GenerarAmbiente2()
//		{
//			// Creo las tablas
//			Tabla tablaFact1 = new Tabla("Tabla Fact 1","db","TablaFact1");
//			Tabla tablaFact2 = new Tabla("Tabla Fact 2","db","TablaFact2");
//			Tabla tablaLkp1 = new Tabla("Tabla Lkp 1","db","TablaLkp1");
//
//			// Creo las columnas
//
//			Columna columna1  = new Columna("campo_a","char");
//			Columna columna2  = new Columna("campo_b","char");
//			Columna columna3  = new Columna("campo_c","char");
//			Columna columna4  = new Columna("campo_d","char");
//			Columna columna5  = new Columna("campo_j","char");
//			Columna columna6  = new Columna("campo_a","char");
//			Columna columna7  = new Columna("campo_b","char");
//			Columna columna8  = new Columna("campo_c","char");
//			Columna columna9  = new Columna("campo_e","char");
//
//			Columna columnaLkp1  = new Columna("campoLkp_a","char",tablaLkp1 );
//
//			// Creo los campos con las columnas
//
//			Campo campo_a = new Campo(columna1);
//			Campo campo_b = new Campo(columna2);
//			Campo campo_c = new Campo(columna3);
//			Campo campo_d = new Campo(columna4);
//			Campo campo_e = new Campo(columna9);
//			Campo campo_j = new Campo(columna5);
//
//			Campo campoLkp_a = new Campo(columnaLkp1);
//		
//			// Agrego el resto de las columnas a los campos del mismo nombre
//
//			campo_a.AgregarColumnas(columna6);
//			campo_b.AgregarColumnas(columna7);
//			campo_c.AgregarColumnas(columna8);
//			
//			// Agrego las columnas a sus correspondientes tablas
//
//			tablaFact1.AgregarColumna(columna1); 
//			tablaFact1.AgregarColumna(columna2); 
//			tablaFact1.AgregarColumna(columna3); 
//			tablaFact1.AgregarColumna(columna4); 
//			tablaFact1.AgregarColumna(columna5); 
//			
//			tablaFact2.AgregarColumna(columna6); 
//			tablaFact2.AgregarColumna(columna7); 
//			tablaFact2.AgregarColumna(columna8); 
//			tablaFact2.AgregarColumna(columna9); 
//
//			tablaLkp1.AgregarColumna(columnaLkp1);
//
//			// Creo el atributo en base a el campo
//
//			Atributo atributo_a = new Atributo("Atributo a",campoLkp_a,tablaLkp1,null);
//			
//			// Creo los hechos en base a las campos
//
//			Hecho hecho_a = new Hecho("Hecho a",campo_a);
//			Hecho hecho_b = new Hecho("Hecho b",campo_b);
//			Hecho hecho_c = new Hecho("Hecho c",campo_c);
//			Hecho hecho_d = new Hecho("Hecho d",campo_d);
//			Hecho hecho_e = new Hecho("Hecho e",campo_e);
//			Hecho hecho_j = new Hecho("Hecho j",campo_j);
//
//			// Creo las metricas de esos echos para el reporte
//
//			Metrica metrica_a = new Metrica("Metrica a","sum",hecho_a);
//			Metrica metrica_b = new Metrica("Metrica b","sum",hecho_b);
//			Metrica metrica_c = new Metrica("Metrica c","sum",hecho_c);
//			Metrica metrica_d = new Metrica("Metrica d","sum",hecho_d);
//			Metrica metrica_e = new Metrica("Metrica e","sum",hecho_e);
//			Metrica metrica_j = new Metrica("Metrica j","sum",hecho_j);
//
//			// Agrego las tablas
//			this.tablasFact.Add("Tabla Fact 1",tablaFact1);
//			this.tablasFact.Add("Tabla Fact 2",tablaFact2);
//			this.tablasLkp.Add("Tabla Lkp 1",tablaLkp1);
//
//			// Agrego los campos
//			this.campos.Add("campo_a",campo_a);
//			this.campos.Add("campo_b",campo_b);
//			this.campos.Add("campo_c",campo_c);
//			this.campos.Add("campo_d",campo_d);
//			this.campos.Add("campo_e",campo_e);
//			this.campos.Add("campo_j",campo_j);
//
//			// Agrego los atributos
//			this.atributos.Add("Atributo a",atributo_a);
//
//			// Agrego los hechos
//			this.hechos.Add("Hecho a",hecho_a);
//			this.hechos.Add("Hecho b",hecho_b);
//			this.hechos.Add("Hecho c",hecho_c);
//			this.hechos.Add("Hecho d",hecho_d);
//			this.hechos.Add("Hecho e",hecho_e);
//			this.hechos.Add("Hecho j",hecho_j);
//
//			// Agrego las metricas
//			this.metricas.Add("Metrica a",metrica_a);
//			this.metricas.Add("Metrica b",metrica_b);
//			this.metricas.Add("Metrica c",metrica_c);
//			this.metricas.Add("Metrica d",metrica_d);
//			this.metricas.Add("Metrica e",metrica_e);
//			this.metricas.Add("Metrica j",metrica_j);
//
//
//
//		}
//
//
//		public void GenerarAmbiente3()
//		{
//			// Creo las tablas
//			Tabla tablaFact1 = new Tabla("Tabla Fact 1","TablaFact1","db");
//			Tabla tablaFact2 = new Tabla("Tabla Fact 2","TablaFact2","db");
//			Tabla tablaFact3 = new Tabla("Tabla Fact 3","TablaFact3","db");
//			Tabla tablaLkp1 = new Tabla("Tabla Lkp 1","TablaLkp1","db");
//			Tabla tablaLkp2 = new Tabla("Tabla Lkp 2","TablaLkp2","db");
//			Tabla tablaLkp3 = new Tabla("Tabla Lkp 3","TablaLkp3","db");
//			Tabla tablaLkp4 = new Tabla("Tabla Lkp 4","TablaLkp4","db");
//			Tabla tablaLkp5 = new Tabla("Tabla Lkp 5","TablaLkp5","db");
//			Tabla tablaLkp6 = new Tabla("Tabla Lkp 6","TablaLkp6","db");
//
//			// Le asigno el peso
//
//			tablaFact1.Peso = 50;
//			tablaFact2.Peso = 30;
//			tablaFact3.Peso = 10;
//
//			// Creo las columnas
//
//			Columna columna1  = new Columna("campo_a","char");
//			Columna columna2  = new Columna("campo_b","char");
//			Columna columna3  = new Columna("campo_c","char");
//			Columna columna4  = new Columna("campo_d","char");
//			Columna columna5  = new Columna("campo_j","char");
//			Columna columna6  = new Columna("campo_a","char",tablaFact2 );
//			Columna columna7  = new Columna("campo_b","char",tablaFact2 );
//			Columna columna8  = new Columna("campo_c","char",tablaFact2 );
//			Columna columna9  = new Columna("campo_e","char");
//			Columna columna10  = new Columna("campo_a","char");
//
//			Columna columnaLkp1  = new Columna("campoLkp_a","char",tablaLkp1 );
//			Columna columnaLkp2  = new Columna("campoLkp_b","char",tablaLkp2 );
//			Columna columnaLkp3  = new Columna("campoLkp_c","char",tablaLkp3 );
//			Columna columnaLkp4  = new Columna("campoLkp_d","char",tablaLkp4 );
//			Columna columnaLkp5  = new Columna("campoLkp_e","char",tablaLkp5 );
//			Columna columnaLkp6  = new Columna("campoLkp_f","char",tablaLkp6 );
//
//			// creo la columna que relaciona las lkps 5-4 y 6-3.
//			Columna columnaLkp7  = new Columna("campoLkp_c","char",tablaLkp6 );
//			Columna columnaLkp8  = new Columna("campoLkp_d","char",tablaLkp5 );
//
//			// Creo la columna en la fact que se relaciona con las lkps
//			Columna columnaFact1  = new Columna("campoLkp_e","char",tablaFact1);
//			Columna columnaFact2  = new Columna("campoLkp_f","char",tablaFact1);
//			Columna columnaFact3  = new Columna("campoLkp_e","char",tablaFact2);
//			Columna columnaFact4  = new Columna("campoLkp_f","char",tablaFact2);
//
//			// Creo los campos con las columnas
//
//			Campo campo_a = new Campo(columna1);
//			Campo campo_b = new Campo(columna2);
//			Campo campo_c = new Campo(columna3);
//			Campo campo_d = new Campo(columna4);
//			Campo campo_e = new Campo(columna9);
//			Campo campo_j = new Campo(columna5);
//
//			Campo campoLkp_a = new Campo(columnaLkp1);
//			Campo campoLkp_b = new Campo(columnaLkp2);
//			Campo campoLkp_c = new Campo(columnaLkp3);
//			Campo campoLkp_d = new Campo(columnaLkp4);
//			Campo campoLkp_e = new Campo(columnaLkp5);
//			Campo campoLkp_f = new Campo(columnaLkp6);
//		
//			// Agrego el resto de las columnas a los campos del mismo nombre
//
//			campo_a.AgregarColumnas(columna6);
//			campo_a.AgregarColumnas(columna10);
//			campo_b.AgregarColumnas(columna7);
//			campo_c.AgregarColumnas(columna8);
//			campoLkp_e.AgregarColumnas(columnaFact1);
//			campoLkp_e.AgregarColumnas(columnaFact3);
//			campoLkp_f.AgregarColumnas(columnaFact2);
//			campoLkp_f.AgregarColumnas(columnaFact4);
//			campoLkp_c.AgregarColumnas(columnaLkp7);
//			campoLkp_d.AgregarColumnas(columnaLkp8);
//			
//			// Agrego las columnas a sus correspondientes tablas
//
//			tablaFact1.AgregarColumna(columna1); 
//			tablaFact1.AgregarColumna(columna2); 
//			tablaFact1.AgregarColumna(columna3); 
//			tablaFact1.AgregarColumna(columna4); 
//			tablaFact1.AgregarColumna(columna5); 
//			tablaFact1.AgregarColumna(columnaFact1);
//			tablaFact1.AgregarColumna(columnaFact2);
//			
//			tablaFact2.AgregarColumna(columna6); 
//			tablaFact2.AgregarColumna(columna7); 
//			tablaFact2.AgregarColumna(columna8); 
//			tablaFact2.AgregarColumna(columna9); 
//			tablaFact2.AgregarColumna(columnaFact3); 
//			tablaFact2.AgregarColumna(columnaFact4); 
//
//			tablaFact3.AgregarColumna(columna10);
//
//			tablaLkp1.AgregarColumna(columnaLkp1);
//			tablaLkp2.AgregarColumna(columnaLkp2);
//			tablaLkp3.AgregarColumna(columnaLkp3);
//			tablaLkp4.AgregarColumna(columnaLkp4);
//			tablaLkp5.AgregarColumna(columnaLkp5);
//			tablaLkp6.AgregarColumna(columnaLkp6);
//			tablaLkp5.AgregarColumna(columnaLkp8);
//			tablaLkp6.AgregarColumna(columnaLkp7);
//
//			// Creo el atributo en base a el campo
//
//			Atributo atributo_a = new Atributo("Atributo a",campoLkp_a,tablaLkp1,null);
//			Atributo atributo_b = new Atributo("Atributo b",campoLkp_b,tablaLkp2,null);
//			Atributo atributo_c = new Atributo("Atributo c",campoLkp_c,tablaLkp3,null);
//			Atributo atributo_d = new Atributo("Atributo d",campoLkp_d,tablaLkp4,null);
//			
//			// Creo atributos que tengan como campo_id uno que este en la fact
//			Atributo atributo_e = new Atributo("Atributo e",campoLkp_e,tablaLkp5,null);
//			Atributo atributo_f = new Atributo("Atributo f",campoLkp_f,tablaLkp6,null);
//
//			// Agrego los padres y los hijos.
//
//			//atributo_d.Hijo = atributo_e;
//			//atributo_c.Hijo = atributo_f;
//
//			atributo_e.AgregarPadre(atributo_d);
//			atributo_f.AgregarPadre(atributo_c);
//
//			// Creo los hechos en base a las campos
//
//			Hecho hecho_a = new Hecho("Hecho a",campo_a);
//			Hecho hecho_b = new Hecho("Hecho b",campo_b);
//			Hecho hecho_c = new Hecho("Hecho c",campo_c);
//			Hecho hecho_d = new Hecho("Hecho d",campo_d);
//			Hecho hecho_e = new Hecho("Hecho e",campo_e);
//			Hecho hecho_j = new Hecho("Hecho j",campo_j);
//
//			// Creo las metricas de esos echos para el reporte
//
//			Metrica metrica_a = new Metrica("Metrica a","sum",hecho_a);
//			Metrica metrica_b = new Metrica("Metrica b","sum",hecho_b);
//			Metrica metrica_c = new Metrica("Metrica c","sum",hecho_c);
//			Metrica metrica_d = new Metrica("Metrica d","sum",hecho_d);
//			Metrica metrica_e = new Metrica("Metrica e","sum",hecho_e);
//			Metrica metrica_j = new Metrica("Metrica j","sum",hecho_j);
//
//			// Agrego las tablas
//			this.tablasFact.Add("Tabla Fact 1",tablaFact1);
//			this.tablasFact.Add("Tabla Fact 2",tablaFact2);
//			this.tablasLkp.Add("Tabla Lkp 1",tablaLkp1);
//			this.tablasLkp.Add("Tabla Lkp 2",tablaLkp2);
//			this.tablasLkp.Add("Tabla Lkp 3",tablaLkp3);
//			this.tablasLkp.Add("Tabla Lkp 4",tablaLkp4);
//			this.tablasLkp.Add("Tabla Lkp 5",tablaLkp5);
//			this.tablasLkp.Add("Tabla Lkp 6",tablaLkp6);
//
//			// Agrego los campos
//			this.campos.Add("campo_a",campo_a);
//			this.campos.Add("campo_b",campo_b);
//			this.campos.Add("campo_c",campo_c);
//			this.campos.Add("campo_d",campo_d);
//			this.campos.Add("campo_e",campo_e);
//			this.campos.Add("campo_j",campo_j);
//			this.campos.Add("campoLkp_a",campoLkp_a);
//			this.campos.Add("campoLkp_b",campoLkp_b);
//			this.campos.Add("campoLkp_c",campoLkp_c);
//			this.campos.Add("campoLkp_d",campoLkp_d);
//			this.campos.Add("campoLkp_e",campoLkp_e);
//			this.campos.Add("campoLkp_f",campoLkp_f);
//
//
//			// Agrego los atributos
//			this.atributos.Add("Atributo a",atributo_a);
//			this.atributos.Add("Atributo b",atributo_b);
//			this.atributos.Add("Atributo c",atributo_c);
//			this.atributos.Add("Atributo d",atributo_d);
//			this.atributos.Add("Atributo e",atributo_e);
//			this.atributos.Add("Atributo f",atributo_f);
//
//
//			// Agrego los hechos
//			this.hechos.Add("Hecho a",hecho_a);
//			this.hechos.Add("Hecho b",hecho_b);
//			this.hechos.Add("Hecho c",hecho_c);
//			this.hechos.Add("Hecho d",hecho_d);
//			this.hechos.Add("Hecho e",hecho_e);
//			this.hechos.Add("Hecho j",hecho_j);
//
//			// Agrego las metricas
//			this.metricas.Add("Metrica a",metrica_a);
//			this.metricas.Add("Metrica b",metrica_b);
//			this.metricas.Add("Metrica c",metrica_c);
//			this.metricas.Add("Metrica d",metrica_d);
//			this.metricas.Add("Metrica e",metrica_e);
//			this.metricas.Add("Metrica j",metrica_j);
//
//
//
//		}
//
//		#endregion
//	}
//}
