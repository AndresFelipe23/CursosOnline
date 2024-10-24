import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  standalone: true,
  selector: 'app-navigation-buttons',
  templateUrl: './navigation-buttons.component.html',
  imports: [CommonModule]
})
export class NavigationButtonsComponent {
  @Input() leccionId!: number;  // ID de la lección actual
  @Input() totalLessons!: number;  // Total de lecciones

  constructor(private router: Router) {}

  irAtras(): void {
    const previousLessonId = this.leccionId - 1;
    if (previousLessonId > 0) {
      this.router.navigate(['/contenido', previousLessonId]);
    }
  }

  irSiguiente(): void {
    const nextLessonId = this.leccionId + 1;
    if (nextLessonId <= this.totalLessons) {
      this.router.navigate(['/contenido', nextLessonId]);
    }
  }
}
