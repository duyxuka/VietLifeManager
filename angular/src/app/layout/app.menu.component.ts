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
            permission: 'VietLifeAdminCatalog.ChiNhanh.View',
          },
          {
            label: 'Danh sách phòng ban',
            icon: 'pi pi-fw pi-circle',
            routerLink: ['/catalog/phongban'],
            permission: 'VietLifeAdminCatalog.PhongBan.View',
          },
          {
            label: 'Danh sách chức vụ',
            icon: 'pi pi-fw pi-circle',
            routerLink: ['/catalog/chucvu'],
            permission: 'VietLifeAdminCatalog.ChucVu.View',
          },
          {
            label: 'Bảng chấm công',
            icon: 'pi pi-fw pi-circle',
            routerLink: ['/catalog/chamcong'],
            permission: 'VietLifeAdminCatalog.ChamCong.View',
          },
          {
            label: 'Danh sách lịch làm việc',
            icon: 'pi pi-fw pi-circle',
            routerLink: ['/catalog/lichlamviec'],
            permission: 'VietLifeAdminCatalog.LichLamViec.View',
          },
          {
            label: 'Chế độ làm việc',
            permission: 'VietLifeAdminCatalog.CheDoNhanVien.View',
            items: [
              {
                label: 'Danh sách loại chế độ',
                icon: 'pi pi-fw pi-circle',
                routerLink: ['/catalog/loaichedo'],
                permission: 'VietLifeAdminCatalog.LoaiCheDo.View',
              },
              {
                label: 'Danh sách chế độ nhân viên',
                icon: 'pi pi-fw pi-circle',
                routerLink: ['/catalog/chedonhanvien'],
                permission: 'VietLifeAdminCatalog.CheDoNhanVien.View',
              },
            ]
          },
          {
            label: 'Phụ cấp nhân viên',
            icon: 'pi pi-fw pi-circle',
            routerLink: ['/catalog/phucapnhanvien'],
            permission: 'VietLifeAdminCatalog.PhuCapNhanVien.View',
          },
          {
            label: 'KPI',
            permission: 'VietLifeAdminCatalog.KpiNhanVien.View',
            items: [
              {
                label: 'KPI nhân viên',
                icon: 'pi pi-fw pi-circle',
                routerLink: ['/catalog/kpis/kpinhanvien'],
                permission: 'VietLifeAdminCatalog.KpiNhanVien.View',
              },
              {
                label: 'Kế hoạch công việc',
                icon: 'pi pi-fw pi-circle',
                routerLink: ['/catalog/kpis/kehoachcongviec'],
                permission: 'VietLifeAdminCatalog.KpiNhanVien.KeHoachCongViec.View',
              },
              {
                label: 'Mục tiêu KPI',
                icon: 'pi pi-fw pi-circle',
                routerLink: ['/catalog/kpis/muctieukpi'],
                permission: 'VietLifeAdminCatalog.KpiNhanVien.MucTieuKpi.View',
              },
              {
                label: 'Tiến độ làm việc',
                icon: 'pi pi-fw pi-circle',
                routerLink: ['/catalog/kpis/tiendolamviec'],
                permission: 'VietLifeAdminCatalog.KpiNhanVien.TienDoLamViec.View',
              },
              {
                label: 'Đánh giá KPI',
                icon: 'pi pi-fw pi-circle',
                routerLink: ['/catalog/kpis/danhgiakpi'],
                permission: 'VietLifeAdminCatalog.KpiNhanVien.DanhGiaKpi.View',
              },
            ],
          },
          {
            label: 'Lương nhân viên',
            icon: 'pi pi-fw pi-circle',
            routerLink: ['/catalog/luongnhanvien'],
            permission: 'VietLifeAdminCatalog.LuongNhanVien.View',
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
            permission: 'AbpIdentity.Roles.View',
          },
          {
            label: 'Danh sách người dùng',
            icon: 'pi pi-fw pi-circle',
            routerLink: ['/system/user'],
            permission: 'AbpIdentity.Users.View',
          },
        ],
      },
    ];
  }
}
