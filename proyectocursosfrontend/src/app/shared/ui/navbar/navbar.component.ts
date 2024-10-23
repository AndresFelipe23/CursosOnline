import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../auth/data-access/auth.service';


@Component({
  selector: 'app-navbar',
  standalone: true,
  templateUrl: './navbar.component.html',
})
export class NavbarComponent {
  private _authService = inject(AuthService);
  private _router = inject(Router);

  async logOut() {
    await this._authService.logOut();
    this._router.navigateByUrl('/auth/sign-in');
  }
}
