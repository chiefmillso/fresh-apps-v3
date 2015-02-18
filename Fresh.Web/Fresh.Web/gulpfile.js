/// <vs AfterBuild='build' />
var gulp = require('gulp');

var jshint = require('gulp-jshint');
var uglify = require('gulp-uglify');
var minifyCSS = require('gulp-minify-css');
var bowerFiles = require('gulp-bower-files');

var paths = {
    scripts: ['client/js/**/*.js', '!client/external/**/*.coffee'],
    images: 'client/img/**/*'
};

gulp.task('lint', function () {
    gulp.src(['./Scripts/**/*.js', '!./bower_components/**', '!./Scripts/lib/**'])
      .pipe(jshint())
      .pipe(jshint.reporter('default'))
      .pipe(jshint.reporter('fail'));
});

// task
gulp.task('bower-files', function () {
    bowerFiles().pipe(gulp.dest("./Scripts/lib"));
});

gulp.task('build', ['bower-files','lint'])

gulp.task('default', ['build']);