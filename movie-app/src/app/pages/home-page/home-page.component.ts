import { Component } from '@angular/core';
import { TableModule } from 'primeng/table';
import { MovieService } from '../../services/movie.service';
import { Movie } from '../../models/movie';

@Component({
    selector: 'app-home-page',
    standalone: true,
    imports: [TableModule],
    templateUrl: './home-page.component.html',
    styleUrl: './home-page.component.css'
})
export class HomePageComponent {
    movies!: Movie[];

    constructor(private movieService: MovieService) {

        movieService.getTop5HighestRatedMovies().subscribe(data => {
            this.movies = data;
        });
    }
}
