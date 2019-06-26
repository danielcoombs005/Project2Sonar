import { Component, OnInit } from '@angular/core';
import { Song } from '../models/song';
import { FormBuilder, FormGroup } from '@angular/forms';
import { SongService } from '../song.service';

@Component({
  selector: 'app-song',
  templateUrl: './song.component.html',
  styleUrls: ['./song.component.css']
})
export class SongComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, private songService: SongService ) { }


  song: Song  = {
      id:0,
      Title: "",
      Artist: "",
      Genre: "",
      Size:"",
      Length:"2",
      ReleaseDate: "",
      FilePath: ""
  }


  uploadForm: FormGroup;

  ngOnInit() {

    this.uploadForm = this.formBuilder.group({
      profile: ['']
    });
  }

  onAddSong (){

    this.songService.GetSong(this.song).then((result)=>{

      if(result == null){

        this.songService.AddSongReference(this.song);
        const formData = new FormData();
        formData.append('file', this.uploadForm.get('profile').value);

        this.songService.AddSongStorage(formData);

      }else {
        alert("The song exist");
      }

    });




  }

  onFileChange(event) {

    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.uploadForm.get('profile').setValue(file);
    }

  }

}
