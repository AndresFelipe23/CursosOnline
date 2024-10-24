import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  standalone: true,
  selector: 'app-leccion-header',
  templateUrl: './leccion-header.component.html',
  imports: [CommonModule]
})
export class LeccionHeaderComponent {
  @Input() cursoId!: number;  // Recibe el cursoId para redirigir a las etapas correctas

  constructor(private router: Router) {}

  irAEtapas(): void {
    // Redirigir a la vista de las etapas del curso correspondiente
    this.router.navigate(['/etapas', this.cursoId]);
  }
}
