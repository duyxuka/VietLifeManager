import type { ChamCongDto, ChamCongInListDto, ChamCongListFilterDto, CreateUpdateChamCongDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto, PagedResultRequestDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ChamCongsService {
  apiName = 'Default';
  

  checkIn = () =>
    this.restService.request<any, void>({
      method: 'POST',
      url: '/api/app/cham-congs/check-in',
    },
    { apiName: this.apiName });
  

  checkOut = () =>
    this.restService.request<any, void>({
      method: 'POST',
      url: '/api/app/cham-congs/check-out',
    },
    { apiName: this.apiName });
  

  create = (input: CreateUpdateChamCongDto) =>
    this.restService.request<any, ChamCongDto>({
      method: 'POST',
      url: '/api/app/cham-congs',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/cham-congs/${id}`,
    },
    { apiName: this.apiName });
  

  deleteMultiple = (ids: string[]) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: '/api/app/cham-congs/multiple',
      params: { ids },
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, ChamCongDto>({
      method: 'GET',
      url: `/api/app/cham-congs/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: PagedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<ChamCongDto>>({
      method: 'GET',
      url: '/api/app/cham-congs',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  getListAll = () =>
    this.restService.request<any, ChamCongInListDto[]>({
      method: 'GET',
      url: '/api/app/cham-congs/all',
    },
    { apiName: this.apiName });
  

  getListFilter = (input: ChamCongListFilterDto) =>
    this.restService.request<any, PagedResultDto<ChamCongInListDto>>({
      method: 'GET',
      url: '/api/app/cham-congs/filter',
      params: { nhanVienId: input.nhanVienId, keyword: input.keyword, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: CreateUpdateChamCongDto) =>
    this.restService.request<any, ChamCongDto>({
      method: 'PUT',
      url: `/api/app/cham-congs/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
