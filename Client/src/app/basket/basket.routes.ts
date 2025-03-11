import { Routes } from "@angular/router";
import { BasketListComponent } from "./basket-list/basket-list.component";

export const BASKET_ROUTES: Routes = [
	{
		path: "list",
		component: BasketListComponent,
	},
	{ path: "**", redirectTo: "list" },
];
