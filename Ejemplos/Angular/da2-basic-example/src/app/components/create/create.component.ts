import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Color } from 'src/app/models/color';
import { ColorsService } from 'src/app/services/colors.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent {

  constructor(private colorsService: ColorsService, private router: Router) { }

  colorForm = new FormGroup({
    id: new FormControl(0),
    color: new FormControl("")
  })

  onCreate(){
    const color = new Color(
      this.colorForm.value.id,
      this.colorForm.value.color,
    )
    this.colorsService.postColor(color).subscribe(
      (response) => {
        alert("Se agrego correctamente")
        this.router.navigateByUrl("/")
      }
    );
  }

}
