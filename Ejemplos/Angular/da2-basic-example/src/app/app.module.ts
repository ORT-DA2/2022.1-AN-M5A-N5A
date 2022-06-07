import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ChildComponent } from './components/child/child.component';
import { JinkannaComponent } from './components/jinkanna/jinkanna.component';
import { ParentComponent } from './components/parent/parent.component';
import { ExampleGuard } from './guards/example.guard';
import { CustomFilterPipe } from './pipes/custom-filter.pipe';
import { CreateComponent } from './components/create/create.component';

@NgModule({
  declarations: [
    AppComponent,
    ParentComponent,
    ChildComponent,
    JinkannaComponent,
    CustomFilterPipe,
    CreateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [ExampleGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
