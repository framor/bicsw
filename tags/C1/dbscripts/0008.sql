ALTER TABLE `bic`.`proyecto` DROP COLUMN `puerto`;
ALTER TABLE `bic`.`atributo` CHANGE COLUMN `campo_id` `columna_id` VARCHAR(45) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL;
ALTER TABLE `bic`.`atributo` MODIFY COLUMN `columna_id` INTEGER UNSIGNED NOT NULL;
ALTER TABLE `bic`.`atributo` DROP COLUMN `campoDescripcion`;