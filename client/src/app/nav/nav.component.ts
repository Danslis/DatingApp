import { Component, OnInit } from '@angular/core';
import { AccountService } from '../services/account.service';
import { Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';


@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
  model: any = {}

  constructor(public accountService: AccountService, private router: Router,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  login() {
    this.accountService.login(this.model) .subscribe({
      next: _ => {
        this.router.navigateByUrl('/members');
      }
  })
}



  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/')
  }
}
