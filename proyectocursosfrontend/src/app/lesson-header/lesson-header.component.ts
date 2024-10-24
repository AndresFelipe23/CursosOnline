import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  standalone: true,
  selector: 'app-lesson-header',
  templateUrl: './lesson-header.component.html',
  imports: [CommonModule]
})
export class LessonHeaderComponent {
  @Input() lecTitulo!: string;  // El título de la lección
  @Input() etapaId!: number;    // ID de la etapa para redirigir al listado de lecciones

  constructor(private router: Router) {}

  cerrarContenido(): void {
    // Redirigir a la lista de lecciones de la etapa actual
    this.router.navigate(['/lecciones', this.etapaId]);
  }
}
