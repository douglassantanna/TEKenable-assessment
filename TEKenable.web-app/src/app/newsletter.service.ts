import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';

import { SignUpRequest } from './models/signup-request';
import { Observable } from 'rxjs';

const API_URL = environment.apiUrl;
@Injectable({
  providedIn: 'root'
})
export class NewsletterService {

  constructor(private http: HttpClient) { }
  signUp(request: SignUpRequest): Observable<any> {
    return this.http.post(`${API_URL}/newsletter/sign-up`, request);
  }
}
