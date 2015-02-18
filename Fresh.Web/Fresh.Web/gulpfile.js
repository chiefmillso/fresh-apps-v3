/// <vs AfterBuild='compile' />
var gulp = require('gulp');

var paths = {
    scripts: ['client/js/**/*.js', '!client/external/**/*.coffee'],
    images: 'client/img/**/*'
};

gulp.task('clean', function () {

});

gulp.task('scripts', function () {

});

gulp.task('compile', function () {

});

gulp.task('default', ['compile', 'scripts']);