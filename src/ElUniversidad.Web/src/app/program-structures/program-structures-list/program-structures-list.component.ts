import { Component, OnInit } from '@angular/core';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertService } from 'src/app/shared/services/alert.service';
import { Program } from '../../programs/models/program.model';
import { ProgramsService } from '../../programs/services/programs.service';

@Component({
  selector: 'app-program-structures-list.component',
  templateUrl: './program-structures-list.component.component.html',
  styleUrls: ['./program-structures-list.component.component.scss']
})
export class ProgramStructuresListComponent implements OnInit {

  constructor(
    private programsService: ProgramsService) { }

  public programs: Program[] = new Array<Program>();

  ngOnInit(): void {
    this.getPrograms();
  }

  getPrograms() {
    this.programsService.getPrograms().subscribe((data) => {
      this.programs = data.programs as Program[];
    });
  }
}
