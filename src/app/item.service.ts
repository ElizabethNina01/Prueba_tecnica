import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import { Item } from './item.model';

@Injectable({
  providedIn: 'root'
})
export class ItemService {
  private basePath = 'https://localhost:5001/api/v1/';
  apiEndPoint = 'item';
  constructor(private http: HttpClient) { }
  // tslint:disable-next-line:typedef
  postItem(data: any): Observable<Item> {
    return this.http.post<Item>(this.basePath + this.apiEndPoint, data);
  }
  // tslint:disable-next-line:typedef
  getItemById(Id: number): Observable<Item> {
    return this.http.get<Item>(this.basePath + this.apiEndPoint+ '?id='+ Id.toString());
  }

  getItems(): Observable<Item[]>{
    return this.http.get<Item[]>(this.basePath + this.apiEndPoint);
  }

  deleteItem(id: number): Observable<Item> {
    return this.http.delete<Item>(this.basePath + this.apiEndPoint +  '/'+ id.toString());
  }
 
  updateItembyId(id: number, data: Item): Observable<Item>{
    return this.http.put<Item>(this.basePath + this.apiEndPoint+ '/'+id.toString(),data);
  }
}
