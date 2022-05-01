module.exports = {
  devServer: {
    proxy: {
      '/api': {
        target: 'https://localhost:7132',
        // target: 'http://10.51.10.4:8092/',
      },
    },
    // disableHostCheck: true,
  },
  lintOnSave: false,
  outputDir: '../server/wwwroot',
  // publicPath: process.env.NODE_ENV === 'development'
  //   ? '/' : '/metrisis/',
    // ? '/' : '/',
}
