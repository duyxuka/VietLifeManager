import { PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AttributeComponent } from './attribute/attribute.component';
import { ProductComponent } from './product/product.component';
import { PhongBanComponent } from './phongban/phongban.component';
import { ChucVuComponent } from './chucvu/chucvu.component';
import { ChamCongComponent } from './chamcong/chamcong.component';
import { ChiNhanhComponent } from './chinhanh/chinhanh.component';
import { LichLamViecComponent } from './lichlamviec/lichlamviec.component';
import { LoaiCheDoComponent } from './loaichedo/loaichedo.component';
import { CheDoNhanVienComponent } from './chedonhanvien/chedonhanvien.component';
import { PhuCapNhanVienComponent } from './phucapnhanvien/phucapnhanvien.component';

const routes: Routes = [
  {
    path: 'product',
    component: ProductComponent,
    canActivate: [PermissionGuard],
    data: {
      requiredPolicy: 'VietLifeAdminCatalog.Product',
    },
  },
  {
    path: 'attribute',
    component: AttributeComponent,
    canActivate: [PermissionGuard],
    data: {
      requiredPolicy: 'VietLifeAdminCatalog.Attribute',
    },
  },
  {
    path: 'phongban',
    component: PhongBanComponent
  },
  {
    path: 'chucvu',
    component: ChucVuComponent
  },
  {
    path: 'chamcong',
    component: ChamCongComponent
  },
  {
    path: 'chinhanh',
    component: ChiNhanhComponent
  },
  {
    path: 'lichlamviec',
    component: LichLamViecComponent
  },
  {
    path: 'loaichedo',
    component: LoaiCheDoComponent
  },
  {
    path: 'chedonhanvien',
    component: CheDoNhanVienComponent
  },
  {
    path: 'phucapnhanvien',
    component: PhuCapNhanVienComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CatalogRoutingModule {}
