import { Component, Input } from '@angular/core';
import { Task } from '../../../Shared/Task';
import { Output, EventEmitter } from '@angular/core';

@Component({
	selector: 'app-task',
	standalone: true,
	imports: [],
	templateUrl: './task.component.html',
	styleUrl: './task.component.css'
})
export class TaskComponent {
	@Input({ required: true }) task!: Task;

	@Output() completedTaskId = new EventEmitter<number>();

	completeTask(taskId: number) {
		this.completedTaskId.emit(taskId);
	}
}
