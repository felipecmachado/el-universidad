import { Component, OnInit } from '@angular/core';
import { ProgramStructure } from '../models/program-structure.model';
import { ProgramStructureService } from '../services/program-structure.service';


@Component({
  selector: 'app-program-structures-list',
  templateUrl: './program-structures-list.component.html',
  styleUrls: ['./program-structures-list.component.scss']
})
export class ProgramStructuresListComponent implements OnInit {

  constructor(
    private programStructureService: ProgramStructureService) { }

  public programStructures: ProgramStructure[] = new Array<ProgramStructure>();

  ngOnInit(): void {
    this.getProgramStructures();
  }

  getProgramStructures() {
    this.programStructureService.getProgramStructures().subscribe((data) => {
      this.programStructures = data.programStructures as ProgramStructure[];
    });
  }
}
