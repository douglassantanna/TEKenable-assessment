import { Routes } from '@angular/router';
import { NewsletterFormComponent } from './newsletter-form.component';
import { SignupconfirmationComponent } from './signupconfirmation.component';

export const routes: Routes = [
  {
    path: "",
    pathMatch: "full",
    redirectTo: "newsletter-form",
  },
  {
    path: "newsletter-form",
    component: NewsletterFormComponent,
  },
  {
    path: "signupconfirmation",
    component: SignupconfirmationComponent,
  }
];
