import { Component, OnInit } from '@angular/core';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertService } from 'src/app/shared/services/alert.service';
import { ProgramsService } from '../../programs/services/programs.service';
import { Program } from '../../programs/models/program.model';

@Component({
  selector: 'app-program-offers',
  templateUrl: './program-offers.component.html',
  styleUrls: ['./program-offers.component.scss']
})
export class ProgramOffersComponent implements OnInit {

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
