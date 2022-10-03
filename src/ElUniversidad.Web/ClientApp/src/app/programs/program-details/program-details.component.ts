import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Program } from '../models/program.model';
import { ProgramsService } from '../services/programs.service';

@Component({
  selector: 'app-program-details',
  templateUrl: './program-details.component.html',
  styleUrls: ['./program-details.component.scss']
})

export class ProgramDetailsComponent implements OnInit {
  public program: Program = <Program>{};

  constructor(private service: ProgramsService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      let id = params['id']; // (+) converts string 'id' to a number
      this.getProgram(id);
    });
  }

  getProgram(id: string) {
    this.service.getProgramById(id).subscribe(program => {
      this.program = program;
      console.log('program retrieved: ' + program.code);
      console.log(this.program);
    });
  }
}
