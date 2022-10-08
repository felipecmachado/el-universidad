import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { ProgramsService } from '../services/programs.service';
import { Program } from '../models/program.model';

import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-new-program',
  templateUrl: './add-new-program.component.html',
  styleUrls: ['./add-new-program.component.scss']
})
export class AddNewProgramComponent implements OnInit {

  degrees = ['Associate', 'Bachelors', 'Specialization', 'Masters', 'Doctorate'];

  newProgram = {
    code: '',
    title: '',
    degree: this.degrees[0],
    description: ''
  };

  newProgramForm: FormGroup;
  showMsg: boolean = false;

  constructor(private programsService: ProgramsService, fb: FormBuilder, private router: Router) {
    this.newProgramForm = new FormGroup({
      code: new FormControl(this.newProgram.code, [
        Validators.required,
        Validators.minLength(4)
      ]),
      title: new FormControl(this.newProgram.title, [
        Validators.required,
        Validators.minLength(10)
      ]),
      description: new FormControl(this.newProgram.description, [
        Validators.required,
        Validators.minLength(30)
      ]),
      degree: new FormControl(this.newProgram.degree, Validators.required)
    });
  }

  ngOnInit(): void {
  }

  get code() { return this.newProgramForm.get('code'); }
  get title() { return this.newProgramForm.get('title'); }
  get degree() { return this.newProgramForm.get('degree'); }
  get description() { return this.newProgramForm.get('description'); }
  
  submitForm(value: any) {

    var program = new Program();
    
    program.code = this.newProgramForm.controls['code'].value;
    program.title = this.newProgramForm.controls['title'].value;
    program.description = this.newProgramForm.controls['description'].value;
    program.degree = this.newProgramForm.controls['degree'].value;

    this.programsService.createProgram(program);

    this.showMsg = true;
  }
}
