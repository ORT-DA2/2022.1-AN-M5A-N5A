import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateComponent } from './components/create/create.component';
import { JinkannaComponent } from './components/jinkanna/jinkanna.component';
import { ParentComponent } from './components/parent/parent.component';
import { ExampleGuard } from './guards/example.guard';

const routes: Routes = [
  { path: "", component: ParentComponent },
  { path: "jinkanna/:id", component: JinkannaComponent, canActivate: [ExampleGuard] },
  { path: "jinkanna", component: JinkannaComponent },
  { path: "create", component: CreateComponent },
  { path: "redirect", redirectTo: "/jinkanna" },
  { path: "**", component: ParentComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
