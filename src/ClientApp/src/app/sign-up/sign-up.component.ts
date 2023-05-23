import {Component} from '@angular/core';
import {IdentityService} from "../common/services/identity.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent {
  username = "";
  password = "";
  repeatPassword = "";
  errorMessage = "";

  constructor(private identityService: IdentityService, private router: Router) { }

  async signUp() {
    if (this.password !== this.repeatPassword) {
      this.errorMessage = "Passwords don't match";
      return;
    }

    const signUpValues = {
      login: this.username,
      password: this.password,
    };

    console.log(signUpValues);

    const response = await this.identityService.signUp(signUpValues);
    await this.router.navigate(["/files"]);
  }
}
