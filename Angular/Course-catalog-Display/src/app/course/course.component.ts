import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Course } from './course.model';

@Component({
  selector: 'app-course',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css']
})
export class CourseComponent {
  courses: Course[] = [
    {
      id: 1,
      title: 'Angular Fundamentals',
      instructor: 'John Doe',
      startDate: new Date('2025-07-15'),
      price: 4999,
      description: 'Learn the basics of Angular including components, modules, and directives.'
    },
    {
      id: 2,
      title: 'React Basics',
      instructor: 'Jane Smith',
      startDate: new Date('2025-07-20'),
      price: 3499,
      description: 'Build interactive UIs with React and manage state effectively.'
    }
  ];
}