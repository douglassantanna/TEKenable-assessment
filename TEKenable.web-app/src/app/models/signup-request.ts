import { HowHeardAboutUs } from "./how-heard-about-us";

export interface SignUpRequest {
  email: string;
  reasonForSignUp: string;
  howHeardAboutUs: HowHeardAboutUs;
}
