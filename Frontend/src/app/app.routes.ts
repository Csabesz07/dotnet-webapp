import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: 'main',
        loadChildren: () =>
            import('./modules/main/main.module').then(m => m.MainModule)
    },
    {
        path: '',
        pathMatch: 'full',
        redirectTo: '/main',
      },
      {
        path: '**',
        pathMatch: 'full',
        redirectTo: '/main',
      },
];
