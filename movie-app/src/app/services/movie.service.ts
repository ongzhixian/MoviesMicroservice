import { Injectable } from '@angular/core';
import { Movie } from '../models/movie';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { AddMovieRequest } from '../models/add-movie-request';
import { UpdateMovieRequest } from '../models/update-movie-request';
import { Apollo } from 'apollo-angular';
import { CREATE_MOVIE, GET_MOVIES, UPDATE_MOVIE } from '../graphql.operations';
import { map  } from 'rxjs';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class MovieService {
    updateMovie(updateMovie: UpdateMovieRequest) : Observable<any> {

        if (environment.useGraphQL)
            return this.apollo.mutate<AddMovieRequest>({
                mutation: UPDATE_MOVIE,
                variables: { movie: updateMovie }
            });
            
        return this.http.put<UpdateMovieRequest>(`http://localhost:6600/api/movie/${updateMovie.id||''}`, updateMovie)
    }

    getMovie(id: string) {

        return this.http.get<Movie>(`http://localhost:6600/api/movie/${id||''}`);
    }

    addMovie(addMovie: AddMovieRequest) {

        if (environment.useGraphQL)
            return this.apollo.mutate<AddMovieRequest>({
                mutation: CREATE_MOVIE,
                variables: { movie: addMovie }
            }).subscribe();
        
        return this.http.post<AddMovieRequest>("http://localhost:6600/api/movie", addMovie).subscribe();
    }

    filterMovies(searchTerm: string | undefined, selectedGenre: string | undefined) {

        return this.http.get<Movie[]>(`http://localhost:6600/api/movie?genre=${selectedGenre||''}&search=${searchTerm||''}`);
    }

    getAllMovies() {

        if (environment.useGraphQL)
            return this.apollo.watchQuery<{ movies: Movie[] }>({
                query: GET_MOVIES
            }).valueChanges.pipe(map(result => { 
                return result.data.movies; 
            }));

        return this.http.get<Movie[]>("http://localhost:6600/api/movie");
    }

    getMovieGenres() {
        
        return this.http.get<string[]>("http://localhost:6600/api/movie/genre-list");
    }

    getMoviesByGenre(genre: string) {

        return this.http.get<Movie[]>(`http://localhost:6600/api/movie?genre=${genre||''}`);
    }

    getTop5HighestRatedMovies() {

        return this.http.get<Movie[]>("http://localhost:6600/api/movie/highest-rated");
    }

    constructor(
        private router: Router,
        private http: HttpClient, 
        private apollo : Apollo) { }
}
