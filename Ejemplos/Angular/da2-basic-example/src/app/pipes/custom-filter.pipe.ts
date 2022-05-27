import { Pipe, PipeTransform } from '@angular/core';
import { Color } from '../models/color';

@Pipe({
  name: 'customFilter'
})
export class CustomFilterPipe implements PipeTransform {

  transform(list: Array<Color>, filter: string): Array<Color> {
    return list.filter((c) => 
      c.name.toLocaleLowerCase().includes(filter.toLocaleLowerCase())
    );
  }

}
