$(document).ready(function() {
	$('.sleeves-section .sleeve').on('click', function() {
		var width = $(this).attr('data-width'),
		height = $(this).attr('data-height'),
		displayWidth = 2.8 * width,
		displayHeight = 2.8 * height,
		id = $(this).attr('data-id'),
		card = '/dist/img/sleeves/' + $(this).attr('data-card'),
		badge = '/dist/img/sleeves/' + $(this).attr('data-badge'),
		name = $(this).attr('data-name'),
		description = $(this).attr('data-description'),
		price = $(this).attr('data-price'),
		dimensions = width + ' x ' + height,
		games = $(this).attr('data-games'),
		stock = $(this).attr('data-stock');
		
		if ($('.modal-sleeve').is(':hidden') && $('.form-search form').is(':visible')) {
			$('.form-search > form').fadeOut();
			updateModal();
			$('.modal-sleeve').delay(100).fadeIn();
			
		} else {
			$('#js-sleeve-card').removeClass('is-focus');
			setTimeout(updateModal, 300);

			// $('#js-sleeve-card').css({
			// 	'background-image': 'url(/dist/img/sleeves/' + $(this).attr('data-card') + ')',
			// 	'width': width,
			// 	'height': height
			// });

			// $('#js-sleeve-card').delay(200).queue(function(next) {
			// 	$(this).addClass('is-focus');
			// 	$('#js-sleeve-card').css({
			// 	'background-image': 'url(/dist/img/sleeves/' + $(this).attr('data-card') + ')',
			// 	'width': width,
			// 	'height': height
			// });
			// 	next();
			// });
			
		}
		
		
		// $('#js-sleeve-card').delay(200).queue(function(next) {
		// 	$(this).addClass('is-focus');
		// 	next();
		// });
		function updateModal() {
			$('.js-sleeve').height(displayHeight);
			$('.js-sleeve').width(displayWidth);
			$('#js-sleeve-card').css({
				'background-image': 'url(' + card + ')',
				'width': displayWidth,
				'height': displayHeight
			});
			setTimeout(function() {
				$('#js-sleeve-card').addClass('is-focus');
			}, 300);
			// $().delay(500).queue(function(next) {
				
			// });
			$('.js-sleeve-name').html(name);
			$('#js-sleeve-price').html(price);
			$('#js-sleeve-id').html(id);
			$('#js-sleeve-description').html(description);
			$('#js-sleeve-dimensions').html(width + ' x ' + height + ' mm');
			$('#js-sleeve-stock').html(stock);
			$('#js-sleeve-games').html(games);
			$('#js-sleeve-id-hidden').attr({
				"value":id
			});
			$('#js-sleeve-badge').attr('src', badge);
		}

	});
	$('.js-modal-close').on('click', function() {
		$('#js-sleeve-card').removeClass('is-focus');
		$(this).parent('.modal').delay(300).fadeOut();
		$('.form-search form').delay(300).fadeIn();

	});
});