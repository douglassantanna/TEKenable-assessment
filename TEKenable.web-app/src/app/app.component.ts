import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { NewsletterFormComponent } from './newsletter-form.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule,
    RouterOutlet,
    NewsletterFormComponent],
  template: `
    <app-newsletter-form />
    <router-outlet></router-outlet>
  `,
  styles: [],
})
export class AppComponent {
  title = 'TEKenable.web-app';
}
