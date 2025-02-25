import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterModule], // Importiamo il RouterModule direttamente
  template: `
    <h1>Gestione Anagrafica Medica</h1>
    <nav>
      <a routerLink="/doctors">Gestione Medici</a>
      <a routerLink="/patients">Gestione Pazienti</a>
    </nav>
    <router-outlet></router-outlet>
  `,
  styles: [`
    nav {
      margin-bottom: 15px;
    }
    a {
      margin-right: 10px;
      text-decoration: none;
      color: blue;
    }
  `]
})
export class AppComponent {}
