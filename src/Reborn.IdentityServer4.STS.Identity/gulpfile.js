import gulp from 'gulp';
import concat from 'gulp-concat';
import uglify from 'gulp-uglify';
import sassCompiler from 'sass';
import gulpSass from 'gulp-sass';
import minifyCSS from 'gulp-clean-css';
import { deleteAsync } from 'del';
import debug from 'gulp-debug'; // 首先需要安装 gulp-debug

const sass = gulpSass(sassCompiler);

var distFolder = "./wwwroot/dist/";
var jsFolder = `${distFolder}js/`;
var cssFolder = `${distFolder}css/`;
var cssThemeFolder = `${distFolder}css/themes/`;

function processClean() {
  return deleteAsync(`${distFolder}**`, { force: true });
}

function processScripts() {
  return gulp
    .src([
      "./node_modules/bootstrap/dist/js/bootstrap.bundle.min.js", // 更新 Bootstrap 脚本路径，并使用包含 Popper 的 bundle
      "./node_modules/cookieconsent/build/cookieconsent.min.js",
      "./node_modules/holderjs/holder.min.js", // 确保使用了 holderjs 的 min 文件
      "./Scripts/App/components/Menu.js",
      "./Scripts/App/components/Language.js",
      "./Scripts/App/components/Theme.js",
      "./Scripts/App/components/CookieConsent.js",
    ])
    .pipe(concat("bundle.min.js"))
    .pipe(uglify())
    .pipe(gulp.dest(jsFolder));
}

function processFonts() {
  return gulp
    .src([
      "./node_modules/font-awesome/fonts/**",
      "./node_modules/open-iconic/font/fonts/open-iconic.eot",
      "./node_modules/open-iconic/font/fonts/open-iconic.otf",
      "./node_modules/open-iconic/font/fonts/open-iconic.svg",
      "./node_modules/open-iconic/font/fonts/open-iconic.ttf",
      "./node_modules/open-iconic/font/fonts/open-iconic.woff",
    ])
    .pipe(debug({title: 'Copying fonts:'})) // 添加这行来输出处理的文件
    .pipe(gulp.dest(`${distFolder}fonts/`));
}

function processSass() {
  return gulp
    .src("Styles/web.scss")
    .pipe(sass())
    .on("error", sass.logError)
    .pipe(gulp.dest(cssFolder));
}

function processSassMin() {
  return gulp
    .src("Styles/web.scss")
    .pipe(sass())
    .on("error", sass.logError)
    .pipe(minifyCSS())
    .pipe(concat("web.min.css"))
    .pipe(gulp.dest(cssFolder));
}

function processStyles() {
  return gulp
    .src([
      "./node_modules/bootstrap/dist/css/bootstrap.min.css", // 使用 minified 版本的 CSS
      "./node_modules/open-iconic/font/css/open-iconic-bootstrap.min.css", // 确保使用 minified 版本
      "./node_modules/font-awesome/css/font-awesome.min.css", // 确保使用 minified 版本
      "./node_modules/cookieconsent/build/cookieconsent.min.css", // 确保使用 minified 版本
    ])
    .pipe(minifyCSS())
    .pipe(concat("bundle.min.css"))
    .pipe(gulp.dest(cssFolder));
}

function processTheme() {
  return gulp
    .src("node_modules/bootswatch/dist/**/bootstrap.min.css") // 使用 Bootswatch 的 minified 版本
    .pipe(gulp.dest(cssThemeFolder));
}

var buildStyles = gulp.series(
  processFonts,
  processStyles,
  processTheme,
  processSass,
  processSassMin
);
var build = gulp.parallel(buildStyles, processScripts);

gulp.task("clean", processClean);
gulp.task("styles", buildStyles);
gulp.task("sass", processSass);
gulp.task("sass:min", processSassMin);
gulp.task("fonts", processFonts);
gulp.task("scripts", processScripts);
gulp.task("build", build);
gulp.task("default", build);

// watch
function processWatch() {
  gulp.watch(["Styles/**/*.scss"], buildStyles);
}

gulp.task("watch", processWatch);
export default processWatch;
