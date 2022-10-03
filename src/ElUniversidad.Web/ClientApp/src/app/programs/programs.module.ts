import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProgramRoutingModule } from './programs-routing.module';

import { ProgramDetailsComponent } from './program-details/program-details.component';
import { AddNewProgramComponent } from './add-new-program/add-new-program.component';
import { ProgramsListComponent } from './programs-list/programs-list.component';

import { ProgramsService } from './services/programs.service';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    ProgramDetailsComponent,
    AddNewProgramComponent,
    ProgramsListComponent
  ],
  imports: [
    CommonModule,
    ProgramRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    ProgramsService
  ],
})
export class ProgramsModule { }
