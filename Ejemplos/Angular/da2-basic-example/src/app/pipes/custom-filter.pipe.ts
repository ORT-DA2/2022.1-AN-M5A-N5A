import { Pipe, PipeTransform } from '@angular/core';
import { Color } from '../models/Color';

@Pipe({
  name: 'customFilter'
})
export class CustomFilterPipe implements PipeTransform {

  transform(list: Array<Color>, filter: string): Array<Color> {
    return list.filter((i) =>
      i.color.toLowerCase().includes(filter.toLowerCase())
    );
  }

}