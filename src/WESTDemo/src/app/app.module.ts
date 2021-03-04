import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { NgbModule, NgbNav } from '@ng-bootstrap/ng-bootstrap';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { UserService } from './_services/users.service';
import { ConfirmationDialogService } from './_services/confirmation-dialog.service';
import { UserComponent } from './users/user/user.component';
import { UserListComponent } from './users/user-list/user-list.component';
import { HomeComponent } from './home/home.component';
import { NavComponent } from './nav/nav.component';
import { ConfirmationDialogComponent } from './confirmation-dialog/confirmation-dialog.component';
import { NgbdDatepickerPopup } from './datepicker/datepicker-popup';
import { LoginComponent } from './login/login.component';
import { NavTabComponent } from './nav-tab/nav-tab.component';
import { FooterComponent } from './footer/footer.component';
import { GroupService } from './_services/group.service';
import { CentreService } from './_services/centre.service';
import { CourseService } from './_services/course.service';
import { ContainerComponent } from './container/container.component';
import { LearnerResourceComponent } from './learner-resource/learner-resource.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavComponent,
    UserComponent,
    UserListComponent,
    ConfirmationDialogComponent,
    NgbdDatepickerPopup,
    LoginComponent,
    NavTabComponent,
    FooterComponent,
    ContainerComponent,
    LearnerResourceComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    NgbModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    // NgbNav
  ],
  providers: [
    UserService,
    ConfirmationDialogService,
    GroupService,
    CentreService,
    CourseService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
