import { Component, OnInit } from '@angular/core';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertService } from 'src/app/shared/services/alert.service';
import { CoursesService } from '../services/courses.service';
import { Course } from '../models/course.model';

@Component({
  selector: 'app-courses',
  templateUrl: './courses-list.component.html',
  styleUrls: ['./courses-list.component.scss']
})
export class CoursesListComponent implements OnInit {

  constructor(
    private coursesService: CoursesService) { }

  public courses: Course[] = new Array<Course>();

  ngOnInit(): void {
    this.getCourses();
  }

  getCourses() {
    this.coursesService.getCourses().subscribe((data) => {
      this.courses = data.courses as Course[];
    });
  }
}
