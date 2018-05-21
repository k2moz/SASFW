//import { Component } from '@angular/core';

//@Component({
//    selector: 'app',
//    template: `<label>Введите имя:</label>
//                 <input [(ngModel)]="name" placeholder="name">
//                 <h2>Добро пожаловать {{name}}!</h2>`
//})
//export class AppComponent {
//    name = '';
//}

import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Page } from './page';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [DataService]
})
export class AppComponent implements OnInit {

    page: Page = new Page();   // изменяемый товар
    pages: Page[];                // массив товаров
    tableMode: boolean = true;          // табличный режим

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.loadProducts();    // загрузка данных при старте компонента  
    }
    // получаем данные через сервис
    loadProducts() {
        this.dataService.getProducts()
            .subscribe((data: Page[]) => this.pages = data);
    }
    // сохранение данных
    save() {
        if (this.page.id == null) {
            this.dataService.createProduct(this.page)
                .subscribe((data: Page) => this.pages.push(data));
        } else {
            this.dataService.updateProduct(this.page)
                .subscribe(data => this.loadProducts());
        }
        this.cancel();
    }
    editProduct(p: Page) {
        this.page = p;
    }
    cancel() {
        this.page = new Page();
        this.tableMode = true;
    }
    delete(p: Page) {
        this.dataService.deleteProduct(p.id)
            .subscribe(data => this.loadProducts());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
}