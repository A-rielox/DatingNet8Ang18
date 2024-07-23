import { Component, inject, OnInit } from '@angular/core';
import { RegisterComponent } from '../register/register.component';
import { HttpClient } from '@angular/common/http';
import { User } from '../_models/user';

@Component({
   selector: 'app-home',
   standalone: true,
   imports: [RegisterComponent],
   templateUrl: './home.component.html',
   styleUrl: './home.component.css',
})
export class HomeComponent implements OnInit {
   http = inject(HttpClient);
   registerMode = false;
   users: any = [];

   ngOnInit(): void {
      this.getUsers();
   }

   registerToggle() {
      this.registerMode = !this.registerMode;
   }

   getUsers() {
      this.http.get<User[]>('https://localhost:5001/api/users').subscribe({
         next: (resp) => (this.users = resp),
         error: (err) => console.log(err),
         complete: () => console.log('complete!'),
      });
   }

   cancelRegisterMode(e: boolean) {
      this.registerMode = e;
   }
}
