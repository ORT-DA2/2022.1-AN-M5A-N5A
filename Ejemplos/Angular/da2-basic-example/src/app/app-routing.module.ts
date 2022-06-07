import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateComponent } from './components/create/create.component';
import { JinkannaComponent } from './components/jinkanna/jinkanna.component';
import { ParentComponent } from './components/parent/parent.component';
import { ExampleGuard } from './guards/example.guard';

const routes: Routes = [
  { path: "", component: ParentComponent },
  { path: "colors/:id", component: JinkannaComponent, canActivate: [ExampleGuard] },
  { path: "colors", component: JinkannaComponent },
  { path: "create", component: CreateComponent },
  { path: "jinkanna", redirectTo: "/colors" },
  { path: "**", component: ParentComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
