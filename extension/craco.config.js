module.exports = {
  configure: (webpackConfig, { env, paths }) => {
    return {
      ...webpackConfig,
      entry: {
        main: [
          env === 'development' && require.resolve('react-dev-utils/webpackHotDevClient'),
          paths.appIndexJs,
        ].filter(Boolean),
        content: './src/chromeServices/ContentScript.tsx',
        background: './src/chromeServices/Background.ts',
      },
      output: {
        ...webpackConfig.output,
        filename: 'static/js/[name].js',
      },
      optimization: {
        ...webpackConfig.optimization,
        runtimeChunk: false,
      },
    };
  },
};
