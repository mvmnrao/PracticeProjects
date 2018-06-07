import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {FormsModule} from '@angular/forms';
import {HttpModule} from '@angular/http';

import {AppComponent} from './app.component';
import {MovieTileComponent} from './movietile/movietile.component';
import {SearchPipe} from './commons/search.pipe';
import {MovieService} from './services/movie.service';

@NgModule({
    declarations: [AppComponent, MovieTileComponent, SearchPipe],
    imports: [BrowserModule, FormsModule, HttpModule],
    providers:[MovieService],
    bootstrap: [AppComponent]
})

export class AppModule{}