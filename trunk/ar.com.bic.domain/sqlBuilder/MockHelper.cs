using System;
using SqlBuilder.Model;
using System.Collections;


namespace SqlBuilder
{
	/// <summary>
	/// Clase usada para instanciar objetos.
	/// </summary>
	public class MockHelper
	{
		#region Constructor

		private MockHelper()
		{}

		private static MockHelper instance;

		public static MockHelper GetInstance()
		{
			if(instance == null)
			{
				instance = new MockHelper();
			}

			return instance;
		}

		#endregion
		
		#region Miembros privados

		private ArrayList atributos;
		private ArrayList hechos;
		private Hashtable tablas;

		#endregion

		#region	Métodos publicos

		public ArrayList GetFactTables()
		{
			ArrayList factTables = new ArrayList();

			foreach ( Tabla tabla in this.Tablas )

				if ( tabla.IsFact )
				{
					factTables.Add(tabla);
				}				

			return factTables;
		}


		#endregion

		#region Métodos privados

		private void InstanceModel()
		{
			this.tablas = new Hashtable();
			this.atributos = new ArrayList();
			this.hechos = new ArrayList();

			#region	Tabla proveedor

			LookUpTable tablaProveedor = new LookUpTable("proveedor", new ArrayList());

			Atributo idProveedor_Proveedor = new Atributo("prov_id","Identificador del proveedor",tablaProveedor,false);
			Atributo nombreProveedor = new Atributo("nombre","Nombre del proveedor",tablaProveedor,true);
			Atributo domicilioProveedor = new Atributo("domicilio","Domicilio del proveedor",tablaProveedor,true);

			this.atributos.Add(idProveedor_Proveedor);
			this.atributos.Add(nombreProveedor);
			this.atributos.Add(domicilioProveedor);

			this.tablas.Add(tablaProveedor.Nombre,tablaProveedor);

			#endregion

			#region	Tabla producto

			LookUpTable tablaProducto = new LookUpTable("producto", new ArrayList());

			Atributo idProveedor_Producto = new Atributo("prov_id","Identificador del proveedor",tablaProducto,false);
			Atributo idProducto_Producto = new Atributo("producto_id","Identificador del producto",tablaProducto,false);
			Atributo categoriaProducto = new Atributo("categoria_prod","Categoria del producto",tablaProducto,true);
			Atributo nombreProducto = new Atributo("nombre_prod","Nombre del producto",tablaProducto,true);
			Atributo unidadMedidaProducto = new Atributo("unidad_medid","Unidad de medida del producto",tablaProducto,true);
			Atributo costoUnitarioProducto = new Atributo("costo_unitario","Costo unitario del producto",tablaProducto,true);			

			this.atributos.Add(idProveedor_Producto);
			this.atributos.Add(idProducto_Producto);
			this.atributos.Add(categoriaProducto);
			this.atributos.Add(nombreProducto);
			this.atributos.Add(unidadMedidaProducto);
			this.atributos.Add(costoUnitarioProducto);

			this.tablas.Add(tablaProducto.Nombre,tablaProducto);

			#endregion

			#region Relacion tabla producto - tabla proveedor

			Relacion relacionProductoProveedor = new Relacion(idProveedor_Producto,idProveedor_Proveedor);   
			tablaProducto.Relaciones.Add(relacionProductoProveedor);
			tablaProveedor.Relaciones.Add(relacionProductoProveedor);

			#endregion
			
			#region	Tabla agente

			LookUpTable tablaAgente = new LookUpTable("agente", new ArrayList());

			Atributo idAgente_Agente = new Atributo("agente_id","Id del agente", tablaAgente,false);
			Atributo nombreAgente = new Atributo("nombre_Agen","Nombre del agente", tablaAgente,true);
			Atributo categoriaAgente = new Atributo("categoria","Categoria del agente", tablaAgente,true);
			Atributo antiguedadAgente = new Atributo("antiguedad_Agen","Antiguedad del agente", tablaAgente,true);

			this.atributos.Add(idAgente_Agente);
			this.atributos.Add(nombreAgente);
			this.atributos.Add(categoriaAgente);
			this.atributos.Add(antiguedadAgente);

			this.tablas.Add(tablaAgente.Nombre,tablaAgente);

			#endregion

			#region	Tabla vendedor

			LookUpTable tablaVendedor = new LookUpTable("vendedor",new ArrayList());

			Atributo idAgente_Vendedor = new Atributo("agente_id","Id del agente", tablaVendedor,false);
			Atributo idADeptoVentas_Vendedor = new Atributo("depto_v_id","Id del departamento de ventas", tablaVendedor,false);

			this.atributos.Add(idAgente_Vendedor);
			this.atributos.Add(idADeptoVentas_Vendedor);

			this.tablas.Add(tablaVendedor.Nombre,tablaVendedor);

			#endregion

			#region Relacion tabla vendedor - tabla agente

			Relacion relacionVendedorAgente = new Relacion(idAgente_Vendedor,idAgente_Agente);
			tablaVendedor.Relaciones.Add(relacionVendedorAgente);
			tablaAgente.Relaciones.Add(relacionVendedorAgente);

			#endregion

			#region Tabla dept-vtas

			LookUpTable tablaDept_Vtas = new LookUpTable("dept_Vtas",new ArrayList());

			Atributo idADeptoVentas_Dept_Vtas = new Atributo("depto_v_id","Id del departamento de ventas", tablaDept_Vtas,false);
			Atributo Nombre_Dept_Vtas = new Atributo("nombre","Nombre del departamento de ventas", tablaDept_Vtas,true);

			this.atributos.Add(idADeptoVentas_Dept_Vtas);
			this.atributos.Add(Nombre_Dept_Vtas);

			this.tablas.Add(tablaDept_Vtas.Nombre,tablaDept_Vtas);

			#endregion

			#region	Relacion tabla vendedor - tabla Dept-Vtas

			Relacion relacionVendedorDept_Vtas = new Relacion(idADeptoVentas_Vendedor,idADeptoVentas_Dept_Vtas);
			tablaVendedor.Relaciones.Add(relacionVendedorDept_Vtas);
			tablaDept_Vtas.Relaciones.Add(relacionVendedorDept_Vtas); 

			#endregion

			#region Tabla estacion

			LookUpTable tablaEstacion = new LookUpTable("estacion",new ArrayList());

			Atributo codigoEstacion_Estacion = new Atributo("cod_estac","Codigo de estacion",tablaEstacion,false);
			Atributo nombreEstacion = new Atributo("nombre","Nombre de la estacion",tablaEstacion,true);
			Atributo climaEstacion = new Atributo("clima","Clima de la estacion",tablaEstacion,true);

			this.atributos.Add(codigoEstacion_Estacion);
			this.atributos.Add(nombreEstacion);
			this.atributos.Add(climaEstacion);

			this.tablas.Add(tablaEstacion.Nombre,tablaEstacion);

			#endregion

			#region Tabla tiempo

			LookUpTable tablaTiempo = new LookUpTable("tiempo",new ArrayList());

			Atributo codigoEstacion_Tiempo = new Atributo("cod_estac","Codigo de estacion",tablaTiempo,false);
			Atributo fecha_Tiempo = new Atributo("ddmmaaaa","Fecha",tablaTiempo,true);
			Atributo diaSema = new Atributo("dia_semana","Dia de la semana",tablaTiempo,true);

			this.atributos.Add(codigoEstacion_Tiempo);
			this.atributos.Add(fecha_Tiempo);
			this.atributos.Add(diaSema);

			this.tablas.Add(tablaTiempo.Nombre,tablaTiempo);

			#endregion

			#region Relacion tabla estacion - tabla tiempo

			Relacion relacionEstacionTiempo = new Relacion(codigoEstacion_Estacion,codigoEstacion_Tiempo);
			tablaEstacion.Relaciones.Add(relacionEstacionTiempo);
			tablaTiempo.Relaciones.Add(relacionEstacionTiempo);

			#endregion

			#region Tabla Local

			LookUpTable tablaLocal = new LookUpTable("local", new ArrayList());

			Atributo idLocal_Local = new Atributo("local_id","Id del local",tablaLocal,false);
			Atributo direccionLocal = new Atributo("direccion","Direccion del local",tablaLocal,true);
			Atributo superficieLocal = new Atributo("superficie","Superficie del local",tablaLocal,true);
			Atributo tipoLocal = new Atributo("tipo","Tipo de local",tablaLocal,true);

			this.atributos.Add(idLocal_Local);
			this.atributos.Add(direccionLocal);
			this.atributos.Add(superficieLocal);
			this.atributos.Add(tipoLocal);

			this.tablas.Add(tablaLocal.Nombre,tablaLocal);

			#endregion 

			#region	Tabla ubicacion

			LookUpTable tablaUbicacion = new LookUpTable("ubicacion",new ArrayList());

			Atributo idLocal_Ubicacion = new Atributo("local_id","Id del local",tablaUbicacion,false);
			Atributo codigoDistrito_Ubicacion = new Atributo("cod_dist","Codigo del distrito",tablaUbicacion,false);
			Atributo codigoRegion_Ubicacion = new Atributo("cod_reg","Codigo de region",tablaUbicacion,false);

			this.atributos.Add(idLocal_Ubicacion);
			this.atributos.Add(codigoDistrito_Ubicacion);
			this.atributos.Add(codigoRegion_Ubicacion);
			
			this.tablas.Add(tablaUbicacion.Nombre,tablaUbicacion);

			#endregion

			#region	Relacion tabla ubicacion - tabla local

			Relacion relacionLocalUbicacion = new Relacion(idLocal_Ubicacion,idLocal_Local);
			tablaUbicacion.Relaciones.Add(relacionLocalUbicacion);
			tablaLocal.Relaciones.Add(relacionLocalUbicacion); 

			#endregion

			#region Tabla region

			LookUpTable tablaRegion = new LookUpTable("region",new ArrayList());

			Atributo codigoRegion_Region = new Atributo("cod_reg","Codigo de region",tablaRegion,false);
			Atributo nombreRegion= new Atributo("nombre","Nomre de la region",tablaRegion,true);

			this.atributos.Add(codigoRegion_Region);
			this.atributos.Add(nombreRegion);

			this.tablas.Add(tablaRegion.Nombre,tablaRegion);

			#endregion

			#region	Relacion tabla ubicacion - tabla region

			Relacion relacionUbicacionRegion = new Relacion(codigoRegion_Ubicacion,codigoRegion_Region);
			tablaUbicacion.Relaciones.Add(relacionUbicacionRegion);
			tablaRegion.Relaciones.Add(relacionUbicacionRegion); 

			#endregion

			#region Tabla distrito

			LookUpTable tablaDistrito = new LookUpTable("distrito",new ArrayList());

			Atributo codigoDistrito_Distrito = new Atributo("cod_dist","Codigo del distrito",tablaDistrito,false);
			Atributo nombreDistrito = new Atributo("nombre","Nombre del distrito",tablaDistrito,true);

			this.atributos.Add(codigoDistrito_Distrito);
			this.atributos.Add(nombreDistrito);

			this.tablas.Add(tablaDistrito.Nombre,tablaDistrito);

			#endregion

			#region	Relacion tabla ubicacion - tabla distrito

			Relacion relacionUbicacionDistrito = new Relacion(codigoDistrito_Ubicacion,codigoDistrito_Distrito);
			tablaUbicacion.Relaciones.Add(relacionUbicacionDistrito);
			tablaDistrito.Relaciones.Add(relacionUbicacionDistrito); 

			#endregion

			#region	Tabla ventas

			FactTable tablaVentas = new FactTable("ventas",new ArrayList(),new ArrayList());

			Atributo idLocal_Ventas = new Atributo("local_id","Id del local",tablaVentas,false);
			Atributo idProducto_Ventas = new Atributo("producto_id","Identificador del producto",tablaVentas,false);
			Atributo fecha_Ventas= new Atributo("ddmmaaaa","Fecha",tablaVentas,false);
			Atributo idAgente_Ventas = new Atributo("agente_id","Id del agente", tablaVentas,false);

			this.atributos.Add(idLocal_Ventas);
			this.atributos.Add(idProducto_Ventas);
			this.atributos.Add(fecha_Ventas);
			this.atributos.Add(idAgente_Ventas);

			Hecho ventasUnidades = new Hecho("vtas_unidades","Unidades vendidas",tablaVentas);
			Hecho ventasImporte = new Hecho("vtas_importe","Importe de unidades vendidas",tablaVentas);
			Hecho formaPago = new Hecho("forma_pago","Forma de pago",tablaVentas);

			tablaVentas.Hechos.Add(ventasUnidades);
			tablaVentas.Hechos.Add(ventasImporte);
			tablaVentas.Hechos.Add(formaPago);

			this.hechos.Add(ventasUnidades);
			this.hechos.Add(ventasImporte);
			this.hechos.Add(formaPago);

			this.tablas.Add(tablaVentas.Nombre,tablaVentas);

			#endregion

			#region	Relacion Fact Table - otras tablas

			Relacion relacionVentasProducto = new Relacion(idProducto_Ventas,idProducto_Producto);
			tablaVentas.Relaciones.Add(relacionVentasProducto);
			tablaProducto.Relaciones.Add(relacionVentasProducto);

			Relacion relacionVentasVendedor = new Relacion(idAgente_Ventas ,idAgente_Vendedor);
			tablaVentas.Relaciones.Add(relacionVentasVendedor);
			tablaVendedor.Relaciones.Add(relacionVentasVendedor);

			Relacion relacionVentasTiempo = new Relacion(fecha_Ventas ,fecha_Tiempo);
			tablaVentas.Relaciones.Add(relacionVentasTiempo);
			tablaTiempo.Relaciones.Add(relacionVentasTiempo);

			Relacion relacionVentasUbicacion = new Relacion(idLocal_Ventas ,idLocal_Ubicacion);
			tablaVentas.Relaciones.Add(relacionVentasUbicacion);
			tablaUbicacion.Relaciones.Add(relacionVentasUbicacion);

			#endregion
		}


		#endregion

		#region Propiedades publicas

		public ArrayList Tablas
		{
			get
			{
				if (this.tablas == null)
				{
					this.InstanceModel();
				}

				return new ArrayList (this.tablas.Values);
			}
		}
		
		public ArrayList Atributos
		{
			get
			{
				if (this.atributos == null)
				{
					this.InstanceModel();
				}

				return this.atributos; 
			}
		}
		
		public ArrayList AtributosMostrables
		{
			get
			{
				ArrayList atts = new ArrayList();

				foreach ( Atributo att in this.Atributos)
				{
					if (att.EsMostrable)
					{
						atts.Add(att);
					}
				}
				
				return atts; 
			}
		}

		public ArrayList Hechos
		{
			get
			{
				if (this.hechos == null)
				{
					this.InstanceModel();
				}

				return this.hechos; 
			}
		}

		#endregion
	}
}
