ALTER TABLE `bic`.`usuario` ADD COLUMN `rol` VARCHAR(5) NOT NULL AFTER `clave`;
INSERT INTO bic.usuario values (1, 'reportero', 'bic', 'R');
INSERT INTO bic.usuario values (2, 'administrador', 'bic', 'D');
INSERT INTO bic.usuario values (3, 'arquitecto', 'bic', 'A');
ALTER TABLE `bic`.`usuario` ADD COLUMN `email` VARCHAR(45) NOT NULL AFTER `rol`;