import { HttpClient } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { User } from './user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  userList: User[];
  selectedUser: User;

  readonly baseURL = "http://localhost:32773/api";

  constructor(private http: HttpClient) { }

  postUser(user: User) {
    debugger
    return this.http.post(this.baseURL + '/Users', user);
  }

  refreshList() {
    this.http.get(this.baseURL + '/Users')
      .toPromise().then(res => this.userList = res as User[]);
  }

  async getUsers() {
    return await this.http.get(this.baseURL + '/Users').toPromise();
  }

  putUser(user: User) {
    return this.http.put(this.baseURL + '/Users/', user);
  }
}
