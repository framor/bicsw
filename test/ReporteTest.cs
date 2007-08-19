using ar.com.bic.domain;
using NUnit.Framework;

namespace test
{
	[TestFixture]
	public class ReporteTest
	{

		private Reporte reporte = new Reporte();

		public ReporteTest()
		{
			//
			// TODO: agregar aquí la lógica del constructor
			//
		}

		[Test]
		public void DameTablasCandidatas()
		{
//			// Creo las tablas fact
//			Tabla tablaFact1 = new Tabla("Tabla Fact 1","db","TablaFact1");
//			Tabla tablaFact2 = new Tabla("Tabla Fact 2","db","TablaFact2");
//			Tabla tablaFact3 = new Tabla("Tabla Fact 3","db","TablaFact3");
//			Tabla tablaFact4 = new Tabla("Tabla Fact 4","db","TablaFact4");
//			Tabla tablaFact5 = new Tabla("Tabla Fact 5","db","TablaFact5");
//			Tabla tablaFact6 = new Tabla("Tabla Fact 6","db","TablaFact6");
//			
//			// Creo las campos
//			Campo campo1 = new Campo("Campo1","char");
//			Campo campo2 = new Campo("Campo2","char");
//			Campo campo3 = new Campo("Campo3","char");
//			Campo campo4 = new Campo("Campo4","char");
//			Campo campo5 = new Campo("Campo5","char");
//			Campo campo6 = new Campo("Campo6","char");
//			Campo campo7 = new Campo("Campo7","char");
//			Campo campo8 = new Campo("Campo8","char");
//			Campo campo9 = new Campo("Campo9","char");
//			Campo campo10 = new Campo("Campo10","char");
//
//			
//			//Agrego las campos a las tablas
//			tablaFact1.AgregarCampo(campo1);
//			tablaFact1.AgregarCampo(campo2);
//			tablaFact1.AgregarCampo(campo3);
//			tablaFact1.AgregarCampo(campo4);
//			tablaFact1.AgregarCampo(campo10);
//
//			tablaFact2.AgregarCampo(campo1);
//			tablaFact2.AgregarCampo(campo2);
//			tablaFact2.AgregarCampo(campo3);
//			tablaFact2.AgregarCampo(campo5);
//
//			tablaFact3.AgregarCampo(campo1);
//			tablaFact3.AgregarCampo(campo2);
//			tablaFact3.AgregarCampo(campo3);
//			tablaFact3.AgregarCampo(campo6);
//			tablaFact3.AgregarCampo(campo10);
//
//			tablaFact4.AgregarCampo(campo1);
//			tablaFact4.AgregarCampo(campo2);
//			tablaFact4.AgregarCampo(campo3);
//			tablaFact4.AgregarCampo(campo7);
//
//			tablaFact5.AgregarCampo(campo1);
//			tablaFact5.AgregarCampo(campo2);
//			tablaFact5.AgregarCampo(campo3);
//			tablaFact5.AgregarCampo(campo8);
//			tablaFact5.AgregarCampo(campo10);
//			
//			tablaFact6.AgregarCampo(campo1);
//			tablaFact6.AgregarCampo(campo2);
//			tablaFact6.AgregarCampo(campo3);
//			tablaFact6.AgregarCampo(campo9);
//
//			// Agrego las tablas a las campos
//			campo1.AgregarTabla(tablaFact1);
//			campo1.AgregarTabla(tablaFact2);
//			campo1.AgregarTabla(tablaFact3);
//			campo1.AgregarTabla(tablaFact4);
//			campo1.AgregarTabla(tablaFact5);
//			campo1.AgregarTabla(tablaFact6);
//
//			campo2.AgregarTabla(tablaFact1);
//			campo2.AgregarTabla(tablaFact2);
//			campo2.AgregarTabla(tablaFact3);
//			campo2.AgregarTabla(tablaFact4);
//			campo2.AgregarTabla(tablaFact5);
//			campo2.AgregarTabla(tablaFact6);
//
//			campo3.AgregarTabla(tablaFact1);
//			campo3.AgregarTabla(tablaFact2);
//			campo3.AgregarTabla(tablaFact3);
//			campo3.AgregarTabla(tablaFact4);
//			campo3.AgregarTabla(tablaFact5);
//			campo3.AgregarTabla(tablaFact6);
//
//            campo4.AgregarTabla(tablaFact1);
//
//			campo5.AgregarTabla(tablaFact2);
//
//			campo6.AgregarTabla(tablaFact3);
//
//			campo7.AgregarTabla(tablaFact4);
//
//			campo8.AgregarTabla(tablaFact5);
//
//			campo9.AgregarTabla(tablaFact6);
//
//			campo10.AgregarTabla(tablaFact1);
//			campo10.AgregarTabla(tablaFact3);
//			campo10.AgregarTabla(tablaFact5);
//
//
//			// Creo los hechos en base a las campos
//			Hecho hecho1 = new Hecho("Hecho 1",campo1);
//			Hecho hecho2 = new Hecho("Hecho 2",campo2);
//			Hecho hecho3 = new Hecho("Hecho 3",campo3);
//			Hecho hecho4 = new Hecho("Hecho 4",campo4);
//			Hecho hecho5 = new Hecho("Hecho 5",campo5);
//			Hecho hecho6 = new Hecho("Hecho 6",campo6);
//			Hecho hecho7 = new Hecho("Hecho 7",campo7);
//			Hecho hecho8 = new Hecho("Hecho 8",campo8);
//			Hecho hecho9 = new Hecho("Hecho 9",campo9);
//			Hecho hecho10 = new Hecho("Hecho 10",campo10);
//			
//			// Creo las metricas de esos echos para el reporte
//			Metrica metrica1 = new Metrica("Metrica 1","sum",hecho1);
//			Metrica metrica2 = new Metrica("Metrica 2","sum",hecho2);
//			Metrica metrica3 = new Metrica("Metrica 3","sum",hecho3);
//			Metrica metrica4 = new Metrica("Metrica 4","sum",hecho4);
//			Metrica metrica5 = new Metrica("Metrica 5","sum",hecho5);
//			Metrica metrica6 = new Metrica("Metrica 6","sum",hecho6);
//			Metrica metrica7 = new Metrica("Metrica 7","sum",hecho7);
//			Metrica metrica8 = new Metrica("Metrica 8","sum",hecho8);
//			Metrica metrica9 = new Metrica("Metrica 9","sum",hecho9);
//			Metrica metrica10 = new Metrica("Metrica 10","sum",hecho10);
//			
//			//Agrego metricas al reporte
//			this.reporte.AgregarMetrica(metrica1);
//			this.reporte.AgregarMetrica(metrica10);
//            
//			//Le pido las tablas fact que tienen todas las metricas o sea las candidatas
//			ArrayList tablasCandidatas = this.reporte.DameTablasCandidatas();
//			
//			//Verifico que se alla elegido bien las tablas candidatas
//			Assert.Contains(tablaFact1,tablasCandidatas);
//			Assert.Contains(tablaFact3,tablasCandidatas);
//			Assert.Contains(tablaFact5,tablasCandidatas);
//
//			//Verifico que no se allan elegido tablas que no tenian esas metricas
//
//			Assert.IsFalse(tablasCandidatas.Contains(tablaFact2));
//			Assert.IsFalse(tablasCandidatas.Contains(tablaFact4));
//			Assert.IsFalse(tablasCandidatas.Contains(tablaFact6));
		}
	}
}
