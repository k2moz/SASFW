import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Page } from './page';
 
@Injectable()
export class DataService {
 
    private url = "/api/products";
 
    constructor(private http: HttpClient) {
    }
 
    getProducts() {
        return this.http.get(this.url);
    }
 
    createProduct(page: Page) {
        return this.http.post(this.url, page);
    }
    updateProduct(page: Page) {
  
        return this.http.put(this.url + '/' + page.id, page);
    }
    deleteProduct(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}