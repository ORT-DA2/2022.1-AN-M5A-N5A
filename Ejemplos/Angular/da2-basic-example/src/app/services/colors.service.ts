import { Injectable } from '@angular/core';
import { Color } from '../models/color';

@Injectable({
  providedIn: 'root'
})
export class ColorsService {

  constructor() { }

  getColors(): Array<Color> {

    return [
      new Color("Azul", "#blue"),
      new Color("Blanco", "#white"),
      new Color("Rojo", "#red")]
  }
}
