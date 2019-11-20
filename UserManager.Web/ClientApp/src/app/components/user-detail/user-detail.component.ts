import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { NgForm } from '@angular/forms';

import { User } from '../../models/user';
import { UserService } from '../../services/user.service';

@Component({
    selector: 'app-user-detail',
    templateUrl: './user-detail.component.html',
})
export class UserDetailComponent implements OnInit {
    private user: User;
    @ViewChild('detailForm', null) detailForm: NgForm;

    constructor(
        private route: ActivatedRoute,
        private userService: UserService,
        private location: Location,
    ) { }

    ngOnInit() {
        this.getUser();
    }

    getUser(): void {
        const id = +this.route.snapshot.paramMap.get('id');
        if (id == 0) {
            this.user = new User();
            this.user.id = 0;

        } else {
            this.userService.getUser(id).subscribe(user => this.user = user);
        }
    }

    goBack(): void {
        this.detailForm.reset();
        this.location.back();
    }

    save(): void {
        if (this.user.id == 0) {
            this.userService.addUser(this.user)
                .subscribe(() => this.goBack());
        } else {
            this.userService.updateUser(this.user)
                .subscribe(() => this.goBack());
        }
    }

    delete(user: User): void {
        if (confirm(`Are you sure you want to delete ${user.firstName} ${user.lastName}?`)) {
            this.userService.deleteUser(this.user).subscribe();
        }
    }
}
