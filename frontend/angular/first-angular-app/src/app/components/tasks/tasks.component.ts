import { Component, Input } from '@angular/core';
import { TaskComponent } from './task/task.component';
import { Task } from '../../Shared/Task';
import { AddTaskComponent } from './add-task/add-task.component';
import { WrapperComponent } from '../../Shared/wrapper/wrapper.component';
import { TasksService } from './tasks.service';

@Component({
	selector: 'app-tasks',
	standalone: true,
	imports: [TaskComponent, AddTaskComponent, WrapperComponent],
	templateUrl: './tasks.component.html',
	styleUrl: './tasks.component.css'
})
export class TasksComponent {
	@Input({ required: true }) name!: string;
	@Input({ required: true }) id!: number;
	completedTaskId?: number;
	showAddTask: boolean = false;

	constructor(private tasksService: TasksService) {}

	get selectedUserTasks() {
		return this.tasksService.getUserTasks(this.id);
	}

	addNewTask(newTask: Task) {
		this.tasksService.addTask(newTask);
	}

	markTaskAsCompleted(id: number) {
		this.tasksService.removeTask(id);
	}

	toggleAddTask() {
		this.showAddTask = !this.showAddTask;
	}
}
