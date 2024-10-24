import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router'; // Para obtener el etapaId y cursoId y manejar la navegación
import { LeccionService } from '../shared/data-access/leccion.service'; // Servicio para obtener lecciones
import { Leccion } from '../shared/data-access/leccion.service'; // Modelo de Leccion
import { RouterModule } from '@angular/router'; // Para manejar las rutas
import { LeccionHeaderComponent } from '../leccion-header/leccion-header.component'; // Importa el componente

@Component({
  standalone: true,
  selector: 'app-lecciones',
  templateUrl: './lecciones.component.html',
  imports: [CommonModule, RouterModule, LeccionHeaderComponent] // Asegúrate de importar LeccionHeaderComponent
})
export class LeccionesComponent implements OnInit {
  lecciones: Leccion[] = [];
  etapaId: number = 0; // ID de la etapa para obtener sus lecciones
  cursoId: number = 0; // ID del curso para la navegación de vuelta
  progresoTotal: number = 0;




  private leccionService = inject(LeccionService);
  private route = inject(ActivatedRoute); // Inyectar ActivatedRoute para obtener el etapaId
  private router = inject(Router); // Inyectar Router para navegar programáticamente

  ngOnInit(): void {
    // Obtener etapaId y cursoId desde la URL
    this.etapaId = Number(this.route.snapshot.paramMap.get('etapaId'));
    this.cursoId = Number(this.route.snapshot.queryParamMap.get('cursoId')); // Obtener cursoId de los parámetros de la URL

    if (this.etapaId) {
      this.obtenerLecciones(); // Llamar a la función para obtener las lecciones
    } else {
      console.error('No se proporcionó un etapaId');
    }
  }

  obtenerLecciones(): void {
    this.leccionService.obtenerLeccionesPorEtapa(this.etapaId).subscribe({
      next: (data: any) => {
        this.lecciones = data.$values;
        console.log('Lecciones obtenidas:', this.lecciones); // Verificar que se obtengan las lecciones correctamente
      },
      error: (error) => {
        console.error('Error al obtener las lecciones:', error);
      }
    });
  }

  iirAEtapas(): void {
    // Redirigir a la vista de las etapas del curso correspondiente
    if (this.cursoId) {
      this.router.navigate(['/etapas', this.cursoId]);  // Aquí usamos el cursoId para redirigir correctamente
    } else {
      console.error('No se proporcionó un cursoId');
    }
  }



  irALeccion(leccionId: number): void {
    console.log('Navegando a la lección con ID:', leccionId);
    this.router.navigate([`/contenido/${leccionId}`], { queryParams: { cursoId: this.cursoId } });
  }

}
