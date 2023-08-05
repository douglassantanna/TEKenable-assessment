import { Component } from '@angular/core';

@Component({
  template: `
    <div class="signup-success-container">
    <h2>Thank You for Signing Up!</h2>
    <p>You have successfully subscribed to our newsletter.</p>
    <p>Stay tuned for the latest updates and news!</p>
    </div>
  `,
  styles: [`
  .signup-success-container {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    height: 100vh;
    background-color: #f9f9f9;
  }

  h2 {
    font-size: 24px;
    font-weight: bold;
    margin-bottom: 10px;
  }

  p {
    font-size: 18px;
    margin-bottom: 8px;
  }
  `  ]
})
export class SignupconfirmationComponent {

}
