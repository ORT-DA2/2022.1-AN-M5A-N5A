import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ChildComponent } from './components/child/child.component';
import { JinkannaComponent } from './components/jinkanna/jinkanna.component';
import { ParentComponent } from './components/parent/parent.component';
import { CustomFilterPipe } from './pipes/custom-filter.pipe';

@NgModule({
  declarations: [
    AppComponent,
    ParentComponent,
    ChildComponent,
    JinkannaComponent,
    CustomFilterPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
