import { Injectable } from '@angular/core';
import { Parameter } from '../models/Parameter';

@Injectable({
  providedIn: 'root'
})
export class ImporterService {

  constructor() { }

  getParameters() {
    return [
      new Parameter("IP", "ip", ""),
      new Parameter("Puerto", "port", ""),
      new Parameter("Nombre", "name", "")
    ]
  }
}
