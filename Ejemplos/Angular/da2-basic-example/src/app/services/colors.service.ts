import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Color } from '../models/color';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ColorsService {

  constructor(private http: HttpClient) { }

  BASE_URL = `${environment.API_URL}/v1/colors`;

  getColors(): Observable<Array<Color>> {
    const headers = new HttpHeaders()
      .set('h1', 'v1')
      .set('h2', 'v2');
    
    const params = new HttpParams()
      .set('q1', 'v1')
      .set('q2', 'v2');

    const options = {
      headers,
      params
    }

    return this.http.get<Array<Color>>(this.BASE_URL, options);
  }

  postColor(color: Color): Observable<void> {
    return this.http.post<void>(this.BASE_URL, color);
  }

  getColorById(id: number): Observable<Color> {
    return this.http.get<Color>(`${this.BASE_URL}/${id}`);
  }

  deleteColor(id: number): Observable<void> {
    return this.http.get<void>(`${this.BASE_URL}/${id}`);
  }
}
