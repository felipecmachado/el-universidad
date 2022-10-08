import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProgramStructuresDetailsComponent } from './program-structures-details/program-structures-details.component';
import { ProgramStructuresListComponent } from './program-structures-list/program-structures-list.component';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: '',
        component: ProgramStructuresListComponent,
        data: {
          title: 'Program Structures'
        }
      },
      {
        path: ':id',
        component: ProgramStructuresDetailsComponent,
        data: {
          title: 'Program Structure'
        }
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProgramStructuresRoutingModule { }
