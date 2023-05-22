import {NgModule} from "@angular/core";
import {BrowserModule} from "@angular/platform-browser";

import {AppRoutingModule} from "./app-routing.module";
import {AppComponent} from "./app.component";
import {LoginComponent} from "./login/login.component";
import {SignUpComponent} from "./sign-up/sign-up.component";
import {FilesComponent} from './files/files.component';
import {FormsModule} from "@angular/forms";
import {FileService} from "./files/file.service";

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SignUpComponent,
    FilesComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
  ],
  providers: [FileService],
  bootstrap: [AppComponent]
})
export class AppModule {
}
