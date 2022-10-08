import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Program } from '../../programs/models/program.model';
import { ProgramsService } from '../../programs/services/programs.service';
import { ProgramStructure } from '../models/program-structure.model';
import { ProgramStructureService } from '../services/program-structure.service';


@Component({
  selector: 'app-program-structures-details',
  templateUrl: './program-structures-details.component.html',
  styleUrls: ['./program-structures-details.component.scss']
})
export class ProgramStructuresDetailsComponent implements OnInit {

  constructor(
    private programStructureService: ProgramStructureService,
    private programService: ProgramsService,
    private route: ActivatedRoute) { }

  public programStructure: ProgramStructure = <ProgramStructure>{};
  public program: Program = <Program>{};

  ngOnInit() {
    this.route.params.subscribe(params => {
      let id = params['id'];
      this.getProgramStructure(id);
    });
  }

  getProgramStructure(id: string) {
    this.programStructureService.getProgramStructureById(id).subscribe(programStructure => {
      this.programStructure = programStructure;
      this.getProgram(programStructure.programId);
      console.log('programStructure retrieved: ' + programStructure.id);
      console.log(this.programStructure);
    });
  }

  getProgram(id: string) {
    this.programService.getProgramById(id).subscribe(program => {
      this.program = program;
      console.log('program retrieved: ' + program.id);
      console.log(this.program);
    });
  }
}
