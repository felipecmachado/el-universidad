import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpUtilService } from '../../shared/services/http-util.service';
import { environment } from 'src/environments/environment';
import { map, catchError, retryWhen, delay, take } from 'rxjs/operators';

@Injectable()
export class ProgramStructureService {

  private API_URL = environment.URL;

  constructor(private http: HttpClient, private httpUtil: HttpUtilService) { }

  getProgramStructures() {
    return this.http.get(this.API_URL + 'program-structures')
      .pipe(map(this.httpUtil.extract))
      .pipe(
        retryWhen(errors => errors.pipe(delay(1000), take(10))),
        catchError(this.httpUtil.processErrors));
  }

  getProgramStructureById(id: string) {
    return this.http.get(this.API_URL + 'program-structures/' + id)
      .pipe(map(this.httpUtil.extract))
      .pipe(
        retryWhen(errors => errors.pipe(delay(1000), take(10))),
        catchError(this.httpUtil.processErrors));
  }
}
