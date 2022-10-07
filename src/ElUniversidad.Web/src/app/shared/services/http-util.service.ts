import { Injectable } from '@angular/core';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpUtilService {

  constructor() { }

  extract(response: any) {
    const data = response;
    console.log(data);
    return data || {};
  }

  processErrors(error: any) {
    return throwError(() => new Error(error))
  }
}
