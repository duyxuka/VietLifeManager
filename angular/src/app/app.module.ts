import { LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { registerLocaleData } from '@angular/common';
import localeVi from '@angular/common/locales/vi';

import { CoreModule } from '@abp/ng.core';
import { AccountConfigModule } from '@abp/ng.account/config';
import { IdentityConfigModule } from '@abp/ng.identity/config';
import { SettingManagementConfigModule } from '@abp/ng.setting-management/config';
import { TenantManagementConfigModule } from '@abp/ng.tenant-management/config';
import { ThemeLeptonXModule } from '@abp/ng.theme.lepton-x';
import { SideMenuLayoutModule } from '@abp/ng.theme.lepton-x/layouts';
import { ThemeSharedModule } from '@abp/ng.theme.shared';

import { ConfirmationService, MessageService } from 'primeng/api';
import { DialogService } from 'primeng/dynamicdialog';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ToastModule } from 'primeng/toast';

import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from './shared/interceptors/token.interceptor';
import { GlobalHttpInterceptorService } from './shared/interceptors/error-handler.interceptor';

import { environment } from '../environments/environment';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AppLayoutModule } from './layout/app.layout.module';
import { APP_ROUTE_PROVIDER } from './route.provider';
import { NotificationService } from './shared/services/notification.service';
import { UtilityService } from './shared/services/utility.service';

// import hàm tự tạo
import { registerLocale } from './register-locale';

// đăng ký locale tiếng Việt cho Angular pipes (DatePipe, CurrencyPipe...)
registerLocaleData(localeVi);

@NgModule({
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    AppLayoutModule,
    CoreModule.forRoot({
      environment,
      registerLocaleFn: registerLocale, // 👈 đúng cú pháp
    }),
    ThemeSharedModule.forRoot(),
    AccountConfigModule.forRoot(),
    IdentityConfigModule.forRoot(),
    TenantManagementConfigModule.forRoot(),
    SettingManagementConfigModule.forRoot(),
    ThemeLeptonXModule.forRoot(),
    SideMenuLayoutModule.forRoot(),
    ConfirmDialogModule,
    ToastModule,
  ],
  declarations: [AppComponent],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: GlobalHttpInterceptorService, multi: true },
    { provide: LOCALE_ID, useValue: 'vi' }, // 👈 cấu hình locale mặc định
    APP_ROUTE_PROVIDER,
    DialogService,
    MessageService,
    NotificationService,
    UtilityService,
    ConfirmationService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
