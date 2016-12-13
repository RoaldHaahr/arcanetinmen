$(document).ready(function() {
	$(".mobile-menu-open").click(function() {
		$(".site-nav").slideToggle("fast");
		$(".mobile-menu-open").hide();
		$(".mobile-menu-close").show();
	});

	$(".mobile-menu-close").click(function() {
		$(".site-nav").slideToggle("fast");
		$(".mobile-menu-close").hide();
		$(".mobile-menu-open").show();
	});
});
