import { RestService } from '@abp/ng.core';
import type { PagedResultDto, PagedResultRequestDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { CreateUpdateKpiNhanVienDto, KpiNhanVienDto, KpiNhanVienInListDto } from '../kpis/kpi-nhan-viens/models';
import type { BaseListFilterDto } from '../../models';

@Injectable({
  providedIn: 'root',
})
export class KpiNhanViensService {
  apiName = 'Default';
  

  create = (input: CreateUpdateKpiNhanVienDto) =>
    this.restService.request<any, KpiNhanVienDto>({
      method: 'POST',
      url: '/api/app/kpi-nhan-viens',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/kpi-nhan-viens/${id}`,
    },
    { apiName: this.apiName });
  

  deleteMultiple = (ids: string[]) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: '/api/app/kpi-nhan-viens/multiple',
      params: { ids },
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, KpiNhanVienDto>({
      method: 'GET',
      url: `/api/app/kpi-nhan-viens/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: PagedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<KpiNhanVienDto>>({
      method: 'GET',
      url: '/api/app/kpi-nhan-viens',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  getListAll = () =>
    this.restService.request<any, KpiNhanVienInListDto[]>({
      method: 'GET',
      url: '/api/app/kpi-nhan-viens/all',
    },
    { apiName: this.apiName });
  

  getListFilter = (input: BaseListFilterDto) =>
    this.restService.request<any, PagedResultDto<KpiNhanVienInListDto>>({
      method: 'GET',
      url: '/api/app/kpi-nhan-viens/filter',
      params: { keyword: input.keyword, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: CreateUpdateKpiNhanVienDto) =>
    this.restService.request<any, KpiNhanVienDto>({
      method: 'PUT',
      url: `/api/app/kpi-nhan-viens/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
