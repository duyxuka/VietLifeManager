import { ChangeDetectorRef, Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { DomSanitizer } from '@angular/platform-browser';
import { ChucVuDto, ChucVusService } from '@proxy/viet-life/catalog/chuc-vus';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { Subject, takeUntil } from 'rxjs';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { UtilityService } from 'src/app/shared/services/utility.service';

@Component({
  selector: 'app-chucvu-detail',
  templateUrl: './chucvu-detail.component.html',
})
export class ChucVuDetailComponent implements OnInit, OnDestroy {
  private ngUnsubscribe = new Subject<void>();
  blockedPanel: boolean = false;
  btnDisabled = false;
  public form: FormGroup;

  //Dropdown
  selectedEntity = {} as ChucVuDto;

  constructor(
    private chucvuService: ChucVusService,
    private fb: FormBuilder,
    private config: DynamicDialogConfig,
    private ref: DynamicDialogRef,
    private utilService: UtilityService,
    private notificationSerivce: NotificationService
  ) { }

  validationMessages = {
    tenChucVu: [
      { type: 'required', message: 'Bạn phải nhập tên chức vụ' },
      { type: 'maxlength', message: 'Bạn không được nhập quá 255 kí tự' },
    ]
  };

  ngOnDestroy(): void {
    if (this.ref) {
      this.ref.close();
    }
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
  }

  ngOnInit(): void {
    this.buildForm();
    this.initFormData();
  }


  initFormData() {
    this.toggleBlockUI(true);
    //Load edit data to form
    if (this.utilService.isEmpty(this.config.data?.id) == true) {
      this.toggleBlockUI(false);
    } else {
      this.loadFormDetails(this.config.data?.id);
    }
  }

  loadFormDetails(id: string) {
    this.toggleBlockUI(true);
    this.chucvuService
      .get(id)
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe({
        next: (response: ChucVuDto) => {
          this.selectedEntity = response;
          this.buildForm();
          this.toggleBlockUI(false);
        },
        error: () => {
          this.toggleBlockUI(false);
        },
      });
  }

  saveChange() {
    this.toggleBlockUI(true);

    if (this.utilService.isEmpty(this.config.data?.id) == true) {
      this.chucvuService
        .create(this.form.value)
        .pipe(takeUntil(this.ngUnsubscribe))
        .subscribe({
          next: () => {
            this.toggleBlockUI(false);

            this.ref.close(this.form.value);
          },
          error: err => {
            this.notificationSerivce.showError(err.error.error.message);

            this.toggleBlockUI(false);
          },
        });
    } else {
      this.chucvuService
        .update(this.config.data?.id, this.form.value)
        .pipe(takeUntil(this.ngUnsubscribe))
        .subscribe({
          next: () => {
            this.toggleBlockUI(false);
            this.ref.close(this.form.value);
          },
          error: err => {
            this.notificationSerivce.showError(err.error.error.message);
            this.toggleBlockUI(false);
          },
        });
    }
  }

  private buildForm() {
    this.form = this.fb.group({
      tenChucVu: new FormControl(this.selectedEntity.tenChucVu || null, Validators.required),
      moTa: new FormControl(this.selectedEntity.moTa || null)
    });
  }

  private toggleBlockUI(enabled: boolean) {
    if (enabled == true) {
      this.blockedPanel = true;
      this.btnDisabled = true;
    } else {
      setTimeout(() => {
        this.blockedPanel = false;
        this.btnDisabled = false;
      }, 1000);
    }
  }

}
