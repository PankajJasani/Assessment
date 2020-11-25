
import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiService } from '../../services/api.service';
import { Person, HomeComponent } from '../home/home.component'

@Component({
  selector: 'app-person-component',
  templateUrl: './person.component.html'
})
export class PersonComponent {

  constructor(private apiService: ApiService, private homeComponent: HomeComponent) { }

  public currentCount = 0;

  cities = ['Bangalore', 'Mysore', 'Hyderabad', 'Vijayawada'];

  model = new Person('', '', this.cities[0], '');

  submitted = false;

   newPerson() {
     this.model = new Person('', '', 'Bangalore', '');
}

  addPerson() {
    this.apiService.addPerson(this.model)
      .subscribe(data => {
        console.log(data)
       // this.refreshPeople();
      })
  }


  onSubmit() {
    this.addPerson();
    this.homeComponent.refreshPeople();
    this.newPerson();   
  }

 

}
