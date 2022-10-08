import { Component, OnInit } from '@angular/core';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertService } from 'src/app/shared/services/alert.service';
import { ProgramsService } from '../services/programs.service';
import { Program } from '../models/program.model';

@Component({
  selector: 'app-programs',
  templateUrl: './programs-list.component.html',
  styleUrls: ['./programs-list.component.scss']
})
export class ProgramsListComponent implements OnInit {

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
