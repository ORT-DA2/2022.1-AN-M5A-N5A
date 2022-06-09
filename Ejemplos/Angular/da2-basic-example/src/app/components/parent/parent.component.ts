import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Color } from 'src/app/models/Color';
import { ColorsService } from 'src/app/services/colors.service';

@Component({
  selector: 'app-parent',
  templateUrl: './parent.component.html',
  styleUrls: ['./parent.component.scss']
})
export class ParentComponent {

  inputValue = "";

  colors: Array<Color> = [];

  condition = true

  constructor(colorsService: ColorsService, private router: Router) {
    colorsService.getColors().subscribe(
      (response) => {
        this.colors = response;
      },
      (error) => {
        alert(error.message);
      },
      () => {

      }
    )
  }

  onClick(event: string) {
    alert(event)
    this.condition = !this.condition;
  }

  onClickColor(id: number) {
    this.router.navigate(['/jinkanna', id])
  }

}
