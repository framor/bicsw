# Introduction #

Agregar las tareas postergadas que hay que tener en cuenta en el futuro.


# TODO #

- Validar edición y eliminación de entidades (ver que no quede el sistema inconsistente).

- Cuando un id tiene dos o mas desc hay que poner las desc como desc de un solo atributo                                       pero uno elige cual mostrar en el reporte.

- Cuando hay una lkp desnormalizada osea padre e hijo en la misma tabla se deberia                  detectar que es la misma tabla y no joinear con si misma, mas alla de que en la jerarquia si debo definir como padre e hija.

- Aveces en las fact\_tables o en las lkps de menos nivel se le agregan los ids de las otras
lkps para hacerlo mas performante y no tener la necesidad de seguir todo el camino de las
lkps intermedias y joinear directamente con la de destion. Para esto es conveniente crear
relaciones ocultas para que sepan que se pueden relacionar. Ocultas significa que no se deberian ver en el snowflake pero que en realidad el sistema y el arquitecto las conozca.

- ( Esto es una funcionalidad que es muy pero muy secundaria, si no se hace no importa )Se pueden crear metricas que tengan filtros asociados. Por ejemplo:metrica:"ventas que se hicieron los lunes", seria una metrica que suma el hecho total de ventas y filtra dentro de la misma fact o por alguna dimension preguntando por el dia = lunes. Despues les muestro para que sirve.

- Cuando verifica la existencia de algun objeto que use el objeto a borrar, se le deveria mostrar la ruta completa o el nombre del objeto que lo contiene, para poder facilitarle el analisis.

- Se deberia hacer seguridad a nivel de objeto. O sea hay objetos que solo el arquitecto puede hacer ABM, pero hay otros en los cuales el reportero puede hacer ABM, siempre y cuando tenga permisos sobre dicho objeto.

- Estaria bueno que se puedan hacer filtros locales, significa que una vez que se tiene los datos, poder ocultar algunos. Tipo como hace Excel con los autofiltros.

- Falta hacer los CP de métricas y de proyecto.