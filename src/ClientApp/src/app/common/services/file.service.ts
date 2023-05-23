import {Injectable} from "@angular/core";
import {firstValueFrom} from "rxjs";
import {environment} from "../enviroment";
import {AuthData} from "../data/auth.data";
import {HttpClient} from "@angular/common/http";

export interface FileRecord {
  name: string;
  sizeInBytes: number;
  extension: string;
  date: string;
  isDirectory: boolean;
}

export interface FileRecordResponse {
  path: string;
  sizeInBytes: number,
  uploadedAt: string,
}

@Injectable()
export class FileService {
  private filesUrl = environment.baseUrl + "files/";
  private fileRecords?: FileRecordResponse[]

  constructor(private httpClient: HttpClient, private authData: AuthData) {
  }

  async getFilesByDirectory(path: string): Promise<FileRecord[]> {
    const fileRecords = await this.getFileRecords();
    if (path[0] === "/") path = path.substring(1) + "/";
    console.log(path);

    return fileRecords
      .filter(fileRecord => fileRecord.path.startsWith(path))
      .map(fileRecord => {
        const relativePath = fileRecord.path.replace(path, "")

        console.log(path)
        console.log(relativePath)
        return ({
          name: relativePath.split("/")[0],
          sizeInBytes: fileRecord.sizeInBytes,
          extension: "",
          date: fileRecord.uploadedAt,
          isDirectory: relativePath.includes("/"),
        });
      }).filter((fr, i, array) => array.findIndex(fr2 => fr2.name === fr.name) === i);
  }

  async getFileRecords(): Promise<FileRecordResponse[]> {
    if (!this.fileRecords) {
      await this.loadFileRecords();
    }

    return this.fileRecords!;
  }

  async downloadFile(path: string): Promise<any> {
    if (path[0] === "/") path = path.substring(1);

    const options = {
      responseType: 'blob' as 'json',
      headers: {Authorization: `Bearer ${this.authData.token}`},
    };

    const url = this.filesUrl + path.replaceAll("/", "%2F")
    this.httpClient.get<Blob>(url, options)
      .subscribe((response: Blob) => {
        const downloadLink = document.createElement('a');
        const url = window.URL.createObjectURL(response);
        downloadLink.href = url;
        downloadLink.download = path.split("/").at(-1)!;
        downloadLink.click();
        window.URL.revokeObjectURL(url);
      });
  }

  async uploadFile(path: string, file: Blob) {
    if (path[0] === "/") path = path.substring(1);
    const formData = new FormData();
    formData.append("file", file);

    await firstValueFrom(
      this.httpClient.post(
        this.filesUrl + path.replaceAll("/", "%2F"),
        formData,
        {headers: {Authorization: `Bearer ${this.authData.token}`}}));

    await this.loadFileRecords();
  }

  private async loadFileRecords() {
    this.fileRecords = await firstValueFrom(
      this.httpClient.get<FileRecordResponse[]>(
        this.filesUrl,
        {headers: {Authorization: `Bearer ${this.authData.token}`}}));
  }

}
