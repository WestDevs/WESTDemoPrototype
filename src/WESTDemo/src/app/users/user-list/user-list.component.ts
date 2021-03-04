import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/_services/users.service';
import { ToastrService } from 'ngx-toastr';
import { ConfirmationDialogService } from 'src/app/_services/confirmation-dialog.service';
import { Subject } from 'rxjs';
import { debounceTime } from 'rxjs/operators';
import { CourseService } from 'src/app/_services/course.service';
import { GroupService } from 'src/app/_services/group.service';
import { LearnerService } from 'src/app/_services/learner.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  public users: any;
  public listComplet: any;
  public searchTerm: string;
  public searchValueChanged: Subject<string> = new Subject<string>();
  public courses: any;
  public groups: any;
  public learners: any;

  constructor(private router: Router,
              private service: UserService,
              private toastr: ToastrService,
              private _courseService: CourseService,
              private _groupService: GroupService,
              private confirmationDialogService: ConfirmationDialogService,
              private _learnerService: LearnerService) { }

  ngOnInit() {
    this.getValues();
    this.getCourses();
    this.getGroups();
    this.getLearners();

    this.searchValueChanged.pipe(debounceTime(1000))
    .subscribe(() => {
      this.search();
    });
  }


  private getValues() {

    this.service.getUsers().subscribe(users => {
      this.users = users;
      this.listComplet = users;
      console.log(users);
    });
  }

  private getCourses() {
    this._courseService.getCourse().subscribe(courses => {
      this.courses = courses;
      this.listComplet = courses;
    });
  }
  
  private getGroups() {
    this._groupService.getGroup().subscribe(groups => {
      this.groups = groups;
      this.listComplet = groups;
    });
  }

  private getLearners() {
    this._learnerService.getLearner().subscribe(learners => {
      this.learners = learners;
      this.listComplet = learners;
      console.log(learners);
      
    });
  }

  public addUser() {
    this.router.navigate(['/user']);
  }

  public editUser(userId: number) {
    this.router.navigate(['/user/' + userId]);
  }

  public deleteUser(userId: number) {
    this.confirmationDialogService.confirm('Atention', 'Do you really want to delete this user?')
      .then(() =>
        this.service.deleteUser(userId).subscribe(() => {
          this.toastr.success('The user has been deleted');
          this.getValues();
        },
          err => {
            this.toastr.error('Failed to delete the user.');
          }))
      .catch(() => '');
  }

  // Use the code below if you want to filter only using the front end;
  // public search() {
  //   const value = this.searchTerm.toLowerCase();
  //   this.books = this.listComplet.filter(
  //     book => book.name.toLowerCase().startsWith(value, 0) ||
  //       book.author.toLowerCase().startsWith(value, 0) ||
  //       book.description.toString().startsWith(value, 0) ||
  //       book.value.toString().startsWith(value, 0) ||
  //       book.publishDate.toString().startsWith(value, 0));
  // }

  public searchUsers() {
    this.searchValueChanged.next();
  }

  private search() {
    if (this.searchTerm !== '') {
      this.service.searchUsers(this.searchTerm).subscribe(user => {
        this.users = user;
      }, error => {
        this.users = [];
      });
    } else {
      this.service.getUsers().subscribe(users => this.users = users);
    }
  }

  
}