import { Component, OnInit } from '@angular/core';
import { User } from './shared/user.model';
import { UserService } from './shared/user.service';
import { ToastrService } from 'ngx-toastr';
import { LocalDataSource } from 'ng2-smart-table';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  source: LocalDataSource; // add a property to the component

  settings = {
    columns: {
      id: {
        title: 'ID',
        editable: false,
        filter: false
      },
      name: {
        title: 'Name'
      },
      age: {
        title: 'Age',
        filter: false
      },
      address: {
        title: 'Address',
        filter: false
      }
    },
    actions:
    {
      delete: false
    },
    add: {
      confirmCreate: true,
    },
    edit: {
      confirmSave: true,
    },
  }; 

  private userList: User[];

  constructor(private userService: UserService,
    private toastr: ToastrService) { 
     
    }

  async ngOnInit() {
   await this.refreshList();
  }

  async refreshList() {
    this.userList = await this.userService.getUsers() as User[];
    this.source = new LocalDataSource(this.userList); // create the source
  }

  onSaveConfirm(event) {
    if (window.confirm('Are you sure you want to save?')) {
      this.userService.putUser(event.newData).subscribe(res => {
        this.toastr.info('Updated successfully', 'User');
        event.confirm.resolve(event.newData);
        this.refreshList();
      },
      error => {
        this.toastr.error(error, 'User');
      });      
    } else {
      event.confirm.reject();
    }
  }

  onCreateConfirm(event) {
    if (window.confirm('Are you sure you want to create?')) {
      this.userService.postUser(event.newData).subscribe(res => {
        this.toastr.info('Created successfully', 'User');
        event.confirm.resolve(event.newData);
        this.refreshList();
      }, 
      error => {
        this.toastr.error(error, 'User');
      });     
    } else {
      event.confirm.reject();
    }
  }
}
