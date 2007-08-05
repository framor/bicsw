CREATE TABLE `bic`.`atributo` (
  `id` INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(45) NOT NULL,
  `campoId` VARCHAR(45) NOT NULL,
  `campoDescripcion` VARCHAR(45) NOT NULL,
  `tablaLookup` VARCHAR(45) NOT NULL,
  `proyecto_id` INTEGER UNSIGNED NOT NULL,
  PRIMARY KEY (`id`)
)
ENGINE = InnoDB;