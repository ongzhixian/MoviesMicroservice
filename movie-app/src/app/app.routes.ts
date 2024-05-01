import { Routes } from '@angular/router';
import { NotFoundPageComponent } from './pages/not-found-page/not-found-page.component';
import { AppLayoutComponent } from './layouts/app-layout/app-layout.component';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { MovieListPageComponent } from './pages/movie-list-page/movie-list-page.component';
import { AddMoviePageComponent } from './pages/add-movie-page/add-movie-page.component';
import { EditMoviePageComponent } from './pages/edit-movie-page/edit-movie-page.component';

export const routes: Routes = [
        
    {
        path: '',
        component: AppLayoutComponent,
        children: [
            { path: 'home', component: HomePageComponent, title: "Home" },
            { path: 'movies', component: MovieListPageComponent, title: "Movie list" },
            
            {
                path: 'movie',
                children: [
                    { path: 'add', component: AddMoviePageComponent, title: "Add movie" },
                    { path: 'edit/:id', component: EditMoviePageComponent, title: "Edit movie" },
                ]
            },
            { path: 'not-found-page', component: NotFoundPageComponent, title: "Not found" },
            { path: '', redirectTo: '/home', pathMatch: 'full' },
            { path: '**', redirectTo: '/not-found-page' }
        ]
    },
    
];
