import { Injectable } from '@angular/core';
 
@Injectable({
    providedIn: 'root'
})
export class ConfigService {    
    constructor() {}

    get authApiURI() {
        return 'https://localhost:44328/api';
    }    
     
    get resourceApiURI() {
        return 'http://localhost:44366';
    }  
}