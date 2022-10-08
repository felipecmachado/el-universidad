import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { CoursesService } from './services/courses.service';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddNewCourseComponent } from './add-new-course/add-new-course.component';
import { CoursesListComponent } from './courses-list/courses-list.component';
import { CourseRoutingModule } from './courses-routing.module';
import { EditCourseComponent } from './edit-course/edit-course.component';

@NgModule({
  declarations: [
    AddNewCourseComponent,
    CoursesListComponent,
    EditCourseComponent
  ],
  imports: [
    CommonModule,
    CourseRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    CoursesService
  ],
})
export class CoursesModule { }
