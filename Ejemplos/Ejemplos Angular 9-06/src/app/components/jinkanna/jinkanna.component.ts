import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Color } from 'src/app/models/Color';
import { ColorsService } from 'src/app/services/colors.service';

@Component({
  selector: 'app-jinkanna',
  templateUrl: './jinkanna.component.html',
  styleUrls: ['./jinkanna.component.scss']
})
export class JinkannaComponent {

  id = ""

  color = new Color(0, '');

  constructor(private router: Router, private currentRoute: ActivatedRoute, private colorsService: ColorsService) {
    this.id = this.currentRoute.snapshot.params.id;
    this.colorsService.getColor(+this.id).subscribe(
      (response) => {
        this.color = response
      }
    );
  }

  image = "https://jinkanna.com/wp-content/uploads/2021/10/jinkanna-768x217.png"

  goHome() {
    this.router.navigateByUrl("/")
  }

  deleteColor() {
    this.colorsService.deleteColor(this.color.id).subscribe(
      (response) => {
        this.goHome();
      },
      (error) => {
        alert(error.message);
      }
    )
  }

}
