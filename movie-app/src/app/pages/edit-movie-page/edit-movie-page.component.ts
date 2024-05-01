import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { MovieService } from '../../services/movie.service';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';


@Component({
    selector: 'app-edit-movie-page',
    standalone: true,
    imports: [FormsModule, ReactiveFormsModule, InputTextModule, ButtonModule],
    templateUrl: './edit-movie-page.component.html',
    styleUrl: './edit-movie-page.component.css'
})
export class EditMoviePageComponent implements OnInit {

    id: string = '';

    addMovieForm = new FormGroup({
        movieName: new FormControl(''),
        movieRating: new FormControl(''),
    });

    submitForm(event: Event) {
        
        this.movieService.updateMovie({
            id: parseInt(this.id, 10),
            name: this.addMovieForm.value.movieName ?? "",
            rate: parseFloat(this.addMovieForm.value.movieRating ?? "0"),
        }).subscribe();
    }


    ngOnInit(): void {

        this.id = this.route.snapshot.paramMap.get('id') ?? '';

        this.movieService.getMovie(this.id).subscribe(movie => {
            this.addMovieForm.setValue({
                movieName: movie.name,
                movieRating: movie.rate.toString(),
            });
        });
    }

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private movieService: MovieService) {
    }

}
