import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { environment } from 'environments/environment';
import { BasketItem } from './models/basketItem';
import { catchError, Observable, of, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BasketService {

  private readonly http = inject(HttpClient);
      private readonly path = environment.Apiurl;
      
      private readonly _basket = signal<BasketItem[]>([]);
      public basket = this._basket;

      
      
      private readonly _basketCount = signal<number>(0);

  
      public getBasketItems(): Observable<BasketItem[]> {
        return this.http.get<BasketItem[]>(this.path + '/basket/items').pipe(
            catchError((error) => {
                return of([]);
            }),
            tap((basket) => this._basket.set(basket)),

        );
    }

      public getBasketCount(): Observable<number> {
          return this.http.get<number>(this.path + '/basket/itemCount').pipe(
              catchError((error) => {
                  return of(0);
              }),
              tap((basketCount) => this._basketCount.set(basketCount)),
          );
      }
  
      // public create(product: Product): Observable<boolean> {
      //     return this.http.post<boolean>(this.path + '/products', product).pipe(
      //         catchError(() => {
      //             return of(true);
      //         }),
      //         tap(() => this._products.update(products => [product, ...products])),
      //     );
      // }
  
      // public update(product: Product): Observable<boolean> {
      //     return this.http.put<boolean>(`${this.path + '/products'}/${product.id}`, product).pipe(
      //         catchError(() => {
      //             return of(true);
      //         }),
      //         tap(() => this._products.update(products => {
      //             return products.map(p => p.id === product.id ? product : p)
      //         })),
      //     );
      // }
  
      // public delete(productId: number): Observable<boolean> {
      //     return this.http.delete<boolean>(`${this.path + '/products'}/${productId}`).pipe(
      //         catchError(() => {
      //             return of(true);
      //         }),
      //         tap(() => this._products.update(products => products.filter(product => product.id !== productId))),
      //     );
      // }
}
