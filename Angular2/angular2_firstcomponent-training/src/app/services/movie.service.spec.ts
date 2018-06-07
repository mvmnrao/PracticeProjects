import {Movie} from '../models/movie';
import {MovieService} from './movie.service';

describe("Test Movie Service", ()=>{
    let movieService : MovieService;

    let movie = new Movie();
    movie.Title = 'Test movie';
    movie.imdbID = '23432';
    movie.Poster = 'Test poster';
    movie.Type = 'Test type';
    movie.Year = 2017;

    // it('Isolated test without service dependency mocking', inject([MovieService], (service: MovieService) => {

    //     //let service = new MovieService();


    // }));

    it('Just pass', ()=>{
        expect(true).toBe(true);
    });
});