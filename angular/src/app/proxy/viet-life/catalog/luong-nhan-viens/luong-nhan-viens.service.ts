import type { CreateUpdateLuongNhanVienDto, LuongNhanVienDto, LuongNhanVienInListDto, LuongNhanVienListFilterDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto, PagedResultRequestDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class LuongNhanViensService {
  apiName = 'Default';
  

  create = (input: CreateUpdateLuongNhanVienDto) =>
    this.restService.request<any, LuongNhanVienDto>({
      method: 'POST',
      url: '/api/app/luong-nhan-viens',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/luong-nhan-viens/${id}`,
    },
    { apiName: this.apiName });
  

  deleteMultiple = (ids: string[]) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: '/api/app/luong-nhan-viens/multiple',
      params: { ids },
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, LuongNhanVienDto>({
      method: 'GET',
      url: `/api/app/luong-nhan-viens/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: PagedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<LuongNhanVienDto>>({
      method: 'GET',
      url: '/api/app/luong-nhan-viens',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  getListAll = () =>
    this.restService.request<any, LuongNhanVienInListDto[]>({
      method: 'GET',
      url: '/api/app/luong-nhan-viens/all',
    },
    { apiName: this.apiName });
  

  getListFilter = (input: LuongNhanVienListFilterDto) =>
    this.restService.request<any, PagedResultDto<LuongNhanVienInListDto>>({
      method: 'GET',
      url: '/api/app/luong-nhan-viens/filter',
      params: { nhanVienId: input.nhanVienId, thang: input.thang, nam: input.nam, keyword: input.keyword, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  tinhLuongHangNgay = () =>
    this.restService.request<any, void>({
      method: 'POST',
      url: '/api/app/luong-nhan-viens/tinh-luong-hang-ngay',
    },
    { apiName: this.apiName });
  

  tinhLuongThang = (thang: number, nam: number) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: '/api/app/luong-nhan-viens/tinh-luong-thang',
      params: { thang, nam },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: CreateUpdateLuongNhanVienDto) =>
    this.restService.request<any, LuongNhanVienDto>({
      method: 'PUT',
      url: `/api/app/luong-nhan-viens/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
