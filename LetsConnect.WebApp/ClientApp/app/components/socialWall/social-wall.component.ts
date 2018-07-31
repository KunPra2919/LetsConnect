import { Global } from '../../Shared/global';
import { Component, OnInit } from '@angular/core';
import { Angular2SocialLoginModule, AuthService } from "angular2-social-login";


@Component({
    templateUrl: './social-wall.component.html'
})

export class SocialWallComponent implements OnInit {
    //public user;
    //sub: any;
    //constructor(public _auth: AuthService) { }

    //signIn(provider) {
    //    this.sub = this._auth.login(provider).subscribe(
    //        (data) => {
    //            console.log(data); this.user = data;
    //        }
    //    )
    //}

    //logout() {
    //    this._auth.logout().subscribe(
    //        (data) => { console.log(data); this.user = null; }
    //    )
    //}

    ngOnInit() {
        
    }
}
