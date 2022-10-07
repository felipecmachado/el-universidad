import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { CoursesService } from '../services/courses.service';
import { Course } from '../models/course.model';

import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit-course',
  templateUrl: './edit-course.component.html',
  styleUrls: ['./edit-course.component.scss']
})
export class EditCourseComponent implements OnInit {

  private course: Course = <Course>{};
  private id: any;

  editCourseForm: FormGroup;

  constructor(
    private coursesService: CoursesService,
    private fb: FormBuilder,
    private route: ActivatedRoute) {
    this.editCourseForm = fb.group({
      'title': '',
      'description': '',
      'additionalInformation': '',
      'credits': '',
      'minimumGrade': ''
    });

  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = params['id']; // (+) converts string 'id' to a number
    });

    this.getCourse(this.id);
  }

  getCourse(id: string) {
    this.coursesService.getCourseById(id).subscribe(course => {
      this.course = course;
      this.editCourseForm = this.fb.group({
        'title': this.course.title,
        'description': this.course.description,
        'additionalInformation': this.course.additionalInformation,
        'credits': this.course.credits,
        'minimumGrade': this.course.minimumGrade,
      });
    });
  }

  submitForm(value: any) {
    this.course.title = this.editCourseForm.controls['title'].value;
    this.course.description = this.editCourseForm.controls['description'].value;
    this.course.additionalInformation = this.editCourseForm.controls['additionalInformation'].value;
    this.course.credits = this.editCourseForm.controls['credits'].value;
    this.course.minimumGrade = this.editCourseForm.controls['minimumGrade'].value;

    this.coursesService.updateCourse(this.course);
  }
}
