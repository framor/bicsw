ALTER TABLE `bic`.`usuario` ADD COLUMN `usuario` VARCHAR(45) NOT NULL AFTER `email`;
ALTER TABLE `bic`.`usuario` CHANGE COLUMN `usuario` `alias` VARCHAR(45) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL;
