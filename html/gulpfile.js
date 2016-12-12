var gulp = require('gulp'),
    sass = require('gulp-sass'),
    livereload = require('gulp-livereload');

var paths = {
    styles: 'assets/sass/source/**/*.scss',
    cssDest: 'dist/css'
};

gulp.task('styles', function() {
    return gulp.src("assets/sass/source/main.scss")
        .pipe(sass())
        .pipe(gulp.dest(paths.cssDest))
        .pipe(livereload());
});

gulp.task('watch', function() {
	livereload.listen();
    gulp.watch(paths.styles, ['styles']);
});

gulp.task('default', ['watch']);
