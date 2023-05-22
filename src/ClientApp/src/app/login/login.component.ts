import {Component} from "@angular/core";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"],
})
export class LoginComponent {
  username = "";
  password = "";
  errorMessage = "";

  signUp() {
    this.errorMessage = "Not implemented yet";
  }
}
