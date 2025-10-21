import type { ChiNhanhDto, ChiNhanhInListDto, CreateUpdateChiNhanhDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto, PagedResultRequestDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { BaseListFilterDto } from '../../models';

@Injectable({
  providedIn: 'root',
})
export class ChiNhanhsService {
  apiName = 'Default';
  

  create = (input: CreateUpdateChiNhanhDto) =>
    this.restService.request<any, ChiNhanhDto>({
      method: 'POST',
      url: '/api/app/chi-nhanhs',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/chi-nhanhs/${id}`,
    },
    { apiName: this.apiName });
  

  deleteMultiple = (ids: string[]) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: '/api/app/chi-nhanhs/multiple',
      params: { ids },
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, ChiNhanhDto>({
      method: 'GET',
      url: `/api/app/chi-nhanhs/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: PagedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<ChiNhanhDto>>({
      method: 'GET',
      url: '/api/app/chi-nhanhs',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  getListAll = () =>
    this.restService.request<any, ChiNhanhInListDto[]>({
      method: 'GET',
      url: '/api/app/chi-nhanhs/all',
    },
    { apiName: this.apiName });
  

  getListFilter = (input: BaseListFilterDto) =>
    this.restService.request<any, PagedResultDto<ChiNhanhInListDto>>({
      method: 'GET',
      url: '/api/app/chi-nhanhs/filter',
      params: { keyword: input.keyword, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: CreateUpdateChiNhanhDto) =>
    this.restService.request<any, ChiNhanhDto>({
      method: 'PUT',
      url: `/api/app/chi-nhanhs/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
