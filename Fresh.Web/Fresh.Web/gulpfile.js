/// <vs AfterBuild='build' />
var gulp = require('gulp');

var jshint = require('gulp-jshint');
var uglify = require('gulp-uglify');
var minifyCSS = require('gulp-minify-css');
var bower = require('gulp-bower-files');
var gulpFilter = require('gulp-filter');
var rename = require('gulp-rename');
var concat = require('gulp-concat');

var src = {
    styl: ['assets/**/*.styl'],
    css: ['assets/**/*.css'],
    coffee: ['assets/**/*.coffee'],
    js: ['assets/**/*.js'],
    bower: ['bower.json', '.bowerrc']
};

src.styles = src.styl.concat(src.css);
src.scripts = src.coffee.concat(src.js);

var publishdir = 'public'
var dist = {
    all: [publishdir + '/**/*'],
    css: publishdir + '/static/',
    js: publishdir + '/static/',
    vendor: publishdir + '/static/'
};

gulp.task('lint', function () {
    gulp.src(['./Scripts/**/*.js', '!./bower_components/**', '!./Scripts/lib/**'])
      .pipe(jshint())
      .pipe(jshint.reporter('default'))
      .pipe(jshint.reporter('fail'));
});

// task
gulp.task('bower-files', function () {
    var jsFilter = gulpFilter('**/*.js')
    var cssFilter = gulpFilter('**/*.css')
    return bower()
      .pipe(jsFilter)
      .pipe(concat('vendor.js'))
      .pipe(gulp.dest(dist.js))
      .pipe(jsFilter.restore())
      .pipe(cssFilter)
      .pipe(concat('vendor.css'))
      .pipe(gulp.dest(dist.css))
      .pipe(cssFilter.restore())
      .pipe(rename(function (path) {
          if (~path.dirname.indexOf('fonts')) {
              path.dirname = '/fonts'
          }
      }))
      .pipe(gulp.dest(dist.vendor));
});

gulp.task('build', ['bower-files','lint'])

gulp.task('default', ['build']);