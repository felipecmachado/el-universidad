import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from "@angular/common/http";
import { StorageService } from './storage.service';

@Injectable()
export class ConfigurationService {
  serverSettings: IConfiguration;
  isReady: boolean = false;

  constructor(private http: HttpClient, private storageService: StorageService) { }
}

export interface IConfiguration {
}
