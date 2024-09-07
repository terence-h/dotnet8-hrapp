import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AccountService } from '../account/shared/account.service';

export const adminGuard: CanActivateFn = () => {
  const router = inject(Router);
  const accountService = inject(AccountService);

  if (accountService.roles().includes('Admin'))
    return true;
  return router.navigate(['/']);
};
