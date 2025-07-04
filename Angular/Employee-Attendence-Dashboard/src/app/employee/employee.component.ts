import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Employee } from './employee.model';

@Component({
  selector: 'app-employee',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent {
  employees: Employee[] = [
    { name: 'Alice', department: 'IT', isPresent: true, workFromHome: false },
    { name: 'Bob', department: 'HR', isPresent: false, workFromHome: true },
    { name: 'Charlie', department: 'Sales', isPresent: false, workFromHome: false }
  ];
}