import { DecimalPipe } from '@angular/common';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'amount',
})
export class AmountPipe extends DecimalPipe implements PipeTransform {
  transform(value: any, valueIfZero: string = null): string {
    if (typeof value !== 'number') {
      return value;
    }

    const num = value as number;

    if (valueIfZero && num == 0) {
      return valueIfZero;
    }

    const numberFormat = '1.2-2';
    const formatted = super.transform(Math.abs(num), numberFormat, null);

    return num < 0 ? `(${formatted})` : formatted;
  }
}
