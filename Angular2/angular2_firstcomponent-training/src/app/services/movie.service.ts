import { Injectable } from '@angular/core';
import {Movie} from '../models/movie';
import {Http, Response} from '@angular/http';
import {Observable} from 'rxjs/Observable';

@Injectable()
export class MovieService {

    constructor(private http: Http) { }

    getMovieList(): any{

    }

    // getMovies(): Observable<Movie[]>{
    //     return this.http.get("http://www.omdlapi.com/?s=Batman")
    //         .map(this.handleSuccess).catch(this.handleError);

    // }

    // private handleSuccess(res: Response){
    //     let body = res.json();
    //     return body.data || {};
    // };

    // private handleError(error: any){
    //     let errMsg = error.message || 'Server error';
    //     console.error(errMsg);
    //     return Observable.throw(errMsg);
    // }

        getMovies(): Promise<Movie[]>{
        return this.http.get("http://www.omdbapi.com/?s=Batman")
            .toPromise().then(this.handleSuccess).catch(this.handleError);

    }

    private handleSuccess(res: Response){
        let body = res.json();
        console.log(body);
        return body.Search || {};
    };

    private handleError(error: any){
        let errMsg = error.message || 'Server error';
        console.error(errMsg);
        return Promise.reject(errMsg);
    }

    // private getMovies(): Movie[] {
    //     let movies: Movie[] = [];

    //     let movie1 = new Movie();
    //     //movie1.im

    //         // movies: Movie[] = [{imdbId: "MV34234", title: "Interstellar", year: 2014, type: "", price: 25},
    //         //     {imdbId: "MV43234", title: "Bahubali", year: 2016, type: "fantacy", price: 150}];

    //             return movies;
    // }
}