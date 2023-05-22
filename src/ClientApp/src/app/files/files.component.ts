import { Component } from '@angular/core';
import {FileRecord, FilesService} from "./files.service";

@Component({
  selector: 'app-files',
  templateUrl: './files.component.html',
  styleUrls: ['./files.component.scss']
})
export class FilesComponent {
  files: FileRecord[];

  constructor(private filesService: FilesService) {
    this.files = this.filesService.getFilesByDirectory("");
  }
}
