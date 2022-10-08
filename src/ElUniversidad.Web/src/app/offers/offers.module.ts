import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { OffersRoutingModule } from './offers-routing.module';
import { ProgramOffersComponent } from './program-offers/program-offers.component';
import { OffersService } from './services/offers.service';

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
    OffersService
  ],
})
export class OffersModule { }
