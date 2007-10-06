-- Crea la tabla reporte
CREATE TABLE `bic`.`reporte` (
  `id` INTEGER UNSIGNED NOT NULL DEFAULT null AUTO_INCREMENT,
  `nombre` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`)
)
ENGINE = InnoDB;

-- Crea la tabla reporte_atributo
CREATE TABLE `bic`.`reporte_atributo` (
  `idReporte` INTEGER UNSIGNED NOT NULL,
  `idAtributo` INTEGER UNSIGNED NOT NULL,
  PRIMARY KEY (`idReporte`, `idAtributo`)
)
ENGINE = InnoDB;

-- Crea la tabla reporte_metrica
CREATE TABLE `bic`.`reporte_metrica` (
  `idReporte` INTEGER UNSIGNED NOT NULL,
  `idMetrica` INTEGER UNSIGNED NOT NULL,
  PRIMARY KEY (`idReporte`, `idMetrica`)
)
ENGINE = InnoDB;

-- Crea la tabla reporte_filtro
CREATE TABLE `bic`.`reporte_filtro` (
  `idReporte` INTEGER UNSIGNED NOT NULL,
  `idFiltro` INTEGER UNSIGNED NOT NULL,
  PRIMARY KEY (`idReporte`, `idFiltro`)
)
ENGINE = InnoDB;
