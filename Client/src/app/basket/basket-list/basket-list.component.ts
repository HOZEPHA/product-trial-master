import { Component, inject, OnInit } from "@angular/core";
import { BasketService } from "../basket.service";
import { AccountService } from "app/account/_services/account.service";

@Component({
  selector: "app-basket-list",
  standalone: true,
  imports: [],
  templateUrl: "./basket-list.component.html",
  styleUrl: "./basket-list.component.css",
})
export class BasketListComponent implements OnInit {
  basketItems: any[] = [];
  

  basketService = inject(BasketService);
  accountService = inject(AccountService);
  ngOnInit() {
    this.loadBasket();
  }

  loadBasket() {
    this.basketService.getBasketItems().subscribe((next: any) => {
      if(this.accountService.currentUser() != null){
        this.basketItems = next;
      }
      else{
        this.basketItems = [];  
      }
    });
  }
}
