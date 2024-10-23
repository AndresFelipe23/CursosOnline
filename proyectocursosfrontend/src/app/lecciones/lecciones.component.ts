import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router'; // Para obtener el etapaId
import { LeccionService } from '../shared/data-access/leccion.service'; // Servicio para obtener lecciones
import { Leccion } from '../shared/data-access/leccion.service'; // Modelo de Leccion
import { RouterModule } from '@angular/router'; // Para manejar las rutas

@Component({
  standalone: true,
  selector: 'app-lecciones',
  templateUrl: './lecciones.component.html',
  styleUrls: ['./lecciones.component.css'],
  imports: [CommonModule, RouterModule] // Importar RouterModule para usar [routerLink]
})
export class LeccionesComponent implements OnInit {
  lecciones: Leccion[] = [];
  etapaId: number = 0; // ID de la etapa para obtener sus lecciones
  private leccionService = inject(LeccionService);
  private route = inject(ActivatedRoute); // Inyectar ActivatedRoute para obtener el etapaId

  ngOnInit(): void {
    // Obtener etapaId desde la URL
    this.etapaId = Number(this.route.snapshot.paramMap.get('etapaId'));

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
        console.log('Lecciones obtenidas:', this.lecciones);
      },
      error: (error) => {
        console.error('Error al obtener las lecciones:', error);
      }
    });
  }
}
