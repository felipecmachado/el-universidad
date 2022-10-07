import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { ProgramsService } from '../services/programs.service';
import { Program } from '../models/program.model';

import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit-program',
  templateUrl: './edit-program.component.html',
  styleUrls: ['./edit-program.component.scss']
})
export class EditProgramComponent implements OnInit {

  private program: Program = <Program>{};
  private id: any;

  editProgramForm: FormGroup;

  constructor(
    private programsService: ProgramsService,
    private fb: FormBuilder,
    private route: ActivatedRoute) {
    this.editProgramForm = fb.group({
      'code': '',
      'title': '',
      'degree': '',
      'description': ''
    });

  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = params['id']; // (+) converts string 'id' to a number
    });

    this.getProgram(this.id);
  }

  getProgram(id: string) {
    this.programsService.getProgramById(id).subscribe(program => {
      this.program = program;

      this.editProgramForm = this.fb.group({
        'code': [{ value: this.program.code, disabled: true }] ,
        'title': this.program.title,
        'degree': this.program.degree,
        'description': this.program.description
      });
    });
  }

  submitForm(value: any) {
    this.program.title = this.editProgramForm.controls['title'].value;
    this.program.description = this.editProgramForm.controls['description'].value;
    this.program.degree = this.editProgramForm.controls['degree'].value;

    this.programsService.updateProgram(this.program);
  }
}
