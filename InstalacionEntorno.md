# Introducción #

Esta guía presenta los pasos necesarios para poder instalar todas las herramientas que conforman el entorno de desarrollo de BIC.


# Detalles #

# Cliente SVN - Tortoise SVN
VER http://weblogs.asp.net/rchartier/archive/2005/08/10/422184.aspx
  * Bajar el Tortoise 1.4.3 de http://tortoisesvn.net/downloads (	TortoiseSVN-1.4.3.8645-win32-svn-1.4.3.msi)
  * Instalar
Para que funcione SVN con IIS hay que usar un patch. El tema es que el tortoise usa los directorio .svn para mantener la información de versionado y el IIS tiene problemas con este tipo de directorios. Una vez aplicado el patch el tortoise va a usar los directorios _svn.
  * MiPC -> Propiedades -> Avanzada -> Variables de entorno
  * New (nombre: SVN\_ASP\_DOT\_NET\_HACK - valor: true)
  * Reiniciar_

# Internet Information Server (IIS) - Instalación.
  * Para ello dirigirse a	Panel de control -> Agregar o quitar componentes de windows -> Application server
  * Alli chekear:
  1. Internet Information Services
  1. ASP .NET
  1. Application Server Console
  1. Enable network COM+ access.

# IDE - Visual Studio 2003 - Enterprise Architect:
  * Instalar FrontPage Extensions y Internet Information Services desde Agregar/Quitar Programas
  * Instalar Prerequisitos
  * Instalar VS2003

# Crear directorio virtual
  * Para ello dirirse a Panel de control -> Herramientas administrativas -> Internet Information services manager
  * Alli dirigirse al nodo raiz : "Default Web Site", hacer click derecho y elegor la opcion "Crear Directorio Virtual"

  1. Alias : "bic"
  1. Path : La carpeta "Web" en el directorio donde se ha bajado BIC del svn (D:\BIC\web por ejemplo)

# Asignacion de permisos
  * Dirigirse al directorio web fisico donde se ha creado el directorio virtual ( la carpeta path del punto anterior )
  * Allí hacer click derecho sobre la carpeta, y seleccionar Propiedades -> Seguridad -> Agregar
  * En la ventana que se abre
  1. Cambiar la locacion desde el boton Locations, y elegir el nombre del equipo local en el que se esta trabajando
  1. Agregar en el cuadro de texto el nombre ASPNET y clickear en el boton "Check names". El sistema reconocerá el nombre del servicio colocando
> > el nombre del equipo como prefijo (EJ: HXWS043/ASPNET). Debe prestarse atencion en elegir adecuadamente el nombre del equipo en "LOcations"

# DB - MySQL:
  * Bajar MySQL 5.0 de http://dev.mysql.com/downloads/mysql/5.0.html (Windows (x86) ZIP/Setup.EXE)
  * Instalar

# DB Client - MySQL GUI
  * Bajar la GUI de http://dev.mysql.com/downloads/gui-tools/5.0.html (Windows (x86))
  * Instalar

# Unit Tests - NUnit
  * Bajar NUnit 2.4 de http://www.nunit.org/index.php?p=download (NUnit-2.4.0-[r2](https://code.google.com/p/bicsw/source/detail?r=2)-net-1.1.msi)
  * Instalar
  * Para correr los test se debe ejecturar el archivo Test.nunit dentro del proyecto test. Habría que probar esta configuración http://www.codeproject.com/csharp/TomazNunitTests.asp


