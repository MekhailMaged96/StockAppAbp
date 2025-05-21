import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44321/',
  redirectUri: baseUrl,
  clientId: 'InventoryService_App',
  responseType: 'code',
  scope: 'offline_access InventoryService',
  requireHttps: true,
};

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'InventoryService',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44321',
      rootNamespace: 'InventoryService',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
  remoteEnv: {
    url: '/getEnvConfig',
    mergeStrategy: 'deepmerge'
  }
} as Environment;
