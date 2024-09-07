import { Directive, inject, Input, OnInit, TemplateRef, ViewContainerRef } from '@angular/core';
import { AccountService } from '../account/shared/account.service';

@Directive({
  selector: '[appIsLoggedIn]',
  standalone: true
})
export class IsLoggedInDirective implements OnInit {
  @Input() appIsLoggedIn = false;

  private accountService = inject(AccountService);
  private viewContainerRef = inject(ViewContainerRef);
  private templateRef = inject(TemplateRef);

  ngOnInit(): void {
    if (this.appIsLoggedIn) {
      if (this.accountService.currentUser()) {
        this.viewContainerRef.createEmbeddedView(this.templateRef);
      } else {
        this.viewContainerRef.clear();
      }
    } else {
      if (this.accountService.currentUser()) {
        this.viewContainerRef.clear();
      } else {
        this.viewContainerRef.createEmbeddedView(this.templateRef);
      }
    }
  }
}