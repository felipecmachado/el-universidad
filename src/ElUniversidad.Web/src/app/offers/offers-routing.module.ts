import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProgramOffersComponent } from '../offers/program-offers/program-offers.component';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: '',
        component: ProgramOffersComponent,
        data: {
          title: 'Offers'
        }
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OffersRoutingModule { }
