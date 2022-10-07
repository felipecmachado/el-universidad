import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProgramsService } from '../programs/services/programs.service';
import { ProgramStructuresRoutingModule } from './program-structures-routing.module';
import { ProgramStructuresListComponent } from './program-structures-list/program-structures-list.component';

@NgModule({
  declarations: [
    ProgramStructuresListComponent
  ],
  imports: [
    CommonModule,
    ProgramStructuresRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    ProgramsService
  ],
})
export class ProgramStructuresModule { }
