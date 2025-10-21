import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { ProductComponent } from './product/product.component';
import { PanelModule } from 'primeng/panel';
import { TableModule } from 'primeng/table';
import { PaginatorModule } from 'primeng/paginator';
import { BlockUIModule } from 'primeng/blockui';
import { ButtonModule } from 'primeng/button';
import { DropdownModule } from 'primeng/dropdown';
import { InputTextModule } from 'primeng/inputtext';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { DynamicDialogModule } from 'primeng/dynamicdialog';
import { ProductDetailComponent } from './product/product-detail.component';
import { InputNumberModule } from 'primeng/inputnumber';
import { CheckboxModule } from 'primeng/checkbox';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { EditorModule } from 'primeng/editor';
import { VietLifeSharedModule } from '../shared/modules/vietlife-shared.module';
import { BadgeModule } from 'primeng/badge';
import { ImageModule } from 'primeng/image';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ProductAttributeComponent } from './product/product-attribute.component';
import { CalendarModule } from 'primeng/calendar';
import { CatalogRoutingModule } from './catalog-routing.module';
import { AttributeComponent } from './attribute/attribute.component';
import { AttributeDetailComponent } from './attribute/attribute-detail.component';
import { PhongBanComponent } from './phongban/phongban.component';
import { PhongBanDetailComponent } from './phongban/phongban-detail.component';
import { ChucVuComponent } from './chucvu/chucvu.component';
import { ChucVuDetailComponent } from './chucvu/chucvu-detail.component';
import { ChamCongComponent } from './chamcong/chamcong.component';
import { ChamCongDetailComponent } from './chamcong/chamcong-detail.component';
import { InputSwitchModule } from 'primeng/inputswitch';
import { ChiNhanhComponent } from './chinhanh/chinhanh.component';
import { ChiNhanhDetailComponent } from './chinhanh/chinhanh-detail.component';
import { LichLamViecComponent } from './lichlamviec/lichlamviec.component';
import { LichLamViecDetailComponent } from './lichlamviec/lichlamviec-detail.component';
import { TooltipModule } from 'primeng/tooltip';
import { LoaiCheDoComponent } from './loaichedo/loaichedo.component';
import { LoaiCheDoDetailComponent } from './loaichedo/loaichedo-detail.component';
import { CheDoNhanVienComponent } from './chedonhanvien/chedonhanvien.component';
import { CheDoNhanVienDetailComponent } from './chedonhanvien/chedonhanvien-detail.component';
import { PhuCapNhanVienComponent } from './phucapnhanvien/phucapnhanvien.component';
import { PhuCapNhanVienDetailComponent } from './phucapnhanvien/phucapnhanvien-detail.component';

@NgModule({
  declarations: [
    ProductComponent,
    ProductDetailComponent,
    ProductAttributeComponent,
    AttributeComponent,
    AttributeDetailComponent,
    PhongBanComponent,
    PhongBanDetailComponent,
    ChucVuComponent,
    ChucVuDetailComponent,
    ChamCongComponent,
    ChamCongDetailComponent,
    ChiNhanhComponent,
    ChiNhanhDetailComponent,
    LichLamViecComponent,
    LichLamViecDetailComponent,
    LoaiCheDoComponent,
    LoaiCheDoDetailComponent,
    CheDoNhanVienComponent,
    CheDoNhanVienDetailComponent,
    PhuCapNhanVienComponent,
    PhuCapNhanVienDetailComponent
  ],
  imports: [
    SharedModule,
    CatalogRoutingModule,
    PanelModule,
    TableModule,
    PaginatorModule,
    BlockUIModule,
    ButtonModule,
    DropdownModule,
    InputTextModule,
    ProgressSpinnerModule,
    DynamicDialogModule,
    InputNumberModule,
    CheckboxModule,
    InputTextareaModule,
    EditorModule,
    VietLifeSharedModule,
    BadgeModule,
    ImageModule,
    ConfirmDialogModule,
    CalendarModule,
    InputSwitchModule,
    TooltipModule
  ],
  entryComponents: [
    ProductDetailComponent, 
    ProductAttributeComponent, 
    AttributeDetailComponent, 
    PhongBanDetailComponent, 
    ChucVuDetailComponent, 
    ChamCongDetailComponent,
    ChiNhanhDetailComponent,
    LichLamViecDetailComponent,
    LoaiCheDoDetailComponent,
    CheDoNhanVienDetailComponent,
    PhuCapNhanVienDetailComponent
  ],
})
export class CatalogModule { }
