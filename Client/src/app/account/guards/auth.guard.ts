import { CanActivateFn, Router } from '@angular/router';
import { AccountService } from '../_services/account.service';
import { inject } from '@angular/core';

export const authGuard: CanActivateFn = (route, state) => {
  const accountService = inject(AccountService);

  if (accountService.currentUser()) {
    return true;
  } else {
    console.log('You shall not pass!');
    return false;
  }
};
