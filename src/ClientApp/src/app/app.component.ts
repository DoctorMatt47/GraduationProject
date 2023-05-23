import {Component} from "@angular/core";
import {AuthData} from "./common/data/auth.data";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.scss"],
})
export class AppComponent {
  constructor(public authData: AuthData) {
  }
}
