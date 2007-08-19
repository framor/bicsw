ALTER TABLE `bic`.`proyecto` CHANGE COLUMN `esquema` `nombreBD` VARCHAR(45) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL;
ALTER TABLE `bic`.`atributo` CHANGE COLUMN `campoId` `campo_id` VARCHAR(45) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL;
CREATE TABLE `bic`.`campo` (
  `id` INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`)
)
ENGINE = InnoDB;
CREATE TABLE `bic`.`columna` (
  `id` INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(45) NOT NULL,
  `tipo` VARCHAR(45) NOT NULL,
  `tabla_id` INTEGER UNSIGNED NOT NULL,
  PRIMARY KEY (`id`)
)
ENGINE = InnoDB;
CREATE TABLE `bic`.`tabla` (
  `id` INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(45) NOT NULL,
  `alias` VARCHAR(45) NOT NULL,
  `nombreBD` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`)
)
ENGINE = InnoDB;
ALTER TABLE `bic`.`atributo` CHANGE COLUMN `tablaLookup` `tabla_lookup_id` INTEGER UNSIGNED NOT NULL;
