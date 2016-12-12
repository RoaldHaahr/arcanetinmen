$(document).ready(function() {
	$('.sleeve').on('click', function() {
		$('#js-sleeve-price').html(this.attr('data-id'));
	});
});