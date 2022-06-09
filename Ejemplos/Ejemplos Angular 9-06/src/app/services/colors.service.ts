import { Injectable } from '@angular/core';
import { Color } from '../models/Color';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ColorsService {

  constructor(private http: HttpClient) { }

  API_URL = `${environment.API_URL}/v1/colors`;

  getColors(): Observable<Array<Color>> {
    return this.http.get<Array<Color>>(this.API_URL);
  }

  postColor(color: Color): Observable<void> {

    const headers = new HttpHeaders()
      .set('header1', 'value1')
      .set('header2', 'value2')
      .set('header3', 'value3')
      .set('header4', 'value4');

    const params = new HttpParams()
      .set('query1', 'value1')
      .set('query2', 'value2')
      .set('query3', 'value3');

    const options = {
      headers,
      params
    }

    return this.http.post<void>(this.API_URL, color, options);
  }

  getColor(id: number): Observable<Color> {
    return this.http.get<Color>(`${this.API_URL}/${id}`);
  }

  deleteColor(id: number): Observable<void> {
    return this.http.delete<void>(`${this.API_URL}/${id}`)
  }
}
