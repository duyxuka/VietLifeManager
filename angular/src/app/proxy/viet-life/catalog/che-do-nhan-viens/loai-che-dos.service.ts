import { RestService } from '@abp/ng.core';
import type { PagedResultDto, PagedResultRequestDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { CreateUpdateLoaiCheDoDto, LoaiCheDoDto, LoaiCheDoInListDto } from '../che-dos/loai-che-dos/models';
import type { BaseListFilterDto } from '../../models';

@Injectable({
  providedIn: 'root',
})
export class LoaiCheDosService {
  apiName = 'Default';
  

  create = (input: CreateUpdateLoaiCheDoDto) =>
    this.restService.request<any, LoaiCheDoDto>({
      method: 'POST',
      url: '/api/app/loai-che-dos',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/loai-che-dos/${id}`,
    },
    { apiName: this.apiName });
  

  deleteMultiple = (ids: string[]) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: '/api/app/loai-che-dos/multiple',
      params: { ids },
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, LoaiCheDoDto>({
      method: 'GET',
      url: `/api/app/loai-che-dos/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: PagedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<LoaiCheDoDto>>({
      method: 'GET',
      url: '/api/app/loai-che-dos',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  getListAll = () =>
    this.restService.request<any, LoaiCheDoInListDto[]>({
      method: 'GET',
      url: '/api/app/loai-che-dos/all',
    },
    { apiName: this.apiName });
  

  getListFilter = (input: BaseListFilterDto) =>
    this.restService.request<any, PagedResultDto<LoaiCheDoInListDto>>({
      method: 'GET',
      url: '/api/app/loai-che-dos/filter',
      params: { keyword: input.keyword, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: CreateUpdateLoaiCheDoDto) =>
    this.restService.request<any, LoaiCheDoDto>({
      method: 'PUT',
      url: `/api/app/loai-che-dos/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
