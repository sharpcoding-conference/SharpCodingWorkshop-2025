import { Component, OnInit } from '@angular/core';
import { NgFor, NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { DoctorService, Doctor } from '../../services/doctor.service';

@Component({
  selector: 'app-doctor',
  standalone: true,
  imports: [NgFor, NgIf, FormsModule],
  templateUrl: './doctor.component.html',
  styleUrls: ['./doctor.component.css']
})
export class DoctorComponent implements OnInit {
  doctors: Doctor[] = [];
  newDoctor: Doctor = { firstName: '', lastName: '', specialization: '', email: '', phone: '' };
  editDoctor?: Doctor;

  constructor(private doctorService: DoctorService) {}

  ngOnInit(): void {
    this.loadDoctors();
  }

  loadDoctors(): void {
    this.doctorService.getDoctors().subscribe(data => this.doctors = data);
  }

  addDoctor(): void {
    this.doctorService.addDoctor(this.newDoctor).subscribe(() => {
      this.loadDoctors();
      this.resetDoctorForm();
    });
  }

  updateDoctor(): void {
    if (this.editDoctor) {
      this.doctorService.updateDoctor(this.editDoctor.id!, this.editDoctor).subscribe(() => {
        this.loadDoctors();
        this.editDoctor = undefined;
      });
    }
  }

  deleteDoctor(id: string): void {
    this.doctorService.deleteDoctor(id).subscribe(() => this.loadDoctors());
  }

  selectDoctor(doctor: Doctor): void {
    this.editDoctor = { ...doctor };
  }

  resetDoctorForm(): void {
    this.newDoctor = { firstName: '', lastName: '', specialization: '', email: '', phone: '' };
  }
}
