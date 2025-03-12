import { Pipe, PipeTransform } from '@angular/core';
import {User} from '../models/user';

@Pipe({
  name: 'fullName'
})
export class FullNamePipe implements PipeTransform {

  transform(value: User | null, ...args: unknown[]): unknown {
    if(value?.firstName === undefined || value?.lastName === undefined) {
      return '';
    }

    return `${value.firstName} ${value.lastName}`;
  }

}
