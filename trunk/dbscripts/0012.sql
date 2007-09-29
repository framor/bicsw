ALTER TABLE `bic`.`atributo` ADD COLUMN `hijo_id` INTEGER UNSIGNED NOT NULL AFTER `proyecto_id`;
ALTER TABLE `bic`.`atributo` MODIFY COLUMN `hijo_id` INTEGER UNSIGNED;