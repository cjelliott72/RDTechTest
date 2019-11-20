import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

import { MessageService } from './message.service';
import { User } from '../models/user';


@Injectable({
  providedIn: 'root'
})
export class UserService {
    private httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json'})
    };

    constructor(
        private http: HttpClient,
        private messageService: MessageService,
        @Inject('BASE_URL') private baseUrl: string) { }

    /** GET list of users from the server */
    getUsers(): Observable<User[]> {
        return this.http.get<User[]>(this.baseUrl + 'api/users')
            .pipe(
                tap(_ => this.log('fetched users')),
                catchError(this.handleError<User[]>('getUsers', []))
            );
    }

    /** GET user by id. Will 404 if id not found */
    getUser(id: number): Observable<User> {
        return this.http.get<User>(this.baseUrl + 'api/users/' + id)
            .pipe(
                tap(_ => this.log(`fetched user id=${id}`)),
                catchError(this.handleError<User>(`getUser id=${id}`))
            );
    }

    /** PUT: update the user on the server */
    updateUser(user: User): Observable<any> {
        return this.http.put(this.baseUrl + 'api/users/' + user.id, user, this.httpOptions)
            .pipe(
                tap(_ => this.log(`updated user id=${user.id}`)),
                catchError(this.handleError<any>('updateUser'))
            );
    }

    /** POST: add a new user on the server */
    addUser(user: User): Observable<User> {
        return this.http.post<User>(this.baseUrl + 'api/users', user, this.httpOptions)
            .pipe(
                tap((newUser: User) => this.log(`added new user id=${newUser.id}`)),
                catchError(this.handleError<User>('addUser'))
            );
    }

    /** DELETE: delete the user from the server */
    deleteUser(user: User | number): Observable<User> {
        const id = typeof user === 'number' ? user : user.id;
        return this.http.delete<User>(this.baseUrl + 'api/users/' + id, this.httpOptions)
            .pipe(
                tap(_ => this.log(`deleted user id=${id}`)),
                catchError(this.handleError<User>(`deleteUser id=${id}`))
            );
    }

    private log(message: string) {
        this.messageService.add(`UserService: ${message}`);
    }

    /*
  * Handle Http operation that failed.
  * Let the app continue.
  * @param operation - name of the operation that failed
  * @param result - optional value to return as the observable result
  */
    private handleError<T>(operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {

            // TODO: send the error to remote logging infrastructure
            console.error(error); // log to console instead

            // TODO: better job of transforming error for user consumption
            this.log(`${operation} failed: ${error.message}`);

            // Let the app keep running by returning an empty result.
            return of(result as T);
        };
    }
}
