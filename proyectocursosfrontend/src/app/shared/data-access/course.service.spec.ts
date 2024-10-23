import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

export interface Curso {
  cursoId: number;
  curTitulo: string;
  curDescripcion: string;
  curProfesorId: string;
  curFechaCreacion: string;
  curActivo: boolean;
  curDuracion: number;
  curNivelDificultad: string;
  curImagenURL: string;
}

@Injectable({
  providedIn: 'root'
})
export class CursoService {

  private http = inject(HttpClient);
  private apiURL = `${environment.apiURL}/api/Cursos`;

  constructor() {}

  obtenerCursos(): Observable<Curso[]> {
    return this.http.get<Curso[]>(this.apiURL);
  }
}
