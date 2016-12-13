$(document).ready(function() {
	$('.sleeve').on('click', function() {
		if ($('.modal-sleeve').is(':hidden') && $('.form-search form').is(':visible')) {
			$('.form-search > form').hide();
			$('.modal-sleeve').show();
		}
		var width = 2.8 * $(this).attr('data-width');
		var height = 2.8 * $(this).attr('data-height');
		var id = $(this).attr('data-id');
		$('.js-sleeve-name').html($(this).attr('data-name'));
		$('#js-sleeve-price').html($(this).attr('data-price'));
		$('#js-sleeve-id').html(id);
		$('#js-sleeve-description').html($(this).attr('data-description'));
		$('#js-sleeve-dimensions').html($(this).attr('data-width') + ' x ' + $(this).attr('data-height') + ' mm');
		$('#js-sleeve-stock').html($(this).attr('data-stock'));
		$('#js-sleeve-games').html($(this).attr('data-games'));
		$('#js-sleeve-id-hidden').attr({
			"value":id
		});
		$('#js-sleeve-card').css({
			'background-image': 'url(/dist/img/sleeves/' + $(this).attr('data-card') + ')',
			'width': width,
			'height': height
		});
		$('.js-sleeve').height(height);
		$('.js-sleeve').width(width);

		$('#js-sleeve-badge').attr('src', '/dist/img/sleeves/' + $(this).attr('data-badge'));
	});
	$('.js-modal-close').on('click', function() {
		$(this).parent('.modal').hide();
		$('.form-search form').show();
	});
});