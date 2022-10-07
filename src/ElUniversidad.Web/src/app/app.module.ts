import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HttpClient, HTTP_INTERCEPTORS } from "@angular/common/http";

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SharedModule } from "./shared/shared.module";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { ContentLayoutComponent } from "./layouts/content/content-layout.component";
import { FullLayoutComponent } from "./layouts/full/full-layout.component";

import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { PERFECT_SCROLLBAR_CONFIG } from 'ngx-perfect-scrollbar';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';

import { FormsModule } from '@angular/forms';
import { AlertService } from './shared/services/alert.service';
import { AuthInterceptor } from './shared/services/auth.interceptor';

const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
  suppressScrollX: true,
  wheelPropagation: false
};

import * as $ from 'jquery';

@NgModule({
  declarations: [
    AppComponent,
    FullLayoutComponent,
    ContentLayoutComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    NgbModule,
    HttpClientModule,
    NgbModule,
    AppRoutingModule,
    SharedModule,
    PerfectScrollbarModule,
    FormsModule
  ],
  providers: [
    { provide: PERFECT_SCROLLBAR_CONFIG, useValue: DEFAULT_PERFECT_SCROLLBAR_CONFIG },
    AlertService,
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }