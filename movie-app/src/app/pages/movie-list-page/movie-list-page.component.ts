import { Component, OnInit } from '@angular/core';
import { TableModule } from 'primeng/table';
import { DropdownChangeEvent, DropdownModule } from 'primeng/dropdown';
import { Movie } from '../../models/movie';
import { MovieService } from '../../services/movie.service';
import { FormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { RouterModule } from '@angular/router';


@Component({
    selector: 'app-movie-list-page',
    standalone: true,
    imports: [RouterModule, FormsModule, TableModule, DropdownModule, InputTextModule, ButtonModule],
    templateUrl: './movie-list-page.component.html',
    styleUrl: './movie-list-page.component.css'
})
export class MovieListPageComponent implements OnInit {

    movies!: Movie[];

    selectedGenre: string | undefined;

    genres: string[] | undefined;

    searchTerm: string | undefined;

    filterMovies(event: Event) {
        
        this.movieService.filterMovies(this.searchTerm, this.selectedGenre).subscribe(data => {
            this.movies = data;
        });
    }

    filterByGenre(event: DropdownChangeEvent) {
        
        this.movieService.getMoviesByGenre(event.value).subscribe(data => {
            this.movies = data;
        });
    }

    constructor(private movieService: MovieService) { }

    ngOnInit() {

        this.movieService.getAllMovies().subscribe(data => { this.movies = data; });

        this.movieService.getMovieGenres().subscribe(data => { this.genres = data; });
    }
}
