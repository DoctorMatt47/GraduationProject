import {Component} from '@angular/core';

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

  constructor() { }

  login() {
    if (this.password !== this.repeatPassword) {
      this.errorMessage = "Passwords don't match";
      return;
    }

    const signUpValues = {
      username: this.username,
      password: this.password,
    };

    console.log(signUpValues);
  }
}
