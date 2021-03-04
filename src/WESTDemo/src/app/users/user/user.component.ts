import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Users } from 'src/app/_models/Users';
import { UserService } from 'src/app/_services/users.service';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-users',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css'],
})
export class UserComponent implements OnInit {
  public formData: Users;
  public categories: any;

  constructor(
    public service: UserService,
    private router: Router,
    private route: ActivatedRoute,
    private toastr: ToastrService
  ) {}

  ngOnInit() {
    this.resetForm();
    let id;
    this.route.params.subscribe((params) => {
      id = params['id'];
    });

    if (id != null) {
      this.service.getUserById(id).subscribe(
        (user) => {
          this.formData = user;
          const birthdate = new Date(user.birthdate);
          this.formData.birthdate = {
            year: birthdate.getFullYear(),
            month: birthdate.getMonth(),
            day: birthdate.getDay(),
          };
        },
        (err) => {
          this.toastr.error('An error occurred on get the record.');
        }
      );
    } else {
      this.resetForm();
    }
  }

  public onSubmit(form: NgForm) {
    // form.value.id = Number(4);
    form.value.birthdate = this.convertStringToDate(form.value.birthdate);
    if (form.value.id === 0) {
      console.log(form)
      this.insertRecord(form);
    } else {
      this.updateRecord(form);
    }
  }

  public insertRecord(form: NgForm) {
    this.service.addUser(form.form.value).subscribe(
      () => {
        this.toastr.success('Registration successful');
        this.resetForm(form);
        this.router.navigate(['/users']);
      },
      () => {
        this.toastr.error('An error occurred on insert the record.');
      }
    );
  }

  public updateRecord(form: NgForm) {
    this.service.updateUser(form.form.value.id, form.form.value).subscribe(
      () => {
        this.toastr.success('Updated successful');
        this.resetForm(form);
        this.router.navigate(['/users']);
      },
      () => {
        this.toastr.error('An error occurred on update the record.');
      }
    );
  }

  public cancel() {
    this.router.navigate(['/users']);
  }

  private resetForm(form?: NgForm) {
    if (form != null) {
      form.form.reset();
    }

    this.formData = {
      id: 0,
      username: '',
      firstName: '',
      lastName: '',
      typeId: null,
      organisationId: null,
      birthdate: null,
    };
  }

  private convertStringToDate(date) {
    return new Date(`${date.year}-${date.month}-${date.day}`);
  }
}
