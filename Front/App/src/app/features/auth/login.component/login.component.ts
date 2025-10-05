import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../../../core/services/auth.service';
import { AuthenticationRequest } from '../../../core/models/authentication-request.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login.component',
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginForm: FormGroup;
  errorMessage = '';
  showPassword = false;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.loginForm.invalid) return;
    
    const { username, password } = this.loginForm.value;

    let authRequest: AuthenticationRequest = {
      username: username,
      password: password
    }

    if (this.loginForm.valid) {
      this.errorMessage = '';
      this.authService.login(authRequest).subscribe({
        next: () => {
          this.router.navigate(['/shared/supplier']);
        }
      })
    } else {
      this.errorMessage = 'Usuario o contraseña incorrectos.';
    }
  }
}