import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {AppComponent} from './app.component';
import {MovieTileComponent} from './movietile/movietile.component';

@NgModule({
    declarations: [AppComponent, MovieTileComponent],
    imports: [BrowserModule],
    providers:[],
    bootstrap: [AppComponent]
})

export class AppModule{}