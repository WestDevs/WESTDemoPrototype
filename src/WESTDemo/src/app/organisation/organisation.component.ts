import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { OrganisationService } from 'src/app/_services/organisation.service';
import { Organisation } from 'src/app/_models/Organisation';

@Component({
  selector: 'app-organisation',
  templateUrl: './organisation.component.html',
  styleUrls: ['./organisation.component.css'],
})
export class OrganisationComponent implements OnInit {
  public formData: Organisation;

  constructor(
    public service: OrganisationService,
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
      this.service.getOrganisationById(id).subscribe(
        (organisation) => {
          this.formData = organisation;
        },
        (error) => {
          this.toastr.error('An error occurred on get the record.');
        }
      );
    } else {
      this.resetForm();
    }
  }

  private resetForm(form?: NgForm) {
    if (form != null) {
      form.form.reset();
    }

    this.formData = {
      id: 0,
      name: '',
    };
  }

  public onSubmit(form: NgForm) {
    if (form.value.id === 0) {
      this.insertRecord(form);
    } else {
      this.updateRecord(form);
    }
  }

  public insertRecord(form: NgForm) {
    this.service.addOrganisation(form.form.value).subscribe(
      () => {
        this.toastr.success('Registration successful');
        this.resetForm(form);
        this.router.navigate(['/categories']);
      },
      () => {
        this.toastr.error('An error occurred on insert the record.');
      }
    );
  }

  public updateRecord(form: NgForm) {
    this.service
      .updateOrganisation(form.form.value.id, form.form.value)
      .subscribe(
        () => {
          this.toastr.success('Updated successful');
          this.resetForm(form);
          this.router.navigate(['/categories']);
        },
        () => {
          this.toastr.error('An error occurred on update the record.');
        }
      );
  }

  public cancel() {
    this.router.navigate(['/categories']);
  }
}
