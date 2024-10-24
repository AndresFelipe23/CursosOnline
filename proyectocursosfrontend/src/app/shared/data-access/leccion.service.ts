import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment'; // Asegúrate de que la ruta a `environment` sea correcta

// Interfaz para el modelo de Lección, que refleja la estructura de tu lección
export interface Leccion {
  leccionId: number;
  lecTitulo: string;
  lecContenido: string; // Este campo debe coincidir con el campo que almacena el contenido en tu JSON
  etapaId: number;
  cursoId: number;
  lecDescripcion: string;
  lecDuracion: number;
  lecFechaCreacion: string;
  lecActivo: boolean;
  lecOrden: number;
  lecTipo: string;
  lecPuntosRecompensa: number;
  lecNumeroIntentos: number;
  lecTiempoEstimado: number;

}

@Injectable({
  providedIn: 'root' // Proveedor del servicio a nivel de root
})
export class LeccionService {
  private apiURL = `${environment.apiURL}/api/Lecciones`;  // Asegúrate de que `environment.apiURL` esté bien definido

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
