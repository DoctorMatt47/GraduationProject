import {NgModule} from "@angular/core";
import {BrowserModule} from "@angular/platform-browser";

import {AppRoutingModule} from "./app-routing.module";
import {AppComponent} from "./app.component";
import {LoginComponent} from "./login/login.component";
import {AppButtonComponent} from "./common/components/app-button.component";
import {SignUpComponent} from "./sign-up/sign-up.component";
import {AppInputComponent} from "./common/components/app-input.component";
import {SubmitAppButtonComponent} from "./common/components/submit-app-button.component";

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SignUpComponent,
    AppButtonComponent,
    AppInputComponent,
    SubmitAppButtonComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
