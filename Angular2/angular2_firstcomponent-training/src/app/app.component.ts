import {Component} from '@angular/core';
import '../css/main.css';
import {Movie} from './models/movie';
import {MovieService} from './services/movie.service';

@Component({
    selector: "emdb",
    template: require('./app.component.html')
    //templateUrl: './src/app/app.component.html'
})


export class AppComponent{

    private movies: Movie[];

    ngOnInit(){
        console.log('App Started');
    }

    constructor(private _movieService: MovieService){
        _movieService.getMovies().then((response) => {
            this.movies = response;
        }, (error: any) => {
            console.log("Error occured");
        });
    }

    
    
    //movies: Movie[] = _movieService.getMovies();

    // movies: Movie[] = [{imdbId: "MV34234", title: "Interstellar", year: 2014, type: "", price: 25},
    //             {imdbId: "MV43234", title: "Bahubali", year: 2016, type: "fantacy", price: 150}];


}