import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';
import { Constantes } from '../util/Constantes';

@Pipe({
  name: 'DateFormatPipe'
})
export class DateFormatPipePipe extends DatePipe implements PipeTransform {

  transform(value: any, args?: any): any {
    return super.transform(value,Constantes.date_format);
  }

}
