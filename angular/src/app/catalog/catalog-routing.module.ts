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
    component: PhongBanComponent,
    canActivate: [PermissionGuard],
    data: {
      requiredPolicy: 'VietLifeAdminCatalog.PhongBan.View',
    },
  },
  {
    path: 'chucvu',
    component: ChucVuComponent,
    canActivate: [PermissionGuard],
    data: {
      requiredPolicy: 'VietLifeAdminCatalog.ChucVu.View',
    },
  },
  {
    path: 'chamcong',
    component: ChamCongComponent,
    canActivate: [PermissionGuard],
    data: {
      requiredPolicy: 'VietLifeAdminCatalog.ChamCong.View',
    },
  },
  {
    path: 'chinhanh',
    component: ChiNhanhComponent,
    canActivate: [PermissionGuard],
    data: {
      requiredPolicy: 'VietLifeAdminCatalog.ChiNhanh.View',
    },
  },
  {
    path: 'lichlamviec',
    component: LichLamViecComponent,
    canActivate: [PermissionGuard],
    data: {
      requiredPolicy: 'VietLifeAdminCatalog.LichLamViec.View',
    },
  },
  {
    path: 'loaichedo',
    component: LoaiCheDoComponent,
    canActivate: [PermissionGuard],
    data: {
      requiredPolicy: 'VietLifeAdminCatalog.LoaiCheDo.View',
    },
  },
  {
    path: 'chedonhanvien',
    component: CheDoNhanVienComponent,
    canActivate: [PermissionGuard],
    data: {
      requiredPolicy: 'VietLifeAdminCatalog.CheDoNhanVien.View',
    },
  },
  {
    path: 'phucapnhanvien',
    component: PhuCapNhanVienComponent,
    canActivate: [PermissionGuard],
    data: {
      requiredPolicy: 'VietLifeAdminCatalog.PhuCapNhanVien.View',
    },
  },
  {
    path: 'kpis',
    canActivate: [PermissionGuard],
    data: { requiredPolicy: 'VietLifeAdminCatalog.KpiNhanVien.View' },
    children: [
      {
        path: 'kpinhanvien',
        component: KpiNhanVienComponent,
        canActivate: [PermissionGuard],
        data: { requiredPolicy: 'VietLifeAdminCatalog.KpiNhanVien.View' },
      },
      {
        path: 'kehoachcongviec',
        component: KeHoachCongViecComponent,
        canActivate: [PermissionGuard],
        data: { requiredPolicy: 'VietLifeAdminCatalog.KpiNhanVien.KeHoachCongViec.View' },
      },
      {
        path: 'muctieukpi',
        component: MucTieuKpiComponent,
        canActivate: [PermissionGuard],
        data: { requiredPolicy: 'VietLifeAdminCatalog.KpiNhanVien.MucTieuKpi.View' },
      },
      {
        path: 'tiendolamviec',
        component: TienDoLamViecComponent,
        canActivate: [PermissionGuard],
        data: { requiredPolicy: 'VietLifeAdminCatalog.KpiNhanVien.TienDoLamViec.View' },
      },
      {
        path: 'danhgiakpi',
        component: DanhGiaKpiComponent,
        canActivate: [PermissionGuard],
        data: { requiredPolicy: 'VietLifeAdminCatalog.KpiNhanVien.DanhGiaKpi.View' },
      },
    ],
  },

  {
    path: 'luongnhanvien',
    component: LuongNhanvienComponent,
    canActivate: [PermissionGuard],
    data: {
      requiredPolicy: 'VietLifeAdminCatalog.LuongNhanVien.View',
    },
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CatalogRoutingModule { }
