ALTER TABLE `bic`.`tabla` ADD COLUMN `proyecto_id` INTEGER UNSIGNED NOT NULL AFTER `nombreBD`;
ALTER TABLE `bic`.`tabla` ADD COLUMN `peso` INTEGER UNSIGNED NOT NULL AFTER `proyecto_id`;
CREATE TABLE `bic`.`hecho` (
  `id` INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(45) NOT NULL,
  `columna_id` INTEGER UNSIGNED NOT NULL,
  `proyecto_id` INTEGER UNSIGNED NOT NULL,
  PRIMARY KEY (`id`)
)
ENGINE = InnoDB;
ALTER TABLE `bic`.`columna` DROP COLUMN `tabla_id`;