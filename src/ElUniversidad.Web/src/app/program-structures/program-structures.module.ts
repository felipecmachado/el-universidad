import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProgramsService } from '../programs/services/programs.service';
import { ProgramStructuresDetailsComponent } from './program-structures-details/program-structures-details.component';
import { ProgramStructuresListComponent } from './program-structures-list/program-structures-list.component';
import { ProgramStructuresRoutingModule } from './program-structures-routing.module';
import { ProgramStructureService } from './services/program-structure.service';

@NgModule({
  declarations: [
    ProgramStructuresListComponent,
    ProgramStructuresDetailsComponent
  ],
  imports: [
    CommonModule,
    ProgramStructuresRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    ProgramStructureService,
    ProgramsService
  ],
})
export class ProgramStructuresModule { }
