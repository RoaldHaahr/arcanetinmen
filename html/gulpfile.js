var gulp = require('gulp'),
    sass = require('gulp-sass'),
    notify = require('gulp-notify'),
    livereload = require('gulp-livereload');

var paths = {
    styles: 'assets/sass/source/**/*.scss',
    cssDest: '../ArcaneTinmen/dist/css'
};

gulp.task('styles', function() {
    return gulp.src("assets/sass/source/main.scss")
        .pipe(sass())
        .on('error', function(err) {
            notify().write(err);
            this.emit('end');
        })
        .pipe(gulp.dest(paths.cssDest))
        .pipe(livereload())
        .pipe(notify({message: 'Sass compiled successfully!'}));
});

gulp.task('watch', function() {
    livereload.listen();
    gulp.watch(paths.styles, ['styles']);
});

gulp.task('default', ['watch']);