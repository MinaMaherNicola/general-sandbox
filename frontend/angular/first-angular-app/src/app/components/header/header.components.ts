import { Component } from '@angular/core';

@Component({
	// this should be ideally two words, because if it's only 'header', you will replace the default HTML <header>
	selector: 'app-header',
	// this should direct to your HTML file
	templateUrl: './header.component.html',
	// this should direct to your CSS file
	styleUrl: './header.component.css',
	standalone: true
})
export class HeaderComponent {}
