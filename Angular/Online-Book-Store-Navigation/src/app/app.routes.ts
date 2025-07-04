import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { BookListComponent } from './book-list/book-list.component';
import { BookDetailsComponent } from './book-details/book-details.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'books', component: BookListComponent },
  { path: 'books/:id', component: BookDetailsComponent }
];