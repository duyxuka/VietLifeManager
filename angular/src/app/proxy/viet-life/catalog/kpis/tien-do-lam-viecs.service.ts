import { RestService } from '@abp/ng.core';
import type { PagedResultDto, PagedResultRequestDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { CreateUpdateTienDoLamViecDto, TienDoLamViecDto, TienDoLamViecInListDto } from '../kpis/tien-do-lam-viecs/models';
import type { BaseListFilterDto } from '../../models';

@Injectable({
  providedIn: 'root',
})
export class TienDoLamViecsService {
  apiName = 'Default';
  

  create = (input: CreateUpdateTienDoLamViecDto) =>
    this.restService.request<any, TienDoLamViecDto>({
      method: 'POST',
      url: '/api/app/tien-do-lam-viecs',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/tien-do-lam-viecs/${id}`,
    },
    { apiName: this.apiName });
  

  deleteMultiple = (ids: string[]) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: '/api/app/tien-do-lam-viecs/multiple',
      params: { ids },
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, TienDoLamViecDto>({
      method: 'GET',
      url: `/api/app/tien-do-lam-viecs/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: PagedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<TienDoLamViecDto>>({
      method: 'GET',
      url: '/api/app/tien-do-lam-viecs',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  getListAll = () =>
    this.restService.request<any, TienDoLamViecInListDto[]>({
      method: 'GET',
      url: '/api/app/tien-do-lam-viecs/all',
    },
    { apiName: this.apiName });
  

  getListFilter = (input: BaseListFilterDto) =>
    this.restService.request<any, PagedResultDto<TienDoLamViecInListDto>>({
      method: 'GET',
      url: '/api/app/tien-do-lam-viecs/filter',
      params: { keyword: input.keyword, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: CreateUpdateTienDoLamViecDto) =>
    this.restService.request<any, TienDoLamViecDto>({
      method: 'PUT',
      url: `/api/app/tien-do-lam-viecs/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
