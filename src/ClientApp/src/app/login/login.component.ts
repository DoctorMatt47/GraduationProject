import {Component} from "@angular/core";
import {IdentityService} from "../common/services/identity.service";
import {Router} from "@angular/router";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"],
})
export class LoginComponent {
  username = "";
  password = "";
  errorMessage = "";

  constructor(
    private identityService: IdentityService,
    private router: Router ) { }

  async login() {
    const request = {
      login: this.username,
      password: this.password,
    };

    const identity = await this.identityService.login(request);
    await this.router.navigate(["/files"]);
  }
}
