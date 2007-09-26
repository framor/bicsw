/**
 * Cambia la visibilidad de un elemento. De visible a oculoto y viceversa
 * @param id el id del elemento en el DOM
 */
function toggleDiv(id) {
	if (document.getElementById(id).style.display == '')
	{
		document.getElementById(id).style.display = 'none';
	} 
	else 
	{
		document.getElementById(id).style.display = '';
	}
}
