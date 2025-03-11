import { Component, inject, OnInit } from "@angular/core";
import { Router, RouterModule } from "@angular/router";
import { SplitterModule } from "primeng/splitter";
import { ToolbarModule } from "primeng/toolbar";
import { PanelMenuComponent } from "./shared/ui/panel-menu/panel-menu.component";
import { AccountService } from "./account/_services/account.service";
import { User } from "./account/_models/user";
import { FormsModule } from "@angular/forms";
import { ButtonModule } from "primeng/button";
import { InputTextModule } from "primeng/inputtext";
import { BasketService } from "./basket/basket-service.service";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.scss"],
  standalone: true,
  imports: [
    InputTextModule,
    FormsModule,
    RouterModule,
    SplitterModule,
    ToolbarModule,
    PanelMenuComponent,
    ButtonModule,
  ],
})
export class AppComponent implements OnInit {
  accountService = inject(AccountService);
  basketService = inject(BasketService);
  private router = inject(Router);

  model: User | any = {};
  basketItemCount: number = 0;
  username: string = "";
  title = "ALTEN SHOP";

  ngOnInit(): void {
    this.setCurrentUser();
    this.basketService.getBasketCount().subscribe();
  }

  login() {
    this.accountService.login(this.model).subscribe({
      next: (response) => {
        console.log("Logged in successfully");
        void this.router.navigateByUrl("/home");
      },
      error: (error) => {
        console.log(error.error);
      },
      complete: () => {
        console.log("Completed");
      },
    });
  }

  logout() {
    this.accountService.logout();
    console.log("Logged out successfully");
    this.router.navigateByUrl("/");
  }

  private setCurrentUser() {
    const userString = localStorage.getItem("user");
    if (!userString) return;
    const user = JSON.parse(userString);
    this.accountService.currentUser.set(user);
  }
}
