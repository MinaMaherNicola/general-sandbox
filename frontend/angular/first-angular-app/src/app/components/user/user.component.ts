import { Component, EventEmitter, Input, Output } from '@angular/core';

interface User {
	id: number;
	avatar: string;
	name: string;
}

@Component({
	selector: 'app-user',
	standalone: true,
	templateUrl: './user.component.html',
	styleUrl: './user.component.css'
})
export class UserComponent {
	@Input({ required: true }) user!: User;
	@Input({ required: true }) selected!: boolean;

	@Output() select = new EventEmitter<number>();

	onSelectUser() {
		this.select.emit(this.user.id);
	}
}
