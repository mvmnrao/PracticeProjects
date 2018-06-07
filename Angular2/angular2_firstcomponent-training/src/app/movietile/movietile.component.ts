import { Component, OnInit, Input } from '@angular/core';
import {Movie} from '../models/movie';

@Component({
    selector: 'movietile',
    template: require('./movietile.component.html')
})
export class MovieTileComponent implements OnInit {
    constructor() { }

    @Input() movieDetail: Movie;
    @Input('message') msg: string;
    great: string = "hello";

    ngOnInit() { 
        console.log(" Component initialized", this.msg);
    }

    movieNameClick(){
        console.log("Movie Name: " + this.movieDetail.Title + " clicked");
    }
}