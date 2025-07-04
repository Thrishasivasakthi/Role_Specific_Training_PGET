import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-book-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent {
  books = [
    { id: 1, title: 'Angular Basics' },
    { id: 2, title: 'TypeScript Mastery' },
    { id: 3, title: 'RxJS Deep Dive' }
  ];
}