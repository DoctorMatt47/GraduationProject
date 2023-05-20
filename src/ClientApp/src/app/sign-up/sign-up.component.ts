import {Component} from '@angular/core';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent {
  username: string = "";
  password: string = "";

  onUsernameChange(event: Event) {
    this.username = (event.target as HTMLInputElement).value;
  }

  onPasswordChange(event: Event) {
    this.password = (event.target as HTMLInputElement).value;
  }

  onRepeatPasswordChange(event: Event) {
    const inputElement = event.target as HTMLInputElement;
    const repeatPassword = inputElement.value
    if (repeatPassword === this.password) {
      inputElement.setCustomValidity("");
    }

    inputElement.setCustomValidity("Passwords don't match");
  }
}
