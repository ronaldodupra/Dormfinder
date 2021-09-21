import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RegistrationClaims } from '../components/signup/shared/registration-claims';
import * as jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})
export class RegistrationService {
  apiUrl = 'api/account';

  constructor(private httpClient: HttpClient) {}

  mapTokenToClaims(token: string): RegistrationClaims {
    try {
      const payload = jwt_decode(token);

      const claims: RegistrationClaims = {
        userId: payload['sub'],
        email: payload['email'],
        name: payload['given_name'],
        lastName: payload['family_name'],
        city: payload['city'],
        expiration: payload['exp'],
      };

      return claims;
    } catch (error) {
      throw new Error('Invalid token');
    }
  }

  isExpired(claims: RegistrationClaims): boolean {
    const expirationTime = claims.expiration;
    const currentTime = Number(Math.floor(Date.now() / 1000));

    return expirationTime < currentTime;
  }

  verify(token: string) {
    return this.httpClient.get(`${this.apiUrl}/tokens?token=${token}`);
  }

  getUser(userName: string) {
    return this.httpClient.get(`${this.apiUrl}/availability/${userName}`);
  }

  create(account: Account) {
    console.log(account);
    return this.httpClient.post(`${this.apiUrl}/register`, account);
  }
}
