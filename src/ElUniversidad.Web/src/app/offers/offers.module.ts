import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProgramsService } from '../programs/services/programs.service';
import { OffersRoutingModule } from './offers-routing.module';
import { ProgramOffersComponent } from './program-offers/program-offers.component';

@NgModule({
  declarations: [
    ProgramOffersComponent
  ],
  imports: [
    CommonModule,
    OffersRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    ProgramsService
  ],
})
export class OffersModule { }
