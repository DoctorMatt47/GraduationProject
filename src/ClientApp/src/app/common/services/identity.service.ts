import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {environment} from "../enviroment";
import {firstValueFrom, Observable} from "rxjs";
import {AuthData} from "../data/auth.data";

interface IdentityRequest {
  login: string;
  password: string;
}

interface IdentityResponse {
  token: string;
  id: string;
  maxBytesAvailable: number;
  bytesUsed: number;
}

@Injectable()
export class IdentityService {
  identitiesUrl = environment.baseUrl + "identities/";
  usersUrl = environment.baseUrl + "users/";


  constructor(private http: HttpClient, private authData: AuthData) {

  }

  async login({login, password} : IdentityRequest): Promise<IdentityResponse> {
    const response = await firstValueFrom(
        this.http.post<IdentityResponse>(this.identitiesUrl + "authenticate", {login, password}));

    this.authData.setData(
      response.token,
      response.id,
      response.maxBytesAvailable,
      response.bytesUsed);

    return response;
  }

  async signUp(request: IdentityRequest): Promise<IdentityResponse> {
    const response =
      await firstValueFrom(
      this.http.post<IdentityResponse>(this.usersUrl, request))

    this.authData.setData(
      response.token,
      response.id,
      response.maxBytesAvailable,
      response.bytesUsed);

    return response;
  }
}
