import { Routes } from '@angular/router';
import { DoctorComponent } from './components/doctor/doctor.component';
import { PatientComponent } from './components/patient/patient.component';

export const routes: Routes = [
  { path: 'doctors', component: DoctorComponent },
  { path: 'patients', component: PatientComponent },
  { path: '', redirectTo: '/doctors', pathMatch: 'full' }
];
