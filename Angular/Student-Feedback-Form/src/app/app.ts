import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FeedbackComponent } from "./student-feedback/student-feedback.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, FeedbackComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'Student-Feedback-Form';
}
