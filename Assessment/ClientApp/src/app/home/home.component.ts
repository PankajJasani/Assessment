
import { Component, Inject, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  public people: Person[];

  //constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  //  http.get<Person[]>(baseUrl + 'api/Person').subscribe(result => {
  //    this.people = result;
  //  }, error => console.error(error));
  //}

  constructor(private apiService: ApiService) { }


    ngOnInit(): void {
    this.refreshPeople()
  }

  refreshPeople() {
    this.apiService.getPeople()
      .subscribe(data => {
        console.log(data)
        this.people = data;
      })

  }

  addPerson() {
    //this.apiService.addPerson(this.person)
    //  .subscribe(data => {
    //    console.log(data)
    //    this.refreshPeople();
    //  })
  }
}

export class Person {
  constructor(
    public firstName: string,
    public lastName: string,
    public cityName: string,
    public phoneNumber: string
  ) { }

}

