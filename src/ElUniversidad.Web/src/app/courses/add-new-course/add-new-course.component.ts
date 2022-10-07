import { Component, OnInit } from '@angular/core';

import { Course } from '../models/course.model';
import { CoursesService } from '../services/courses.service';

import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-new-course',
  templateUrl: './add-new-course.component.html',
  styleUrls: ['./add-new-course.component.scss']
})
export class AddNewCourseComponent implements OnInit {

  newCourseForm: FormGroup;  // new program form
  course: Course;

  constructor(private coursesService: CoursesService, fb: FormBuilder, private router: Router) {
    this.newCourseForm = fb.group({
      'title': '',
      'description': '',
      'additionalInformation': '',
      'hours': '',
      'minimumGrade': ''
    });
    this.course = new Course();
  }

  ngOnInit(): void {
  }

  submitForm(value: any) {
    this.course.title = this.newCourseForm.controls['title'].value;
    this.course.description = this.newCourseForm.controls['description'].value;
    this.course.additionalInformation = this.newCourseForm.controls['additionalInformation'].value;
    this.course.hours = this.newCourseForm.controls['hours'].value;
    this.course.minimumGrade = this.newCourseForm.controls['minimumGrade'].value;

    this.coursesService.createCourse(this.course);
  }
}
