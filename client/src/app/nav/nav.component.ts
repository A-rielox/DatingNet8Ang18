import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { TitleCasePipe } from '@angular/common';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

@Component({
   selector: 'app-nav',
   standalone: true,
   imports: [FormsModule, TitleCasePipe, BsDropdownModule],
   templateUrl: './nav.component.html',
   styleUrl: './nav.component.css',
})
export class NavComponent {
   accountService = inject(AccountService);
   model: any = { userName: 'sam', password: 'P@ssword1' };

   login() {
      console.log(this.model);

      this.accountService.login(this.model).subscribe({
         next: (res) => {
            console.log(res, 'res login next');
         },
         error: (res) => console.log('error en login', res),
      });
   }

   logout() {
      this.accountService.logout();
   }
}
