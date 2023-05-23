import {Component} from '@angular/core';
import {FileRecord, FileService} from "../common/services/file.service";
import {firstValueFrom} from "rxjs";
import {Router} from "@angular/router";

@Component({
  selector: 'app-files',
  templateUrl: './files.component.html',
  styleUrls: ['./files.component.scss']
})
export class FilesComponent {
  files: FileRecord[];
  path: string;
  bytesAvailable: number = 1000000000;

  constructor(
    private filesService: FileService,
    private router: Router,
) {

    this.path = this.router.url;
    this.files = this.filesService.getFilesByDirectory(this.path);
    console.log(router.getCurrentNavigation());
  }

  async newFolder() {
    const folderName = prompt("Enter folder name");
    if (!folderName) return;

    const fileResponse = await firstValueFrom(this.filesService.uploadFolder(folderName))
    this.files.push(fileResponse);
  }

  async navigateOrDownload(file: FileRecord) {
    if (file.isDirectory) {
      const path = `${this.path}/${file.name}`;
      await this.router.navigate([path]);
      this.path = path
      return;
    }

    alert("Downloading " + file.name);
  }

  async uploadFile(event: any) {
    const fileResponse = await firstValueFrom(this.filesService.uploadFile(event.target.files[0]));
    this.files.push(fileResponse);
  }
}
