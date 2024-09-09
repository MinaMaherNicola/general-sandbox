import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Task } from '../../../Shared/Task';
import { fa } from '@faker-js/faker';

@Component({
	selector: 'app-add-task',
	standalone: true,
	imports: [FormsModule],
	templateUrl: './add-task.component.html',
	styleUrl: './add-task.component.css'
})
export class AddTaskComponent {
	@Output() toggleForm = new EventEmitter();
	@Output() addTask = new EventEmitter<Task>();
	@Input({ required: true }) userId!: number;

	newTask: Task = {
		id: Math.floor(Math.random() * 10000) + 1,
		title: '',
		dueDate: undefined,
		summary: '',
		userId: this.userId
	};

	toggleFormEvent() {
		this.toggleForm.emit();
	}

	submitNewTask() {
		if (!this.validateTask(this.newTask)) {
			return;
		}
		this.newTask.dueDate = new Date(this.newTask.dueDate!).toDateString();
		this.addTask.emit(this.newTask);
		this.toggleForm.emit();
	}

	validateTask(task: Task): boolean {
		this.newTask.userId = this.userId;
		if (
			!task.title ||
			!task.summary ||
			!task.id ||
			!task.userId ||
			!task.dueDate
		) {
			return false;
		}
		return true;
	}
}
