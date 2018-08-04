import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';
import { UserApi } from '../user-api';
import { Http } from '@angular/http';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent {

  formError: string;
  submitting = false;
  returnUrl: string;

  constructor(private userApi: UserApi,
              private router: Router,
              private route: ActivatedRoute, private http: Http) { }

  onSubmit(signInForm: NgForm) {

    if (signInForm.valid) {
      this.submitting = true;
      this.formError = null;

      this.http.delete(environment.api_url + '/reset').subscribe(result => {
      }, error => console.error(error));

      this.userApi.signIn(signInForm.value.username, signInForm.value.password)
        .subscribe((data) => {
             this.router.navigate([this.route.snapshot.queryParams['returnUrl']]);
          },
          (err) => {
            this.submitting = false;
            this.formError = err;
          }
        );
    }
  }
}
