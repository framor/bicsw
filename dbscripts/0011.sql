CREATE TABLE `bic`.`atributo_columna` (
  `atributo_id` INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  `columna_id` INTEGER UNSIGNED NOT NULL,
  PRIMARY KEY (`atributo_id`)
)
ENGINE = InnoDB;
ALTER TABLE `bic`.`atributo_columna` MODIFY COLUMN `atributo_id` INTEGER UNSIGNED NOT NULL,
 DROP PRIMARY KEY;
