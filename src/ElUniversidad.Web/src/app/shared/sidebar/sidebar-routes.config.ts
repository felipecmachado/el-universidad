import { RouteInfo } from './sidebar.metadata';

//Sidebar menu Routes and data
export const ROUTES: RouteInfo[] =[
    { path: '/dashboard', title: 'Dashboard', icon: 'bx bx-home-circle', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] },
    {
      path: '', title: 'Programs', icon: 'bx bx-arch', class: 'sub', badge: '', badgeClass: '', isExternalLink: false,
      submenu: [
        { path: '/programs/list', title: 'Programs', icon: 'bx bx-right-arrow-alt', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] },
        { path: '/programs/new', title: 'Add New Program', icon: 'bx bx-right-arrow-alt', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] },
      ]
    },
    {
      path: '', title: 'Offers', icon: 'bx bx-calendar', class: 'sub', badge: '', badgeClass: '', isExternalLink: false,
      submenu: [
        { path: '/program-structures', title: 'Structures', icon: 'bx bx-right-arrow-alt', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] },
        { path: '/offers', title: 'Offers', icon: 'bx bx-right-arrow-alt', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] },
      ]
    },
    {
      path: '', title: 'Courses', icon: 'bx bx-notepad', class: 'sub', badge: '', badgeClass: '', isExternalLink: false,
      submenu: [
        { path: '/courses/list', title: 'Courses', icon: 'bx bx-right-arrow-alt', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] },
        { path: '/courses/new', title: 'Add New Course', icon: 'bx bx-right-arrow-alt', class: '', badge: '', badgeClass: '', isExternalLink: false, submenu: [] },
      ]
    },
    { path: 'https://github.com/felipecmachado/sw-engineering-unisinos-case/', title: 'Github Repo', icon: 'bx bx-folder', class: '', badge: '', badgeClass: '', isExternalLink: true, submenu: [] },
  ];
