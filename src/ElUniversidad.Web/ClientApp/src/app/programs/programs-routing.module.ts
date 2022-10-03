import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddNewProgramComponent } from './add-new-program/add-new-program.component';
import { ProgramsListComponent } from './programs-list/programs-list.component';
import { ProgramDetailsComponent } from './program-details/program-details.component';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'add-new',
        component: AddNewProgramComponent,
        data: {
          title: 'Add New Program'
        }
      },
      {
        path: 'list',
        component: ProgramsListComponent,
        data: {
          title: 'Programs'
        }
      },
      {
        path: ':id',
        component: ProgramDetailsComponent,
        data: {
          title: 'Programs'
        }
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProgramRoutingModule { }
