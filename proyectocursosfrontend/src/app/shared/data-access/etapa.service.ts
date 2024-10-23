import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

export interface Etapa {
  etapaId: number;
  etaNombre: string;
  etaDescripcion: string;
  cursoId: number;
  etaOrden: number;
  etaFechaCreacion: string;
  etaActivo: boolean;
  etaNumeroLecciones: number;
}

@Injectable({
  providedIn: 'root'
})
export class EtapaService {
  private apiURL = `${environment.apiURL}/api/Etapas`;

  constructor(private http: HttpClient) {}

   // Método existente para obtener las etapas de un curso
   obtenerEtapasPorCurso(cursoId: number): Observable<Etapa[]> {
    return this.http.get<Etapa[]>(`${this.apiURL}/curso/${cursoId}`);
  }

  // Nuevo método para obtener una etapa específica por cursoId y etapaId
  obtenerEtapaPorCursoYSeccion(cursoId: number, etapaId: number): Observable<Etapa> {
    return this.http.get<Etapa>(`${this.apiURL}/curso/${cursoId}/etapa/${etapaId}`);
  }

}

