import { Component, OnInit } from '@angular/core';
import { NgFor, NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PatientService, Patient } from '../../services/patient.service';

@Component({
  selector: 'app-patient',
  standalone: true,
  imports: [NgFor, NgIf, FormsModule], // Importiamo direttive Angular necessarie
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.css']
})
export class PatientComponent implements OnInit {
  patients: Patient[] = [];
  newPatient: Patient = { firstName: '', lastName: '', taxCode: '' };
  editPatient?: Patient;

  constructor(private patientService: PatientService) {}

  ngOnInit(): void {
    this.loadPatients();
  }

  loadPatients(): void {
    this.patientService.getPatients().subscribe(data => this.patients = data);
  }

  addPatient(): void {
    this.patientService.addPatient(this.newPatient).subscribe(() => {
      this.loadPatients();
      this.newPatient = { firstName: '', lastName: '', taxCode: '' };
    });
  }

  updatePatient(): void {
    if (this.editPatient) {
      this.patientService.updatePatient(this.editPatient.id!, this.editPatient).subscribe(() => {
        this.loadPatients();
        this.editPatient = undefined;
      });
    }
  }

  deletePatient(id: string): void {
    this.patientService.deletePatient(id).subscribe(() => this.loadPatients());
  }

  selectPatient(patient: Patient): void {
    this.editPatient = { ...patient };
  }
}
