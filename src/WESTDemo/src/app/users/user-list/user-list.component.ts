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
import { Learner } from 'src/app/_models/Learner';
import { textChangeRangeIsUnchanged } from 'typescript';
import { Group } from 'src/app/_models/Group';
import { Course } from 'src/app/_models/Course';
// import { runInThisContext } from 'vm';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  public users: any;
  public listComplete: Learner[];
  public _searchTerm = "";
  // public searchValueChanged: Subject<string> = new Subject<string>();
  public courses: Course[];
  public groups: Group[];
  public learners: Learner[];
  private _courseFilter: number = 0;
  private _groupFilter: number = 0;
  get searchTerm(): string {
    return this._searchTerm;
  }
  set searchTerm(value: string) {
    this._searchTerm=value;
  }
  get courseFilter(): number {
    return this._courseFilter;
  }
  set courseFilter(value: number) {
    this._courseFilter = value;
    this.search();
  }
  get groupFilter(): number {
    return this._groupFilter;
  }
  set groupFilter(value: number) {
    this._groupFilter = value;
    this.search();
  }

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

    // this.searchValueChanged.pipe(debounceTime(1000))
    // .subscribe(() => {
    //   this.search();
    // });
  }


  private getValues() {

    this.service.getUsers().subscribe(users => {
      this.users = users;
    });
  }

  private getCourses() {
    this._courseService.getCourse().subscribe(courses => {
      this.courses = courses;
    });
  }
  
  private getGroups() {
    this._groupService.getGroup().subscribe(groups => {
      this.groups = groups;
    });
  }

  private getLearners() {
    this._learnerService.getLearner().subscribe(learners => {
      this.learners = learners;
      this.listComplete = learners;
      
    });
  }
  // private searchLearner(searchValue: string) {
  //   this._learnerService.searchLearner(searchValue).subscribe(learners => {
  //     this.learners = learners;
  //   }, error => {
  //     console.log(error.error);
  //     this.searchResult = error.error;
  //     this.learners = [];
  //   });
  // }

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

  // public searchUsers() {
  //   this.searchValueChanged.next();
  // }

  public search() {
      // this.searchLearner(this.searchTerm); commented out API search
      this.learners = this.listComplete;
      console.log("before " + this.learners);
      this.searchByNames();
      console.log("1" + this.learners);
      this.searchByCourse();
      console.log("2" + this.learners);
      this.searchByGroup();
      console.log("3" + this.learners);
  }

  public searchByCourse() {
    const value = this.courseFilter;
    if (value != 0)   
    {
      this.learners = this.learners?.filter(
        l => l.learnerStatus?.find(
          c => c.id === value));
          console.log(this.learners);
        }
  }

  public searchByNames() {
    const value = this.searchTerm;
    if (value !== "")   
    {
      this.learners = this.learners?.filter(
        l => l.username.toLocaleLowerCase().indexOf(value) !== -1 || 
            l.firstname.toLocaleLowerCase().indexOf(value) !== -1 || 
            l.lastname.toLocaleLowerCase().indexOf(value) !== -1 ); 
        }
  }

  public searchByGroup() {
    const value = this.groupFilter;
    if (value != 0)   
    {
      this.learners = this.learners?.filter(
        l => l.group?.id === value);
        }
  }

  
}