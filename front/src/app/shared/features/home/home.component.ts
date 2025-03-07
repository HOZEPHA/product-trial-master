import { Component } from "@angular/core";
import { RouterLink } from "@angular/router";
import { RegisterComponent } from "app/account/register/register.component";
import { ButtonModule } from "primeng/button";
import { CardModule } from "primeng/card";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.scss"],
  standalone: true,
  imports: [CardModule, ButtonModule, RegisterComponent],
})
export class HomeComponent {
  public readonly appTitle = "ALTEN SHOP";

  registerMode = false;

  registerToggle() {
    this.registerMode = !this.registerMode;
  }

  cancelRegisterMode(event: boolean) {
    this.registerMode = event;
  }


}
