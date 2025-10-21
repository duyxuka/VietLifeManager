import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { LayoutService } from './service/app.layout.service';

@Component({
  selector: 'app-menu',
  templateUrl: './app.menu.component.html',
})
export class AppMenuComponent implements OnInit {
  model: any[] = [];

  constructor(public layoutService: LayoutService) {}

  ngOnInit() {
    this.model = [
      {
        label: 'Trang chủ',
        items: [{ label: 'Dashboard', icon: 'pi pi-fw pi-home', routerLink: ['/'] }],
      },
      {
        label: 'Sản phẩm',
        items: [
          {
            label: 'Danh sách sản phẩm',
            icon: 'pi pi-fw pi-circle',
            routerLink: ['/catalog/product'],
            permission: 'VietLifeAdminCatalog.Product',
          },
          {
            label: 'Danh sách thuộc tính',
            icon: 'pi pi-fw pi-circle',
            routerLink: ['/catalog/attribute'],
            permission: 'VietLifeAdminCatalog.Attribute',
          },
          {
            label: 'Danh sách phòng ban',
            icon: 'pi pi-fw pi-circle',
            routerLink: ['/catalog/phongban'],
            // permission: 'VietLifeAdminCatalog.Attribute',
          },
          {
            label: 'Danh sách chức vụ',
            icon: 'pi pi-fw pi-circle',
            routerLink: ['/catalog/chucvu'],
            // permission: 'VietLifeAdminCatalog.Attribute',
          },
          {
            label: 'Bảng chấm công',
            icon: 'pi pi-fw pi-circle',
            routerLink: ['/catalog/chamcong'],
            // permission: 'VietLifeAdminCatalog.Attribute',
          },
          {
            label: 'Danh sách chi nhánh',
            icon: 'pi pi-fw pi-circle',
            routerLink: ['/catalog/chinhanh'],
            // permission: 'VietLifeAdminCatalog.Attribute',
          },
          {
            label: 'Danh sách lịch làm việc',
            icon: 'pi pi-fw pi-circle',
            routerLink: ['/catalog/lichlamviec'],
            // permission: 'VietLifeAdminCatalog.Attribute',
          },
          {
            label: 'Danh sách loại chế độ',
            icon: 'pi pi-fw pi-circle',
            routerLink: ['/catalog/loaichedo'],
            // permission: 'VietLifeAdminCatalog.Attribute',
          },
          {
            label: 'Danh sách chế độ nhân viên',
            icon: 'pi pi-fw pi-circle',
            routerLink: ['/catalog/chedonhanvien'],
            // permission: 'VietLifeAdminCatalog.Attribute',
          },
          {
            label: 'Danh sách chế độ nhân viên',
            icon: 'pi pi-fw pi-circle',
            routerLink: ['/catalog/phucapnhanvien'],
            // permission: 'VietLifeAdminCatalog.Attribute',
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
