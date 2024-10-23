import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EtapaService } from '../shared/data-access/etapa.service';
import { RouterModule } from '@angular/router'; // Asegúrate de importar RouterModule
import { Etapa } from '../shared/data-access/etapa.service';

@Component({
  standalone: true,
  selector: 'app-etapas',
  templateUrl: './etapas.component.html',
  styleUrls: ['./etapas.component.css'],
  imports: [CommonModule, RouterModule], // Incluye RouterModule
})
export class EtapasComponent implements OnInit {
  etapas: Etapa[] = [];
  cursoId: number = 0;
  private etapaService = inject(EtapaService);
  private route = inject(ActivatedRoute);

  ngOnInit(): void {
    this.cursoId = Number(this.route.snapshot.paramMap.get('cursoId'));
    if (this.cursoId) {
      this.obtenerEtapas();
    } else {
      console.error('No se proporcionó un cursoId');
    }
  }

  obtenerEtapas(): void {
    this.etapaService.obtenerEtapasPorCurso(this.cursoId).subscribe({
      next: (data: any) => {
        this.etapas = data.$values;
        console.log('Etapas obtenidas:', this.etapas);
      },
      error: (error) => {
        console.error('Error al obtener las etapas:', error);
      }
    });
  }
}
