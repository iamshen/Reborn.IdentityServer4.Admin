const path = require("path");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const CssMinimizerPlugin = require("css-minimizer-webpack-plugin");
const TerserPlugin = require("terser-webpack-plugin");
const CopyPlugin = require("copy-webpack-plugin");
const { CleanWebpackPlugin } = require("clean-webpack-plugin");

module.exports = {
  mode: "production",
  performance: {
    maxEntrypointSize: 512000,
    maxAssetSize: 512000,
  },
  entry: {
    "bundle.min": [
      "./node_modules/bootstrap/dist/js/bootstrap.bundle.min.js",
      "./node_modules/cookieconsent/build/cookieconsent.min.js",
      "./node_modules/holderjs/holder.min.js",
      "./Scripts/App/components/Menu.js",
      "./Scripts/App/components/Language.js",
      "./Scripts/App/components/Theme.js",
      "./Scripts/App/components/CookieConsent.js",
      "./node_modules/bootstrap/dist/css/bootstrap.min.css",
      "./node_modules/open-iconic/font/css/open-iconic-bootstrap.min.css",
      "./node_modules/font-awesome/css/font-awesome.min.css",
      "./node_modules/cookieconsent/build/cookieconsent.min.css",
    ],
    'web.min': "./Styles/web.scss", // 添加 web.scss 作为一个新的入口点
  },
  output: {
    filename: "js/[name].js", // 输出到 js 目录下
    path: path.resolve(__dirname, "wwwroot/dist"),
    clean: true, // 清理输出目录
  },
  module: {
    rules: [
      {
        test: /\.(scss|css)$/,
        use: [MiniCssExtractPlugin.loader, "css-loader", "sass-loader"],
      },
    ],
  },
  plugins: [
    new CleanWebpackPlugin(),
    new MiniCssExtractPlugin({
      filename: "css/[name].css",
    }),
    new CopyPlugin({
      patterns: [
        // Bootswatch 主题的复制规则
        {
          from: "node_modules/bootswatch/dist/*/bootstrap.min.css",
          to: ({ context, absoluteFilename }) => {
            const themeName = path.basename(path.dirname(absoluteFilename));
            return `css/themes/${themeName}/[name][ext]`;
          },
        },
      ],
    }),
    new CssMinimizerPlugin(),
    new TerserPlugin({
      extractComments: false,
    }),
  ],
  optimization: {
    minimize: true,
    minimizer: [new TerserPlugin(), new CssMinimizerPlugin()],
  },
};
