using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBxApp.Models
{
    public class DataAccessLayer
    {
        IMDBxContext db = new IMDBxContext();
        List<Movie_Master> movies = new List<Movie_Master>();

        public List<Movie_Master> GetMovieList()
        {
            List<MovieMaster> movieList = db.MovieMaster.ToList();
            foreach (var movie in movieList)
            {
                var movie_info = new Movie_Master();
                movie_info.movie = movie;
                List<ActorMaster> actorList = new List<ActorMaster>();
                List<MovieActorDb>movieActors = db.MovieActorDb.Where(it => it.MovieId == movie.MovieId).ToList();
                movie_info.producer = db.ProducerMaster.Where(it => it.ProdId == movie.ProdId).FirstOrDefault();
                foreach (var actor in movieActors)
                {
                    var actorObj = db.ActorMaster.Where(it => it.ActorId == actor.ActorId).FirstOrDefault();
                    actorList.Add(actorObj);

                }
                movie_info.actors = actorList;
                movies.Add(movie_info);
            }
            return movies;
        }

        public List<ActorMaster>GetAllActorList(){
            return db.ActorMaster.ToList();
        }

        public List<ProducerMaster>GetAllProducerList(){
            return db.ProducerMaster.ToList();
        }

        public long saveActor(ActorMaster newActor)
        {
            db.ActorMaster.Add(newActor);
            db.SaveChanges();

            return newActor.ActorId;
        }

        public long saveProducer(ProducerMaster newProducer)
        {
            db.ProducerMaster.Add(newProducer);
            db.SaveChanges();

            return newProducer.ProdId;
        }

        public bool saveMovie(Movie_Master newMovie)
        {
            db.MovieMaster.Add(newMovie.movie);
            db.SaveChanges();
            long newid = newMovie.movie.MovieId;

            foreach (var item in newMovie.actors)
            {
                db.MovieActorDb.Add(new MovieActorDb
                {
                    ActorId = item.ActorId,
                    MovieId = newid                   
                });
            }
            db.SaveChanges();
            return true; ;
        }

        public bool updateMovie(Movie_Master newMovie)
        {
            var movieId = newMovie.movie.MovieId;
            var movie = db.MovieMaster.Where(it => it.MovieId == movieId).FirstOrDefault();
            if (movie != null)
            {
                movie.MovieName = newMovie.movie.MovieName;
                movie.Plot = newMovie.movie.Plot;                                                                                 
                movie.ProdId = newMovie.movie.ProdId;
                movie.ReleaseYear = newMovie.movie.ReleaseYear;
                movie.Thumbnail = newMovie.movie.Thumbnail;
                db.SaveChanges();



                db.MovieActorDb.RemoveRange(db.MovieActorDb.Where(x => x.MovieId == movieId));

                foreach (var item in newMovie.actors)
                {
                        db.MovieActorDb.Add(new MovieActorDb
                        {
                            ActorId = item.ActorId,
                            MovieId = movieId
                        });
                }


                db.SaveChanges();



                return true ;
            }
            else
            {
                return false;
            }
        }
        
    }
}
