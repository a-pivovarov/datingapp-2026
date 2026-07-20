import { inject, Service } from '@angular/core';
import { AccountService } from './account-service';
import { Observable, of } from 'rxjs';

@Service()
export class InitService {
    private accountService = inject(AccountService);

    init() {
        const userString = localStorage.getItem('user');
        if (!userString) return of(null); // Return an observable to indicate completion
        const user = JSON.parse(userString);
        this.accountService.currentUser.set(user);

        return of(null); // Return an observable to indicate completion
    }
}
