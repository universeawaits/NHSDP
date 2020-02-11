import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContactListProfileBindingService {
  private contact = new Subject<any>();

  constructor() { }

  getContact(): Observable<any> {
    return this.contact.asObservable();
  }

  updateContact(contact: any) {
    this.contact.next(contact);
  }
}
