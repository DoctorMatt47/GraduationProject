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
  files: FileRecord[] = [];
  path: string;
  bytesAvailable: number = 1000000000;

  constructor(
    private filesService: FileService,
    private router: Router,
) {
    this.path = this.router.url
      .replace("/root", "");
  }

  async ngOnInit() {
    this.files = await this.filesService.getFilesByDirectory(this.path);
  }

  async newFolder() {
    const folderName = prompt("Enter folder name");
    if (!folderName) return;

    this.files.push({
      name: folderName,
      isDirectory: true,
      sizeInBytes: 0,
      extension: "",
      date: "",
    });
  }

  async navigateOrDownload(file: FileRecord) {
    const path = `${this.path}/${file.name}`;
    if (file.isDirectory) {
      await this.router.navigate(["/root" + path]);
      this.path = path
      console.log(this.path);
      this.files = await this.filesService.getFilesByDirectory(this.path);
      return;
    }

    await this.filesService.downloadFile(path);
  }

  async uploadFile(event: any) {
    const file = event.target.files[0];
    if (!file) return;

    await this.filesService.uploadFile(this.path, file);
    this.files = await this.filesService.getFilesByDirectory(this.path);
  }

  async remove(file: FileRecord) {
    const path = `${this.path}/${file.name}`;
    await this.filesService.removeFile(path);
  }
}
