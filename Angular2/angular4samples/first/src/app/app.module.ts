import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';

import { SortPipe } from './app.pipe';
import { AppComponent } from './app.component';
import { MyCompComponent } from './my-comp/my-comp.component';
import { ProductComponent } from './product/product.component';
import { MembersComponent } from './members/members.component';
import { PipeComponent } from './pipe/pipe.component';
import { FormsComponent } from './forms/forms.component';

@NgModule({
  declarations: [
    SortPipe,
    AppComponent,
    MyCompComponent,
    ProductComponent,
    MembersComponent,
    PipeComponent,
    FormsComponent    
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      {
        path: 'member',
        component: MembersComponent
      },
      {
        path: 'product',
        component: ProductComponent
      },
      {
        path: "pipe",
        component: PipeComponent
      },
      {
        path: "forms",
        component: FormsComponent
      }
    ])
    // ], {
    //   enableTracing: true
    // })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
