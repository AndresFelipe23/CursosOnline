import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  // Remover la inyección del servicio si no es necesario
  // weatherForecastService = inject(WeatherforecastService);
  // climas: any[] = [];

  constructor() {
    // Comentar o eliminar la lógica relacionada con la llamada al servicio
    // this.weatherForecastService.obtenerClima().subscribe(datos => {
    //   this.climas = datos;
    // });
  }
}
