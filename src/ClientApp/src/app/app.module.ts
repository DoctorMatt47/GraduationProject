import {NgModule} from "@angular/core";
import {BrowserModule} from "@angular/platform-browser";

import {AppRoutingModule} from "./app-routing.module";
import {AppComponent} from "./app.component";
import {LoginComponent} from "./login/login.component";
import {SignUpComponent} from "./sign-up/sign-up.component";
import {FilesComponent} from './files/files.component';
import {FormsModule} from "@angular/forms";
import {FileService} from "./common/services/file.service";
import {BytesPipe} from "./common/pipes/bytes.pipe";
import {AuthData} from "./common/data/auth.data";
import {IdentityService} from "./common/services/identity.service";
import {HttpClientModule} from "@angular/common/http";

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SignUpComponent,
    FilesComponent,
    BytesPipe,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
  ],
  providers: [
    FileService,
    IdentityService,
    AuthData],
  bootstrap: [AppComponent]
})
export class AppModule {
}
