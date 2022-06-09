import { Component } from '@angular/core';
import { LoaderService } from './services/loader.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  constructor(private loaderService: LoaderService) {
  }

  isLoading(): boolean {
    return this.loaderService.isLoading();
  }

}
