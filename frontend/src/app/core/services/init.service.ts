import {inject, Injectable} from '@angular/core';
import {forkJoin} from 'rxjs';
import {AccountService} from './account.service';

@Injectable({
  providedIn: 'root'
})
export class InitService {
  accountService = inject(AccountService);

  init(){
    return forkJoin({
      user: this.accountService.getUserInfo()
    })
  }
}
