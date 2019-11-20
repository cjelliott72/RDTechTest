import { Component, OnInit } from '@angular/core';
import { User } from '../../models/user';
import { UserService } from '../../services/user.service';
@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
})
export class UserListComponent {
    public userList: User[];

    constructor(private userService: UserService) { }

    ngOnInit() {
        this.getUsers();
    }

    getUsers(): void {
        this.userService.getUsers().subscribe(people => this.userList = people);
    }

    delete(user: User): void {
        if (confirm(`Are you sure you want to delete ${user.firstName} ${user.lastName}?`)) {
            this.userList = this.userList.filter(h => h !== user);
            this.userService.deleteUser(user).subscribe();
        }
    }
}
