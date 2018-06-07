import { Pipe, PipeTransform } from '@angular/core';
import {Movie} from './../models/movie';

@Pipe({
    name: 'search'
})

export class SearchPipe implements PipeTransform {
    transform(movies: Movie[], searchStr: string): any {

        console.log(searchStr);        

        if(searchStr == null || searchStr.trim() == '')
        {
            return movies;
        }

        return movies.filter((item: any) => {

            return item.Title.toLocaleLowerCase().includes(searchStr.toLocaleLowerCase());
        });
        //return movies;

    }
}