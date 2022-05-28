import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { JinkannaComponent } from './components/jinkanna/jinkanna.component';
import { ParentComponent } from './components/parent/parent.component';

const routes: Routes = [
  { path: "", component: ParentComponent },
  { path: "jinkanna", component: JinkannaComponent },
  { path: "**", component: ParentComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
