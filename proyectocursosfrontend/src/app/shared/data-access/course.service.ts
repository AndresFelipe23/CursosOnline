import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { Etapa } from './etapa.service';

// Define tu modelo de Curso
export interface Curso {
  cursoId: number;
  curTitulo: string;
  curDescripcion: string;
  curProfesorUid: string;
  curFechaCreacion: string;
  curActivo: boolean;
  curDuracion: number;
  curNivelDificultad: string;
  curImagenUrl: string;
  etapas?: Etapa[]; // Etapas relacionadas
}

@Injectable({
  providedIn: 'root',
})
export class CourseService {
  private http = inject(HttpClient);
  private apiURL = `${environment.apiURL}/api/Cursos`;

  constructor() {}

  // Método para obtener los cursos junto con sus etapas
  obtenerCursos(): Observable<Curso[]> {
    return this.http.get<Curso[]>(this.apiURL).pipe(
      catchError(this.handleError)
    );
  }

  // Manejo de errores
  private handleError(error: HttpErrorResponse) {
    console.error('API request failed', error);
    return throwError(() => new Error('Error al obtener los cursos. Intenta nuevamente más tarde.'));
  }
}
