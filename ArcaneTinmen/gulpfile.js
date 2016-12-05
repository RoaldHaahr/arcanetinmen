var gulp = require('gulp'),
    sass = require('gulp-sass');

var paths = {
    styles: 'sass/*.scss',
    cssDest: 'dist/css'
};

gulp.task('styles', function() {
    return gulp.src(paths.styles)
        .pipe(sass())
        .pipe(gulp.dest(paths.cssDest))
});

gulp.task('watch', function() {
    gulp.watch(paths.styles, ['styles']);
});

gulp.task('default', ['watch']);

