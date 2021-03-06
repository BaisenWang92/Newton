import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { UIRouterModule } from '@uirouter/angular';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { uiRouterConfigFn } from '../core/routing-config/router.config';
import { detailsState, listState } from '../core/routing-config/states';

import { AppComponent } from './app.component';
import { DetailsComponent } from './details/details.component';
import { ListComponent } from './list/list.component';
import { ModalComponent } from './modal/modal.component';

const INITIAL_STATES = [detailsState, listState];

@NgModule({
  declarations: [
    AppComponent,
    ListComponent,
    DetailsComponent,
    ModalComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgbModule,
    NgMultiSelectDropDownModule.forRoot(),
    UIRouterModule.forRoot({ 
      states: INITIAL_STATES,
      config: uiRouterConfigFn
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
