import type { CreateUpdatePhuCapNhanVienDto, PhuCapNhanVienDto, PhuCapNhanVienFilterListDto, PhuCapNhanVienInListDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto, PagedResultRequestDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class PhuCapNhanViensService {
  apiName = 'Default';
  

  create = (input: CreateUpdatePhuCapNhanVienDto) =>
    this.restService.request<any, PhuCapNhanVienDto>({
      method: 'POST',
      url: '/api/app/phu-cap-nhan-viens',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/phu-cap-nhan-viens/${id}`,
    },
    { apiName: this.apiName });
  

  deleteMultiple = (ids: string[]) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: '/api/app/phu-cap-nhan-viens/multiple',
      params: { ids },
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, PhuCapNhanVienDto>({
      method: 'GET',
      url: `/api/app/phu-cap-nhan-viens/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: PagedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<PhuCapNhanVienDto>>({
      method: 'GET',
      url: '/api/app/phu-cap-nhan-viens',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  getListAll = () =>
    this.restService.request<any, PhuCapNhanVienInListDto[]>({
      method: 'GET',
      url: '/api/app/phu-cap-nhan-viens/all',
    },
    { apiName: this.apiName });
  

  getListFilter = (input: PhuCapNhanVienFilterListDto) =>
    this.restService.request<any, PagedResultDto<PhuCapNhanVienInListDto>>({
      method: 'GET',
      url: '/api/app/phu-cap-nhan-viens/filter',
      params: { chucVuId: input.chucVuId, keyword: input.keyword, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: CreateUpdatePhuCapNhanVienDto) =>
    this.restService.request<any, PhuCapNhanVienDto>({
      method: 'PUT',
      url: `/api/app/phu-cap-nhan-viens/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
