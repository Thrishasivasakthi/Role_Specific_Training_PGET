import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { EmployeeComponent } from "./employee/employee.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, EmployeeComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'Employee-Attendence-Dashboard';
}
