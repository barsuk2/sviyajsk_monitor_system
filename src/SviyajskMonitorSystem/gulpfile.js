/// <binding AfterBuild='default' Clean='clean' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var del = require('del');

gulp.task('restore', function () {
    gulp.src([
        'node_modules/core-js/client/**/*.js',
        'node_modules/zone.js/dist/*.js',
        'node_modules/reflect-metadata/reflect.js',
        'node_modules/systemjs/dist/*.js',
        'node_modules/@angular/**/bundles/*.js',
        'node_modules/rxjs/**/*.js',
        'node_modules/angular2-in-memory-web-api/**/*.js'
        /*
        'node_modules/jquery/dist/ *.js',
        'node_modules/bootstrap/dist/ ** / *.*' */
    ], { base: './node_modules' }).pipe(gulp.dest('./wwwroot/libs'));
    gulp.src([
        'app/**/*.js'
    ]).pipe(gulp.dest('./wwwroot/app'));
});

gulp.task('clean', function () {
    del(['wwwroot/app/**/*']);
    return del(['wwwroot/libs/**/*']);
});

gulp.task('default', ['restore'], function () {

});