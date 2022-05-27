import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-child',
  templateUrl: './child.component.html',
  styleUrls: ['./child.component.scss']
})
export class ChildComponent {

  imageURL = "https://www.google.com.uy/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png"

  constructor() { }

  @Input() showVar = false;
  @Output() onClickOutput = new EventEmitter<string>()

  onClick() {
    this.onClickOutput.emit("Te dije que no me toques");
  }

}
