import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { Curso, CourseService } from '../shared/data-access/course.service';
import { NavbarComponent } from '../shared/ui/navbar/navbar.component';
import { RouterModule } from '@angular/router'; // Importa RouterModule para usar routerLink en las plantillas

@Component({
  standalone: true,
  selector: 'app-home',
  templateUrl: './home.component.html',
  imports: [CommonModule, NavbarComponent, RouterModule] // Asegúrate de incluir RouterModule para routerLink
})
export class HomeComponent implements OnInit {
  cursos: Curso[] = [];
  private courseService = inject(CourseService);

  ngOnInit(): void {
    this.obtenerCursos();
  }

  obtenerCursos(): void {
    this.courseService.obtenerCursos().subscribe({
      next: (data: any) => {
        // Acceder a los cursos en la propiedad $values si los cursos vienen en ese formato
        this.cursos = data.$values || data;
        console.log('Cursos obtenidos:', this.cursos);
      },
      error: (error) => {
        console.error('Error al obtener los cursos:', error);
      }
    });
  }
}
