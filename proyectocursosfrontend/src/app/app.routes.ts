import { Routes } from '@angular/router';
import { privateGuard, publicGuard } from './core/auth.guard';
import { EtapasComponent } from './etapas/etapas.component';

export const routes: Routes = [
  {
    canActivateChild: [publicGuard()],
    path: 'auth',
    loadChildren: () => import('./auth/features/auth.routes'),
  },
  // {
  //   canActivateChild: [privateGuard()],
  //   path: 'tasks',
  //   loadComponent: () => import('./shared/ui/layout.component'),
  //   loadChildren: () => import('./task/features/task.routes'),
  // },
  {
    path: 'home',
    loadComponent: () => import('./home/home.component').then(m => m.HomeComponent),
    canActivateChild: [privateGuard()],
  },
  {
    path: 'etapas/:cursoId',
    loadComponent: () => import('./etapas/etapas.component').then(m => m.EtapasComponent),
    canActivateChild: [privateGuard()],
  },
  {
    path: 'lecciones/:etapaId',
    loadComponent: () => import('./lecciones/lecciones.component').then(m => m.LeccionesComponent),
    canActivateChild: [privateGuard()],
  },
  {
    path: 'contenido/:leccionId',
    loadComponent: () => import('./contenido-leccion/contenido-leccion.component').then(m => m.ContenidoLeccionComponent),
    canActivateChild: [privateGuard()],
  },
  {
    path: '**',
    redirectTo: '/home',
  },
  {
    path: '**',
    redirectTo: '/tasks',
  },

];
