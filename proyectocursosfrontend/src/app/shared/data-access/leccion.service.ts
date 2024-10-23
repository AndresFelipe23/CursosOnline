import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

export interface Leccion {
  leccionId: number;
  lecTitulo: string;
  lecDescripcion: string;
  lecDuracion: number;
  etapaId: number; // Relación con la Etapa
}

@Injectable({
  providedIn: 'root'
})
export class LeccionService {
  private apiURL = `${environment.apiURL}/api/Lecciones`;  // Asegúrate que `environment.apiURL` esté bien definido

  constructor(private http: HttpClient) {}

  // Método para obtener todas las lecciones
  obtenerLecciones(): Observable<Leccion[]> {
    return this.http.get<Leccion[]>(this.apiURL);
  }

  // Método para obtener las lecciones por etapa
  obtenerLeccionesPorEtapa(etapaId: number): Observable<Leccion[]> {
    return this.http.get<Leccion[]>(`${this.apiURL}/etapa/${etapaId}`);
  }

  // Método para obtener una lección por su ID
  obtenerLeccionPorId(leccionId: number): Observable<Leccion> {
    return this.http.get<Leccion>(`${this.apiURL}/${leccionId}`);
  }
}
