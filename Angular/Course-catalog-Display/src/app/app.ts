import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CourseComponent } from "./course/course.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, CourseComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'Course-catalog-Display';
}
