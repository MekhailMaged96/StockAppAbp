import type { AuditedEntityDto } from '@abp/ng.core';

export interface CreateOrderDto {
  productId?: string;
  productName?: string;
  quantity: number;
  price: number;
}

export interface OrderDto extends AuditedEntityDto<string> {
  productId?: string;
  productName?: string;
  quantity: number;
  price: number;
  status?: string;
}
