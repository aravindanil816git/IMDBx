import { Component, OnInit, Input, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router, NavigationExtras } from '@angular/router';

@Component({
  selector: 'app-view-edit-blade',
  templateUrl: './view-edit-blade.component.html',
  styleUrls: ['./view-edit-blade.component.css']
})
export class ViewEditBladeComponent implements OnInit {


  @Input() selectedMovie: string;

  public selectedActor = {};
  public isEditMode = false;
  constructor(private router: Router) { }


  viewBio(actor) {
    this.selectedActor = actor;
  }

  turnEditmode(selectedMovie) {
    let navigationExtras: NavigationExtras = {
      queryParams: {
        data: JSON.stringify(selectedMovie)
      }
    };
    this.router.navigate(['edit-movie'], navigationExtras);
  }

  SaveEdit() {

  }

  CancelEdit() {
    this.isEditMode = false;
  }

  ngOnInit() {
  }

}


interface Actor {
  actorId?: number;
  actorName?: string;
  sex?: string;
  dob?: string;
  bio?: string;
}

interface Producer {
  prodId?: number;
  prodName?: string;
  sex?: string;
  dob?: string;
  bio?: string;
}


interface Movie {
  movieId?: number;
  movieName?: string;
  releaseYear?: string;
  plot?: string;
  thumbnail?: string;
  prodId?: number;
}

interface Movie_Master {
  movie?: Movie;
  actors?: Actor[];
  producer?: Producer;
}

