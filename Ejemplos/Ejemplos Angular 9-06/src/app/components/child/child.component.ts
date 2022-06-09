import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-child',
  templateUrl: './child.component.html',
  styleUrls: ['./child.component.scss']
})
export class ChildComponent {

  imageURL = "https://www.google.com.uy/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png"

  @Input() condition = false;
  @Output() onClick = new EventEmitter<string>()

  onClickButton(){
    this.onClick.emit("Te dije que no me toques.")
  }

  constructor(private router: Router) { }

  goJinkanna(){
    this.router.navigateByUrl("/jinkanna/vengo-de-home")
  }

}
