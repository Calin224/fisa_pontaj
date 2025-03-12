import {APP_INITIALIZER, ApplicationConfig, provideZoneChangeDetection} from '@angular/core';
import { provideRouter } from '@angular/router';
import { providePrimeNG } from 'primeng/config';

import { routes } from './app.routes';
import { provideHttpClient } from '@angular/common/http';
import {MyPreset} from '../../mytheme';
import {InitService} from './core/services/init.service';
import {lastValueFrom} from 'rxjs';
import {provideAnimations} from '@angular/platform-browser/animations';

function initializeApp(initService: InitService) {
  return () => lastValueFrom(initService.init());
}

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideHttpClient(),
    provideAnimations(),
    providePrimeNG({
      theme: {
        preset: MyPreset
      }
    }),
    {
      provide: APP_INITIALIZER,
      useFactory: initializeApp,
      multi:true,
      deps: [InitService]
    }
  ],
};
