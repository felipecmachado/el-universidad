import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddNewProgramComponent } from './add-new-program/add-new-program.component';
import { ProgramsListComponent } from './programs-list/programs-list.component';
import { ProgramDetailsComponent } from './program-details/program-details.component';
import { EditProgramComponent } from './edit-program/edit-program.component';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'list',
        component: ProgramsListComponent,
        data: {
          title: 'Programs'
        }
      },
      {
        path: 'new',
        component: AddNewProgramComponent,
        data: {
          title: 'Add New Program'
        }
      },
      {
        path: 'edit/:id',
        component: EditProgramComponent,
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
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProgramRoutingModule { }
