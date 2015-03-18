# Introduccion #

Aca se deberían poner todos los problemas con los que se encuentran y solucionan y pueden llegar a servirle a otro.


# aspnet\_wp.exe could not be started #

OK, if anyone experiences a similar issue: I changed the userName attribute
of the processModel tag in the machine.config file (under
%WINDIR%\Microsoft.NET\Framework\v1.0.3705\CONFIG) from "machine" to
"system" and it seemed to fix the problem.