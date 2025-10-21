import type { CreateUpdatePhongBanDto, PhongBanDto, PhongBanInListDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto, PagedResultRequestDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { BaseListFilterDto } from '../../models';

@Injectable({
  providedIn: 'root',
})
export class PhongBansService {
  apiName = 'Default';
  

  create = (input: CreateUpdatePhongBanDto) =>
    this.restService.request<any, PhongBanDto>({
      method: 'POST',
      url: '/api/app/phong-bans',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/phong-bans/${id}`,
    },
    { apiName: this.apiName });
  

  deleteMultiple = (ids: string[]) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: '/api/app/phong-bans/multiple',
      params: { ids },
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, PhongBanDto>({
      method: 'GET',
      url: `/api/app/phong-bans/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: PagedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<PhongBanDto>>({
      method: 'GET',
      url: '/api/app/phong-bans',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  getListAll = () =>
    this.restService.request<any, PhongBanInListDto[]>({
      method: 'GET',
      url: '/api/app/phong-bans/all',
    },
    { apiName: this.apiName });
  

  getListFilter = (input: BaseListFilterDto) =>
    this.restService.request<any, PagedResultDto<PhongBanInListDto>>({
      method: 'GET',
      url: '/api/app/phong-bans/filter',
      params: { keyword: input.keyword, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: CreateUpdatePhongBanDto) =>
    this.restService.request<any, PhongBanDto>({
      method: 'PUT',
      url: `/api/app/phong-bans/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
