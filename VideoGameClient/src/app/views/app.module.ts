import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { UIRouterModule } from '@uirouter/angular';
import { uiRouterConfigFn } from '../core/routing-config/router.config';
import { detailsState, listState } from '../core/routing-config/states';

import { AppComponent } from './app.component';
import { DetailsComponent } from './details/details.component';
import { ListComponent } from './list/list.component';

const INITIAL_STATES = [detailsState, listState];

@NgModule({
  declarations: [
    AppComponent,
    ListComponent,
    DetailsComponent
  ],
  imports: [
    BrowserModule,
    UIRouterModule.forRoot({ 
      states: INITIAL_STATES,
      config: uiRouterConfigFn
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
