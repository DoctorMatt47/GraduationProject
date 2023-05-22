import {NgModule} from "@angular/core";
import {RouterModule, Routes} from "@angular/router";
import {LoginComponent} from "./login/login.component";
import {SignUpComponent} from "./sign-up/sign-up.component";
import {FilesComponent} from "./files/files.component";

const routes: Routes = [
  {path: "login", component: LoginComponent},
  {path: "sign-up", component: SignUpComponent},
  {path: "root", component: FilesComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {
}
