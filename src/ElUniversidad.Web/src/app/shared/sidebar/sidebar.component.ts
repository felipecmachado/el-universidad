import { Component, OnInit, HostListener } from '@angular/core';
import { ROUTES } from './sidebar-routes.config';
import { Router, Event, NavigationStart, NavigationEnd, NavigationError } from '@angular/router';
import { SidebarService } from "./sidebar.service";

import * as $ from 'jquery';

@Component({
    selector: 'app-sidebar',
    templateUrl: './sidebar.component.html',
})

export class SidebarComponent implements OnInit {
    
    public menuItems: any[] | undefined;

    public getScreenWidth: any;
    public getScreenHeight: any;

    constructor( public sidebarservice: SidebarService,private router: Router) {

        router.events.subscribe( (event: Event) => {

            if (event instanceof NavigationStart) {
                // Show loading indicator
            }

          var windows = $(window);

          if (event instanceof NavigationEnd && this.getScreenWidth < 1025 && ( document.readyState == 'complete' || false ) ) {
                this.toggleSidebar();
            }

            if (event instanceof NavigationError) {
                console.log(event.error);
            }
        });
    }

    toggleSidebar() {
        this.sidebarservice.setSidebarState(!this.sidebarservice.getSidebarState());
        
        if ($(".wrapper").hasClass("nav-collapsed")) {
            // unpin sidebar when hovered
            $(".wrapper").removeClass("nav-collapsed");
            $(".sidebar-wrapper").unbind( "hover");
        } else {
            $(".wrapper").addClass("nav-collapsed");
            $(".sidebar-wrapper").hover(
                function () {
                    $(".wrapper").addClass("sidebar-hovered");
                },
                function () {
                    $(".wrapper").removeClass("sidebar-hovered");
                }
            )
        }
    }

    getSideBarState() {
        return this.sidebarservice.getSidebarState();
    }

    hideSidebar() {
        this.sidebarservice.setSidebarState(true);
    }

    ngOnInit() {
    this.getScreenWidth = window.innerWidth;
    this.getScreenHeight = window.innerHeight;
        this.menuItems = ROUTES.filter(menuItem => menuItem);
        $.getScript('./assets/js/app-sidebar.js');
    }

    @HostListener('window:resize', ['$event'])
    onWindowResize() {
      this.getScreenWidth = window.innerWidth;
      this.getScreenHeight = window.innerHeight;
    }

}
