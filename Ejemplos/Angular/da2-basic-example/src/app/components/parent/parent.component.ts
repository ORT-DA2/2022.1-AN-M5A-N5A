import { Component } from '@angular/core';
import { ColorsService } from 'src/app/services/colors.service';
import { Color } from '../../models/color';

@Component({
  selector: 'app-parent',
  templateUrl: './parent.component.html',
  styleUrls: ['./parent.component.scss']
})
export class ParentComponent {

  inputValue = "";

  colors: Array<Color> = []

  display = false;

  constructor(private service: ColorsService) {
    this.service.getColors().subscribe(
      (response) => {
        this.colors = response;
      },
      (error) => {
        alert(error.message)
      },
      () => {
        // se ejecuta siempre, cuando entra en (response) o cuando entra en (error)
      }
    )
  }

  onClickEvent(event: string): void {
    alert(event)
    this.display = !this.display
  }

  showColor(color: Color) {
    alert(`Color: ${color.id} | Hex: ${color.color}`)
  }

}
