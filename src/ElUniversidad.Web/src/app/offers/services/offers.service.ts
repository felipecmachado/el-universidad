import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpUtilService } from '../../shared/services/http-util.service';
import { environment } from 'src/environments/environment';
import { map, catchError, retryWhen, delay, take } from 'rxjs/operators';
import { Offer, AssignedCourse, ProgramStructure } from '../models/offer.model';

@Injectable()
export class OffersService {

  private API_URL = environment.URL;

  constructor(private http: HttpClient, private httpUtil: HttpUtilService) { }

  getOffers() {
    return this.http.get(this.API_URL + 'offers')
      .pipe(map(this.httpUtil.extract))
      .pipe(
        retryWhen(errors => errors.pipe(delay(1000), take(10))),
        catchError(this.httpUtil.processErrors));
  }

  getOfferById(id: string) {
    return this.http.get(this.API_URL + 'offers/' + id)
      .pipe(map(this.httpUtil.extract))
      .pipe(
        retryWhen(errors => errors.pipe(delay(1000), take(10))),
        catchError(this.httpUtil.processErrors));
  }
}
