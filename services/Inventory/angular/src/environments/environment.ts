import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44362/',
  redirectUri: baseUrl,
  clientId: 'InventoryService_App',
  responseType: 'code',
  scope: 'offline_access InventoryService',
  requireHttps: true,
};

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'InventoryService',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44305',
      rootNamespace: 'InventoryService',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
} as Environment;
