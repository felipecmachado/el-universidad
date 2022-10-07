import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
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
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProgramStructuresRoutingModule { }
