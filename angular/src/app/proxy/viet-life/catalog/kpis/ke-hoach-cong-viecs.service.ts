import { RestService } from '@abp/ng.core';
import type { PagedResultDto, PagedResultRequestDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { CreateUpdateKeHoachCongViecDto, KeHoachCongViecDto, KeHoachCongViecInListDto } from '../kpis/ke-hoach-cong-viecs/models';
import type { BaseListFilterDto } from '../../models';

@Injectable({
  providedIn: 'root',
})
export class KeHoachCongViecsService {
  apiName = 'Default';
  

  create = (input: CreateUpdateKeHoachCongViecDto) =>
    this.restService.request<any, KeHoachCongViecDto>({
      method: 'POST',
      url: '/api/app/ke-hoach-cong-viecs',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/ke-hoach-cong-viecs/${id}`,
    },
    { apiName: this.apiName });
  

  deleteMultiple = (ids: string[]) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: '/api/app/ke-hoach-cong-viecs/multiple',
      params: { ids },
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, KeHoachCongViecDto>({
      method: 'GET',
      url: `/api/app/ke-hoach-cong-viecs/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: PagedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<KeHoachCongViecDto>>({
      method: 'GET',
      url: '/api/app/ke-hoach-cong-viecs',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  getListAll = () =>
    this.restService.request<any, KeHoachCongViecInListDto[]>({
      method: 'GET',
      url: '/api/app/ke-hoach-cong-viecs/all',
    },
    { apiName: this.apiName });
  

  getListFilter = (input: BaseListFilterDto) =>
    this.restService.request<any, PagedResultDto<KeHoachCongViecInListDto>>({
      method: 'GET',
      url: '/api/app/ke-hoach-cong-viecs/filter',
      params: { keyword: input.keyword, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: CreateUpdateKeHoachCongViecDto) =>
    this.restService.request<any, KeHoachCongViecDto>({
      method: 'PUT',
      url: `/api/app/ke-hoach-cong-viecs/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
