import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public movies: Movie_Master[];
  public selectedMovieItem: Movie_Master;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Movie_Master[]>(baseUrl + 'api/Home/GetAllMovieList').subscribe(result => {
      this.movies = result;
      console.log(this.movies);
    }, error => console.error(error));
  }

  openViewEditMode(movieitem) {
    this.selectedMovieItem = movieitem;
  }

}

interface Actor {
  ActorId: number;
  ActorName: string;
  Sex: string;
  Dob: string;
  Bio: string;
}


interface Producer {
  ProdId: number;
  ProdName: string;
  Sex: string;
  Dob: string;
  Bio: string;
}

interface Movie {
  MovieId: number;
  MovieName: string;
  ReleaseYear: string;
  Plot: string;
  Thumbnail: string;
  ProdId: number;
}

interface Movie_Master {
  movie: Movie;
  actors: Actor[];
  producer: Producer;
}

