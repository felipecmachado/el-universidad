import { Injectable } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { StorageService } from './storage.service';

const ACCESS_TOKEN: string = 'access_token';
const REFRESH_TOKEN: string = 'refresh_token';

@Injectable({
  providedIn: 'root'
})
export class TokenService {

  constructor(private storageService: StorageService) { }

  getToken(): string {
    return this.storageService.retrieve(ACCESS_TOKEN);
  }

  getRefreshToken(): string {
    return this.storageService.retrieve(REFRESH_TOKEN);
  }

  saveToken(token: string): void {
    this.storageService.store(ACCESS_TOKEN, token);
  }

  saveRefreshToken(refreshToken: string): void {
    this.storageService.store(REFRESH_TOKEN, refreshToken);
  }

  removeToken(): void {
    this.storageService.remove(ACCESS_TOKEN);
  }

  removeRefreshToken(): void {
    this.storageService.remove(REFRESH_TOKEN);
  }
}
