import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LeccionService, Leccion } from '../shared/data-access/leccion.service';
import { CommonModule } from '@angular/common';
import { NavigationButtonsComponent } from '../navigation-buttons/navigation-buttons.component';
import { LessonHeaderComponent } from '../lesson-header/lesson-header.component';  // Importa el nuevo componente

@Component({
  standalone: true,
  selector: 'app-contenido-leccion',
  templateUrl: './contenido-leccion.component.html',
  imports: [CommonModule, NavigationButtonsComponent, LessonHeaderComponent]  // Incluye el nuevo componente
})
export class ContenidoLeccionComponent implements OnInit {
  leccion: Leccion | null = null;
  leccionId: number = 0;
  totalLessons: number = 10;

  private leccionService = inject(LeccionService);
  private route = inject(ActivatedRoute);
  private router = inject(Router);

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.leccionId = Number(params.get('leccionId'));
      if (this.leccionId) {
        this.obtenerLeccion();
      } else {
        console.error('No se proporcionó un leccionId');
      }
    });
  }

  obtenerLeccion(): void {
    this.leccionService.obtenerLeccionPorId(this.leccionId).subscribe({
      next: (data: Leccion) => {
        this.leccion = data;
      },
      error: (error) => {
        console.error('Error al obtener la lección:', error);
        this.leccion = null;
      }
    });
  }
}
