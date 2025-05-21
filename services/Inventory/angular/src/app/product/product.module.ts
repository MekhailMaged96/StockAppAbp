import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductRoutingModule } from './product.routing.module';
import { SharedModule } from '../shared/shared.module';
import { ProductComponent } from './product.component';
import { ListService } from '@abp/ng.core';

@NgModule({
  declarations: [ProductComponent],
  imports: [CommonModule, SharedModule, ProductRoutingModule],
  providers: [ListService],
})
export class ProductModule {}
