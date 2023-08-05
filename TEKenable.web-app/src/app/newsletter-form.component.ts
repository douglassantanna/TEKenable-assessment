import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';

import { HowHeardAboutUs } from './models/how-heard-about-us';
import { Router } from '@angular/router';

@Component({
  selector: 'app-newsletter-form',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  template: `
    <div class="newsletter-form-container">
    <h2>Subscribe to our Newsletter</h2>
    <form [formGroup]="newsletterForm" (ngSubmit)="onSubmit()">
      <div class="form-group">
        <label>Email:</label>
        <input type="email" formControlName="email" class="form-control" />
        <div *ngIf="email.hasError('email') && !email.hasError('required')" class="alert alert-danger">Email is invalid</div>
        <div *ngIf="email.hasError('required')" class="alert alert-danger">Email is required</div>
      </div>
      <div class="form-group">
        <label>How did you hear about us?</label>
        <select formControlName="howHeardAboutUs" class="form-control">
          <option *ngFor="let options of howHeardAboutUsOptions" [value]="options.id">
            {{ options.value }}
          </option>
        </select>
        <div *ngIf="howHeardAboutUs.hasError('required')" class="alert alert-danger">Required field</div>
      </div>
      <div class="form-group">
        <label>Reason for Sign Up:</label>
        <textarea cols="2" rows="4" #reasonForSignUp maxlength="255" formControlName="reasonForSignUp" class="form-control"></textarea>
        <span>{{reasonForSignUp.value.length}} / 255</span>
      </div>
      <button type="submit" [disabled]="!newsletterForm.valid">Subscribe</button>
    </form>
  </div>
  `,
  styles: [`
  textarea{
    max-width: 400px;
    max-height: 100px;
  }
  .newsletter-form-container {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    height: 100vh;
    background-color: #f9f9f9;
  }

  form {
    width: 400px;
    padding: 20px;
    border: 1px solid #ccc;
    border-radius: 5px;
    background-color: #fff;
  }

  h2 {
    margin-bottom: 20px;
    font-weight: lighter;
  }

  .form-group {
    display: flex;
    flex-direction: column;
    margin-bottom: 15px;
  }

  label {
    font-weight: bold;
  }

  input,
  select {
    padding: 10px;
    border: 1px solid #ccc;
    border-radius: 5px;
  }

  .alert {
    color: #721c24;
    background-color: #f8d7da;
    border-color: #f5c6cb;
    padding: 8px;
    margin: 2px 0px 10px 0px;
    border: 1px solid transparent;
    border-radius: 5px;
  }

  .alert-danger {
    color: #721c24;
    background-color: #f8d7da;
    border-color: #f5c6cb;
  }
  button {
    background-color: rgb(12, 89, 166);
    border: none;
    border-radius: 4px;
    cursor: pointer;
    color: white;
    font-size: 1.2rem;
    padding: 1rem;
    margin-right: 1rem;
    margin-bottom: 1rem;
    margin-top: 1rem;
  }
  button:hover {
    background-color: rgb(23, 108, 193);
  }
  button:disabled {
    background-color: #eee;
    color: #aaa;
    cursor: auto;
  }
  `]
})
export class NewsletterFormComponent implements OnInit {
  newsletterForm: FormGroup = {} as FormGroup;
  howHeardAboutUsOptions: any[] = [
    { id: HowHeardAboutUs.Advert, value: 'Advert' },
    { id: HowHeardAboutUs.WordOfMouth, value: 'Word of mouth' },
    { id: HowHeardAboutUs.Other, value: 'Other' }
  ];
  constructor(
    private formBuilder: FormBuilder,
    private router: Router) { }

  ngOnInit() {
    this.newsletterForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      reasonForSignUp: ['', Validators.maxLength(255)],
      howHeardAboutUs: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.newsletterForm.valid) {
      console.log(this.newsletterForm.value);
      this.router.navigate(['/signupconfirmation']);
    }
  }
  get email() { return this.newsletterForm.get('email') as FormControl }
  get reasonForSignUp() { return this.newsletterForm.get('reasonForSignUp') as FormControl }
  get howHeardAboutUs() { return this.newsletterForm.get('howHeardAboutUs') as FormControl }
}
