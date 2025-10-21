import type { CreateUpdateLichLamViecDto, LichLamViecDto, LichLamViecInListDto, LichLamViecListFilterDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto, PagedResultRequestDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class LichLamViecsService {
  apiName = 'Default';
  

  create = (input: CreateUpdateLichLamViecDto) =>
    this.restService.request<any, LichLamViecDto>({
      method: 'POST',
      url: '/api/app/lich-lam-viecs',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/lich-lam-viecs/${id}`,
    },
    { apiName: this.apiName });
  

  deleteMultiple = (ids: string[]) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: '/api/app/lich-lam-viecs/multiple',
      params: { ids },
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, LichLamViecDto>({
      method: 'GET',
      url: `/api/app/lich-lam-viecs/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: PagedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<LichLamViecDto>>({
      method: 'GET',
      url: '/api/app/lich-lam-viecs',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  getListAll = () =>
    this.restService.request<any, LichLamViecInListDto[]>({
      method: 'GET',
      url: '/api/app/lich-lam-viecs/all',
    },
    { apiName: this.apiName });
  

  getListFilter = (input: LichLamViecListFilterDto) =>
    this.restService.request<any, PagedResultDto<LichLamViecInListDto>>({
      method: 'GET',
      url: '/api/app/lich-lam-viecs/filter',
      params: { startDate: input.startDate, endDate: input.endDate, keyword: input.keyword, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: CreateUpdateLichLamViecDto) =>
    this.restService.request<any, LichLamViecDto>({
      method: 'PUT',
      url: `/api/app/lich-lam-viecs/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
