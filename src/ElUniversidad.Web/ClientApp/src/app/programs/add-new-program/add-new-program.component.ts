import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { ProgramsService } from '../services/programs.service';
import { Program } from '../models/program.model';

import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-new-program',
  templateUrl: './add-new-program.component.html',
  styleUrls: ['./add-new-program.component.scss']
})
export class AddNewProgramComponent implements OnInit {

  newProgramForm: FormGroup;  // new program form
  program: Program;

  constructor(private programsService: ProgramsService, fb: FormBuilder, private router: Router) {
    this.newProgramForm = fb.group({
      'code': '',
      'title': '',
      'degree': '',
      'description': ''
    });
    this.program = new Program();
  }

  ngOnInit(): void {
    $.getScript('./assets/plugins/Drag-And-Drop/imageuploadify.min.js');
    $.getScript("./assets/js/add-new-product-image-upload.js")
  }

  submitForm(value: any) {
    this.program.code = this.newProgramForm.controls['code'].value;
    this.program.title = this.newProgramForm.controls['title'].value;
    this.program.description = this.newProgramForm.controls['description'].value;
    this.program.degree = this.newProgramForm.controls['degree'].value;

    this.programsService.createProgram(this.program);
  }
}
