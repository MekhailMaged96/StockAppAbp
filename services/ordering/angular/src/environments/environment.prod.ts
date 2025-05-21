import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4300';

const oAuthConfig = {
  issuer: 'https://localhost:44394/',
  redirectUri: baseUrl,
  clientId: 'OrderingService_App',
  responseType: 'code',
  scope: 'offline_access OrderingService',
  requireHttps: true,
};

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'OrderingService',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44394',
      rootNamespace: 'OrderingService',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
  remoteEnv: {
    url: '/getEnvConfig',
    mergeStrategy: 'deepmerge',
  },
} as Environment;
