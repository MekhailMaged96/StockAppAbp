import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { authGuard, ListService, permissionGuard } from '@abp/ng.core';
import { ProductComponent } from './product.component';

const routes: Routes = [{ path: '', component: ProductComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ProductRoutingModule {}
