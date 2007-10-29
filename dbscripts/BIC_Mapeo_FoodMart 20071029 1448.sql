-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.0.45-community-nt


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema bic
--

CREATE DATABASE IF NOT EXISTS bic;
USE bic;

--
-- Definition of table `atributo`
--

DROP TABLE IF EXISTS `atributo`;
CREATE TABLE `atributo` (
  `id` int(10) unsigned NOT NULL auto_increment,
  `nombre` varchar(45) NOT NULL,
  `columna_id` int(10) unsigned NOT NULL,
  `tabla_lookup_id` int(10) unsigned NOT NULL,
  `proyecto_id` int(10) unsigned NOT NULL,
  `hijo_id` int(10) unsigned default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=66 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `atributo`
--

/*!40000 ALTER TABLE `atributo` DISABLE KEYS */;
INSERT INTO `atributo` (`id`,`nombre`,`columna_id`,`tabla_lookup_id`,`proyecto_id`,`hijo_id`) VALUES 
 (40,'Almacen  - ID',325,39,7,NULL),
 (41,'Clase Almacen - ID',319,38,7,40),
 (42,'Almacen - Nombre',325,39,7,NULL),
 (43,'Almacen - Otros Datos',325,39,7,NULL),
 (44,'Clase Almacen - Descipcion',319,38,7,40),
 (45,'Tiempo - Fecha',316,37,7,NULL),
 (46,'Producto - ID',346,40,7,NULL),
 (47,'Clase Producto - ID',355,41,7,46),
 (48,'Clase Producto - Categoria',355,41,7,46),
 (49,'Clase Producto - Otros Datos',355,41,7,46),
 (50,'Comercio - ID',371,42,7,NULL),
 (51,'Comercio - Nombre, Numero',371,42,7,NULL),
 (52,'Comercio - Otros Datos',371,42,7,NULL),
 (54,'Region Comercio - Nombre',383,43,7,50),
 (55,'Region Comercio - Otros Datos',383,43,7,50),
 (56,'Cuenta - ID',389,44,7,NULL),
 (57,'Cuenta - Descripcion, Tipo',389,44,7,NULL),
 (58,'Moneda - Nombre, Tipo de Cambio',431,48,7,NULL),
 (59,'Categoria - Descripcion',393,45,7,NULL),
 (60,'Promocion - Nombre, Costo',402,46,7,NULL),
 (61,'Cliente - ID',407,47,7,NULL),
 (62,'Cliente - Nombre, Apellido',407,47,7,NULL),
 (63,'Cliente - Otros Datos',407,47,7,NULL),
 (64,'Region Cliente - Nombre',383,43,7,61),
 (65,'Region Cliente - Otros Datos',383,43,7,61);
/*!40000 ALTER TABLE `atributo` ENABLE KEYS */;


--
-- Definition of table `atributo_columna`
--

DROP TABLE IF EXISTS `atributo_columna`;
CREATE TABLE `atributo_columna` (
  `atributo_id` int(10) unsigned NOT NULL,
  `columna_id` int(10) unsigned NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `atributo_columna`
--

/*!40000 ALTER TABLE `atributo_columna` DISABLE KEYS */;
INSERT INTO `atributo_columna` (`atributo_id`,`columna_id`) VALUES 
 (40,325),
 (41,319),
 (42,329),
 (43,335),
 (43,331),
 (43,321),
 (43,323),
 (43,322),
 (43,330),
 (44,320),
 (45,311),
 (46,346),
 (47,355),
 (48,353),
 (49,351),
 (49,352),
 (49,354),
 (50,371),
 (51,379),
 (51,370),
 (52,363),
 (52,356),
 (52,376),
 (52,362),
 (54,381),
 (55,380),
 (55,382),
 (55,384),
 (55,385),
 (56,389),
 (57,387),
 (57,390),
 (58,432),
 (58,430),
 (59,394),
 (60,398),
 (60,401),
 (61,407),
 (62,404),
 (62,408),
 (63,415),
 (63,420),
 (63,427),
 (63,423),
 (64,381),
 (65,380),
 (65,382),
 (65,384),
 (65,385);
/*!40000 ALTER TABLE `atributo_columna` ENABLE KEYS */;


--
-- Definition of table `columna`
--

DROP TABLE IF EXISTS `columna`;
CREATE TABLE `columna` (
  `id` int(10) unsigned NOT NULL auto_increment,
  `nombre` varchar(45) NOT NULL,
  `tipo` varchar(45) NOT NULL,
  `atributo_id` int(10) unsigned default NULL,
  `tabla_id` int(10) unsigned default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=433 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `columna`
--

/*!40000 ALTER TABLE `columna` DISABLE KEYS */;
INSERT INTO `columna` (`id`,`nombre`,`tipo`,`atributo_id`,`tabla_id`) VALUES 
 (283,'time_id','int',NULL,34),
 (284,'units_shipped','int',NULL,34),
 (285,'warehouse_sales','decimal',NULL,34),
 (286,'warehouse_id','int',NULL,34),
 (287,'units_ordered','int',NULL,34),
 (288,'product_id','int',NULL,34),
 (289,'store_cost','int',NULL,34),
 (290,'store_invoice','decimal',NULL,34),
 (291,'store_id','int',NULL,34),
 (292,'warehouse_cost','decimal',NULL,34),
 (293,'supply_time','smallint',NULL,34),
 (294,'category_id','varchar',NULL,35),
 (295,'time_id','int',NULL,35),
 (296,'amount','decimal',NULL,35),
 (297,'account_id','int',NULL,35),
 (298,'store_id','int',NULL,35),
 (299,'currency_id','int',NULL,35),
 (300,'exp_date','timestamp',NULL,35),
 (301,'store_sales','decimal',NULL,36),
 (302,'time_id','int',NULL,36),
 (303,'unit_sales','decimal',NULL,36),
 (304,'promotion_id','int',NULL,36),
 (305,'product_id','int',NULL,36),
 (306,'customer_id','int',NULL,36),
 (307,'store_id','int',NULL,36),
 (308,'store_cost','decimal',NULL,36),
 (309,'the_year','smallint',NULL,37),
 (310,'day_of_month','smallint',NULL,37),
 (311,'the_date','timestamp',NULL,37),
 (312,'fiscal_period','varchar',NULL,37),
 (313,'week_of_year','int',NULL,37),
 (314,'month_of_year','smallint',NULL,37),
 (315,'quarter','varchar',NULL,37),
 (316,'time_id','int',NULL,37),
 (317,'the_month','varchar',NULL,37),
 (318,'the_day','varchar',NULL,37),
 (319,'warehouse_class_id','int',NULL,38),
 (320,'description','varchar',NULL,38),
 (321,'warehouse_city','varchar',NULL,39),
 (322,'warehouse_postal_code','varchar',NULL,39),
 (323,'warehouse_state_province','varchar',NULL,39),
 (324,'warehouse_class_id','int',NULL,39),
 (325,'warehouse_id','int',NULL,39),
 (326,'warehouse_fax','varchar',NULL,39),
 (327,'stores_id','int',NULL,39),
 (328,'wa_address4','varchar',NULL,39),
 (329,'warehouse_name','varchar',NULL,39),
 (330,'warehouse_phone','varchar',NULL,39),
 (331,'wa_address1','varchar',NULL,39),
 (332,'wa_address3','varchar',NULL,39),
 (333,'wa_address2','varchar',NULL,39),
 (334,'warehouse_owner_name','varchar',NULL,39),
 (335,'warehouse_country','varchar',NULL,39),
 (336,'units_per_case','smallint',NULL,40),
 (337,'shelf_height','double',NULL,40),
 (338,'shelf_depth','double',NULL,40),
 (339,'gross_weight','double',NULL,40),
 (340,'SRP','decimal',NULL,40),
 (341,'recyclable_package','tinyint',NULL,40),
 (342,'SKU','bigint',NULL,40),
 (343,'low_fat','tinyint',NULL,40),
 (344,'net_weight','double',NULL,40),
 (345,'brand_name','varchar',NULL,40),
 (346,'product_id','int',NULL,40),
 (347,'shelf_width','double',NULL,40),
 (348,'product_name','varchar',NULL,40),
 (349,'cases_per_pallet','smallint',NULL,40),
 (350,'product_class_id','int',NULL,40),
 (351,'product_family','varchar',NULL,41),
 (352,'product_subcategory','varchar',NULL,41),
 (353,'product_category','varchar',NULL,41),
 (354,'product_department','varchar',NULL,41),
 (355,'product_class_id','int',NULL,41),
 (356,'store_city','varchar',NULL,42),
 (357,'store_street_address','varchar',NULL,42),
 (358,'prepared_food','tinyint',NULL,42),
 (359,'store_sqft','int',NULL,42),
 (360,'last_remodel_date','timestamp',NULL,42),
 (361,'store_type','varchar',NULL,42),
 (362,'store_manager','varchar',NULL,42),
 (363,'store_phone','varchar',NULL,42),
 (364,'first_opened_date','timestamp',NULL,42),
 (365,'meat_sqft','int',NULL,42),
 (366,'coffee_bar','tinyint',NULL,42),
 (367,'salad_bar','tinyint',NULL,42),
 (368,'store_fax','varchar',NULL,42),
 (369,'grocery_sqft','int',NULL,42),
 (370,'store_number','int',NULL,42),
 (371,'store_id','int',NULL,42),
 (372,'store_state','varchar',NULL,42),
 (373,'store_country','varchar',NULL,42),
 (374,'frozen_sqft','int',NULL,42),
 (375,'region_id','int',NULL,42),
 (376,'store_postal_code','varchar',NULL,42),
 (377,'florist','tinyint',NULL,42),
 (378,'video_store','tinyint',NULL,42),
 (379,'store_name','varchar',NULL,42),
 (380,'country','varchar',NULL,43),
 (381,'region','varchar',NULL,43),
 (382,'district','varchar',NULL,43),
 (383,'region_id','int',NULL,43),
 (384,'state_province','varchar',NULL,43),
 (385,'city','varchar',NULL,43),
 (386,'district_id','int',NULL,43),
 (387,'account_description','varchar',NULL,44),
 (388,'account_rollup','varchar',NULL,44),
 (389,'account_id','int',NULL,44),
 (390,'account_type','varchar',NULL,44),
 (391,'account_parent','int',NULL,44),
 (392,'Custom_Members','varchar',NULL,44),
 (393,'category_id','varchar',NULL,45),
 (394,'category_description','varchar',NULL,45),
 (395,'category_parent','varchar',NULL,45),
 (396,'category_rollup','varchar',NULL,45),
 (397,'media_type','varchar',NULL,46),
 (398,'promotion_name','varchar',NULL,46),
 (399,'end_date','timestamp',NULL,46),
 (400,'promotion_district_id','int',NULL,46),
 (401,'cost','decimal',NULL,46),
 (402,'promotion_id','int',NULL,46),
 (403,'start_date','timestamp',NULL,46),
 (404,'lname','varchar',NULL,47),
 (405,'houseowner','varchar',NULL,47),
 (406,'date_accnt_opened','date',NULL,47),
 (407,'customer_id','int',NULL,47),
 (408,'fname','varchar',NULL,47),
 (409,'account_num','bigint',NULL,47),
 (410,'mi','varchar',NULL,47),
 (411,'marital_status','varchar',NULL,47),
 (412,'birthdate','date',NULL,47),
 (413,'num_cars_owned','int',NULL,47),
 (414,'num_children_at_home','smallint',NULL,47),
 (415,'occupation','varchar',NULL,47),
 (416,'member_card','varchar',NULL,47),
 (417,'total_children','smallint',NULL,47),
 (418,'phone2','varchar',NULL,47),
 (419,'address4','varchar',NULL,47),
 (420,'phone1','varchar',NULL,47),
 (421,'education','varchar',NULL,47),
 (422,'region_id','int',NULL,47),
 (423,'address1','varchar',NULL,47),
 (424,'address2','varchar',NULL,47),
 (425,'address3','varchar',NULL,47),
 (426,'postal_code','varchar',NULL,47),
 (427,'gender','varchar',NULL,47),
 (428,'yearly_income','varchar',NULL,47),
 (429,'date','date',NULL,48),
 (430,'currency','varchar',NULL,48),
 (431,'currency_id','int',NULL,48),
 (432,'conversion_ratio','decimal',NULL,48);
/*!40000 ALTER TABLE `columna` ENABLE KEYS */;


--
-- Definition of table `filtro`
--

DROP TABLE IF EXISTS `filtro`;
CREATE TABLE `filtro` (
  `id` int(10) unsigned NOT NULL auto_increment,
  `nombre` varchar(45) NOT NULL,
  `columna_id` int(10) unsigned NOT NULL,
  `operador` varchar(45) NOT NULL,
  `valor` varchar(45) NOT NULL,
  `proyecto_id` int(10) unsigned NOT NULL,
  `atributo_id` int(10) unsigned NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `filtro`
--

/*!40000 ALTER TABLE `filtro` DISABLE KEYS */;
INSERT INTO `filtro` (`id`,`nombre`,`columna_id`,`operador`,`valor`,`proyecto_id`,`atributo_id`) VALUES 
 (18,'Region Comercio - Empieza con Mexico',381,'Empieza con','Mexico',7,54);
/*!40000 ALTER TABLE `filtro` ENABLE KEYS */;


--
-- Definition of table `hecho`
--

DROP TABLE IF EXISTS `hecho`;
CREATE TABLE `hecho` (
  `id` int(10) unsigned NOT NULL auto_increment,
  `nombre` varchar(45) NOT NULL,
  `columna_id` int(10) unsigned NOT NULL,
  `proyecto_id` int(10) unsigned NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `hecho`
--

/*!40000 ALTER TABLE `hecho` DISABLE KEYS */;
INSERT INTO `hecho` (`id`,`nombre`,`columna_id`,`proyecto_id`) VALUES 
 (6,'Unidades Ordenadas',287,7),
 (7,'Unidades Compradas',284,7),
 (8,'Ventas Almacen',285,7),
 (9,'Costo Almacen',292,7),
 (10,'Tiempo de Reposicion',293,7),
 (11,'Facturacion Local',290,7),
 (12,'Cantidad de Expensas',296,7),
 (13,'Ventas',301,7),
 (14,'Costo',289,7),
 (15,'Unidades Vendidas',303,7);
/*!40000 ALTER TABLE `hecho` ENABLE KEYS */;


--
-- Definition of table `metrica`
--

DROP TABLE IF EXISTS `metrica`;
CREATE TABLE `metrica` (
  `id` int(10) unsigned NOT NULL auto_increment,
  `nombre` varchar(45) NOT NULL,
  `funcion` varchar(45) NOT NULL,
  `hecho_id` int(10) unsigned NOT NULL,
  `proyecto_id` int(10) unsigned NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `metrica`
--

/*!40000 ALTER TABLE `metrica` DISABLE KEYS */;
INSERT INTO `metrica` (`id`,`nombre`,`funcion`,`hecho_id`,`proyecto_id`) VALUES 
 (8,'Total - Unidades Ordenadas','SUM({0})',6,7),
 (9,'Total - Unidades Compradas','SUM({0})',7,7),
 (10,'Total - Ventas Almacen','SUM({0})',8,7),
 (11,'Total - Costo Almacen','SUM({0})',9,7),
 (12,'Promedio - Tiempo de Reposicion','AVG({0})',10,7),
 (13,'Total - Facturacion Local','SUM({0})',11,7),
 (14,'Total - Cantidad Expensas','SUM({0})',12,7),
 (15,'Total - Ventas','SUM({0})',13,7),
 (16,'Total - Costos','SUM({0})',14,7),
 (17,'Total - Unidades Vendidas','SUM({0})',15,7);
/*!40000 ALTER TABLE `metrica` ENABLE KEYS */;


--
-- Definition of table `proyecto`
--

DROP TABLE IF EXISTS `proyecto`;
CREATE TABLE `proyecto` (
  `id` int(10) unsigned NOT NULL auto_increment,
  `nombre` varchar(45) NOT NULL,
  `descripcion` varchar(255) NOT NULL,
  `servidor` varchar(45) NOT NULL,
  `nombreBD` varchar(45) NOT NULL,
  `usuario` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `proyecto`
--

/*!40000 ALTER TABLE `proyecto` DISABLE KEYS */;
INSERT INTO `proyecto` (`id`,`nombre`,`descripcion`,`servidor`,`nombreBD`,`usuario`,`password`) VALUES 
 (7,'FoodMart','Gestion de Mayorista de Productos Alimenticio','localhost','foodmart','bic','bic');
/*!40000 ALTER TABLE `proyecto` ENABLE KEYS */;


--
-- Definition of table `reporte`
--

DROP TABLE IF EXISTS `reporte`;
CREATE TABLE `reporte` (
  `id` int(10) unsigned NOT NULL auto_increment,
  `nombre` varchar(45) NOT NULL,
  `proyecto_id` int(10) unsigned NOT NULL,
  PRIMARY KEY  (`id`,`proyecto_id`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `reporte`
--

/*!40000 ALTER TABLE `reporte` DISABLE KEYS */;
INSERT INTO `reporte` (`id`,`nombre`,`proyecto_id`) VALUES 
 (29,'Ventas y costos por regiones',7);
/*!40000 ALTER TABLE `reporte` ENABLE KEYS */;


--
-- Definition of table `reporte_atributo`
--

DROP TABLE IF EXISTS `reporte_atributo`;
CREATE TABLE `reporte_atributo` (
  `reporte_id` int(10) unsigned NOT NULL,
  `atributo_id` int(10) unsigned NOT NULL,
  PRIMARY KEY  (`reporte_id`,`atributo_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `reporte_atributo`
--

/*!40000 ALTER TABLE `reporte_atributo` DISABLE KEYS */;
INSERT INTO `reporte_atributo` (`reporte_id`,`atributo_id`) VALUES 
 (29,54),
 (29,64);
/*!40000 ALTER TABLE `reporte_atributo` ENABLE KEYS */;


--
-- Definition of table `reporte_filtro`
--

DROP TABLE IF EXISTS `reporte_filtro`;
CREATE TABLE `reporte_filtro` (
  `reporte_id` int(10) unsigned NOT NULL,
  `filtro_id` int(10) unsigned NOT NULL,
  PRIMARY KEY  (`reporte_id`,`filtro_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `reporte_filtro`
--

/*!40000 ALTER TABLE `reporte_filtro` DISABLE KEYS */;
INSERT INTO `reporte_filtro` (`reporte_id`,`filtro_id`) VALUES 
 (29,18);
/*!40000 ALTER TABLE `reporte_filtro` ENABLE KEYS */;


--
-- Definition of table `reporte_metrica`
--

DROP TABLE IF EXISTS `reporte_metrica`;
CREATE TABLE `reporte_metrica` (
  `reporte_id` int(10) unsigned NOT NULL,
  `metrica_id` int(10) unsigned NOT NULL,
  PRIMARY KEY  (`reporte_id`,`metrica_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `reporte_metrica`
--

/*!40000 ALTER TABLE `reporte_metrica` DISABLE KEYS */;
INSERT INTO `reporte_metrica` (`reporte_id`,`metrica_id`) VALUES 
 (29,15),
 (29,16),
 (29,17);
/*!40000 ALTER TABLE `reporte_metrica` ENABLE KEYS */;


--
-- Definition of table `tabla`
--

DROP TABLE IF EXISTS `tabla`;
CREATE TABLE `tabla` (
  `id` int(10) unsigned NOT NULL auto_increment,
  `nombre` varchar(45) NOT NULL,
  `alias` varchar(45) NOT NULL,
  `nombreBD` varchar(45) NOT NULL,
  `proyecto_id` int(10) unsigned NOT NULL,
  `peso` int(10) unsigned NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tabla`
--

/*!40000 ALTER TABLE `tabla` DISABLE KEYS */;
INSERT INTO `tabla` (`id`,`nombre`,`alias`,`nombreBD`,`proyecto_id`,`peso`) VALUES 
 (34,'inventory_fact','Inventario FACT','foodmart',7,2),
 (35,'expense_fact','Expensas FACT','foodmart',7,3),
 (36,'sales_fact','Ventas FACT','foodmart',7,8),
 (37,'time_by_day','Tiempo LKP','foodmart',7,0),
 (38,'warehouse_class','Clase Almacen LKP','foodmart',7,0),
 (39,'warehouse','Almacen LKP','foodmart',7,0),
 (40,'product','Producto LKP','foodmart',7,0),
 (41,'product_class','Clase Producto LKP','foodmart',7,0),
 (42,'store','Comercio LKP','foodmart',7,0),
 (43,'region','Region LKP','foodmart',7,0),
 (44,'account','Cuenta LKP','foodmart',7,0),
 (45,'category','Categoria LKP','foodmart',7,0),
 (46,'promotion','Promocion LKP','foodmart',7,0),
 (47,'customer','Cliente LKP','foodmart',7,0),
 (48,'currency','Moneda LKP','foodmart',7,0);
/*!40000 ALTER TABLE `tabla` ENABLE KEYS */;


--
-- Definition of table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
CREATE TABLE `usuario` (
  `id` int(10) unsigned NOT NULL auto_increment,
  `nombre` varchar(45) NOT NULL,
  `clave` varchar(45) NOT NULL,
  `rol` varchar(5) NOT NULL,
  `email` varchar(45) NOT NULL,
  `alias` varchar(45) NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `usuario`
--

/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` (`id`,`nombre`,`clave`,`rol`,`email`,`alias`) VALUES 
 (1,'Reportero','bic','R','','reportero'),
 (2,'Administrador','bic','D','','administrador'),
 (3,'Arquitecto','bic','A','','arquitecto'),
 (6,'Fernando Rodriguez Amor','fer','A','','fer'),
 (7,'Arquitecto - Quick','a','A','','a'),
 (8,'Reportero - Quick','r','R','','r');
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;




/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
