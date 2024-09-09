import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './components/header/header.components';
import { UserComponent } from './components/user/user.component';
import { USERS } from './components/user/dummy-users';
import { TasksComponent } from './components/tasks/tasks.component';

@Component({
	selector: 'app-root',
	standalone: true,
	imports: [RouterOutlet, HeaderComponent, UserComponent, TasksComponent],
	templateUrl: './app.component.html',
	styleUrl: './app.component.css'
})
export class AppComponent {
	selectedUserId?: number;
	users = USERS;

	onSelectUser(id: number) {
		this.selectedUserId = id;
	}

	get selectedUserName(): string {
		const user = this.users.find(u => u.id === this.selectedUserId);
		if (!user || !user.name) {
			throw new Error('Invalid Operation');
		}
		return user.name;
	}
}

function generateTasks(): string[] {
	return [
		`Task-${Math.floor(Math.random() * 100) + 1}`,
		`Task-${Math.floor(Math.random() * 100) + 1}`,
		`Task-${Math.floor(Math.random() * 100) + 1}`,
		`Task-${Math.floor(Math.random() * 100) + 1}`,
		`Task-${Math.floor(Math.random() * 100) + 1}`,
		`Task-${Math.floor(Math.random() * 100) + 1}`,
		`Task-${Math.floor(Math.random() * 100) + 1}`,
		`Task-${Math.floor(Math.random() * 100) + 1}`,
		`Task-${Math.floor(Math.random() * 100) + 1}`
	];
}
