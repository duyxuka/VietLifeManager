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
import { KpiNhanVienComponent } from './kpis/kpinhanvien/kpinhanvien.component';
import { KeHoachCongViecComponent } from './kpis/kehoachcongviec/kehoachcongviec.component';
import { MucTieuKpiComponent } from './kpis/muctieukpi/muctieukpi.component';
import { TienDoLamViecComponent } from './kpis/tiendolamviec/tiendolamviec.component';
import { DanhGiaKpiComponent } from './kpis/danhgiakpi/danhgiakpi.component';
import { LuongNhanvienComponent } from './luongnhanvien/luongnhanvien.component';

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
  },
  {
    path: 'kpis',
    children: [
      { path: 'kpinhanvien', component: KpiNhanVienComponent },
      { path: 'kehoachcongviec', component: KeHoachCongViecComponent },
      { path: 'muctieukpi', component: MucTieuKpiComponent },
      { path: 'tiendolamviec', component: TienDoLamViecComponent },
      { path: 'danhgiakpi', component: DanhGiaKpiComponent },
    ],
  },
  {
    path: 'luongnhanvien',
    component: LuongNhanvienComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CatalogRoutingModule {}
