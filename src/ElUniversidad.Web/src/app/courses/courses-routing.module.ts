import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddNewCourseComponent } from './add-new-course/add-new-course.component';
import { CoursesListComponent } from './courses-list/courses-list.component';
import { EditCourseComponent } from './edit-course/edit-course.component';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'list',
        component: CoursesListComponent,
        data: {
          title: 'Courses'
        }
      },
      {
        path: 'new',
        component: AddNewCourseComponent,
        data: {
          title: 'Add New Course'
        }
      },
      {
        path: 'edit/:id',
        component: EditCourseComponent,
        data: {
          title: 'Courses'
        }
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CourseRoutingModule { }
