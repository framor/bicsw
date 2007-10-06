ALTER TABLE `bic`.`reporte_atributo` CHANGE COLUMN `idReporte` `reporte_id` INTEGER UNSIGNED NOT NULL,
 CHANGE COLUMN `idAtributo` `atributo_id` INTEGER UNSIGNED NOT NULL,
 DROP PRIMARY KEY,
 ADD PRIMARY KEY  USING BTREE(`reporte_id`, `atributo_id`);

ALTER TABLE `bic`.`reporte_filtro` CHANGE COLUMN `idReporte` `reporte_id` INTEGER UNSIGNED NOT NULL,
 CHANGE COLUMN `idFiltro` `filtro_id` INTEGER UNSIGNED NOT NULL,
 DROP PRIMARY KEY,
 ADD PRIMARY KEY  USING BTREE(`reporte_id`, `filtro_id`);

ALTER TABLE `bic`.`reporte_metrica` CHANGE COLUMN `idReporte` `reporte_id` INTEGER UNSIGNED NOT NULL,
 CHANGE COLUMN `idMetrica` `metrica_id` INTEGER UNSIGNED NOT NULL,
 DROP PRIMARY KEY,
 ADD PRIMARY KEY  USING BTREE(`reporte_id`, `metrica_id`);

ALTER TABLE `bic`.`reporte` ADD COLUMN `proyecto_id` INTEGER UNSIGNED NOT NULL AFTER `nombre`,
 DROP PRIMARY KEY,
 ADD PRIMARY KEY  USING BTREE(`id`, `proyecto_id`);
