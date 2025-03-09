import { Component, inject, output } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { FormsModule } from '@angular/forms';
import { InputText, InputTextModule } from 'primeng/inputtext';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule, InputTextModule ],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  cancelRegister = output<boolean>();

  model: any = {};

  private accountService = inject(AccountService);

  register() {
    this.accountService.register(this.model).subscribe({
      next: (response) => {
        console.log(response);
        this.cancel();
      },
      error: (error) => {
        console.log(error.error);
      }
    });
  }

  cancel() {
    console.log('cancelled');
    this.cancelRegister.emit(false)
  }
}
