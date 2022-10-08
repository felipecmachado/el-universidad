import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpUtilService } from '../../shared/services/http-util.service';
import { environment } from 'src/environments/environment';
import { map, catchError, retryWhen, delay, take } from 'rxjs/operators';
import { Course } from '../models/course.model';

@Injectable()
export class CoursesService {

  private API_URL = environment.URL;

  constructor(private http: HttpClient, private httpUtil: HttpUtilService) { }

  getCourses() {
    return this.http.get(this.API_URL + 'courses')
      .pipe(map(this.httpUtil.extract))
      .pipe(
        retryWhen(errors => errors.pipe(delay(1000), take(10))),
        catchError(this.httpUtil.processErrors));
  }

  createCourse(course: Course) {
    alert(course);
    return this.http.post(this.API_URL + 'courses', course)
      .pipe(map(this.httpUtil.extract))
      .subscribe({
        error: this.httpUtil.processErrors
      });
  }

  updateCourse(course: Course) {
    return this.http.put(this.API_URL + 'courses', course)
      .pipe(map(this.httpUtil.extract))
      .subscribe({
        error: this.httpUtil.processErrors
      });
  }

  disableCourse(id: string) {
    return this.http.delete(this.API_URL + 'courses/' + id)
      .pipe(map(this.httpUtil.extract))
      .pipe(
        retryWhen(errors => errors.pipe(delay(1000), take(3))),
        catchError(this.httpUtil.processErrors));
  }

  getCourseById(id: string) {
    return this.http.get(this.API_URL + 'courses/' + id)
      .pipe(map(this.httpUtil.extract))
      .pipe(
        retryWhen(errors => errors.pipe(delay(1000), take(10))),
        catchError(this.httpUtil.processErrors));
  }
}
