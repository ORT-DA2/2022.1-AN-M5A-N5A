import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Color } from 'src/app/models/color';
import { ColorsService } from 'src/app/services/colors.service';

@Component({
  selector: 'app-jinkanna',
  templateUrl: './jinkanna.component.html',
  styleUrls: ['./jinkanna.component.scss']
})
export class JinkannaComponent {

  color = new Color(0, "")

  constructor(private router: Router, private currentRoute: ActivatedRoute, private colorsService: ColorsService) { 
    this.id = currentRoute.snapshot.params.id;
    this.colorsService.getColorById(+this.id).subscribe(
      (response) => {
        this.color = response
      },
      (error) => {
        alert(error.message);
      }
    )
  }

  id = ""

  backToHome() {
    this.router.navigateByUrl('/')
    // this.router.navigate(['/'])
  }

  image = "https://jinkanna.com/wp-content/uploads/2021/10/jinkanna-768x217.png"

}
