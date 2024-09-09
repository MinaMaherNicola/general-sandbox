import { faker } from '@faker-js/faker';
import { Task } from '../../Shared/Task';
import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class TasksService {
	private tasks: Task[] = this.generateFakeTask();

	getUserTasks(userId: number): Task[] {
		return this.tasks.filter(t => t.userId === userId);
	}

	addTask(newTask: Task) {
		this.tasks.unshift(newTask);
	}

	removeTask(taskId: number) {
		this.tasks.splice(
			this.tasks.findIndex(t => t.id == taskId),
			1
		);
	}

	private generateFakeTask(): Task[] {
		const tasks: Task[] = [];
		for (let i = 0; i < 10; i++) {
			tasks.push({
				id: Math.floor(Math.random() * 99999999) + 100,
				userId: Math.floor(Math.random() * 6),
				title: faker.lorem.words(3),
				summary: faker.lorem.sentences(2),
				dueDate: faker.date.future().toDateString()
			});
		}
		return tasks;
	}
}
