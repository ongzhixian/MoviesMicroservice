import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MenuItem, PrimeNGConfig } from 'primeng/api';
import { MenubarModule } from 'primeng/menubar';

@Component({
    selector: 'app-app-layout',
    standalone: true,
    imports: [RouterOutlet, MenubarModule],
    templateUrl: './app-layout.component.html',
    styleUrl: './app-layout.component.css'
})
export class AppLayoutComponent implements OnInit {
    homeMenuItem: MenuItem = {
        label: 'Home',
        icon: 'pi pi-fw pi-home',
        routerLink: ['/home'], 
        queryParams: { 'recent': 'true' }
    }

    listMenuItem: MenuItem = {
        label: 'Movie List',
        icon: 'pi pi-fw pi-list',
        routerLink: ['/movies'], 
        queryParams: { 'recent': 'true' }
    }

    items: MenuItem[] | undefined = [
        this.homeMenuItem,
        this.listMenuItem
    ];

    constructor(private primengConfig: PrimeNGConfig) { }

    ngOnInit() {
        this.primengConfig.ripple = true;
    }
}
