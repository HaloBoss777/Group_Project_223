module.exports = {
  devServer: {
    proxy: 'http://api.back.end',
  },
    publicPath: '/',
    configureWebpack: {
      devtool: 'source-map'
    },
    chainWebpack: config => {
      config.module.rules.delete('eslint');
    },
    transpileDependencies: [
      'vue-echarts',
      'resize-detector'
    ]
  }