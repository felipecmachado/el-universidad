import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpUtilService } from '../../shared/services/http-util.service';
import { environment } from 'src/environments/environment';
import { map, catchError, retryWhen, delay, take } from 'rxjs/operators';
import { Program } from '../models/program.model';

@Injectable()
export class ProgramsService {

  private API_URL = environment.URL;

  constructor(private http: HttpClient, private httpUtil: HttpUtilService) { }

  getPrograms() {
    return this.http.get(this.API_URL + 'programs')
      .pipe(map(this.httpUtil.extract))
      .pipe(
        retryWhen(errors => errors.pipe(delay(1000), take(10))),
        catchError(this.httpUtil.processErrors));
  }

  createProgram(program: Program) {
    return this.http.post(this.API_URL + 'programs', program)
      .pipe(map(this.httpUtil.extract))
      .subscribe({
        error: this.httpUtil.processErrors
      });
  }

  updateProgram(program: Program) {
    return this.http.put(this.API_URL + 'programs', program)
      .pipe(map(this.httpUtil.extract))
      .subscribe({
        error: this.httpUtil.processErrors
      });
  }

  disableProgram(id: string) {
    return this.http.delete(this.API_URL + 'programs/' + id)
      .pipe(map(this.httpUtil.extract))
      .pipe(
        retryWhen(errors => errors.pipe(delay(1000), take(3))),
        catchError(this.httpUtil.processErrors));
  }

  getProgramById(id: string) {
    return this.http.get(this.API_URL + 'programs/' + id)
      .pipe(map(this.httpUtil.extract))
      .pipe(
        retryWhen(errors => errors.pipe(delay(1000), take(10))),
        catchError(this.httpUtil.processErrors));
  }
}
