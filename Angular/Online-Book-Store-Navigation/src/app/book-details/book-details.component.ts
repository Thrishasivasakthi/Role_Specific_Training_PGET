import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-book-details',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.css']
})
export class BookDetailsComponent {
  book: any;

  books = [
    { id: 1, title: 'Angular Basics', author: 'Jane Dev', price: 299, description: 'Intro to Angular...' },
    { id: 2, title: 'TypeScript Mastery', author: 'Max Programmer', price: 499, description: 'Deep dive into TypeScript...' },
    { id: 3, title: 'RxJS Deep Dive', author: 'Reactive Guru', price: 399, description: 'Advanced reactive programming...' }
  ];

  constructor(private route: ActivatedRoute) {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.book = this.books.find(b => b.id === id);
  }
}