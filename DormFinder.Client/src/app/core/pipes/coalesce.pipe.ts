import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'coalesce',
})
export class CoalescePipe implements PipeTransform {
  transform(value: any, args: string = '-'): any {
    return value != null ? value : args;
  }
}
