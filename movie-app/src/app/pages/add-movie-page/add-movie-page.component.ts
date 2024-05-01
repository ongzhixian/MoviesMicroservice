import { Component } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { MovieService } from '../../services/movie.service';

@Component({
    selector: 'app-add-movie-page',
    standalone: true,
    imports: [FormsModule, ReactiveFormsModule, InputTextModule, ButtonModule],
    templateUrl: './add-movie-page.component.html',
    styleUrl: './add-movie-page.component.css'
})
export class AddMoviePageComponent {

    addMovieForm = new FormGroup({
        movieName: new FormControl(''),
        movieRating: new FormControl(''),
    });

    submitForm(event: Event) {
        
        this.movieService.addMovie({
            name: this.addMovieForm.value.movieName ?? "",
            rate: parseFloat(this.addMovieForm.value.movieRating ?? "0"),
        });
    }

    constructor(private movieService: MovieService) {}
}
