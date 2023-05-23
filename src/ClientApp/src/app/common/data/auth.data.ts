import {Injectable} from "@angular/core";

@Injectable()
export class AuthData {
  token?: string;
  id?: string;
  maxBytesAvailable?: number;
  bytesUsed?: number;

  constructor() {
    this.token = localStorage.getItem("token") ?? undefined;
    this.id = localStorage.getItem("id") ?? undefined;

    const maxBytesAvailable = localStorage.getItem("maxBytesAvailable");
    this.maxBytesAvailable = maxBytesAvailable === null ?
      undefined :
      Number.parseInt(maxBytesAvailable);

    const bytesUsed = localStorage.getItem("bytesUsed");
    this.bytesUsed = bytesUsed === null ? undefined : Number.parseInt(bytesUsed);
  }

  isAuthenticated(): boolean {
    return !!this.token && !!this.id;
  }

  setData(token: string, id: string, maxBytesAvailable: number, bytesUsed: number) {
    this.token = token;
    this.id = id;
    this.maxBytesAvailable = maxBytesAvailable;
    this.bytesUsed = bytesUsed;

    localStorage.setItem("token", token);
    localStorage.setItem("id", id);
    localStorage.setItem("maxBytesAvailable", maxBytesAvailable.toString());
    localStorage.setItem("bytesUsed", bytesUsed.toString());
  }
}
