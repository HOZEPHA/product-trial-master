import { Component, inject } from "@angular/core";
import { Router, RouterModule } from "@angular/router";
import { SplitterModule } from "primeng/splitter";
import { ToolbarModule } from "primeng/toolbar";
import { PanelMenuComponent } from "./shared/ui/panel-menu/panel-menu.component";
import { AccountService } from "./account/_services/account.service";
import { User } from "./account/_models/user";
import { FormsModule } from "@angular/forms";
import { ButtonModule } from "primeng/button";
import { InputTextModule } from "primeng/inputtext";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.scss"],
  standalone: true,
  imports: [InputTextModule, FormsModule,RouterModule, SplitterModule, ToolbarModule, PanelMenuComponent, ButtonModule]
})
export class AppComponent {
  accountService = inject(AccountService);
  private router = inject(Router)
  
  model: User | any = {};
  username: string = "";
  title = "ALTEN SHOP";

  login() {
    this.accountService.login(this.model).subscribe({
      next: (response) => {
      console.log('Logged in successfully');
       void this.router.navigateByUrl('/home');  
      },
      error: (error) => {
        console.log(error.error);
      },
      complete: () => {
        console.log('Completed');
      }
    });
  }

  logout() {
    this.accountService.logout();
    console.log('Logged out successfully');
    this.router.navigateByUrl('/');
  }
}
