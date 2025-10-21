import { RestService } from '@abp/ng.core';
import type { PagedResultDto, PagedResultRequestDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { CheDoNhanVienDto, CheDoNhanVienInListDto, CheDoNhanVienListFilterDto, CreateUpdateCheDoNhanVienDto } from '../che-dos/che-do-nhan-viens/models';

@Injectable({
  providedIn: 'root',
})
export class CheDoNhanViensService {
  apiName = 'Default';
  

  create = (input: CreateUpdateCheDoNhanVienDto) =>
    this.restService.request<any, CheDoNhanVienDto>({
      method: 'POST',
      url: '/api/app/che-do-nhan-viens',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/che-do-nhan-viens/${id}`,
    },
    { apiName: this.apiName });
  

  deleteMultiple = (ids: string[]) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: '/api/app/che-do-nhan-viens/multiple',
      params: { ids },
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, CheDoNhanVienDto>({
      method: 'GET',
      url: `/api/app/che-do-nhan-viens/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: PagedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<CheDoNhanVienDto>>({
      method: 'GET',
      url: '/api/app/che-do-nhan-viens',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  getListAll = () =>
    this.restService.request<any, CheDoNhanVienInListDto[]>({
      method: 'GET',
      url: '/api/app/che-do-nhan-viens/all',
    },
    { apiName: this.apiName });
  

  getListFilter = (input: CheDoNhanVienListFilterDto) =>
    this.restService.request<any, PagedResultDto<CheDoNhanVienInListDto>>({
      method: 'GET',
      url: '/api/app/che-do-nhan-viens/filter',
      params: { nhanVienId: input.nhanVienId, keyword: input.keyword, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: CreateUpdateCheDoNhanVienDto) =>
    this.restService.request<any, CheDoNhanVienDto>({
      method: 'PUT',
      url: `/api/app/che-do-nhan-viens/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
