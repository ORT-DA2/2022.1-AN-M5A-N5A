import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Color } from 'src/app/models/Color';
import { Parameter } from 'src/app/models/Parameter';
import { ColorsService } from 'src/app/services/colors.service';
import { ImporterService } from 'src/app/services/importer.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent {

  constructor(private colorsService: ColorsService, private router: Router, private importerService: ImporterService) {

    let params: any = {}

    this.parameters = this.importerService.getParameters();

    this.parameters.forEach(p => {
      params[p.name] = new FormControl(p.value);
    })

    this.dynamicForm = new FormGroup(params);

    localStorage.clear()
    localStorage.setItem('token', 'value')
    const value = localStorage.getItem('token')

    alert(value)

    localStorage.token = 'value2';
    const vvalue = localStorage.token;

    alert(vvalue)
  }

  showResults = false;

  parameters: Array<Parameter>;

  dynamicForm = new FormGroup({});

  colorForm = new FormGroup({
    id: new FormControl(0),
    color: new FormControl('', [
      Validators.required,
      Validators.minLength(3)
    ]),
    email: new FormControl('', [
      Validators.email
    ])
  });

  onClick() {
    this.showResults = true;
  }

  onCreate() {
    this.colorForm.markAllAsTouched()
    if (this.colorForm.invalid) return;

    const color = new Color(
      this.colorForm.value.id,
      this.colorForm.value.color
    );
    this.colorsService.postColor(color).subscribe(
      (response) => {
        this.router.navigateByUrl("/")
      },
      (error) => {
        alert(error.message);
      },
      () => {

      }
    )
  }

}
