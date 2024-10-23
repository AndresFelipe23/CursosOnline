import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { provideHttpClient, withFetch } from '@angular/common/http';
import { initializeApp, provideFirebaseApp } from '@angular/fire/app';
import { getAuth, provideAuth } from '@angular/fire/auth';
import { getFirestore, provideFirestore } from '@angular/fire/firestore';
import { getDatabase, provideDatabase } from '@angular/fire/database';
import { getMessaging, provideMessaging } from '@angular/fire/messaging';
import { getStorage, provideStorage } from '@angular/fire/storage';
import { CourseService } from './shared/data-access/course.service';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideClientHydration(),
    provideHttpClient(withFetch()),
    CourseService,
    provideFirebaseApp(() =>
      initializeApp({
        projectId: 'proyectocurso-7170f',
        appId: '1:145836331634:web:06acc307aded673880e8eb',
        storageBucket: 'proyectocurso-7170f.appspot.com',
        apiKey: 'AIzaSyCZxeRaPnpgH9KIRJYVvkLmpOLYALG8bvg',
        authDomain: 'proyectocurso-7170f.firebaseapp.com',
        messagingSenderId: '145836331634',
        measurementId: 'G-WRH1NVWD9S',
      })
    ),
    provideAuth(() => getAuth()),
    provideFirestore(() => getFirestore()),
    provideDatabase(() => getDatabase()),
    provideMessaging(() => getMessaging()),
    provideStorage(() => getStorage()),
  ],
};
