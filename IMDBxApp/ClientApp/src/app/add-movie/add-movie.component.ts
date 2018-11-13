import { Component, OnInit, Inject } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { HttpClient, HttpHeaders  } from '@angular/common/http';
import { forEach } from '@angular/router/src/utils/collection';

@Component({
  selector: 'app-add-movie',
  templateUrl: './add-movie.component.html',
  styleUrls: ['./add-movie.component.css']
})
export class AddMovieComponent implements OnInit {


  public actorsList: Actor[];
  public movieActors = [];
  public actorTags=[];

  public producerList: Producer[];
  public movieProducer = [];
  public producerTags = [];

  public newActor: Actor = {};
  public newProducer: Producer = {};

  public newmovie: Movie = {};
  public newmovie_Master: Movie_Master = {};

  public routedData: Movie_Master;
  public isEditMode = false;
  public updateMovieId;


  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private route: ActivatedRoute) {
    http.get<Actor[]>(baseUrl + 'api/Home/GetAllActorList').subscribe(result => {
      this.actorsList = result;
      this.actorsList.forEach((element, index) => {
        this.actorTags.push({ 'display': element.actorName , 'value' : element})
      })
      console.log(this.actorTags);
    }, error => console.error(error));

    http.get<Producer[]>(baseUrl + 'api/Home/GetAllProducerList').subscribe(result => {
      this.producerList = result;
      this.producerList.forEach((element, index) => {
        this.producerTags.push({ 'display': element.prodName, 'value': element })
      })
      console.log(this.producerList);
    }, error => console.error(error));

  }

  addActorTags(tag) {
    if (this.actorsList.find(element => element.actorName === tag.display)) {
      // this.movieActors.push(tag.display);
    } else {
      this.movieActors.pop();
    }
}

  addProducer(tag) {
  if (this.producerList.find(element => element.prodName === tag.display)) {
    // this.movieActors.push(tag.display);
  } else {
    this.movieProducer = null;
  }
  }

  saveNewActor(newActor) {
    this.newActor.actorId = 0;
    const headers = new HttpHeaders().set('content-type', 'application/json');
    this.http.post(this.baseUrl + 'api/Home/SaveNewActor', this.newActor, { headers }).subscribe(result => {
      this.newActor.actorId = Number(result);
      (document.getElementById("actor-modal-close") as HTMLButtonElement).click();
      this.actorsList.push(this.newActor);
      this.actorTags.push({ 'display': this.newActor.actorName, 'value': this.newActor });
      console.log(result);
      (document.getElementById("show-result") as HTMLButtonElement).click();

    }, error => console.error(error));
  }  


  saveNewProducer(newProducer) {
    this.newProducer.prodId = 0;
    const headers = new HttpHeaders().set('content-type', 'application/json');
    this.http.post(this.baseUrl + 'api/Home/SaveNewProducer', this.newProducer, { headers }).subscribe(result => {
      this.newProducer.prodId = Number(result);
      (document.getElementById("producer-modal-close") as HTMLButtonElement).click();
      this.producerList.push(this.newProducer);
      this.producerTags.push({ 'display': this.newProducer.prodName, 'value': this.newProducer });
      console.log(result);
  (document.getElementById("show-result") as HTMLButtonElement).click();
    }, error => console.error(error));
  }


  updateMovie() {
    this.processSubmitData();
    this.newmovie.movieId = this.updateMovieId;
    const headers = new HttpHeaders().set('content-type', 'application/json');
    this.http.post(this.baseUrl + 'api/Home/UpdateMovie', this.newmovie_Master, { headers }).subscribe(result => {
      this.newmovie.movieId = Number(result);
      (document.getElementById("show-result") as HTMLButtonElement).click();
    }, error => console.error(error));
  }

  saveNewMovie() {
    this.processSubmitData();
    console.log(this.newmovie_Master);
    const headers = new HttpHeaders().set('content-type', 'application/json');
    this.http.post(this.baseUrl + 'api/Home/SaveNewMovie', this.newmovie_Master, { headers }).subscribe(result => {
        this.newmovie.movieId = Number(result);
    }, error => console.error(error));

  }

  processSubmitData() {
    this.newmovie.movieId = 0;
    this.newmovie_Master.movie = this.newmovie;
    this.newmovie_Master.producer = this.movieProducer[0].value;
    this.newmovie.prodId = this.newmovie_Master.producer.prodId;
    this.newmovie_Master.actors = [];
    this.movieActors.forEach((element, index) => {
      this.newmovie_Master.actors.push(element.value);
    })
  }


  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      if (params["data"]) {
        this.routedData = JSON.parse(params["data"]);
        this.routedData.actors.forEach((element, index) => {
          this.movieActors.push({ 'display': element.actorName, 'value': element })
        })
        this.movieProducer.push({ 'display': this.routedData.producer.prodName, 'value': this.routedData.producer });
        this.newmovie = this.routedData.movie;
        this.isEditMode = true;
        this.updateMovieId = this.newmovie.movieId;
      }
    });
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

