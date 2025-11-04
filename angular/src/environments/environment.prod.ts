import { Environment } from '@abp/ng.core';

const baseUrl = 'http://192.168.1.223:8012';

const oAuthConfig = {
  issuer: 'http://192.168.1.223:8012/',
  redirectUri: baseUrl,
  clientId: 'VietLife_Admin',
  dummyClientSecret:'1q2w3e*',
  responseType: 'code',
  scope: 'offline_access VietLife.Admin',
  requireHttps: false, // vì bạn dùng HTTP
  useRefreshToken: true,
};

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'VietLife',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'http://192.168.1.223:8012',
      rootNamespace: 'VietLife.Admin',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
  remoteEnv: {
    url: '/getEnvConfig',
    mergeStrategy: 'deepmerge'
  },
  localization: {
    defaultResourceName: 'VietLife',
    supportedLocales: ['en', 'vi'],
  },
} as Environment;
