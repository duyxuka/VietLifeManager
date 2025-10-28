import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { LayoutService } from './service/app.layout.service';

@Component({
  selector: 'app-menu',
  templateUrl: './app.menu.component.html',
})
export class AppMenuComponent implements OnInit {
  model: any[] = [];

  constructor(public layoutService: LayoutService) { }

  ngOnInit() {
    this.model = [
      {
        label: 'Trang chủ',
        items: [{ label: 'Dashboard', icon: 'pi pi-fw pi-home', routerLink: ['/'] }],
      },
      {
        label: 'Nhân Sự',
        items: [
          // {
          //   label: 'Danh sách sản phẩm',
          //   icon: 'pi pi-fw pi-circle',
          //   routerLink: ['/catalog/product'],
          //   permission: 'VietLifeAdminCatalog.Product',
          // },
          // {
          //   label: 'Danh sách thuộc tính',
          //   icon: 'pi pi-fw pi-circle',
          //   routerLink: ['/catalog/attribute'],
          //   permission: 'VietLifeAdminCatalog.Attribute',
          // },
          {
            label: 'Danh sách chi nhánh',
            icon: 'pi pi-fw pi-circle',
            routerLink: ['/catalog/chinhanh'],
            permission: 'VietLifeAdminCatalog.ChiNhanh',
          },
          {
            label: 'Danh sách phòng ban',
            icon: 'pi pi-fw pi-circle',
            routerLink: ['/catalog/phongban'],
            permission: 'VietLifeAdminCatalog.PhongBan',
          },
          {
            label: 'Danh sách chức vụ',
            icon: 'pi pi-fw pi-circle',
            routerLink: ['/catalog/chucvu'],
            permission: 'VietLifeAdminCatalog.ChucVu',
          },
          {
            label: 'Bảng chấm công',
            icon: 'pi pi-fw pi-circle',
            routerLink: ['/catalog/chamcong'],
            permission: 'VietLifeAdminCatalog.ChamCong',
          },
          {
            label: 'Danh sách lịch làm việc',
            icon: 'pi pi-fw pi-circle',
            routerLink: ['/catalog/lichlamviec'],
            permission: 'VietLifeAdminCatalog.LichLamViec',
          },
          {
            label: 'Chế độ làm việc',
            permission: 'VietLifeAdminCatalog.CheDoNhanVien',
            items: [
              {
                label: 'Danh sách loại chế độ',
                icon: 'pi pi-fw pi-circle',
                routerLink: ['/catalog/loaichedo'],
                permission: 'VietLifeAdminCatalog.LoaiCheDo',
              },
              {
                label: 'Danh sách chế độ nhân viên',
                icon: 'pi pi-fw pi-circle',
                routerLink: ['/catalog/chedonhanvien'],
                permission: 'VietLifeAdminCatalog.CheDoNhanVien',
              },
            ]
          },
          {
            label: 'Phụ cấp nhân viên',
            icon: 'pi pi-fw pi-circle',
            routerLink: ['/catalog/phucapnhanvien'],
            permission: 'VietLifeAdminCatalog.PhuCapNhanVien',
          },
          {
            label: 'KPI',
            permission: 'VietLifeAdminCatalog.KpiNhanVien',
            items: [
              {
                label: 'KPI nhân viên',
                icon: 'pi pi-fw pi-circle',
                routerLink: ['/catalog/kpis/kpinhanvien'],
                permission: 'VietLifeAdminCatalog.KpiNhanVien',
              },
              {
                label: 'Kế hoạch công việc',
                icon: 'pi pi-fw pi-circle',
                routerLink: ['/catalog/kpis/kehoachcongviec'],
                permission: 'VietLifeAdminCatalog.KpiNhanVien.KeHoachCongViec',
              },
              {
                label: 'Mục tiêu KPI',
                icon: 'pi pi-fw pi-circle',
                routerLink: ['/catalog/kpis/muctieukpi'],
                permission: 'VietLifeAdminCatalog.KpiNhanVien.MucTieuKpi',
              },
              {
                label: 'Tiến độ làm việc',
                icon: 'pi pi-fw pi-circle',
                routerLink: ['/catalog/kpis/tiendolamviec'],
                permission: 'VietLifeAdminCatalog.KpiNhanVien.TienDoLamViec',
              },
              {
                label: 'Đánh giá KPI',
                icon: 'pi pi-fw pi-circle',
                routerLink: ['/catalog/kpis/danhgiakpi'],
                permission: 'VietLifeAdminCatalog.KpiNhanVien.DanhGiaKpi',
              },
            ],
          },
          {
            label: 'Lương nhân viên',
            icon: 'pi pi-fw pi-circle',
            routerLink: ['/catalog/luongnhanvien'],
            permission: 'VietLifeAdminCatalog.LuongNhanvien',
          },
        ],
      },
      {
        label: 'Hệ thống',
        items: [
          {
            label: 'Danh sách quyền',
            icon: 'pi pi-fw pi-circle',
            routerLink: ['/system/role'],
            permission: 'AbpIdentity.Roles',
          },
          {
            label: 'Danh sách người dùng',
            icon: 'pi pi-fw pi-circle',
            routerLink: ['/system/user'],
            permission: 'AbpIdentity.Users',
          },
        ],
      },
    ];
  }
}
