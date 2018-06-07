import {Component} from '@angular/core';
import '../css/main.css';
import {Movie} from './models/movie';

@Component({
    selector: "emdb",
    template: require('./app.component.html')
    //templateUrl: './src/app/app.component.html'
})


export class AppComponent{

    movies: Movie[] = [{imdbId: "MV34234", title: "Interstellar", year: 2014, type: "sci-fi", price: 25},
                {imdbId: "MV43234", title: "Bahubali", year: 2016, type: "fantacy", price: 150}];


}