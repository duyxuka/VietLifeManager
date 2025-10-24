import { RestService } from '@abp/ng.core';
import type { PagedResultDto, PagedResultRequestDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { CreateUpdateMucTieuKpiDto, MucTieuKpiDto, MucTieuKpiInListDto } from '../kpis/muc-tieu-kpis/models';
import type { BaseListFilterDto } from '../../models';

@Injectable({
  providedIn: 'root',
})
export class MucTieuKpisService {
  apiName = 'Default';
  

  create = (input: CreateUpdateMucTieuKpiDto) =>
    this.restService.request<any, MucTieuKpiDto>({
      method: 'POST',
      url: '/api/app/muc-tieu-kpis',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/muc-tieu-kpis/${id}`,
    },
    { apiName: this.apiName });
  

  deleteMultiple = (ids: string[]) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: '/api/app/muc-tieu-kpis/multiple',
      params: { ids },
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, MucTieuKpiDto>({
      method: 'GET',
      url: `/api/app/muc-tieu-kpis/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: PagedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<MucTieuKpiDto>>({
      method: 'GET',
      url: '/api/app/muc-tieu-kpis',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  getListAll = () =>
    this.restService.request<any, MucTieuKpiInListDto[]>({
      method: 'GET',
      url: '/api/app/muc-tieu-kpis/all',
    },
    { apiName: this.apiName });
  

  getListFilter = (input: BaseListFilterDto) =>
    this.restService.request<any, PagedResultDto<MucTieuKpiInListDto>>({
      method: 'GET',
      url: '/api/app/muc-tieu-kpis/filter',
      params: { keyword: input.keyword, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: CreateUpdateMucTieuKpiDto) =>
    this.restService.request<any, MucTieuKpiDto>({
      method: 'PUT',
      url: `/api/app/muc-tieu-kpis/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
