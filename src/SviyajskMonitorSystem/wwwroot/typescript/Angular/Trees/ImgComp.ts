import { Component, Output, EventEmitter } from "@angular/core";
import { Http, Response } from "@angular/http";
@Component({
    selector: 'image',
    templateUrl: 'Images/ImgTemplate'
   // providers: [Http]
})

export class ImagesComponent {

    ImagesUrls: string[] = [];


    @Output() OnImagesSetted = new EventEmitter<string>();

    constructor(private http:Http) {}
    OnImageAdded(event): void {
        console.log(event);
        var self = this;
        let files: File[] = event.target.files;
        for (let i = 0; i < files.length; i++){
            let fr: FileReader = new FileReader();
            fr.onload = function (e: Event & { target: { result: string } }) {
                self.ImagesUrls.push(e.target.result);
            }
            fr.readAsDataURL(files[i]);
        }
    }



    ClickFile() {
        $('#fileinput').click();
    }


    DeleteImage(index: number) {
        this.ImagesUrls.splice(index, 1);
    }


    UploadPhotos() {
        this.http.post("Images/UploadImage", this.ImagesUrls).subscribe((data: Response) => {
            this.ImagesUrls = [];
            this.OnImagesSetted.emit(data.json());

        });
    }



    GenerateId(id: number):string {
        let sid: string = id.toString + "img";
        return sid;
    }

}
