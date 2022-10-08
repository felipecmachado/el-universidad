import { Routes } from '@angular/router';

//Route for content layout with sidebar, navbar and footer.

export const Full_ROUTES: Routes = [
  {
    path: 'dashboard',
    loadChildren: () => import('../../dashboard/dashboard.module').then(m => m.DashboardModule)
  },
  {
    path: 'programs',
    loadChildren: () => import('../../programs/programs.module').then(m => m.ProgramsModule)
  },
  {
    path: 'offers',
    loadChildren: () => import('../../offers/offers.module').then(m => m.OffersModule)
  },
  {
    path: 'program-structures',
    loadChildren: () => import('../../program-structures/program-structures.module').then(m => m.ProgramStructuresModule)
  },
  {
    path: 'courses',
    loadChildren: () => import('../../courses/courses.module').then(m => m.CoursesModule)
  },
  {
    path: 'user-profile',
    loadChildren: () => import('../../user-profile/user-profile.module').then(m => m.UserProfileModule)
  }
];
