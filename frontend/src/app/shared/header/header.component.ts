import {Component, inject, OnInit} from '@angular/core';
import {AccountService} from '../../core/services/account.service';
import {FullNamePipe} from '../pipes/full-name.pipe';
import {Router, RouterLink} from '@angular/router';
import {MenuItem, MessageService} from 'primeng/api';
import {MatMenu, MatMenuItem, MatMenuTrigger} from '@angular/material/menu';
import {Toast} from 'primeng/toast';

@Component({
  selector: 'app-header',
  imports: [
    FullNamePipe,
    RouterLink,
    MatMenuTrigger,
    MatMenu,
    MatMenuItem,
    Toast,
  ],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
  providers: [MessageService]
})
export class HeaderComponent implements OnInit {
  accountService = inject(AccountService);
  private router = inject(Router);

  items: MenuItem[] | undefined;

  constructor(private messageService: MessageService) {}

  ngOnInit() {
    this.items = [
      {
        label: "Logout",
        icon: "pi pi-sign-out",
      },
      {
        label: "Profile",
        icon: "pi pi-user",
      }
    ]
  }

  logout() {
    this.accountService.logout().subscribe({
      next: () => {
        console.log('Logged out');
        this.accountService.currentUser.set(null);
        this.messageService.add({severity: 'success', summary: 'Logged out', detail: 'You have been logged out'});
        this.router.navigateByUrl('/');
      },
      error: (error) => {
        console.log('Error logging out', error);
      }
    })
  }
}
