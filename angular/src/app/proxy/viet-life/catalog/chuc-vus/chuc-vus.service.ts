import type { ChucVuDto, ChucVuInListDto, CreateUpdateChucVuDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto, PagedResultRequestDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { BaseListFilterDto } from '../../models';

@Injectable({
  providedIn: 'root',
})
export class ChucVusService {
  apiName = 'Default';
  

  create = (input: CreateUpdateChucVuDto) =>
    this.restService.request<any, ChucVuDto>({
      method: 'POST',
      url: '/api/app/chuc-vus',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/chuc-vus/${id}`,
    },
    { apiName: this.apiName });
  

  deleteMultiple = (ids: string[]) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: '/api/app/chuc-vus/multiple',
      params: { ids },
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, ChucVuDto>({
      method: 'GET',
      url: `/api/app/chuc-vus/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: PagedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<ChucVuDto>>({
      method: 'GET',
      url: '/api/app/chuc-vus',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  getListAll = () =>
    this.restService.request<any, ChucVuInListDto[]>({
      method: 'GET',
      url: '/api/app/chuc-vus/all',
    },
    { apiName: this.apiName });
  

  getListFilter = (input: BaseListFilterDto) =>
    this.restService.request<any, PagedResultDto<ChucVuInListDto>>({
      method: 'GET',
      url: '/api/app/chuc-vus/filter',
      params: { keyword: input.keyword, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: CreateUpdateChucVuDto) =>
    this.restService.request<any, ChucVuDto>({
      method: 'PUT',
      url: `/api/app/chuc-vus/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
